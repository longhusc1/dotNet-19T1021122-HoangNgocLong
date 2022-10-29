using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiemTra.ViewModel;
using KiemTra.Services;
using KiemTra.Model;
using System.Text.RegularExpressions;
using static KiemTra.ViewModel.DanhBaVielModel;

namespace KiemTra
{
    public partial class frmLienLac : Form
    {
        ViewModel.DanhBaVielModel danhBa;
        public frmLienLac(ViewModel.DanhBaVielModel dba = null)
        {
            InitializeComponent();
            NapDsNhom();
            this.danhBa = dba;
            if (dba != null)
            {
                cbbTenNhom.SelectedValue = dba.IDNhom;
                txtTenGoi.Text = dba.TenGoi;
                txtEmail.Text = dba.Email;
                txtSdt.Text = dba.Sdt;
                txtDiaChi.Text = dba.DiaChi;
            }
        }

        public NhomViewModel selectedNhom
        {
            get
            {
                return cbbTenNhom.SelectedItem as NhomViewModel;
            }
        }

        void NapDsNhom()
        {
            var ls = NhomService.GetList();
            cbbTenNhom.DataSource = ls;
            cbbTenNhom.ValueMember = "ID";
            cbbTenNhom.DisplayMember = "TenNhom";
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (this.danhBa == null)
            {

                var danhba = new DanhBa
                {
                    IDNhom = selectedNhom.ID,
                    TenGoi = txtTenGoi.Text,
                    Email = txtEmail.Text,
                    DiaChi = txtDiaChi.Text,
                    Sdt = txtSdt.Text,
                };
                if (Services.DanhBaService.AddDanhBa(danhba) == KetQua.ThanhCong)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
