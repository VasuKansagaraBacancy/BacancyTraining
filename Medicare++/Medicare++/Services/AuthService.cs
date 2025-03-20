using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Medicare__.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly JwtService _jwtService;

        public AuthService(IUserRepository userRepo, IUserRefreshTokenRepository refreshRepo, JwtService jwtService)
        {
            _userRepository = userRepo;
            _refreshTokenRepository = refreshRepo;
            _jwtService = jwtService;
        }

        public async Task<(string accessToken, string refreshToken)> LoginAsync(LoginRequestDTO request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid credentials");

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            var refreshTokenEntity = new UserRefreshToken
            {
                UserId = user.UserId,
                RefreshToken = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };

            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            return (accessToken, refreshToken);
        }

        public async Task<(string accessToken, string refreshToken)> RefreshTokenAsync(RefreshTokenRequestDTO request)
        {
            var principal = _jwtService.GetPrincipalFromExpiredToken(request.AccessToken);
            if (principal == null)
                throw new SecurityTokenException("Invalid token");

            var userId = Guid.Parse(principal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var storedRefreshToken = await _refreshTokenRepository.GetValidTokenAsync(userId, request.RefreshToken);

            if (storedRefreshToken == null || storedRefreshToken.ExpiryDate <= DateTime.UtcNow)
                throw new SecurityTokenException("Invalid refresh token");

            storedRefreshToken.IsRevoked = true;

            var user = await _userRepository.GetByIdAsync(userId);

            var newAccessToken = _jwtService.GenerateAccessToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            var newRefreshTokenEntity = new UserRefreshToken
            {
                UserId = user.UserId,
                RefreshToken = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };

            await _refreshTokenRepository.AddAsync(newRefreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            return (newAccessToken, newRefreshToken);
        }

        public async Task LogoutAsync(Guid userId)
        {
            var tokens = await _refreshTokenRepository.GetAllValidTokensByUserIdAsync(userId);

            foreach (var token in tokens)
                token.IsRevoked = true;

            await _refreshTokenRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> AllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
