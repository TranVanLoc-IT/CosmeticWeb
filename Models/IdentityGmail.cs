using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IO;

namespace WebCosmetic.Models
{
    public class MailSettings
    {
        // service.Configure<MailSettings>(mailsettings): đọc thuộc tính tương ứng từ json
        public string Mail { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public int Port { get; set; }
    }
    public class IdentityGmail : IEmailSender
    {
        // inject 
        public MailSettings MailSettings { get; set; }
        // xem log: kiểm tra quá trình
        public ILogger<MailSettings> Logger { get; set; }
        public IdentityGmail(IOptions<MailSettings> _mailSettings, ILogger<MailSettings> _logger)
        {
            MailSettings = _mailSettings.Value;
            Logger = _logger;
            Logger.LogInformation("Create mailsettings");
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(MailSettings.DisplayName, email);
            message.From.Add(new MailboxAddress(MailSettings.DisplayName, email));
            message.Subject = subject;
            message.To.Add(new MailboxAddress(email, email));
            message.ReplyTo.Add(new MailboxAddress(email, email));
            // html
            var html = new BodyBuilder();
            html.HtmlBody = htmlMessage;
            message.Body = html.ToMessageBody();
            // mailkit
            var mailKit = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                Console.WriteLine(MailSettings.Mail + MailSettings.Password);
                await mailKit.ConnectAsync(MailSettings.Host, MailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await mailKit.AuthenticateAsync(MailSettings.Mail, MailSettings.Password);
                await mailKit.SendAsync(message);
            }
            catch (Exception ex)
            {
                // sai password của app nên mới exception, kiểm tra
                Console.WriteLine("Thông báo lỗi send mail: " + ex.Message);
                Directory.CreateDirectory("MailSave");
                string save = string.Format(@"MailSave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(save);
                Logger.LogInformation("Create file save error at: {0}", save);
            }
            await mailKit.DisconnectAsync(true);

        }
    }
}
