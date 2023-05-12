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
    public partial class GiderEkleGuncelle : Form
    {
        dbislem db = new dbislem();
        public GiderEkleGuncelle()
        {
            InitializeComponent();
        }
        private void GiderEkleGuncelle_Load(object sender, EventArgs e)
        {

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnKaydet.Text == "Kaydet")
                {
                    if (dtlGiderTur.Text != "Gider Türü Seçin")
                    {
                        if (txtTutar.Text.Trim()!=null && txtTutar.Text.Trim()!="")
                        {
                            db.execute("insert into Giderler Values('"+dtlGiderTur.Text+ "','"+ txtTutar.Text.Trim().Replace(",",".")+ "','"+txtTarih.Value.ToString("yyyy.MM.dd")+"')");

                            MessageBox.Show("Kayıt Yapıldı");
                            Giderler frm = new Giderler();
                            frm.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Tutar Alanı Boş Bırakılamaz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gider Türü Seçin");
                    }
                }
                else if (btnKaydet.Text == "Güncelle")
                {
                    if (dtlGiderTur.Text != "Gider Türü Seçin")
                    {
                        if (txtTutar.Text.Trim() != null && txtTutar.Text.Trim() != "")
                        {
                            db.execute("Update Giderler Set GiderAdi='"+dtlGiderTur.Text+ "', Tutar='"+txtTutar.Text.Trim().Replace(",",".")+ "', Tarih='"+txtTarih.Value.ToString("yyyy.MM.dd")+"' Where GiderId=" + lblId.Text);

                            MessageBox.Show("Güncelleme Yapıldı");
                            Giderler frm = new Giderler();
                            frm.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Tutar Alanı Boş Bırakılamaz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gider Türü Seçin");
                    }
                }
            }
            catch (Exception msj)
            {

                MessageBox.Show(msj.Message,"Muhasebe Programı");
            }
        }

       
    }
}
