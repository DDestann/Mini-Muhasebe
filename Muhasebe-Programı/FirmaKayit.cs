using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;
using System.IO;

namespace Muhasebe_Programı
{
    public partial class FirmaKayit : Form
    {
         dbislem db = new dbislem();
        public FirmaKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirmaAdi.Text != "")
                {
                    DataTable dt = db.GetDataTable("Select * From Firma Where FirmaAdi='" + txtFirmaAdi.Text + "'");
                    if (dt.Rows.Count == 0)
                    {
                        db.execute("insert into Firma Values('" + txtFirmaAdi.Text + "','" + false + "')");
                        MessageBox.Show("Firma Eklendi", "Muhasebe Programı");
                        
                        Temizle();
                        Firma frm = new Firma();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Girmiş Olduğunuz Firma Adı Mevcut", "Muhasebe Programı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                       
                    }
                }
                else
                {
                    MessageBox.Show("Firma Adı Girilmeden Kayıt Yapılamaz...!!! ", "Muhasebe Programı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Muhasebe Programı");

            }
        }

        private void Temizle()
        {
            txtFirmaAdi.Text = "";
        }

        private void FirmaKayit_Load(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
