using System.Net;
using System.Net.Mail;

namespace CompanyProjectPL.Utilities
{
    public static class EmailSettings
    {
        public static bool SendEmail(Email email)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("rhmarhma360@gmail.com", "doak tath temo fcyv");
                client.Send("rhmarhma360@gmail.com", email.To, email.Subject, email.Body);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
