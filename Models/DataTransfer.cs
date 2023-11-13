using System;
using System.Collections.Generic;
using System.Linq;
using WebCosmetic.Scaffold;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text.Json;

namespace WebCosmetic.Models
{
    public class DataTransfer:PageModel
    {

        private readonly QL_COSMETICContext _cosmeticContext;
        
       
        public DataTransfer()
        {
            this._cosmeticContext = new QL_COSMETICContext();
            transferDbToJson();
        }

        private void transferDbToJson()
        {
            var collectAllProduct = this._cosmeticContext.Sanphams.ToList();
            string productId = collectAllProduct[0].Masp.Substring(0,4);
            ProductTypeId productTypeId = new ProductTypeId();
            if(!System.IO.File.Exists("ProductData.json"))
            {
                List<ProductDataJson> dataJson = new List<ProductDataJson>();
                foreach (var product in collectAllProduct)
                {
                    ProductDataJson productData = new ProductDataJson();

                    productData.masp = product.Masp;
                    if(product.Masp.Substring(0,4).CompareTo(productId) != 0)
                    {
                        productTypeId._productObjectIdType[productId] = dataJson;
                        dataJson = new List<ProductDataJson>();
                        productId = product.Masp.Substring(0, 4);
                        productTypeId._productObjectIdType[productId] = new List<ProductDataJson>();
                    }
                    dataJson.Add(productData);
                }
                var toJsonData = JsonSerializer.Serialize(productTypeId._productObjectIdType, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });
                System.IO.File.WriteAllText("ProductData.json",toJsonData);
            }    
            
        }
        public List<ProductCardModel> claimProductSearchCatalog()
        {
            return this._cosmeticContext.GetProductCardData();
        }
        public List<ProductCardModel> getProductByType(string masp)
        {
            var allProduct = this._cosmeticContext.GetProductCardData();
            return allProduct.Where(product => product.masp.Substring(0,4) == masp).ToList();
        }

