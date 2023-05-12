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
    public partial class CiroHesap : Form
    {
        dbislem db = new dbislem();
        decimal Toplam = 0, AlinanOdeme = 0, Odenen = 0;
        public CiroHesap()
        {
            InitializeComponent();
        }

        private void CiroHesap_Load(object sender, EventArgs e)
        {
          
        }

        private void GenelToplam()
        {
            Toplam = 0;
            AlinanOdeme = 0;
            Odenen = 0;
            DataTable dt = db.GetDataTable("Select * From Giderler Where Tarih BETWEEN '"+txtBaslangic.Value.ToString("yyyy.MM.dd")+"' AND '"+txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["Tutar"]);
            }



            DataTable dtt = db.GetDataTable("Select * From Odemeler  Where Tarih BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                AlinanOdeme += Convert.ToDecimal(dtt.Rows[i]["AlinanOdeme"]);
            }

            DataTable dttt = db.GetDataTable("Select * From TOdemeler  Where Tarih BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dttt.Rows.Count; i++)
            {
                Odenen += Convert.ToDecimal(dttt.Rows[i]["TOdenen"]);
            }

            lblToplamCiro.Text = "Genel Ciro Toplamı = " + (AlinanOdeme - (Toplam + Odenen)).ToString();


        }

        private void GiderList()
        {
            Toplam = 0;

            DataTable dt = db.GetDataTable("Select * From Giderler  Where Tarih BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["Tutar"]);
            }
            lblGiderTutar.Text = "Genel Toplam Gider Tutarı = " + Toplam.ToString();
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            TSiparisList();
            SiparisList();
            GiderList();


            GenelToplam();
        }

        private void SiparisList()
        {
            Toplam = 0;
            AlinanOdeme = 0;

            DataTable dt = db.GetDataTable("Select * From Siparis  Where Tarih BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["Tutar"]);
            }

            lblSiparisTutar.Text = "Genel Toplam Siparis Tutarı = " + Toplam.ToString();

            DataTable dtt = db.GetDataTable("Select * From Odemeler  Where Tarih BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                AlinanOdeme += Convert.ToDecimal(dtt.Rows[i]["AlinanOdeme"]);
            }

            lblAlinanTutar.Text = "Genel Toplam Alınan Tutar = " + AlinanOdeme.ToString();

            lblKalanTutar.Text = "Genel Toplam Kalan Tutar = " + (Toplam - AlinanOdeme).ToString();


        }

        private void TSiparisList()
        {
            Toplam = 0;

            AlinanOdeme = 0;

            DataTable dt = db.GetDataTable("Select * From TSiparis  Where FaturaTarihi BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["Tutar"]);
            }

            lblTsiparisTutar.Text = "Genel Toplam Tedarikçi Sipariş Tutarı = " + Toplam.ToString();

            DataTable dtt = db.GetDataTable("Select * From TOdemeler  Where Tarih BETWEEN '" + txtBaslangic.Value.ToString("yyyy.MM.dd") + "' AND '" + txtBitis.Value.ToString("yyyy.MM.dd") + "' ");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                AlinanOdeme += Convert.ToDecimal(dtt.Rows[i]["TOdenen"]);
            }

            lblTOdenenTutar.Text = "Genel Toplam Tedarikçi Ödenen Tutar = " + AlinanOdeme.ToString();

            lblTKalanTutar.Text = "Genel Toplam Kalan Ödeme Tutar = " + (Toplam - AlinanOdeme).ToString();


        }



    }
}
