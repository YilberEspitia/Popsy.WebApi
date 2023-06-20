using System.Net;
using System.Net.Mail;

using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Settings;

namespace Popsy.Integrations
{
    public class EmailService : IEmailService
    {
        private readonly SMTPSettings _settings;

        public EmailService(SMTPSettings settings)
        {
            _settings = settings;
        }

        void IEmailService.SendEmail(string to, string bodyHtml, EmailType emailType)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(_settings.SmtpServer, int.Parse(_settings.SmtpPort)))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_settings.SmtpUsername, _settings.SmtpPassword);
                    string origen = string.Empty;
                    string asunto = string.Empty;
                    switch (emailType)
                    {
                        case (EmailType.Inventario):
                            origen = _settings.OrigenInventario;
                            asunto = _settings.AsuntoInventario;
                            break;
                        case (EmailType.RecepcionDeCompra):
                            origen = _settings.OrigenRecepcion;
                            asunto = _settings.AsuntoRecepcion;
                            break;
                        default:
                            origen = _settings.OrigenInventario;
                            asunto = _settings.AsuntoInventario;
                            break;
                    }
                    MailMessage message = new MailMessage(origen, to, asunto, bodyHtml);
                    message.IsBodyHtml = true;

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }
    }
}