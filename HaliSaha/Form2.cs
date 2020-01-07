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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        KullaniciGirisTablo admin;
        int a = 0, b = 0;


        public Form2(KullaniciGirisTablo gelenAdmin)
        {
            admin = gelenAdmin;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label11.Text = DateTime.Now.ToString("HH:mm");

            // button2.Enabled = false;
            // button6.Enabled = false;
            //  button9.Enabled = false;
            //  button3.Enabled = false;
            // button7.Enabled = false;
            //  button10.Enabled = false;


            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            comboBox4.Enabled = false;
            comboBox6.Enabled = false;
            button8.Enabled = false;

            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            comboBox10.Enabled = false;
            button12.Enabled = false;



            label17.Text = "Hoşgeldiniz Sn" + admin.KullaniciAdi;

            TakimlariListele();
            OyunculariListele();
            SahalarıListele();

            ComboBoxSemtDoldur(comboBox1);
            ComboBoxSemtDoldur(comboBox2);

            ComboBoxSemtDoldur(comboBox9);
            ComboBoxSemtDoldur(comboBox10);


            int cmb1id = Convert.ToInt32(comboBox1.SelectedValue);
            int cmb2id = Convert.ToInt32(comboBox2.SelectedValue);

            ComboBoxSahaDoldur(comboBox7, cmb1id);
            ComboBoxSahaDoldur(comboBox8, cmb2id);


            ComboBoxSahaDoldur(comboBox5);
            ComboBoxSahaDoldur(comboBox6);




            ComboBoxMevkiDoldur(comboBox3);
            ComboBoxMevkiDoldur(comboBox4);





            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox2.Enabled = false;
            comboBox8.Enabled = false;
            button4.Enabled = false;


        }

        public void Sifirla()
        {
            var oyuncuList = HelperOyuncu.GenelOyuncuListele();
            var takimList = HelperTakimler.GenelTakımList();
            var kiralikSahaList = HelperKiralanmisSaha.BütünSahalarinListesi();
            foreach (var oyuncu in oyuncuList)
            {
                var öncekiDurum = oyuncu.OyuncuSilmedurum;
                oyuncu.KullaniciID = null;
                oyuncu.Durum = true;
                oyuncu.MacSaati = null;
                oyuncu.Tarih = null;
                oyuncu.OyuncuSilmedurum = öncekiDurum;
                HelperOyuncu.OyuncuIslemleri(oyuncu, System.Data.Entity.EntityState.Modified);

            }

            foreach (var takim in takimList)
            {
                var öncekiDurum = takim.TakımSilmedurum;
                takim.KullaniciID = null;
                takim.TakımDurum = true;
                takim.MacSaati = null;
                takim.Tarih = null;
                takim.TakımSilmedurum = öncekiDurum;
                HelperTakimler.TakimIslemleri(takim, System.Data.Entity.EntityState.Modified);
            }

            foreach (var item in kiralikSahaList)
            {
                item.KullaniciID = null;
                HelperKiralanmisSaha.KiralanmisSahaIslemleri(item, System.Data.Entity.EntityState.Modified);
            }

            MessageBox.Show("Takım ve Oyuncular Sıfırlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void TakimlariListele()
        {
            listViewTakim.Items.Clear();
            var liste = HelperTakimler.TakimlariListele();
            listViewTakim.FullRowSelect = true;

            foreach (var item in liste)
            {
                string[] row = { item.TakımAdı, item.Telefon, item.SemtTablo.SemtAdi, item.SahaTablo.SahaAdi, item.TakımID.ToString() };

                var newRow = new ListViewItem(row);
                listViewTakim.Items.Add(newRow);

            }
        }

        public void OyunculariListele()
        {
            listView2.Items.Clear();
            var liste = HelperOyuncu.OyuncuListele();
            listView2.FullRowSelect = true;

            foreach (var item in liste)
            {
                string[] row = { item.OyuncuAdi, item.OyuncuSoyadi, item.OyuncuTelefon, item.MevkiTablo.Mevki, item.SahaTablo.SahaAdi, item.OyuncuID.ToString() };

                var newRow = new ListViewItem(row);
                listView2.Items.Add(newRow);

            }


        }

        public void SahalarıListele()
        {
            listViewSaha.Items.Clear();
            var liste = HelperSaha.SahaModelList();

            listViewSaha.FullRowSelect = true;

            foreach (var item in liste)
            {
                string[] row = { item.SahaAdi, item.SemtTablo.SemtAdi, item.Telefon, item.Adres, item.SahaID.ToString() };

                var newRow = new ListViewItem(row);
                listViewSaha.Items.Add(newRow);

            }


        }

        public void ComboBoxSahaDoldur(ComboBox c, int id)
        {
            var list = HelperSaha.SahaListelee(id);
            c.ValueMember = "SahaID";
            c.DisplayMember = "SahaAdi";
            c.DataSource = list;

        }

        public void ComboBoxSahaDoldur(ComboBox c)
        {

            var list = HelperSaha.SahaListelee();
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

        public void ComboBoxlarıSifirla(ComboBox c)
        {
            c.Items.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()) && comboBox1.SelectedIndex > -1 && comboBox9.SelectedIndex > -1)
            {

                TakımTablo takim = new TakımTablo();
                takim.TakımAdı = textBox1.Text.Trim();
                takim.Telefon = textBox2.Text.Trim();
                takim.SemtID = Convert.ToInt32(comboBox1.SelectedValue);
                takim.SahaID = Convert.ToInt32(comboBox7.SelectedValue);
                takim.TakımSilmedurum = true;
                takim.TakımDurum = true;

                HelperTakimler.TakimIslemleri(takim, System.Data.Entity.EntityState.Added);
                TakimlariListele();
                MessageBox.Show("Takım Başarıyla Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz...");
            }


        }

        private void comboBox7_Click(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = listViewTakim.SelectedItems.Count;
            if (count > 0)
            {
                textBox3.Text = listViewTakim.SelectedItems[0].SubItems[0].Text;
                textBox4.Text = listViewTakim.SelectedItems[0].SubItems[1].Text;
                comboBox2.Text = listViewTakim.SelectedItems[0].SubItems[2].Text;
                comboBox8.Text = listViewTakim.SelectedItems[0].SubItems[3].Text;

                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox2.Enabled = true;
                comboBox8.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen Tablodan İşlem Yapmak İstediğiniz Takımı Seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(textBox3.Text.Trim()) && !string.IsNullOrEmpty(textBox4.Text.Trim()) && comboBox2.SelectedIndex > -1 && comboBox8.SelectedIndex > -1)
            {
                var a = listViewTakim.SelectedItems[0].SubItems[4].Text;
                int id = int.Parse(a);

                var takim = HelperTakimler.TakimIdAlma(id);

                takim.TakımAdı = textBox3.Text.Trim();
                takim.Telefon = textBox4.Text.Trim();
                takim.SemtID = Convert.ToInt32(comboBox2.SelectedValue);
                takim.SahaID = Convert.ToInt32(comboBox8.SelectedValue);

                HelperTakimler.TakimIslemleri(takim, System.Data.Entity.EntityState.Modified);
                TakimlariListele();
                MessageBox.Show("Değişiklikler Kaydedildi..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = listViewTakim.SelectedItems.Count;
            if (count > 0)
            {
                var a = listViewTakim.SelectedItems[0].SubItems[4].Text;
                int id = int.Parse(a);

                var takim = HelperTakimler.TakimIdAlma(id);

                takim.TakımSilmedurum = false;
                HelperTakimler.TakimIslemleri(takim, System.Data.Entity.EntityState.Modified);
                TakimlariListele();
                MessageBox.Show("Takım Başarıyla Silindi..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lütfen Tablodan Silmek İstediğiniz Takımı Seçin!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_Click(object sender, EventArgs e)
        {


        }

        private void Button5_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox5.Text.Trim()) && !string.IsNullOrEmpty(textBox6.Text.Trim()) && !string.IsNullOrEmpty(textBox7.Text.Trim()) && comboBox3.SelectedIndex > -1 && comboBox5.SelectedIndex > -1)
            {
                OyuncuTablo oyuncu = new OyuncuTablo();
                oyuncu.OyuncuAdi = textBox5.Text.Trim();
                oyuncu.OyuncuSoyadi = textBox6.Text.Trim();
                oyuncu.OyuncuTelefon = textBox7.Text.Trim();
                oyuncu.Durum = true;
                oyuncu.OyuncuSilmedurum = true;
                oyuncu.MevkiID = Convert.ToInt32(comboBox3.SelectedValue);
                oyuncu.SahaID = Convert.ToInt32(comboBox5.SelectedValue);

                HelperOyuncu.OyuncuIslemleri(oyuncu, System.Data.Entity.EntityState.Added);
                OyunculariListele();
                MessageBox.Show("Oyuncu Başarıyla Eklendi...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurun");
            }


        }

        private void ComboBox5_Click(object sender, EventArgs e)
        {
            //ComboBoxlarıSifirla(comboBox5);
            //ComboBoxlarıDoldur(comboBox5, sahaList);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int count = listView2.SelectedItems.Count;

            if (count > 0)
            {
                textBox8.Text = listView2.SelectedItems[0].SubItems[0].Text;
                textBox9.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox10.Text = listView2.SelectedItems[0].SubItems[2].Text;
                comboBox4.Text = listView2.SelectedItems[0].SubItems[3].Text;
                comboBox6.Text = listView2.SelectedItems[0].SubItems[4].Text;

                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                comboBox4.Enabled = true;
                comboBox6.Enabled = true;
                button8.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen Tablodan İşlem Düzenlemek İstediğiniz Oyuncuyu Seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void ComboBox6_Click(object sender, EventArgs e)
        {
            //ComboBoxlarıSifirla(comboBox6);
            //ComboBoxlarıDoldur(comboBox6, sahaList);
        }

        private void ComboBox4_Click(object sender, EventArgs e)
        {
            //ComboBoxlarıSifirla(comboBox4);
            //ComboBoxlarıDoldur(comboBox4, mevkiList);
        }

        private void Button8_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox8.Text.Trim()) && !string.IsNullOrEmpty(textBox9.Text.Trim()) && !string.IsNullOrEmpty(textBox10.Text.Trim()) && comboBox4.SelectedIndex > -1 && comboBox6.SelectedIndex > -1)
            {
                var a = listView2.SelectedItems[0].SubItems[5].Text;
                int id = int.Parse(a);
                var oyuncu = HelperOyuncu.OyuncuIdAl(id);

                oyuncu.OyuncuAdi = textBox8.Text.Trim();
                oyuncu.OyuncuSoyadi = textBox9.Text.Trim();
                oyuncu.OyuncuTelefon = textBox10.Text.Trim();
                oyuncu.MevkiID = Convert.ToInt32(comboBox4.SelectedValue);
                oyuncu.SahaID = Convert.ToInt32(comboBox6.SelectedValue);

                HelperOyuncu.OyuncuIslemleri(oyuncu, System.Data.Entity.EntityState.Modified);
                OyunculariListele();
                MessageBox.Show("Değişiklikler Kaydedildi...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox4.Enabled = false;
                comboBox6.Enabled = false;
                button8.Enabled = false;


            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz");
            }




        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int count = listView2.SelectedItems.Count;
            if (count > 0)
            {
                var a = listView2.SelectedItems[0].SubItems[4].Text;
                int id = int.Parse(a);

                var oyuncu = HelperOyuncu.OyuncuIdAl(id);
                oyuncu.OyuncuSilmedurum = false;
                HelperOyuncu.OyuncuIslemleri(oyuncu, System.Data.Entity.EntityState.Modified);
                OyunculariListele();
                MessageBox.Show(" Oyuncu Silindi...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            else
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Oyuncuyu Tablodan Seçiniz!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Button11_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox11.Text.Trim()) && !string.IsNullOrEmpty(textBox12.Text.Trim()) && !string.IsNullOrEmpty(textBox13.Text.Trim()) && comboBox9.SelectedIndex > -1)
            {
                SahaTablo saha = new SahaTablo();
                saha.SahaAdi = textBox11.Text.Trim();
                saha.SemtID = Convert.ToInt32(comboBox9.SelectedValue);
                saha.Telefon = textBox12.Text.Trim();
                saha.Adres = textBox13.Text.Trim();
                saha.SahaSilmeDurum = true;
                HelperSaha.SahaIslemleri(saha, System.Data.Entity.EntityState.Added);


                for (int i = 0; i < 24; i++)
                {
                    KiralanmışSahaTablo ks = new KiralanmışSahaTablo();
                    ks.KullaniciID = null;
                    ks.SahaID = saha.SahaID;
                    ks.SemtID = Convert.ToInt32(comboBox9.SelectedValue);
                    ks.SaatBaslangic = i;
                    HelperKiralanmisSaha.KiralanmisSahaIslemleri(ks, System.Data.Entity.EntityState.Added);

                }
                SahalarıListele();
                ComboBoxSahaDoldur(comboBox5);
                ComboBoxSahaDoldur(comboBox6);
                MessageBox.Show("Saha Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz...");
            }

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            int count = listViewSaha.SelectedItems.Count;
            if (count > 0)
            {
                textBox14.Text = listViewSaha.SelectedItems[0].SubItems[0].Text;
                comboBox10.Text = listViewSaha.SelectedItems[0].SubItems[1].Text;
                textBox15.Text = listViewSaha.SelectedItems[0].SubItems[2].Text;
                textBox16.Text = listViewSaha.SelectedItems[0].SubItems[3].Text;

                textBox14.Enabled = true;
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                comboBox10.Enabled = true;
                button12.Enabled = true;


            }
            else
            {
                MessageBox.Show("Lütfen Düzenlemek İstediğiniz Sahayı Tablodan Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void Button12_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox14.Text.Trim()) && !string.IsNullOrEmpty(textBox15.Text.Trim()) && !string.IsNullOrEmpty(textBox16.Text.Trim()) && comboBox10.SelectedIndex > -1)
            {
                var a = listViewSaha.SelectedItems[0].SubItems[4].Text;
                int id = int.Parse(a);
                var saha = HelperSaha.SahaIdAl(id);

                saha.SahaAdi = textBox14.Text.Trim();
                saha.SemtID = Convert.ToInt32(comboBox10.SelectedValue);
                saha.Telefon = textBox15.Text.Trim();
                saha.Adres = textBox16.Text.Trim();
                HelperSaha.SahaIslemleri(saha, System.Data.Entity.EntityState.Modified);
                SahalarıListele();
                MessageBox.Show("Saha Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                var liste = HelperKiralanmisSaha.IdAlListeGetir(id);


                for (int i = 0; i < liste.Count; i++)
                {

                    liste[i].SemtID = Convert.ToInt32(comboBox10.SelectedValue);
                    HelperKiralanmisSaha.KiralanmisSahaIslemleri(liste[i], System.Data.Entity.EntityState.Modified);

                }


                textBox14.Enabled = false;
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                comboBox10.Enabled = false;
                button12.Enabled = false;

            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz");
            }

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            int count = listViewSaha.SelectedItems.Count;

            if (count > 0)
            {
                var a = listViewSaha.SelectedItems[0].SubItems[4].Text;
                int id = int.Parse(a);
                var saha = HelperSaha.SahaIdAl(id);
                saha.SahaSilmeDurum = false;
                HelperSaha.SahaIslemleri(saha, System.Data.Entity.EntityState.Modified);
                SahalarıListele();
                MessageBox.Show("Saha Silindi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Sahayı Tablodan Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void TextBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ListViewTakim_Click(object sender, EventArgs e)
        {

        }

        private void ListViewTakim_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void ListViewSaha_SelectedIndexChanged(object sender, EventArgs e)
        {
            button9.Enabled = true;
            button10.Enabled = true;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Sifirla();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dönenid1 = Convert.ToInt32(comboBox1.SelectedValue);
            a = dönenid1;
            ComboBoxSahaDoldur(comboBox7, a);
        }

        public void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dönenid1 = Convert.ToInt32(comboBox2.SelectedValue);
            b = dönenid1;
            ComboBoxSahaDoldur(comboBox8, b);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var saat = DateTime.Now.ToString("HH:mm");
            label11.Text = saat;

            if (saat == "00:00")
            {
                Sifirla();
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
