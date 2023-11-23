using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCosmetic.Models;
namespace WebCosmetic.Areas.Staffs.Pages.StatisticMoney
{
    [Authorize(Roles = "Sales")]
    public class StatisticIndexModel : PageModel
    {
        private DataTransfer db = new DataTransfer();
        private readonly IEmailSender _mail;
        public StatisticIndexModel(IEmailSender mail)
        {
            _mail = mail;
        }
        public List<int> monthlabel { get; set; }
        public List<int> yearlabel { get; set; }
        public List<string> productlabel { get; set; }
        public List<DateTime> xlabel { get; set; } = new List<DateTime>();
        public List<double> ylabel { get; set; } = new List<double>();
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
            productlabel = new List<string>(getProduct.Count);
            monthlabel.AddRange(getBill.Select(itm => itm.Ngaylap.Month).Distinct().ToList());
            yearlabel.AddRange(getBill.Select(itm => itm.Ngaylap.Year).Distinct().ToList());

            productlabel.AddRange(getProduct.Select(itm => itm.Masp + "-" + itm.Tensp));

            return Page();
        }
        public async Task<ActionResult> OnPostAsync(string? month, string? year, string? ptype, string?product)
        {
            year = year ?? DateTime.Now.ToString();
            var collect = db.GetAllStatiticMoneys(month==null?0:int.Parse(month), year==null?0:int.Parse(year), ptype, product);
            xlabel = new List<DateTime>(collect.Count);
            ylabel = new List<double>(collect.Count);
            foreach( var i in collect)
            {
                if(xlabel.Contains(i._ngaylap))
                {
                    ylabel[xlabel.IndexOf(i._ngaylap)] += i._tongtien;
                }    
                else
                {

                    xlabel.Add(i._ngaylap);
                    ylabel.Add(i._tongtien);
                }    
            }    
            if(collect != null || collect.Count() != 0)
                ViewData["ChartTitle"] = "Thống kê theo " + collect[0]._tensp;

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
