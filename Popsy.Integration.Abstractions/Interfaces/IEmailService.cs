using Popsy.Enums;

namespace Popsy.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string to, string bodyHtml, EmailType emailType);
    }
}