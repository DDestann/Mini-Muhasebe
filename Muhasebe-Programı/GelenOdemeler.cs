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
    public partial class GelenOdemeler : Form
    {
        dbislem db = new dbislem();
        public GelenOdemeler()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOdeme.Text.Trim()!="" && txtOdeme.Text.Trim()!=null)
                {
                    if (btnKaydet.Text == "Kaydet")
                    {
                        db.execute("insert into Odemeler Values('" + lblID.Text + "','" + txtOdeme.Text.Trim().Replace(",", ".") + "','" + dateTime.Value.ToString("yyyy.MM.dd") + "')");
                        MessageBox.Show("Ödeme Eklendi", "Muhasebe Programı");
                        OdemeListesi frm = new OdemeListesi();
                        frm.Show();
                        this.Hide();

                    }
                    else if (btnKaydet.Text == "Güncelle")
                    {
                        db.execute("Update Odemeler Set AlinanOdeme='" + txtOdeme.Text.Trim().Replace(",", ".") + "', Tarih='" + dateTime.Value.ToString("yyyy.MM.dd") + "' Where OdemeId=" + lblID.Text);
                        MessageBox.Show("Ödeme Güncellendi", "Muhasebe Programı");

                        OdemeGuncelleme frm = new OdemeGuncelleme();
                        frm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Ödeme Alanı Boş Bırakılamaz");
                }
            }
            catch (Exception msj)
            {

                MessageBox.Show(msj.Message,"Muhasebe Programı");
            }
        }
    }
}
