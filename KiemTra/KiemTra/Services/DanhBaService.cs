using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiemTra.Model;
using KiemTra.ViewModel;
using static KiemTra.ViewModel.DanhBaVielModel;

namespace KiemTra.Services
{
    public class DanhBaService
    {
        public static List<ViewModel.DanhBaVielModel> GetList()
        {
            var db = new AppDBContext();
            var rs = db.DanhBas.Select(e => new DanhBaVielModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                Sdt = e.Sdt,
                IDNhom = e.IDNhom,
                DiaChi = e.DiaChi
            }).ToList();
            return rs;
        }

        public static List<ViewModel.DanhBaVielModel> GetList(int idNhom)
        {
            var db = new AppDBContext();
            var rs = db.DanhBas.Where(e => e.IDNhom == idNhom).Select(e => new DanhBaVielModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                Sdt = e.Sdt,
                IDNhom = e.IDNhom,
                DiaChi = e.DiaChi
            }).ToList();
            return rs;
        }

        public static KetQua AddDanhBa(DanhBa d) 
        {
            var db = new AppDBContext();
            db.DanhBas.Add(d);
            db.SaveChanges();
            return KetQua.ThanhCong;
        }

        public static KetQua RemoveDanhBa(ViewModel.DanhBaVielModel d)
        {
            var db = new AppDBContext();
            var rs = db.DanhBas.Where(e => e.ID == d.ID).FirstOrDefault();
            db.DanhBas.Remove(rs);
            db.SaveChanges();
            return KetQua.ThanhCong;
        }
        public static List<DanhBaVielModel> SearchDanhBa(string c, NhomViewModel n)
        {
            var db = new AppDBContext();
            var rs = db.DanhBas.Where(e => e.IDNhom == n.ID).
                                Where(e => e.TenGoi.Contains(c)
                                        || e.DiaChi.Contains(c)
                                        || e.Email.Contains(c)
                                        || e.Sdt.Contains(c))
                                .Select(e => new DanhBaVielModel
                                {
                                    ID = e.ID,
                                    TenGoi = e.TenGoi,
                                    Email = e.Email,
                                    Sdt = e.Sdt,
                                    IDNhom = e.IDNhom,
                                    DiaChi = e.DiaChi

                                }).ToList();
            return rs;
        }
    }
}
