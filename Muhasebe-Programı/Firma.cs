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
    public partial class Firma : Form
    {
        dbislem db = new dbislem();
        public Firma()
        {
            InitializeComponent();


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {

            FirmaKayit frm = new FirmaKayit();
            frm.Show();
            this.Hide();


        }

        private void Firma_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("Select * From Firma");
            dtlist.DataSource = dt;
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetDataTable("Select * From Firma Where FirmaAdi Like '%" + txtara.Text + "%'");
            dtlist.DataSource = dt;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Cevap = MessageBox.Show("Firma Adını Düzenlemek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Cevap == DialogResult.Yes)
                {

                    DataGridViewRow dgrow = new DataGridViewRow();

                    for (int i = 0; i < dtlist.Rows.Count; i++)
                    {
                        dgrow = dtlist.Rows[i];
                        try
                        {
                            if (Convert.ToBoolean(dgrow.Cells["Secim"].Value) == true && dgrow.Cells["FirmaAdi"].Value.ToString() != "")
                            {
                                string FirmaAdi = dgrow.Cells["FirmaAdi"].Value.ToString();
                                int ID = Convert.ToInt32(dtlist.Rows[i].Cells["FirmaId"].Value);
                                DataTable dt = db.GetDataTable("Select * From Firma Where FirmaAdi='" + FirmaAdi + "'");
                                if (dt.Rows.Count == 0)
                                {
                                    db.execute("Update Firma set FirmaAdi='" + FirmaAdi + "' Where FirmaId=" + ID);
                                    MessageBox.Show(FirmaAdi + " Firma Adi Düzenlendi", "Muhasebe Programı");

                                }
                                else
                                {
                                    MessageBox.Show("Girmiş Olduğunuz Firma Adı Mevcut", "Muhasebe Programı");
                                }

                            }


                        }
                        catch (Exception msj)
                        {

                            MessageBox.Show(msj.Message, "Firma Bilgilerini Düzenlerken Boş Alan Bırakmayınız ve Düzenlemek istediğiniz Firmayı Seçim Kutusundan işaretleyiniz.");
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            
                DialogResult Cevap = MessageBox.Show("Firma Adını Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Cevap == DialogResult.Yes)
               {

                try
                {
                    if (Convert.ToBoolean(dtlist.SelectedCells[2].Value) == true)
                    {
                        for (int i = 0; i < dtlist.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dtlist.Rows[i].Cells["Secim"].Value) == true)
                            {
                                string FirmaAdi = dtlist.Rows[i].Cells["FirmaAdi"].Value.ToString();
                                int ID = Convert.ToInt32(dtlist.Rows[i].Cells["FirmaId"].Value);
                                DataTable dt = db.GetDataTable("SELECT Firma.*, Siparis.* FROM  Firma INNER JOIN " +
                                           " Siparis ON Firma.FirmaId = Siparis.FirmaId Where Siparis.FirmaId=" + ID);
                                if (dt.Rows.Count == 0)
                                {
                                    db.execute("Delete From Firma Where FirmaId=" + ID);
                                    MessageBox.Show(FirmaAdi + " Firma Adi Silindi", "Muhasebe Programı");

                                }
                                else
                                {
                                    MessageBox.Show("Silmek istediğiniz Firma Adı Altında Firmaya ait bilgiler mevcut", "Muhasebe Programı");
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Silmek istediğiniz Firmayı Seçim Kutusundan işaretleyiniz.");
                    }
                }
                catch (Exception msj)
                {

                    MessageBox.Show(msj.Message,"Muhasebe Programı");
                }
                   

                }
                Listele();
            
        }
    }
}
