using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zorumbia.DAL;

namespace Zorumbia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var bis = new RegionPayment(new DateTime(2020,10,10), 10, 50, 200, 195);
            var applicant = new SocialWorker(
                "Nodir",
                bis,
                60
                );
            MessageBox.Show($"{applicant.Name} works in Region №{applicant.Region.Region}. " +
                $"There are {bis.Headcount} worker and paid money is {bis.Paid}");
        }
    }
}
