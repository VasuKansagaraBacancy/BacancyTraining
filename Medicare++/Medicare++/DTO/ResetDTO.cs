namespace Medicare__.Model_DTO
{
    public class ResetRequest { 
        public string Email { get; set; } 
    }
    public class ResetPasswordModel {
        public string Token { get; set; } 
        public string NewPassword { get; set; } 
    }
}