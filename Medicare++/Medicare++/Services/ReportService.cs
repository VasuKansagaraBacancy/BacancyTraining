using iTextSharp.text.pdf;
using iTextSharp.text;
using Medicare__.Repositories;

namespace Medicare__.Services
{
    public class ReportService : IReportService
    {
        private readonly IUserRepository _userRepository;

        public ReportService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<byte[]> GenerateUsersPdfAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (!users.Any())
                throw new InvalidOperationException("No users found.");

            using (var ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                PdfWriter.GetInstance(document, ms);

                document.Open();

                string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Medicare.jpg.jpg");
                if (File.Exists(logoPath))
                {
                    var logo = Image.GetInstance(logoPath);
                    logo.ScaleAbsolute(100f, 100f);
                    logo.Alignment = Element.ALIGN_CENTER;
                    document.Add(logo);
                }

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                var title = new Paragraph("Medicare+ User List Report", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(title);

                PdfPTable table = new PdfPTable(15)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10,
                    SpacingAfter = 10
                };

                float[] widths = { 3f, 2f, 2f, 3f, 1f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 1f, 2f, 2f };
                table.SetWidths(widths);

                AddHeaderCell(table, "ID", headerFont);
                AddHeaderCell(table, "First Name", headerFont);
                AddHeaderCell(table, "Last Name", headerFont);
                AddHeaderCell(table, "Email", headerFont);
                AddHeaderCell(table, "RoleID", headerFont);
                AddHeaderCell(table, "BirthDate", headerFont);
                AddHeaderCell(table, "PhoneNumber", headerFont);
                AddHeaderCell(table, "EmergencyNumber", headerFont);
                AddHeaderCell(table, "DateOfJoining", headerFont);
                AddHeaderCell(table, "DateOfRelieving", headerFont);
                AddHeaderCell(table, "CreatedBy", headerFont);
                AddHeaderCell(table, "CreatedAt", headerFont);
                AddHeaderCell(table, "Active", headerFont);
                AddHeaderCell(table, "UpdatedBy", headerFont);
                AddHeaderCell(table, "UpdatedAt", headerFont);

                foreach (var user in users)
                {
                    AddBodyCell(table, user.UserId.ToString(), normalFont);
                    AddBodyCell(table, user.FirstName, normalFont);
                    AddBodyCell(table, user.LastName, normalFont);
                    AddBodyCell(table, user.Email, normalFont);
                    AddBodyCell(table, user.RoleId.ToString(), normalFont);
                    AddBodyCell(table, user.DateOfBirth.ToShortDateString(), normalFont);
                    AddBodyCell(table, user.MobileNo, normalFont);
                    AddBodyCell(table, user.EmergencyNo ?? "Null", normalFont);
                    AddBodyCell(table, user.DateOfJoining.ToShortDateString(), normalFont);
                    AddBodyCell(table, user.DateOfRelieving?.ToString("dd-MM-yyyy") ?? "Null", normalFont);
                    AddBodyCell(table, user.CreatedBy ?? "Null", normalFont);
                    AddBodyCell(table, user.CreatedAt.ToString("dd-MM-yyyy HH:mm"), normalFont);
                    AddBodyCell(table, user.Active.ToString(), normalFont);
                    AddBodyCell(table, user.UpdatedBy ?? "Null", normalFont);
                    AddBodyCell(table, user.UpdatedAt?.ToString("dd-MM-yyyy HH:mm") ?? "Null", normalFont);
                }

                document.Add(table);
                document.Close();

                return ms.ToArray();
            }
        }

        private void AddHeaderCell(PdfPTable table, string text, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = BaseColor.LIGHT_GRAY,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Padding = 5
            };
            table.AddCell(cell);
        }

        private void AddBodyCell(PdfPTable table, string text, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Padding = 5
            };
            table.AddCell(cell);
        }
    }
}
