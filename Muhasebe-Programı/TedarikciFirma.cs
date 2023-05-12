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

    public partial class TedarikciFirma : Form
    {
        dbislem db = new dbislem();
        public TedarikciFirma()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("Select * From Tedarikci");
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
                                int ID = Convert.ToInt32(dtlist.Rows[i].Cells["TedarikciId"].Value);
                                DataTable dt = db.GetDataTable("Select * From Tedarikci Where FirmaAdi='" + FirmaAdi + "'");
                                if (dt.Rows.Count == 0)
                                {
                                    db.execute("Update Tedarikci set FirmaAdi='" + FirmaAdi + "' Where TedarikciId=" + ID);
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

        private void TedarikciFirma_Load(object sender, EventArgs e)
        {
            Listele();
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
                                int ID = Convert.ToInt32(dtlist.Rows[i].Cells["TedarikciId"].Value);
                                DataTable dt = db.GetDataTable("SELECT Tedarikci.*, TSiparis.* FROM  Tedarikci INNER JOIN " +
                                             " TSiparis ON Tedarikci.TedarikciId = TSiparis.TedarikciId Where TSiparis.TedarikciId=" + ID);
                                if (dt.Rows.Count == 0)
                                {
                                    db.execute("Delete From Tedarikci Where TedarikciId=" + ID);
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

                    MessageBox.Show(msj.Message, "Muhasebe Programı");
                }

                

            }
            Listele();

        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetDataTable("Select * From Tedarikci Where FirmaAdi Like '%" + txtara.Text + "%'");
            dtlist.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TedarikciFirmaKayit frm = new TedarikciFirmaKayit();
            frm.Show();
            this.Hide();
        }
    }
}
