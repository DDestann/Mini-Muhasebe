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
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Muhasebe_Programı
{
    public partial class Siparis : Form
    {
        dbislem db = new dbislem();
        decimal Toplamm = 0;
        public Siparis()
        {
            InitializeComponent();
            
        }

        private void Siparis_Load(object sender, EventArgs e)
        {
                Listele();

            Tutarlist();

            

        }

        private void Tutarlist()
        {
            DataTable dtTutar = db.GetDataTable("Select * From Siparis Where Teslimat='" + false + "'");

            for (int i = 0; i < dtTutar.Rows.Count; i++)
            {
                Toplamm += Convert.ToDecimal(dtTutar.Rows[i]["Tutar"].ToString());

                lblToplamTutar.Text = " " + Toplamm.ToString();
            }
        }

        private void Listele()
        {
            DataTable dt = db.GetDataTable("SELECT Firma.FirmaAdi, Siparis.* FROM Firma INNER JOIN Siparis ON Firma.FirmaId = Siparis.FirmaId Where Teslimat='" + false + "'");
            dtlist.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["FirmaId"].Value);
            SiparisKayitDuzen frm = new SiparisKayitDuzen();

            frm.btnKaydet.Text = "Kaydet";
            // frm.txtId.Text = db.Id.ToString();

            frm.Show();

            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.Id = Convert.ToInt32(dtlist.CurrentRow.Cells["SiparisId"].Value);
                SiparisKayitDuzen frm = new SiparisKayitDuzen();

                frm.btnKaydet.Text = "Düzenle";
                frm.txtId.Text = db.Id.ToString();
                frm.chkTeslimat.Visible = true;
                frm.Show();

                this.Hide();
            }
            catch (Exception msj)
            {
                MessageBox.Show(msj.Message, "Muhasebe Programı");

            }
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetDataTable("SELECT Firma.FirmaAdi, Siparis.* FROM Firma INNER JOIN Siparis ON Firma.FirmaId = Siparis.FirmaId Where Firma.FirmaAdi Like '%" + txtara.Text + "%' and Teslimat='" + false + "'");
            dtlist.DataSource = dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
            DialogResult Cevap = MessageBox.Show("Siparişi Silmek istediğinizden Eminmisiniz?", "Muhasebe Programı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Cevap == DialogResult.Yes)
            {

              
               
                try
                {
                    if (Convert.ToBoolean(dtlist.SelectedCells[9].Value)==true)
                    {
                        for (int i = 0; i < dtlist.Rows.Count; i++)
                        {
                           
                            if (Convert.ToBoolean(dtlist.Rows[i].Cells["Secim"].Value) == true)
                            {
                                string FirmaAdi = dtlist.Rows[i].Cells["FirmaAdi"].Value.ToString();
                                int ID = Convert.ToInt32(dtlist.Rows[i].Cells["SiparisId"].Value);

                                db.execute("Delete From Siparis Where SiparisId=" + ID);
                                MessageBox.Show(FirmaAdi + " Siparis Silindi", "Muhasebe Programı");

                            }
                            

                        }
                        Siparis frm = new Siparis();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Silmek istediğiniz Siparisi Seçim Kutusundan işaretleyiniz.");
                        
                    }
                    
                  


                }
                catch (Exception msj)
                {
                    MessageBox.Show(msj.Message, "Hata Oluştu");

                }

            }
            Listele();
            Tutarlist();
       
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            string FirmaAdi = "";
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "PDF DOSYALARI(*.pdf)|*.pdf";
            file.Title = "PDF DOSYA OLUŞTURMA";
            iTextSharp.text.Document document = new iTextSharp.text.Document();

            if (file.ShowDialog() == DialogResult.OK)
            {

                PdfPTable table = new PdfPTable(2);
                FileStream Dosya = File.Open(file.FileName, FileMode.Create);
                PdfWriter.GetInstance(document, Dosya);
                PdfPCell cell = new PdfPCell();
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "CP1254", true);
                iTextSharp.text.Font fontcell = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontheader = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                table.HeaderRows = 1;
                PdfPTable header = table;

                header.HorizontalAlignment = 1;
                header.AddCell(new PdfPCell(new Phrase("Başlık1", fontheader)));
                header.AddCell(new PdfPCell(new Phrase("Başlık2", fontheader)));
                document.Open();





                try
                {
                    for (int i = 0; i < dtlist.Rows.Count; i++)
                    {

                        if (Convert.ToBoolean(dtlist.Rows[i].Cells["PdfSecim"].Value) == true)
                        {
                            FirmaAdi = dtlist.Rows[i].Cells["FirmaAdi"].Value.ToString();
                            int ID = Convert.ToInt32(dtlist.Rows[i].Cells["SiparisId"].Value);


                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 1; //0=Sola, 1=Orta, 2=sağ

                            table.AddCell(new PdfPCell(new Phrase(ID.ToString(), fontcell)));
                            table.AddCell(new PdfPCell(new Phrase(FirmaAdi, fontcell)));





                        }


                    }

                    document.Add(table);
                    document.Close();
                }
                catch (Exception msj)
                {

                    MessageBox.Show(msj.Message);
                }

            }
        }
    }
}
