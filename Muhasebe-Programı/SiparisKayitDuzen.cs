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
    public partial class SiparisKayitDuzen : Form
    {
         dbislem db = new dbislem();
        public SiparisKayitDuzen()
        {
            InitializeComponent();
        }

        private void SiparisKayitDuzen_Load(object sender, EventArgs e)
        {
            DropList();

            GelenVeri();

        }

        private void GelenVeri()
        {
            if (btnKaydet.Text=="Düzenle")
            {
                 DataRow dr = db.GetDataRow("SELECT  Firma.FirmaAdi, dbo.Siparis.* FROM  Firma INNER JOIN "+
                         " Siparis ON Firma.FirmaId = Siparis.FirmaId Where Siparis.SiparisId=" + txtId.Text);
            txtsiparisAdi.Text=dr["SiparisAdi"].ToString();
            txtAdet.Text = dr["Adet"].ToString();
            txtBirimFiyat.Text = dr["BirimFiyat"].ToString();
            txtTarih.Text = dr["Tarih"].ToString();
            drpFirma.Text = dr["FirmaAdi"].ToString();
            chkTeslimat.Checked = Convert.ToBoolean(dr["Teslimat"]);
            }
        }

        private void DropList()
        {
            DataTable dt = db.GetDataTable("Select * From Firma");
            drpFirma.ValueMember = "FirmaId";
            drpFirma.DisplayMember = "FirmaAdi";
            drpFirma.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text=="Kaydet")
            {
                try
                {
                    if (txtsiparisAdi.Text!="" && txtAdet.Text!="" && txtBirimFiyat.Text!="" && txtTarih.Text!="" && drpFirma.Text!="")
                    {
                        decimal Sonuc = 0;
                Sonuc = Convert.ToDecimal(txtAdet.Text) * Convert.ToDecimal(txtBirimFiyat.Text.Replace(".",","));

                        db.execute("insert into Siparis Values('"+drpFirma.SelectedValue+"','"+txtsiparisAdi.Text+"','"+txtAdet.Text+"','"+txtBirimFiyat.Text.ToString().Replace(",",".")+"','"+Sonuc.ToString().Replace(",",".")+"','"+txtTarih.Value.ToString("yyyy.MM.dd")+"','"+false+"','"+false+"','"+false+"'  )");
                        MessageBox.Show("Sipariş Eklendi", "Muhasebe Programı");
                    }
                    else
                    {
                        MessageBox.Show("Boş Alanları Dolurun", "Muhasebe Programı");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Bir Hata Oluştu");
                   
                }
                Siparis frm = new Siparis();
                frm.Show();
                this.Hide();
            }
            else if (btnKaydet.Text == "Düzenle")
            {
                try
                {
                    if (txtsiparisAdi.Text != "" && txtAdet.Text != "" && txtBirimFiyat.Text != "" && txtTarih.Text != "" && drpFirma.Text != "" && txtId.Text!="")
                    {

                        decimal Sonuc = 0;
                        Sonuc = Convert.ToDecimal(txtAdet.Text) * Convert.ToDecimal(txtBirimFiyat.Text.Replace(".", ","));
                        if (chkTeslimat.Checked)
                        {
                            db.execute("Update Siparis Set FirmaId='" + drpFirma.SelectedValue + "', SiparisAdi='" + txtsiparisAdi.Text + "', Adet='" + txtAdet.Text + "', BirimFiyat='" + txtBirimFiyat.Text.Replace(",", ".") + "', Tutar='" + Sonuc.ToString().Replace(",", ".") + "', Tarih='" + txtTarih.Value.ToString("yyyy.MM.dd") + "',Teslimat='" + true + "', Secim='" + false + "', PdfSecim='" + false + "' where SiparisId=" + txtId.Text);
                            MessageBox.Show("Sipariş Düzenlendi", "Muhasebe Programı");
                        }
                        else
                        {
                            db.execute("Update Siparis Set FirmaId='" + drpFirma.SelectedValue + "', SiparisAdi='" + txtsiparisAdi.Text + "', Adet='" + txtAdet.Text + "', BirimFiyat='" + txtBirimFiyat.Text.Replace(",", ".") + "', Tutar='" + Sonuc.ToString().Replace(",", ".") + "', Tarih='" + txtTarih.Value.ToString("yyyy.MM.dd") + "',Teslimat='" + false + "', Secim='" + false + "', PdfSecim='" + false + "' where SiparisId=" + txtId.Text);
                            MessageBox.Show("Sipariş Düzenlendi", "Muhasebe Programı");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Boş Alanları Dolurun", "Muhasebe Programı");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Bir Hata Oluştu");

                }
                Siparis frm = new Siparis();
                frm.Show();
                this.Hide();
            }
        }
    }
}
