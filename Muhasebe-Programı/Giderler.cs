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
    public partial class Giderler : Form
    {
        dbislem db = new dbislem();
        decimal Toplam = 0;
        public Giderler()
        {
            InitializeComponent();
        }

        private void Giderler_Load(object sender, EventArgs e)
        {
            Listele();
            
        }

       

        private void Listele()
        {
            Toplam = 0;

            DataTable dt =db.GetDataTable("Select * From Giderler ");
            dtlist.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dtlist.Rows[i].Cells["Tutar"].Value);
            }

            lblToplamGider.Text = "Toplam Gider = " + Toplam.ToString();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            GiderEkleGuncelle frm = new GiderEkleGuncelle();
            frm.Show();
            this.Hide();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Toplam = 0;

            DataTable dt = db.GetDataTable("Select * From Giderler Where Tarih BETWEEN                              '"+txtBaslangic.Value.ToString("yyyy.MM.dd")+ "' AND '" 
                + txtBitis.Value.ToString("yyyy.MM.dd") + "'    ");
            dtlist.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dtlist.Rows[i].Cells["Tutar"].Value);
            }

            lblToplamGider.Text = "Tarihe Göre Toplam Gider = " + Toplam.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["GiderId"].Value);
                var tutar = Convert.ToDecimal(dtlist.CurrentRow.Cells["Tutar"].Value);
                var GiderAdi = dtlist.CurrentRow.Cells["GiderAdi"].Value;
                var Tarih = dtlist.CurrentRow.Cells["Tarih"].Value;

                GiderEkleGuncelle frm = new GiderEkleGuncelle();
                frm.lblId.Text = db.Id.ToString();
                frm.dtlGiderTur.Text = GiderAdi.ToString();
                frm.txtTutar.Text = tutar.ToString();
                frm.txtTarih.Text = Tarih.ToString();
                frm.btnKaydet.Text = "Güncelle";
                frm.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Bulunamadı", "Muhasebe Programı");
            }
           
                
           


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["GiderId"].Value);

                DialogResult Cevap = MessageBox.Show("Seçtiğiniz Gideri Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Cevap == DialogResult.Yes)
                {
                    db.execute("Delete From Giderler Where GiderId=" + db.Id);

                    MessageBox.Show("Gider silindi");
                    Giderler frm = new Giderler();
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
