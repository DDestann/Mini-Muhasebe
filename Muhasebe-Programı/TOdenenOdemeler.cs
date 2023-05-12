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
    public partial class TOdenenOdemeler : Form
    {
        dbislem db = new dbislem();
        public TOdenenOdemeler()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOdeme.Text.Trim() != "" && txtOdeme.Text.Trim() != null)
                {
                    if (btnKaydet.Text == "Kaydet")
                    {
                        db.execute("insert into TOdemeler Values('" + lblID.Text + "','" + txtOdeme.Text.Trim().Replace(",", ".") + "','" + txtTarih.Value.ToString("yyyy.MM.dd") + "')");
                        MessageBox.Show("Ödeme Eklendi", "Muhasebe Programı");
                        TOdemeListesi frm = new TOdemeListesi();
                        frm.Show();
                        this.Hide();

                    }
                    else if (btnKaydet.Text == "Güncelle")
                    {
                        db.execute("Update TOdemeler Set TOdenen='" + txtOdeme.Text.Trim().Replace(",", ".") + "', Tarih='" + txtTarih.Value.ToString("yyyy.MM.dd") + "' Where TOdemeId=" + lblID.Text);
                        MessageBox.Show("Ödeme Güncellendi", "Muhasebe Programı");

                        TOdemeGuncelleme frm = new TOdemeGuncelleme();
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

                MessageBox.Show(msj.Message, "Muhasebe Programı");
            }
        }
    }
}
