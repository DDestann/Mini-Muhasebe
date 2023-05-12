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
    public partial class TOdemeListesi : Form
    {

        dbislem db = new dbislem();
        decimal Toplam = 0, AlinanOdeme = 0;
        public string FirmaAdi = "";
        public TOdemeListesi()
        {
            InitializeComponent();
        }

        private void TOdemeListesi_Load(object sender, EventArgs e)
        {
            DrpList();
        }

        private void BtnOdeme_Click(object sender, EventArgs e)
        {
            TOdenenOdemeler frm = new TOdenenOdemeler();
            frm.lblID.Text = lblID.Text;
            frm.lblFirmaAdi.Text = FirmaAdi;
            frm.lblBakiye.Text = lblToplam.Text;
            frm.lblKalanBakiye.Text = lblKalan.Text;
            frm.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Toplam = 0;
            AlinanOdeme = 0;

            DataTable dt = db.GetDataTable("SELECT  Tedarikci.*, TSiparis.* FROM  Tedarikci INNER JOIN " +
                         " TSiparis ON Tedarikci.TedarikciId = TSiparis.TedarikciId Where Tedarikci.TedarikciId Like '%" + comboBox1.SelectedValue + "%'");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Toplam += Convert.ToDecimal(dt.Rows[i]["Tutar"].ToString());


            }

            lblToplam.Text = "Toplam Bakiye = " + Toplam.ToString();
            DataTable dtt = db.GetDataTable("SELECT  * From TOdemeler Where TedarikciId =" + comboBox1.SelectedValue);


            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                AlinanOdeme += Convert.ToDecimal(dtt.Rows[i]["TOdenen"].ToString());

            }
            lblKalan.Text = "Kalan Bakiye = " + (Toplam - AlinanOdeme).ToString();


            dtlist.DataSource = dt;

            dtlist.Columns[0].Visible = false;
            dtlist.Columns[2].Visible = false;
            dtlist.Columns[3].Visible = false;
            dtlist.Columns[4].Visible = false;
            //dtlist.Columns[11].Visible = false;
            dtlist.Columns[13].Visible = false;

            lblID.Text = comboBox1.SelectedValue.ToString();
            FirmaAdi = comboBox1.Text;
        }

        private void DrpList()
        {
            DataTable dt = db.GetDataTable("Select * From Tedarikci");

            comboBox1.ValueMember = "TedarikciId";
            comboBox1.DisplayMember = "FirmaAdi";


            comboBox1.DataSource = dt;
        }

    }
}
