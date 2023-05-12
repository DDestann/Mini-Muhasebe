using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe_Programı
{
    public partial class OdemeGuncelleme : Form
    {
        dbislem db = new dbislem();
        decimal Toplam = 0;
        public OdemeGuncelleme()
        {
            InitializeComponent();
        }

        private void OdemeGuncelleme_Load(object sender, EventArgs e)
        {
            DrpList();
           
            
        }

        private void OdemeTutarList()
        {
            DataTable dt = db.GetDataTable("Select * From Odemeler Where FirmaId="+comboBox1.SelectedValue);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["AlinanOdeme"].ToString());
            }

            lblAlinanOdeme.Text = " Toplam = " + Toplam.ToString();
            
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("SELECT  Odemeler.*, Firma.* FROM   Firma INNER JOIN " +
                       "  Odemeler ON Firma.FirmaId = Odemeler.FirmaId where Odemeler.FirmaId="+comboBox1.SelectedValue);

            dtlist.DataSource = dt;
            dtlist.Columns[1].Visible = false;
            dtlist.Columns[4].Visible = false;
            dtlist.Columns[6].Visible = false;
        }


        private void DrpList()
        {
            DataTable dt = db.GetDataTable("Select * From Firma");

            comboBox1.ValueMember = "FirmaId";
            comboBox1.DisplayMember = "FirmaAdi";
            comboBox1.DataSource = dt;
        }


       



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Toplam = 0;
            Listele();
            OdemeTutarList();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["OdemeId"].Value);
                var bakiye = dtlist.CurrentRow.Cells["AlinanOdeme"].Value;
                var firmaAdi = dtlist.CurrentRow.Cells["FirmaAdi"].Value;
                var tarih = dtlist.CurrentRow.Cells["Tarih"].Value;
                GelenOdemeler frm = new GelenOdemeler();
                frm.btnKaydet.Text = "Güncelle";
                frm.txtOdeme.Text = bakiye.ToString();
                frm.lblID.Text = db.Id.ToString();
                frm.dateTime.Text = tarih.ToString();
                frm.lblFirmaAdi.Text = firmaAdi.ToString();
                frm.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Bulunamadı"," Muhasebe Programı");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["OdemeId"].Value);

                DialogResult Cevap = MessageBox.Show("Seçtiğiniz Ödemeyi Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Cevap == DialogResult.Yes)
                {
                    db.execute("Delete From Odemeler Where OdemeId=" + db.Id);

                    MessageBox.Show("Ödeme silindi");
                    OdemeGuncelleme frm = new OdemeGuncelleme();
                    frm.Show();
                    this.Hide();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Bulunamadı", "Muhasebe Programı");
            }
        }
    }
}
