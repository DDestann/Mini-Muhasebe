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
    public partial class TOdemeGuncelleme : Form
    {
        dbislem db = new dbislem();
        decimal Toplam = 0;
        public TOdemeGuncelleme()
        {
            InitializeComponent();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["TOdemeId"].Value);
                var bakiye = dtlist.CurrentRow.Cells["TOdenen"].Value;
                var firmaAdi = dtlist.CurrentRow.Cells["FirmaAdi"].Value;
                var tarih = dtlist.CurrentRow.Cells["Tarih"].Value;
                TOdenenOdemeler frm = new TOdenenOdemeler();
                frm.btnKaydet.Text = "Güncelle";
                frm.txtOdeme.Text = bakiye.ToString();
                frm.lblID.Text = db.Id.ToString();
                frm.txtTarih.Text = tarih.ToString();
                frm.lblFirmaAdi.Text = firmaAdi.ToString();
                frm.Show();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Bulunamadı", " Muhasebe Programı");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["TOdemeId"].Value);

                DialogResult Cevap = MessageBox.Show("Seçtiğiniz Ödemeyi Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Cevap == DialogResult.Yes)
                {
                    db.execute("Delete From TOdemeler Where TOdemeId=" + db.Id);

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

        private void TOdemeGuncelleme_Load(object sender, EventArgs e)
        {
            DrpList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Toplam = 0;
            Listele();
            OdemeTutarList();
        }
        private void Listele()
        {
            DataTable dt = db.GetDataTable("SELECT  TOdemeler.*, Tedarikci.* FROM   Tedarikci INNER JOIN " +
                       "  TOdemeler ON Tedarikci.TedarikciId = TOdemeler.TedarikciId where TOdemeler.TedarikciId=" + comboBox1.SelectedValue);

            dtlist.DataSource = dt;
            dtlist.Columns[1].Visible = false;
            dtlist.Columns[4].Visible = false;
            dtlist.Columns[6].Visible = false;
        }
        private void DrpList()
        {
            DataTable dt = db.GetDataTable("Select * From Tedarikci");

            comboBox1.ValueMember = "TedarikciId";
            comboBox1.DisplayMember = "FirmaAdi";
            comboBox1.DataSource = dt;
        }
        private void OdemeTutarList()
        {
            DataTable dt = db.GetDataTable("Select * From TOdemeler Where TedarikciId=" + comboBox1.SelectedValue);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["TOdenen"].ToString());
            }

            lblAlinanOdeme.Text = " Toplam = " + Toplam.ToString();

        }
    }
}
