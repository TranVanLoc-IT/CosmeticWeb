using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCosmetic.Models;

namespace WebCosmetic.Areas.Staffs.Pages.ManageBill
{
    [Authorize(Policy = "StaffTerm")]
    [Authorize(Roles = "Staff")]
    [Authorize(Roles = "Sales")]
    public class StatisticBillModel : PageModel
    {
        private readonly IEmailSender _mail;
        public StatisticBillModel(IEmailSender mail)
        {
            _mail = mail;
        }
        private DataTransfer db = new DataTransfer();
        public List<int> monthlabel { get; set; }
        public List<int> yearlabel { get; set; }
        public List<DateTime> xlabel { get; set; } = new List<DateTime>();
        public List<int> ylabel { get; set; } = new List<int>();
        [BindProperty]

        public ReportContent _report { get; set; }
        public class ReportContent
        {
            public string _email { get; set; }
            public string _title { get; set; }
        }
        public async Task<ActionResult> OnGetAsync()
        {
            var getBill = db.GetAllBills();
            var getProduct = db.GetAllProducts();
            monthlabel = new List<int>(getProduct.Count);
            yearlabel = new List<int>(getProduct.Count);
            monthlabel.AddRange(getBill.Select(itm => itm.Ngaylap.Month).Distinct().ToList());
            yearlabel.AddRange(getBill.Select(itm => itm.Ngaylap.Year).Distinct().ToList());

            return Page();
        }
        public async Task<ActionResult> OnPostAsync(string? month, string? year)
        {
            year = year ?? DateTime.Now.Year.ToString();
            var collect = db.GetAllBills().Where(itm => itm.Ngaylap.Month == int.Parse(month) && itm.Ngaylap.Year == int.Parse(year));
            xlabel = new List<DateTime>(collect.Count());
            ylabel = new List<int>(collect.Count());
            foreach (var i in collect)
            {
                if (xlabel.Contains(i.Ngaylap))
                {
                    ylabel[xlabel.IndexOf(i.Ngaylap)]++;
                }
                else
                {

                    xlabel.Add(i.Ngaylap);
                    ylabel.Add(1);
                }
            }
            if(month != null)
            {
                ViewData["ChartTitle"] = "Thống kê theo tháng " + month + " năm " + year;
            }

            return await OnGetAsync();
        }

        public async Task<ActionResult> OnPostSendReport(string reportContent)
        {
            if (ModelState.IsValid)
            {
                await _mail.SendEmailAsync(_report._email, _report._title, reportContent);
                ViewData["reportState"] = "Gửi report thành công";
            }
            else
            {
                ViewData["reportState"] = "Gửi report thất bại";
            }
            return await OnGetAsync();
        }
    }
}
