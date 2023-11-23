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
            string productId = collectAllProduct[0].Masp.Substring(0, 4);
            ProductTypeId productTypeId = new ProductTypeId();
            if (!System.IO.File.Exists("ProductData.json"))
            {
                List<ProductDataJson> dataJson = new List<ProductDataJson>();
                foreach (var product in collectAllProduct)
                {
                    ProductDataJson productData = new ProductDataJson();

                    productData.masp = product.Masp;
                    if (product.Masp.Substring(0, 4).CompareTo(productId) != 0)
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
                System.IO.File.WriteAllText("ProductData.json", toJsonData);
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
        public void UpdateAccessTimes(string masp)
        {
            if(this._cosmeticContext.UpdateAccessTimes(masp) == "1")
            {
                Console.WriteLine("Update success times");
                return;
            }
            Console.WriteLine("Update failed times");
        }
        public List<ProductCardModel> GetTopSearch()
        {
            var allProduct = this._cosmeticContext.GetProductCardData();
            return allProduct.Where(product => product.solantruycap > 100).ToList();
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

            if (pay._payment.CompareTo("Money") == 0)
                return true;
            try
            {
                using(QL_COSMETICContext contextAddmethodPayment = new QL_COSMETICContext())
                {
                    if (pay._payment.StartsWith("NH"))
                    {
                        Thanhtoan tt = new Thanhtoan();
                        tt.Makh = pay._makh;
                        tt.Mahd = mahd;
                        tt.Magiaodich = "ABCXYZ123456";
                        tt.Trangthai = "";
                        tt.Ngaylap = DateTime.Now.Date;
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
                        vc.Tinhtrang = "Đang giao";
                        vc.Khoangcach = 10;
                        vc.Tongthanhtoan = (decimal)(pay._totalMoney + (double)this._cosmeticContext.Hotrovanchuyens.Where(v => v.Madichvu == pay._payment).Select(v => v.Chiphi).FirstOrDefault());
                        vc.Ngaydathang = DateTime.Now.Date;
                        if(DateTime.Now.Day == 28 && DateTime.Now.Month == 2 || DateTime.Now.Day == 30)
                        {
                            vc.Ngaygiaohang = new DateTime(DateTime.Now.Year,DateTime.Now.Month + 1, 1);

                        }
                        else
                        {
                            vc.Ngaygiaohang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 2, 8, 0, 0);
                        }
                        contextAddmethodPayment.Hoadonvanchuyens.Add(vc);
                        contextAddmethodPayment.Entry<Hoadonvanchuyen>(vc).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                        
                    changes = contextAddmethodPayment.SaveChanges();
                }    
                
            }
            catch (Exception ex)
            {
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
                hd.Ngaylap = DateTime.Now.Date;
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
                           _dateSet = item.Ngaylap,
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
            khId = this._cosmeticContext.GetKhidByUID(khId);
            if (string.IsNullOrEmpty(khId))
                return null;
            var getHistory = from item in _cosmeticContext.Chitiethoadons
                             join sp in _cosmeticContext.Sanphams
                             on item.Masp equals sp.Masp
                             join hd in _cosmeticContext.Hoadons
                             on item.Mahd equals hd.Mahd
                             where hd.Makh == khId
                             select new HistoryProductBill {_mahd = item.Mahd, _tenSp = sp.Tensp, _giaban = (double)sp.Giaban, _soluong = item.Soluong??0 };
            return getHistory.ToList();
        }
        public List<string> GetBillCodeNotConfirmed()
        {
            return this._cosmeticContext.Hoadons.Where(itm => itm.Manv == null).Select(itm => itm.Mahd).ToList();
        }

        public List<string> GetBillCodeConfirmed()
        {
            return this._cosmeticContext.Hoadons.Where(itm => itm.Manv != null).Select(itm => itm.Mahd).ToList();
        }
        public List<string> GetDeliveryNotConfirmed()
        {
            return this._cosmeticContext.Hoadonvanchuyens.Where(itm => itm.Tinhtrang.CompareTo("Đang giao") == 0).Select(itm => itm.Magiaovan).ToList();
        }

        public List<string> GetDeliveryConfirmed()
        {
            return this._cosmeticContext.Hoadonvanchuyens.Where(itm => itm.Tinhtrang.CompareTo("Đang giao") != 0).Select(itm => itm.Magiaovan).ToList();
        }
        public string UpdateDeliveryConfirmed(string magv, string manv)
        {
            if (magv == null || manv == null) return "Failed by parameters null";
            var hdvc = this._cosmeticContext.Hoadonvanchuyens.Where(itm => itm.Magiaovan == magv).FirstOrDefault();
            if (hdvc == null) return "Failed by not found";
            hdvc.Tinhtrang = "Đã giao";
            try
            {
                this._cosmeticContext.Hoadonvanchuyens.Attach(hdvc);
                this._cosmeticContext.Entry<Hoadonvanchuyen>(hdvc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._cosmeticContext.SaveChanges();
            }catch(Exception ex)
            {
                return "Failed by exception occurred";
            }
            return this._cosmeticContext.UpdateStaffConfirmed(hdvc.Mahd, manv);
        }
        public List<HistoryProductBill> GetProductHistory(List<string> mahds)
        {
            var get = from item in this._cosmeticContext.Chitiethoadons
                      join sp in this._cosmeticContext.Sanphams
                      on item.Masp equals sp.Masp
                      where mahds.Contains(item.Mahd)
                      select new HistoryProductBill {_mahd = item.Mahd, _giaban = (double)sp.Giabanmoi, _soluong = item.Soluong ?? 0, _tenSp = sp.Tensp };
            return get.ToList();
        }
        public string UpdateStaffConfirmed(string _billcode, string _manv)
        {
            return this._cosmeticContext.UpdateStaffConfirmed(_billcode, _manv);
        }
        public List<StatisticModel> GetAllStatiticMoneys(int month, int year, string? ptype, string? product)
        {
             
            if(month != 0 && ptype != null && product == null)
            {

                return (from item in _cosmeticContext.Chitiethoadons
                        join sp in _cosmeticContext.Sanphams
                        on item.Masp equals sp.Masp
                        join hd in _cosmeticContext.Hoadons
                        on item.Mahd equals hd.Mahd
                        where hd.Ngaylap.Month == month && hd.Ngaylap.Year == year && sp.Maloai == ptype
                        select new StatisticModel { _masp = sp.Masp, _ngaylap = hd.Ngaylap, _tongtien = (double)hd.Tongtien, _tensp = this._cosmeticContext.Loaisanphams.Where(itm => itm.Maloai == ptype).Select(itm => itm.Tenloai).First() }).ToList();
            }
            if (month != 0 && ptype == null && product != null)
            {

                return (from item in _cosmeticContext.Chitiethoadons
                        join sp in _cosmeticContext.Sanphams
                        on item.Masp equals sp.Masp
                        join hd in _cosmeticContext.Hoadons
                        on item.Mahd equals hd.Mahd
                        where hd.Ngaylap.Month == month && hd.Ngaylap.Year == year && sp.Masp == product
                        select new StatisticModel { _masp = sp.Masp, _ngaylap = hd.Ngaylap, _tongtien = (double)hd.Tongtien, _tensp = sp.Tensp }).ToList();
            }
            else if (month == 0 && ptype != null && product == null)
            {

                return (from item in _cosmeticContext.Chitiethoadons
                        join sp in _cosmeticContext.Sanphams
                        on item.Masp equals sp.Masp
                        join hd in _cosmeticContext.Hoadons
                        on item.Mahd equals hd.Mahd
                        where hd.Ngaylap.Year == year && sp.Maloai == ptype
                        select new StatisticModel { _masp = sp.Masp, _ngaylap = hd.Ngaylap, _tongtien = (double)hd.Tongtien, _tensp = this._cosmeticContext.Loaisanphams.Where(itm => itm.Maloai == ptype).Select(itm => itm.Tenloai).First() }).ToList();
            }
            else if (month == 0 && ptype == null && product != null)
            {

                return (from item in _cosmeticContext.Chitiethoadons
                        join sp in _cosmeticContext.Sanphams
                        on item.Masp equals sp.Masp
                        join hd in _cosmeticContext.Hoadons
                        on item.Mahd equals hd.Mahd
                        where hd.Ngaylap.Year == year && sp.Masp == product
                        select new StatisticModel { _masp = sp.Masp, _ngaylap = hd.Ngaylap, _tongtien = (double)hd.Tongtien, _tensp = sp.Tensp }).ToList();
            }
            else if (month != 0 && ptype == null && product != null)
            {

                return (from item in _cosmeticContext.Chitiethoadons
                        join sp in _cosmeticContext.Sanphams
                        on item.Masp equals sp.Masp
                        join hd in _cosmeticContext.Hoadons
                        on item.Mahd equals hd.Mahd
                        where hd.Ngaylap.Year == year && sp.Masp == product && hd.Ngaylap.Month == month
                        select new StatisticModel { _masp = sp.Masp, _ngaylap = hd.Ngaylap, _tongtien = (double)hd.Tongtien, _tensp = sp.Tensp }).ToList();
            }
            else
                return null;
        }
        public List<Sanpham> GetAllProducts()
        {
            return this._cosmeticContext.Sanphams.ToList();
        }

        public List<Hoadon> GetAllBills()
        {
            return this._cosmeticContext.Hoadons.ToList();
        }
    }
}
