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
    public partial class TSiparis : Form
    {
         dbislem db = new dbislem();
         decimal Toplam = 0;
        public TSiparis()
        {
            InitializeComponent();
        }
        private void TSiparis_Load(object sender, EventArgs e)
        {
            Listele();

            Tutarlist();
        }

        private void Tutarlist()
        {
            DataTable dtTutar = db.GetDataTable("Select * From TSiparis Where Odendi='" + false + "'");

            for (int i = 0; i < dtTutar.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dtTutar.Rows[i]["Tutar"].ToString());

                lblToplamTutar.Text = " " + Toplam.ToString();
            }
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("SELECT Tedarikci.FirmaAdi, TSiparis.* FROM  Tedarikci INNER JOIN "+
                         " TSiparis ON Tedarikci.TedarikciId = TSiparis.TedarikciId Where Odendi='" + false + "'");
            dtlist.DataSource = dt;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["TSiparisId"].Value);
                TSiparisKayitDuzen frm = new TSiparisKayitDuzen();

                frm.BtnKaydet.Text = "Düzenle";
                frm.lblId.Text = db.Id.ToString();
                frm.chkOdendi.Visible = true;
                frm.txtOdenmeTarihi.Visible = true;
                frm.Show();

                this.Hide();
            }
            catch (Exception msj)
            {
                MessageBox.Show(msj.Message, "Muhasebe Programı");

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult Cevap = MessageBox.Show("Siparişi Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Cevap == DialogResult.Yes)
            {

                // DataGridViewRow dgrow = new DataGridViewRow();
                MessageBox.Show("Silmek istediğiniz Siparisi Seçim Kutusundan işaretleyiniz.");

                try
                {

                    for (int i = 0; i < dtlist.Rows.Count; i++)
                    {
                        // dgrow = dtlist.Rows[i];
                        if (Convert.ToBoolean(dtlist.Rows[i].Cells["Secim"].Value) == true)
                        {
                            string FirmaAdi = dtlist.Rows[i].Cells["FirmaAdi"].Value.ToString();
                            int ID = Convert.ToInt32(dtlist.Rows[i].Cells["TSiparisId"].Value);

                            db.execute("Delete From TSiparis Where TSiparisId=" + ID);
                            MessageBox.Show(FirmaAdi + " Siparis Silindi", "Muhasebe Programı");

                        }

                    }


                }
                catch (Exception msj)
                {
                    MessageBox.Show(msj.Message, "Muhasebe Programı");

                }

            }
            Listele();
            Tutarlist();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetDataTable("SELECT Tedarikci.*, TSiparis.* FROM  Tedarikci INNER JOIN " +
                         " TSiparis ON Tedarikci.TedarikciId = TSiparis.TedarikciId Where Odendi='" + false + "' AND Tedarikci.FirmaAdi Like '%"+txtara.Text+"%'");
            dtlist.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["FirmaId"].Value);
            TSiparisKayitDuzen frm = new TSiparisKayitDuzen();

            frm.BtnKaydet.Text = "Kaydet";
            // frm.txtId.Text = db.Id.ToString();

            frm.Show();

            this.Hide();
        }

        

        
    }
}
