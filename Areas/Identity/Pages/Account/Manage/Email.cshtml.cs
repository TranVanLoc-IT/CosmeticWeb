using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using WebCosmetic.Models;

namespace WebCosmetic.Areas.Identity.Pages.Account.Manage
{
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<CosmeticModel> _userManager;
        private readonly SignInManager<CosmeticModel> _signInManager;
        private readonly IEmailSender _emailSender;

        public EmailModel(
            UserManager<CosmeticModel> userManager,
            SignInManager<CosmeticModel> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "New email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(CosmeticModel user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { userId = userId, email = Input.NewEmail, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    Input.NewEmail,
                    "Xác nhận địa chỉ Email từ SeaBeauty",
                    $@"
          <body>
                <header style='text-align: center'>
                <h2>
                    Chào mừng bạn đến với SeaBeauty
                </h2>
                <img src='https://i.imgur.com/HsLMA98.png' style= 'width: 200px; height: 200px; text-align: center;' />
            </header>
             <main style='width: 75%; margin: 0 auto;'>
                    <p>
                   Xin chào {user.UserName}, hãy thay đổi Email với một click nhẹ vào nút phía dưới nhé !
                    </p>
                    <p>
                        Nếu bạn đã nhấn vào thì chúng tôi xin được phép mời bạn trải nghiệm dịch vụ ngay bây giờ trên Website của chúng tôi nhé !
                    </p>
                    <div style='text-align: center; font-size: 20px;text-decoration: none; border-radius: 20px'>
                        <a href = '
                { HtmlEncoder.Default.Encode(callbackUrl)}' style='padding: 10px; color: white; text-align: center; background-color: green'>Xác nhận Email</a>
                    </div>
                    <p>Ngoài ra nếu bạn muốn đăng ký thì hãy<a href=''>Vào đây</a></p>
                    <p><i>Liên hệ với chúng tôi: </i><b><a href = 'tel:19001600' > 1900 1600</a></b></p>
                    <footer>
                        <p><b>Follow các kênh truyền thông để được biết thêm thông tin</b></p>
                        <div style='display:flex;justify-content: space-between; width: 40%; margin: 0 auto'>
                            <div style='margin: 5px 0px;'>
                                <a href = '' style='color: white; background-color: orange; padding: 10px; border-radius: 20px;font-size: 16px' title='Google'>
                                    Google
                                </a>
                            </div>
                            <div>
                                <a href = '' style='color: white; background-color: blue; padding: 10px; border-radius: 20px;font-size: 16px;margin: 0 10px' title='Facebook Fanpage'>
                                    Facebook
                                </a>
                            </div>
                            <div>
                                <a href = '' style='color: white; background-color: red; padding: 10px; border-radius: 20px;font-size: 16px' title='Youtube'>
                                    Youtube
                                </a>
                            </div>
                        </div>
                    </footer>
            </main>
        </body>
    ");

                StatusMessage = "Đã gửi Email xác thực. Hãy kiểm tra hòm thư của bạn !";
                return RedirectToPage();
            }

            StatusMessage = "Your email is unchanged.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Xác nhận địa chỉ Email từ SeaBeauty",
                 $@"
          <body>
                <header style='text-align: center'>
                <h2>
                    Chào mừng bạn đến với SeaBeauty
                </h2>
                <img src='https://i.imgur.com/HsLMA98.png' style= 'width: 200px; height: 200px; text-align: center;' />
            </header>
             <main style='width: 75%; margin: 0 auto;'>
                    <p>
                    Chúng tôi rất hân hạnh chào mừng một khách hàng mới, hãy xác nhận Email với một click nhẹ vào nút phía dưới nhé !
                    </p>
                    <p>
                        Nếu bạn đã nhấn vào thì chúng tôi xin được phép mời bạn trải nghiệm dịch vụ ngay bây giờ trên Website của chúng tôi nhé !
                    </p>
                    <div style='text-align: center; font-size: 20px;text-decoration: none; border-radius: 20px'>
                        <a href = '
                { HtmlEncoder.Default.Encode(callbackUrl)}' style='padding: 10px; color: white; text-align: center; background-color: green'>Xác nhận Email</a>
                    </div>
                    <p>Ngoài ra nếu bạn muốn đăng ký thì hãy<a href=''>Vào đây</a></p>
                    <p><i>Liên hệ với chúng tôi: </i><b><a href = 'tel:19001600' > 1900 1600</a></b></p>
                    <footer>
                        <p><b>Follow các kênh truyền thông để được biết thêm thông tin</b></p>
                        <div style='display:flex;justify-content: space-between; width: 40%; margin: 0 auto'>
                            <div style='margin: 5px 0px;'>
                                <a href = '' style='color: white; background-color: orange; padding: 10px; border-radius: 20px;font-size: 16px' title='Google'>
                                    Google
                                </a>
                            </div>
                            <div>
                                <a href = '' style='color: white; background-color: blue; padding: 10px; border-radius: 20px;font-size: 16px;margin: 0 10px' title='Facebook Fanpage'>
                                    Facebook
                                </a>
                            </div>
                            <div>
                                <a href = '' style='color: white; background-color: red; padding: 10px; border-radius: 20px;font-size: 16px' title='Youtube'>
                                    Youtube
                                </a>
                            </div>
                        </div>
                    </footer>
            </main>
        </body>
    ");

            StatusMessage = "Đã gửi Email xác thực. Hãy kiểm tra hòm thư của bạn !";
            return RedirectToPage();
        }
    }
}
