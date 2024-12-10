using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCirclePawnWinform
{
    public partial class FormPointsAdd : Form
    {

        public FormPointsAdd()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormPointDetail formPointDetail = new FormPointDetail();
            formPointDetail.StartPosition = FormStartPosition.CenterScreen;

            if (formPointDetail.ShowDialog() == DialogResult.OK)
            {
                MyObject myObject = new MyObject() { Name = $"({formPointDetail.PointD.X},{formPointDetail.PointD.Y})", Value = formPointDetail.PointD };
                this.listBox1.Items.Add(myObject);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0)
            {
                var selectItem = this.listBox1.SelectedItem;
                if (selectItem != null)
                {
                    this.listBox1.Items.Remove(selectItem);
                }
            }
            else
            {
                MessageBox.Show("无数据删除");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count <= 3)
            {
                MessageBox.Show("请添加4组以上点位数据（包含四组）");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class MyObject
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
