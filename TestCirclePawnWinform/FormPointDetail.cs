using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestCirclePawnWinform
{
    public partial class FormPointDetail : Form
    {
        public FormPointDetail()
        {
            InitializeComponent();
        }
        public PointD PointD { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            double pointX = 0;
            double pointY = 0;

            if (double.TryParse(textBox1.Text, out double value))
            {
                pointX = value;
            }
            else
            {
                MessageBox.Show("请输入准确的X数值");
                return;
            }
            if (double.TryParse(textBox2.Text, out double value2))
            {
                pointY = value2;
            }
            else
            {
                MessageBox.Show("请输入准确的Y数值");
                return;
            }
            PointD = new PointD(pointX, pointY);
            DialogResult = DialogResult.OK;
        }
    }
}
