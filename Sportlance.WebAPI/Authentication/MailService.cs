﻿using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using Sportlance.WebAPI.Core.Options;

namespace Sportlance.WebAPI.Authentication
{
    public class MailService : IMailService
    {
        private readonly IHostingEnvironment _env;
        private readonly IAmazonS3 _s3Client;
        private readonly MailTokenService _mailTokenService;
        private readonly SiteUrls _siteUrls;
        private readonly SmtpOptions _smtpOptions;
        private readonly string _root;

        public MailService(IAmazonS3 s3Client,
            IOptions<SmtpOptions> smtpOptions,
            IOptions<SiteOptions> frontendOptions,
            MailTokenService mailTokenService,
            IHostingEnvironment env)
        {
            _mailTokenService = mailTokenService;
            _env = env;
            _s3Client = s3Client;
            _smtpOptions = smtpOptions.Value;
            _siteUrls = new SiteUrls(frontendOptions.Value.Root);
            _root = frontendOptions.Value.Root;
        }

        public async Task<string> SendConfirmRegistration(long userId, string email)
        {
            var token = _mailTokenService.EncryptToken(email);

            var template = _env.IsDevelopment()
                    ? await ReadEmailTemplate("confirm-registration-mail.html")
                    : await ReadEmailTemplateFromS3("confirm-registration-mail.html")
                ;

            template = template
                .Replace("{HOST}", _root)
                .Replace("{CONFIRMLINK}", _siteUrls.GetConfirmRegistration(userId, token));

            await SendMessage(email, "Подтверждение регистрации", template);

            return token;
        }

        public async Task SendChangePassword(string accessToken, string refreshToken, string email)
        {
            var template = _env.IsDevelopment()
                    ? await ReadEmailTemplate("change-password-mail.html")
                    : await ReadEmailTemplateFromS3("change-password-mail.html")
                ;

            template = template
                .Replace("{HOST}", _root)
                .Replace("{CHANGEPASSWORDLINK}", _siteUrls.GetChangePassword(accessToken, refreshToken));
            await SendMessage(email, "Изменение пароля", template);
        }

        public async Task SendUpdateEmail(string email, string newEmail)
        {
            var token = _mailTokenService.EncryptToken(newEmail);

            var template = _env.IsDevelopment()
                    ? await ReadEmailTemplate("update-email-mail.html")
                    : await ReadEmailTemplateFromS3("update-email-mail.html")
                ;

            template = template
                .Replace("{SUBJECT}", "Password change")
                .Replace("{BODY}", $"Click on the button below to change your email {email} to {newEmail}")
                .Replace("{BUTTON}", "Update email")
                .Replace("{BUTTONHREF}", _siteUrls.GetUpdateEmail(token));
            await SendMessage(email, "Изменение почты", template);
        }

        private async Task<string> ReadEmailTemplateFromS3(string objectName)
        {
            var request = new GetObjectRequest
            {
                BucketName = "sportlance-email-templates",
                Key = objectName
            };
            using (var response = await _s3Client.GetObjectAsync(request))
            using (var responseStream = response.ResponseStream)
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        private async Task<string> ReadEmailTemplate(string templateName)
        {
            using (var reader = File.OpenText($"{_env.ContentRootPath}/email/{templateName}"))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private async Task SendMessage(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpOptions.UserName));
            message.To.Add(new MailboxAddress(to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder {HtmlBody = body};
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(_smtpOptions.Host, _smtpOptions.Port, _smtpOptions.UseSsl);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(_smtpOptions.UserName, _smtpOptions.Password);

                await client.SendAsync(message);

                client.Disconnect(true);
            }
        }
    }
}