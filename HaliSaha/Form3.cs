using HaliSaha.DAL;
using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaliSaha
{
    public partial class Form3 : Form
    {
        static Random r = new Random();
        public Form3()
        {
            InitializeComponent();
        }
        KullaniciGirisTablo kullanici;

        public Form3(KullaniciGirisTablo gelenKullanici)
        {
            kullanici = gelenKullanici;
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            KiralikSahaGöster();

            label8.Text = "Hoşgeldiniz Sn " + kullanici.KullaniciAdi;


            ComboBoxSemtDoldur(comboBox4);
            ComboBoxSemtDoldur(comboBox10);
            ComboBoxSemtDoldur(comboBox1);


            int id1 = Convert.ToInt32(comboBox4.SelectedValue);
            int id2 = Convert.ToInt32(comboBox10.SelectedValue);
            int id3 = Convert.ToInt32(comboBox1.SelectedValue);


            ComboBoxSahaDoldur(comboBox6, id1);
            ComboBoxSahaDoldur(comboBox8, id2);
            ComboBoxSahaDoldur(comboBox2, id3);


            ComboBoxMevkiDoldur(comboBox5);
            ComboBoxSaatDoldur(comboBox7);


            ComboBoxSaatDoldur(comboBox9);
            ComboBoxSaatDoldur(comboBox3);

            SecilenOyuncuListele();
            SecilenTakimListele();


        }
        public void ComboBoxSahaDoldur(ComboBox c, int id)
        {


            var list = HelperSaha.SahaListelee(id);
            c.ValueMember = "SahaID";
            c.DisplayMember = "SahaAdi";
            c.DataSource = list;


        }
        public void ComboBoxSemtDoldur(ComboBox c)
        {
            var list = HelperSemt.Listeleee();
            c.ValueMember = "SemtID";
            c.DisplayMember = "SemtAdi";
            c.DataSource = list;
        }
        public void ComboBoxMevkiDoldur(ComboBox c)
        {
            var list = HelperMevki.MevkiListelee();
            c.ValueMember = "MevkiID";
            c.DisplayMember = "Mevki";
            c.DataSource = list;
        }
        public void ComboBoxSaatDoldur(ComboBox c)
        {

            for (int i = 1; i <= 24; i++)
            {
                c.Items.Add(i);
            }


        }
        public void SecilenTakimListele()
        {
            listView2.Items.Clear();
            var liste = HelperTakimler.TakimListele(kullanici.KullaniciID);

            listView2.FullRowSelect = true;

            foreach (var item in liste)
            {
                string[] row = { item.TakımAdı, kullanici.KullaniciAdi, item.Telefon, item.SemtTablo.SemtAdi, item.MacSaati.ToString(), item.TakımID.ToString() };

                var newRow = new ListViewItem(row);
                listView2.Items.Add(newRow);

            }

        }
        public void SecilenOyuncuListele()
        {

            listView3.Items.Clear();
            var liste = HelperOyuncu.OyuncuListele(kullanici.KullaniciID);
            listView3.FullRowSelect = true;

            foreach (var item in liste)
            {

                string[] row = { item.OyuncuAdi, item.OyuncuSoyadi, item.MevkiTablo.Mevki, kullanici.KullaniciAdi, item.OyuncuTelefon, item.SahaTablo.SahaAdi, item.MacSaati.ToString(), item.OyuncuID.ToString() };

                var newRow = new ListViewItem(row);
                listView3.Items.Add(newRow);

            }




        }

        private void Button2_Click(object sender, EventArgs e)
        {


            if (comboBox4.SelectedIndex > -1 && comboBox6.SelectedIndex > -1 && comboBox7.SelectedIndex > -1)
            {
                List<int> idlerList = new List<int>();

                int sahaID = Convert.ToInt32(comboBox6.SelectedValue);
                int macSaati = Convert.ToInt32(comboBox7.SelectedIndex+1);

                if (macSaati>DateTime.Now.Hour)
                {
                    if (macSaati == 24)
                    {
                        macSaati = 0;
                    }

                    var kontrolList = HelperTakimler.TakimlariListele(macSaati, sahaID);
                    var takimListesi = HelperTakimler.TakimlariListele(sahaID);

                    if (kontrolList.Count > 0)
                    {

                        MessageBox.Show("Daha Önceden bu Saate Takım Kiraladınız..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (takimListesi.Count > 0)
                        {

                            foreach (var item in takimListesi)
                            {
                                idlerList.Add(item.TakımID);
                            }
                            int rastegeleid = r.Next(0, idlerList.Count);
                            int secilecekTakimID = idlerList[rastegeleid];

                            HelperTakimler.TakimDurumDüzenle(secilecekTakimID);
                            HelperTakimler.TakimDurumDüzenle(secilecekTakimID, macSaati, kullanici.KullaniciID);
                            SecilenTakimListele();
                            MessageBox.Show($"Takım Kiralandı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Bütün Takımlar Dolu Olduğundan Takım Seçilememektedir...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Şuanki Saatten Önce bir Saat Seçemessiziniz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz..");
            }

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dönenid1 = Convert.ToInt32(comboBox4.SelectedValue);

            ComboBoxSahaDoldur(comboBox6, dönenid1);
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dönenid1 = Convert.ToInt32(comboBox10.SelectedValue);

            ComboBoxSahaDoldur(comboBox8, dönenid1);
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int count = listView3.SelectedItems.Count;
            if (count > 0)
            {
                int id = 0;

                string a = listView3.SelectedItems[0].SubItems[7].Text;
                id = int.Parse(a);

                var oyuncu = HelperOyuncu.OyuncuIdAl(id);

                oyuncu.KullaniciID = null;
                oyuncu.Durum = true;
                oyuncu.MacSaati = null;
                oyuncu.Tarih = null;
                HelperOyuncu.OyuncuIslemleri(oyuncu, System.Data.Entity.EntityState.Modified);
                SecilenOyuncuListele();
                MessageBox.Show("Oyuncu İptal Edildi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                count--;
            }
            else
            {
                MessageBox.Show("Lütfen İptal Etmek İstediğiniz Oyuncuyu Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.SelectedValue);

            ComboBoxSahaDoldur(comboBox2, id);
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)

        {
            int count = listView2.SelectedItems.Count;

            if (count > 0)
            {
                string a = listView2.SelectedItems[0].SubItems[5].Text;
                int id = int.Parse(a);

                var takim = HelperTakimler.TakimIdAlma(id);
                takim.KullaniciID = null;
                takim.TakımDurum = true;
                takim.MacSaati = null;
                takim.Tarih = null;
                HelperTakimler.TakimIslemleri(takim, System.Data.Entity.EntityState.Modified);
                SecilenTakimListele();
                MessageBox.Show("Seçilen Takım İptal Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                count--;

            }
            else
            {
                MessageBox.Show("Lütfen Tablodan İptal Etmek İstediğiniz Takımı Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (comboBox5.SelectedIndex > -1 && comboBox10.SelectedIndex > -1 && comboBox8.SelectedIndex > -1 && comboBox9.SelectedIndex > -1)
            {
                List<int> idlerList = new List<int>();

                int mevkiID = Convert.ToInt32(comboBox5.SelectedValue);
                int sahaID = Convert.ToInt32(comboBox8.SelectedValue);
                int macSaati = Convert.ToInt32(comboBox9.SelectedIndex+1);

                if (macSaati>DateTime.Now.Hour)
                {
                    if (macSaati == 24)
                    {
                        macSaati = 0;
                    }
                    var oyuncuListesi = HelperOyuncu.OyuncuListele(sahaID, mevkiID);

                    var kontrolListesi = HelperOyuncu.OyuncuListeler(macSaati, sahaID);


                    if (kontrolListesi.Count > 2)
                    {

                        MessageBox.Show("Bu Saat,Tarih ve Sahaya Oyuncu Kiralama Limiti Dolmuştur...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (oyuncuListesi.Count > 0)
                        {

                            foreach (var item in oyuncuListesi)
                            {
                                idlerList.Add(item.OyuncuID);
                            }
                            int rastegeleID = r.Next(0, oyuncuListesi.Count);
                            int secilecekOyuncuID = idlerList[rastegeleID];

                            HelperOyuncu.OyuncuDurumDüzenle(secilecekOyuncuID, macSaati, kullanici.KullaniciID);
                            SecilenOyuncuListele();
                            MessageBox.Show($"Oyuncu Kiralandı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Bütün Oyuncular Dolu Olduğundan Oyuncu Kiralanamaz...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }

                }
                else
                {
                    MessageBox.Show("Şuanki Saatten önce bir Saat Seçemessiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz...");
            }





        }
        public void KiralikSahaGöster()
        {


            listView1.Items.Clear();

            //int semtID = Convert.ToInt32(comboBox1.SelectedValue);
            //int sahaID = Convert.ToInt32(comboBox2.SelectedValue);
            // int macSaati = Convert.ToInt32(comboBox3.SelectedIndex + 1);

            //if (macSaati == 24)
            //{
            //    macSaati = 0;
            //}

            var liste = HelperKiralanmisSaha.KiralanmisSahaListesi(kullanici.KullaniciID);
            listView1.FullRowSelect = true;


            foreach (var item in liste)
            {

                string[] row = { item.SahaTablo.SahaAdi, item.SahaTablo.Telefon, item.SahaTablo.Adres, item.SaatBaslangic.ToString(), item.KSID.ToString(), kullanici.KullaniciAdi };

                var newRow = new ListViewItem(row);
                listView1.Items.Add(newRow);

            }

        }
        private void Button4_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 && comboBox3.SelectedIndex > -1)
            {
                int semtID = Convert.ToInt32(comboBox1.SelectedValue);
                int sahaID = Convert.ToInt32(comboBox2.SelectedValue);
                int macSaati = Convert.ToInt32(comboBox3.SelectedIndex + 1);

                if (macSaati > DateTime.Now.Hour)
                {
                    if (macSaati == 24)
                    {
                        macSaati = 0;
                    }

                    var saha = HelperKiralanmisSaha.KiralanmisSaha(semtID, sahaID, macSaati);

                    if (saha != null)
                    {

                        saha.KullaniciID = kullanici.KullaniciID;
                        saha.SemtID = semtID;
                        saha.SahaID = sahaID;
                        saha.SaatBaslangic = macSaati;


                        HelperKiralanmisSaha.KiralanmisSahaIslemleri(saha, System.Data.Entity.EntityState.Modified);
                        KiralikSahaGöster();
                        MessageBox.Show("Sahayı Kiraladınız...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Aradığınız Saha Daha Önceden Kiralanmıştır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Şuanki Satten önce bir Saat Seçemessin","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz..");
            }






        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;

            if (count > 0)
            {
                var a = listView1.SelectedItems[0].SubItems[4].Text;
                int id = int.Parse(a);

                var kiralikSaha = HelperKiralanmisSaha.KiralikSahaIdAl(id);

                kiralikSaha.KullaniciID = null;

                HelperKiralanmisSaha.KiralanmisSahaIslemleri(kiralikSaha, System.Data.Entity.EntityState.Modified);
                KiralikSahaGöster();
                MessageBox.Show("Seçilen Saha İptal Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lütfen Tablodan İptal Etmek İstediğiniz Sahayı Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
