using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.ViewModel
{
    
    public class DanhBaVielModel
    {
        public enum KetQua
        {
            TrungMa,
            ThanhCong
        }
        public int ID { get; set; }
        public string TenGoi { get; set; }

        public string Email { get; set; }

        public string Sdt { get; set; }

        public int? IDNhom { get; set; }

        public string DiaChi { get; set; }

       
    }
}
