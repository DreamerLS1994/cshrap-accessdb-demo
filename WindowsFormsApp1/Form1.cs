using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class from1 : Form
    {
        public OleDbConnection oleDb;
        public from1()
        {
            InitializeComponent();
        }

        private void from1_Load(object sender, EventArgs e)
        {
            oleDb = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\Csharp\WindowsFormsApp1\WindowsFormsApp1\res\App1.mdb");
            oleDb.Open();
            listView1.Columns.Add("ID", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("用户名", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("密码", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("角色", 60, HorizontalAlignment.Left);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "select * from login_sheet";
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, oleDb); //创建适配对象
            DataTable dt = new DataTable(); //新建表对象
            dbDataAdapter.Fill(dt); //用适配对象填充表对象
            foreach (DataRow item in dt.Rows)
            {
                
                Console.WriteLine(item[0] + " | " + item[1] + " | " + item[2]);
                ListViewItem litem = new ListViewItem();
                litem.Text = item[0].ToString();
                litem.SubItems.Add(item[1].ToString());
                litem.SubItems.Add(item[2].ToString());
                litem.SubItems.Add(item[3].ToString());
                listView1.BeginUpdate();
                listView1.Items.Add(litem);
                listView1.EndUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请填写完整！", "提示");
                return;
            }
            string sql = "select * from login_sheet where user='" + textBox1.Text + "'";
            Console.WriteLine(sql);
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, oleDb); //创建适配对象
            DataTable dt = new DataTable(); //新建表对象
            try
            {
                dbDataAdapter.Fill(dt); //用适配对象填充表对象
            }
            catch
            {
                
            }

            DataRow item = dt.Rows[0];
            if (item[2].ToString() == textBox2.Text)
            {
                if (radioButton1.Checked && item[3].ToString() == "0")
                {
                    MessageBox.Show("登陆成功！", "提示");
                    return;
                }
                else if (radioButton2.Checked && item[3].ToString() == "1")
                {
                    MessageBox.Show("登陆成功！", "提示");
                    return;
                }
            }
            MessageBox.Show("用户名密码错误!", "提示");
            return;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void from1_FormClosed(object sender, FormClosedEventArgs e)
        {
            oleDb.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
