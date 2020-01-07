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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Visible = true;
            this.BackColor = Color.Green;
            this.TransparencyKey = Color.Green;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 4;
            if (progressBar1.Value==100)
            {
                timer1.Stop();
                this.Close();
            }


        }
    }
}
