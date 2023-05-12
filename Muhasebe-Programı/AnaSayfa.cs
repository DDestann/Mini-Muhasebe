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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

       

       

        private void yeniFirmaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirmaKayit frm = new FirmaKayit();
            frm.Show();
        }

        private void firmaBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Firma frm = new Firma();
            frm.Show();
        }

        private void siparisListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Siparis frm = new Siparis();
            frm.Show();
        }

        private void yeniSiparisEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparisKayitDuzen frm = new SiparisKayitDuzen();
            frm.Show();

        }

        private void tedarikciFirmaBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TedarikciFirma frm = new TedarikciFirma();
            frm.Show();

        }

        private void yeniTedarikciFirmaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TedarikciFirmaKayit frm = new TedarikciFirmaKayit();
            frm.Show();
        }

        private void teslimEdilenSiparislerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeslimEdilen frm = new TeslimEdilen();
            frm.Show();
        }

        private void alınanÜrünleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSiparis frm = new TSiparis();
            frm.Show();
        }

        private void yeniÜrünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSiparisKayitDuzen frm = new TSiparisKayitDuzen();
            frm.Show();
        }

        private void ödenenFaturalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSiparisOdenen frm = new TSiparisOdenen();
            frm.Show();
        }

        private void ödemelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdemeListesi frm = new OdemeListesi();
            frm.Show();
        }

        private void ödemeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdemeGuncelleme frm = new OdemeGuncelleme();
            frm.Show();
        }

        private void giderlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giderler frm = new Giderler();
            frm.Show();
        }

        private void ödemelerListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TOdemeListesi frm = new TOdemeListesi();
            frm.Show();
        }

        private void ödemeGüncellemeSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TOdemeGuncelleme frm = new TOdemeGuncelleme();
            frm.Show();
        }

        private void genelCiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenelCiro frm = new GenelCiro();
            frm.Show();
        }

        private void ciroHesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiroHesap frm = new CiroHesap();
            frm.Show();
        }
    }
}
