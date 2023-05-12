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
    public partial class TSiparisOdenen : Form
    { 
        dbislem db = new dbislem();
        decimal Toplam = 0;
        public TSiparisOdenen()
        {
            InitializeComponent();
        }

        private void TSiparisOdenen_Load(object sender, EventArgs e)
        {
            Listele();
            Tutarlist();
        }

        private void Tutarlist()
        {
            DataTable dtTutar = db.GetDataTable("Select * From TSiparis Where Odendi='" + true + "'");

           
                for (int i = 0; i < dtTutar.Rows.Count; i++)
                {
                    Toplam += Convert.ToDecimal(dtTutar.Rows[i]["Tutar"].ToString());

                    lblToplamTutar.Text = " " + Toplam.ToString();
                }
           
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("SELECT Tedarikci.FirmaAdi, TSiparis.* FROM  Tedarikci INNER JOIN " +
                         " TSiparis ON Tedarikci.TedarikciId = TSiparis.TedarikciId Where Odendi='" + true + "'");
            dtlist.DataSource = dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
