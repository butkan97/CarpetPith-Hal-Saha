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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            var kontrol = HelperKullaniciler.KullaniciKontrol(textBox1.Text);

            if (kontrol)
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
                {
                    KullaniciGirisTablo k = new KullaniciGirisTablo();
                    k.KullaniciAdi = textBox1.Text;
                    k.KullaniciSifre = textBox2.Text;
                    k.KullaniciTipi = false;
                    HelperKullaniciler.KullaniciIslemleri(k, System.Data.Entity.EntityState.Added);
                    MessageBox.Show("Kullanıcı Başarıyla Kayıt Edildi..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Bütün Alanların Dolu Olması Gerekmektedir...");
                }

            }
            else
            {
                MessageBox.Show("Zaten Böyle bir Kullanici Mevcuttur Kayıt Edilemez..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Button1_Click(object sender, EventArgs e)

        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if (radioButton2.Checked)
                {
                    var admin = HelperKullaniciler.GirisKontrol(textBox1.Text, textBox2.Text, true);

                    if (admin != null)
                    {

                        Form2 f = new Form2(admin);
                        this.Hide();
                        f.Show();

                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }

                if (radioButton1.Checked)
                {
                    var kullanici = HelperKullaniciler.GirisKontrol(textBox1.Text, textBox2.Text, false);
                    if (kullanici != null)
                    {
                        Form3 f = new Form3(kullanici);
                        this.Hide();
                        f.Show();


                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }

                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Lütfen Giriş Seçeneğini Seçiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş Olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           



        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 32 && (int)e.KeyChar <= 47)
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar >= 58 && (int)e.KeyChar <= 64)
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar >= 91 && (int)e.KeyChar <= 95)
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar >= 123 && (int)e.KeyChar <= 126)
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
