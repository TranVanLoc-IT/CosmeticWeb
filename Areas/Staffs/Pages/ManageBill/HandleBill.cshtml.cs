using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCosmetic.Models;
namespace WebCosmetic.Areas.Staffs.Pages.ManageBill
{
    [Authorize(Roles = "Sales")]
    public class HandleBillModel : PageModel
    {
        DataTransfer db = new DataTransfer();

        public List<SuccessPayingModel> historyNotConfirmed = new List<SuccessPayingModel>();
        public List<SuccessPayingModel> historyConfirmed = new List<SuccessPayingModel>();
        private readonly UserManager<CosmeticModel> _userManager;
        private readonly SignInManager<CosmeticModel> _signInManager;

        public HandleBillModel(SignInManager<CosmeticModel> signInManager,
            UserManager<CosmeticModel> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> OnGet()
        {
            var getBillNotConfirmed = db.GetBillCodeNotConfirmed();
            var getBillConfirmed = db.GetBillCodeConfirmed();
            string jsonData = System.IO.File.ReadAllText("BillHistory.json");
            var getDetails = System.Text.Json.JsonSerializer.Deserialize<HistoryUserBill>(jsonData);
            ViewData["HistoryProductNotConfirmed"] = db.GetProductHistory(getBillNotConfirmed);
            ViewData["HistoryProductConfirmed"] = db.GetProductHistory(getBillConfirmed);
            // lấy bill chưa có nhân viên xác nhận
            historyNotConfirmed = getDetails._billHistoryList.Where(itm => getBillNotConfirmed.Contains(itm._bill._billCode)).ToList();
            historyConfirmed = getDetails._billHistoryList.Where(itm => getBillConfirmed.Contains(itm._bill._billCode)).ToList();
            return Page();
        }

        public async Task<ActionResult> OnPostConfirmedBill(string _billcode)
        {
            ViewData["StatusConfirmed"] = db.UpdateStaffConfirmed(_billcode, _userManager.GetUserId(User));
            return await OnGet();
        }
    }
}