        public bool RegisterAnnoucement(string makh)
        {
            Nhanthongbao add = new Nhanthongbao();
            add.Makh = makh;
            add.Ngaydk = DateTime.Now;
            try
            {
                var register = this._cosmeticContext.Nhanthongbaos.Add(add);
                this._cosmeticContext.Entry(register).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                this._cosmeticContext.SaveChanges();
            }catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<ProductCardModel> collectRecommendProduct()
        {
            var allProduct = this._cosmeticContext.GetProductCardData();
            var allRmd = this._cosmeticContext.Dexuatmuas.ToList();

            var finalResult = (from prd in allProduct
                       join rmd in allRmd
                       on prd.masp equals rmd.Masp
                       select prd).ToList();
            return finalResult;
        }
        public bool addDetailsOfBill(PayingModel pay, string mahd)
        {
            // null
            int changes = 0;
            try
            {
                using(QL_COSMETICContext contextAddDetailsOfBill = new QL_COSMETICContext())
                {
                    // ổn
                    foreach (var product in pay._sanphamMua)
                    {
                        double giaban = 0;

                        Chitiethoadon cthd = new Chitiethoadon();
                        cthd.Mahd = mahd;
                        cthd.Masp = product.Key;
                        cthd.Soluong = product.Value;
                        giaban = (double)this._cosmeticContext.Sanphams.Where(sp => sp.Masp == product.Key).FirstOrDefault().Giaban;
                        cthd.Thanhtien = (decimal)(giaban * cthd.Soluong);
                        contextAddDetailsOfBill.Chitiethoadons.Add(cthd);
                        contextAddDetailsOfBill.Entry<Chitiethoadon>(cthd).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                        changes = contextAddDetailsOfBill.SaveChanges();

                }

            }
            catch(Exception ex)
            {
                return false;
            }
            return changes > 0 ? true : false;
        }
        private bool addPaymentOfBill(PayingModel pay, string mahd)
        {
            // null
            int changes = 0;
            Console.WriteLine(pay._payment + changes.ToString());

            if (pay._payment.CompareTo("Money") == 0)
                return true;
            try
            {
                using(QL_COSMETICContext contextAddmethodPayment = new QL_COSMETICContext())
                {
                    if (pay._payment.Contains("NH"))
                    {
                        Thanhtoan tt = new Thanhtoan();
                        tt.Makh = pay._makh;
                        tt.Mahd = mahd;
                        tt.Magiaodich = "ABCXYZ123456";
                        Console.WriteLine("ok vo ne");
                        tt.Trangthai = "";
                        tt.ngaylap = DateTime.Now;
                        tt.Manganhang = pay._payment;
                        contextAddmethodPayment.Thanhtoans.Add(tt);
                        contextAddmethodPayment.Entry<Thanhtoan>(tt).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                    else
                    {
                        Hoadonvanchuyen vc = new Hoadonvanchuyen();
                        vc.Mahd = mahd;
                        vc.Madichvu = pay._payment;
                        vc.Magiaovan = "ABCXYZ123456";
                        vc.Khoangcach = 10;
                        vc.Tongthanhtoan = (decimal)(pay._totalMoney + (double)this._cosmeticContext.Hotrovanchuyens.Where(v => v.Madichvu == pay._payment).Select(v => v.Chiphi).FirstOrDefault());
                        vc.NgayDatHang = DateTime.Now;
                        vc.NgayGiaoHang = new DateTime(DateTime.Now.Day + 2, DateTime.Now.Month, DateTime.Now.Year);
                        contextAddmethodPayment.Hoadonvanchuyens.Add(vc);
                        contextAddmethodPayment.Entry<Hoadonvanchuyen>(vc).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                    changes = contextAddmethodPayment.SaveChanges();
                }    
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;
            }
            return changes > 0 ? true : false;
        }
        public string addBillAndPayment(PayingModel pay)
        {
            if(pay != null)
            {
                Hoadon hd = new Hoadon();
                hd.Makh = pay._makh;
                hd.Tongtien = (decimal)pay._totalMoney;
                hd.Mahd = this._cosmeticContext.GenerateBillCode();
                this._cosmeticContext.Hoadons.Add(hd);
                this._cosmeticContext.Entry<Hoadon>(hd).State = Microsoft.EntityFrameworkCore.EntityState.Added;
              
                this._cosmeticContext.SaveChanges();
                if(addDetailsOfBill(pay, hd.Mahd) && addPaymentOfBill(pay, hd.Mahd))
                    return hd.Mahd;
            }

            return string.Empty;
        }
        public SuccessPayingModel.BillInfo GetBillInfoLatest(string clientId, string mahd)
        {
            var bill = from item in this._cosmeticContext.Thanhtoans
                       join hd in this._cosmeticContext.Hoadons
                       on item.Mahd equals hd.Mahd
                       where item.Makh == clientId
                       && item.Mahd == mahd
                       select new SuccessPayingModel.BillInfo()
                       {
                           _billCode = item.Mahd,
                           _dateSet = item.ngaylap,
                           _transactionCode = item.Magiaodich,
                           _methodPayment = (this._cosmeticContext.Hotrothanhtoans.Where(ht => ht.Manganhang == item.Manganhang).Select(ht => ht.Tennganhang).FirstOrDefault())
                       };
            return bill.FirstOrDefault() ;
        }
        public Khachhang GetCustomerById(string loginId)
        {
            if(string.IsNullOrEmpty(loginId))
            {
                return new Khachhang();
            }    
            return this._cosmeticContext.Khachhangs.Where(kh => kh.Makh.Contains(loginId.Substring(0, 5))).FirstOrDefault();
        }
        public List<KeyValuePair<string, string>> GetAllBankingSupply()
        {
            // Lấy danh sách các cặp "Manganhang" và "Tennganhang"
            var bankingSupplies = this._cosmeticContext.Hotrothanhtoans
                .Select(field => new KeyValuePair<string, string>(field.Manganhang, field.Tennganhang))
                .ToList();

            return bankingSupplies;
        }


        public List<KeyValuePair<string, string>> GetAllShippingSupply()
        {
            // Lấy danh sách các cặp "Manganhang" và "Tennganhang"
            var shippingSupplies = this._cosmeticContext.Hotrovanchuyens
                .Select(field => new KeyValuePair<string, string>(field.Madichvu, field.Tendichvu))
                .ToList();

            return shippingSupplies;
        }

        public List<HistoryProductBill> GetProductHistory(string khId)
        {
            var getHistory = from item in _cosmeticContext.Chitiethoadons
                             join sp in _cosmeticContext.Sanphams
                             on item.Masp equals sp.Masp
                             join hd in _cosmeticContext.Hoadons
                             on item.Mahd equals hd.Mahd
                             where hd.Makh == khId
                             select new HistoryProductBill { _tenSp = sp.Tensp, _giaban = (double)sp.Giaban, _soluong = item.Soluong??0 };
            return getHistory.ToList();
        }
    }
}
