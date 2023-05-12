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
    public partial class TSiparisKayitDuzen : Form
    {
         dbislem db = new dbislem();
        public TSiparisKayitDuzen()
        {
            InitializeComponent();
        }
        private void TSiparisKayitDuzen_Load(object sender, EventArgs e)
        {
            drpTedarikciFirmaList();

            GelenVeriList();
        }

        private void GelenVeriList()
        {
            if (BtnKaydet.Text == "Düzenle")
            {
                DataRow dr = db.GetDataRow("SELECT Tedarikci.FirmaAdi, TSiparis.* FROM  Tedarikci INNER JOIN " +
                        " TSiparis ON Tedarikci.TedarikciId = TSiparis.TedarikciId Where TSiparis.TSiparisId=" + lblId.Text);
                txtFaturaNo.Text=dr["FaturaNo"].ToString();
                txtSiparisAdi.Text = dr["SiparisAdi"].ToString();
                txtAdet.Text = dr["Adet"].ToString();
                txtBirimFiyat.Text = dr["BirimFiyat"].ToString();
                txtTutar.Text=dr["Tutar"].ToString();
                txtFaturaTarihi.Text =dr["FaturaTarihi"].ToString();
                drpList.Text = dr["FirmaAdi"].ToString();
                txtOdenmeTarihi.Text = dr["OdenmeTarihi"].ToString();
                chkOdendi.Checked = Convert.ToBoolean(dr["Odendi"]);
            }
        }

        private void drpTedarikciFirmaList()
        {
            DataTable dt = db.GetDataTable("Select * From Tedarikci");
            drpList.ValueMember = "TedarikciId";
            drpList.DisplayMember = "FirmaAdi";
            drpList.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKaydet.Text=="Kaydet")
            {
                try
                {
                    if (drpList.Text!="" && txtFaturaNo.Text!="" && txtSiparisAdi.Text!="" && txtAdet.Text!="" && txtBirimFiyat.Text!="" && txtTutar.Text!="")
                    {
                        db.execute("insert into TSiparis(TedarikciId,FaturaNo,SiparisAdi,Adet,BirimFiyat,Tutar,FaturaTarihi,Odendi,Secim) Values('" + drpList.SelectedValue + "','" + txtFaturaNo.Text + "','" + txtSiparisAdi.Text + "','" + txtAdet.Text + "','" + txtBirimFiyat.Text.Replace(",", ".") + "','" + txtTutar.Text.Replace(",", ".") + "','" +txtFaturaTarihi.Value.ToString("yyyy.MM.dd") + "','" + false + "','" + false + "')");

                        MessageBox.Show("Fatura Kaydı Yapıldı", "Muhasebe Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Boş Alanları Doldurun","Muhasebe Programı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception msj)
                {

                    MessageBox.Show(msj.Message, "Beklenmedik Bir Hata Oluştu...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                TSiparis frm = new TSiparis();
                frm.Show();
                this.Hide();
            }
            else if (BtnKaydet.Text=="Düzenle")
            {
                try
                {
                    if (drpList.Text != "" && txtFaturaNo.Text != "" && txtSiparisAdi.Text != "" && txtAdet.Text != "" && txtBirimFiyat.Text != "" && txtTutar.Text != "" && lblId.Text!="")
                    {
                        if (chkOdendi.Checked==true)
                        {
                            db.execute("Update TSiparis set  TedarikciId='" + drpList.SelectedValue + "' , FaturaNo='" + txtFaturaNo.Text + "' , SiparisAdi='" + txtSiparisAdi.Text + "' , Adet='" + txtAdet.Text + "' , BirimFiyat='" + txtBirimFiyat.Text.Replace(",", ".") + "' , Tutar='" + txtTutar.Text.Replace(",", ".") + "' , OdenmeTarihi='" + txtOdenmeTarihi.Value.ToString("yyyy.MM.dd") + "' , Odendi='" + true + "', Secim='" + false + "'   Where TSiparisId='" + lblId.Text + "'");
                            MessageBox.Show("Fatura Bilgisi Düzenlendi", "Muhasebe Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            db.execute("Update TSiparis set  TedarikciId='" + drpList.SelectedValue + "' , FaturaNo='" + txtFaturaNo.Text + "' , SiparisAdi='" + txtSiparisAdi.Text + "' , Adet='" + txtAdet.Text + "' , BirimFiyat='" + txtBirimFiyat.Text.Replace(",", ".") + "' , Tutar='" + txtTutar.Text.Replace(",", ".") + "', FaturaTarihi='" + txtOdenmeTarihi.Value.ToString("yyyy.MM.dd") + "' , Odendi='" + false + "' , Secim='" + false + "'  Where TSiparisId='" + lblId.Text + "'");
                            MessageBox.Show("Fatura Bilgisi Düzenlendi", "Muhasebe Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Boş Alanları Doldurun", "Muhasebe Programı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception msj)
                {

                    MessageBox.Show(msj.Message, "Beklenmedik Bir Hata Oluştu...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                TSiparis frm = new TSiparis();
                frm.Show();
                this.Hide();
            }
        }

       
    }
}
