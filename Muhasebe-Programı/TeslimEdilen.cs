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
    public partial class TeslimEdilen : Form
    {
         dbislem db = new dbislem();
         decimal Toplamm = 0;
        public TeslimEdilen()
        {
            InitializeComponent();
        }

       

        private void TeslimEdilen_Load(object sender, EventArgs e)
        {
            Listele();
            Tutarlist();
        }

        private void Tutarlist()
        {
            DataTable dtTutar = db.GetDataTable("Select * From Siparis Where Teslimat='" + true + "'");

            for (int i = 0; i < dtTutar.Rows.Count; i++)
            {
                Toplamm += Convert.ToDecimal(dtTutar.Rows[i]["Tutar"].ToString());

                lblToplamTutar.Text = " " + Toplamm.ToString();
            }
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("SELECT Firma.FirmaAdi, Siparis.* FROM Firma INNER JOIN Siparis ON Firma.FirmaId = Siparis.FirmaId Where Teslimat='" + true + "'");
            dtlist.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["FirmaId"].Value);
            SiparisKayitDuzen frm = new SiparisKayitDuzen();

            frm.btnKaydet.Text = "Kaydet";
            // frm.txtId.Text = db.Id.ToString();

            frm.Show();

            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["SiparisId"].Value);
                SiparisKayitDuzen frm = new SiparisKayitDuzen();

                frm.btnKaydet.Text = "Düzenle";
                frm.txtId.Text = db.Id.ToString();

                frm.Show();

                this.Hide();
            }
            catch (Exception msj)
            {
                MessageBox.Show(msj.Message,"Muhasebe Programı");
               
            }
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetDataTable("SELECT Firma.FirmaAdi, Siparis.* FROM Firma INNER JOIN Siparis ON Firma.FirmaId = Siparis.FirmaId Where Firma.FirmaAdi Like '%" + txtara.Text + "%' and Teslimat='"+true+"'" );
            dtlist.DataSource = dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Cevap = MessageBox.Show("Siparişi Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Cevap == DialogResult.Yes)
                {

                    DataGridViewRow dgrow = new DataGridViewRow();

                    for (int i = 0; i < dtlist.Rows.Count; i++)
                    {
                        dgrow = dtlist.Rows[i];
                        try
                        {
                            if (Convert.ToBoolean(dgrow.Cells["Secim"].Value) == true)
                            {
                                string FirmaAdi = dgrow.Cells["FirmaAdi"].Value.ToString();
                                int ID = Convert.ToInt32(dtlist.Rows[i].Cells["SiparisId"].Value);

                                db.execute("Delete From Siparis Where SiparisId=" + ID);
                                MessageBox.Show(FirmaAdi + " Siparis Silindi", "Muhasebe Programı");

                            }


                        }
                        catch (Exception msj)
                        {

                            MessageBox.Show(msj.Message, "Silmek istediğiniz Siparisi Seçim Kutusundan işaretleyiniz.");
                        }
                    }

                }
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Muhasebe Programı");

            }
        }
    }
}
