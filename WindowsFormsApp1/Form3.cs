using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" 
                || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("请填写完整！", "提示");
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("密码不一致！", "提示");
                return;
            }

            OleDbConnection oleDb = null;
            OleDbCommand oleDbCommand;
            oleDb = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\Csharp\WindowsFormsApp1\WindowsFormsApp1\res\App1.mdb");
            oleDb.Open();

            string sql = "select * from login_sheet where user='" + textBox1.Text + "'";
            Console.WriteLine(sql);
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, oleDb); //创建适配对象
            DataTable dt = new DataTable(); //新建表对象
            try
            {
                dbDataAdapter.Fill(dt); //用适配对象填充表对象
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }

            DataRow item = dt.Rows[0];
            if (item[2].ToString() == textBox2.Text)
            {
                int res = 0;
                try
                {
                    string sql2 = "update login_sheet set pass='" + textBox3.Text + "' where user='" + textBox1.Text + "'";
                    Console.WriteLine(sql2);
                    oleDbCommand = new OleDbCommand(sql2, oleDb);
                    res = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.ToString());
                }

                Console.WriteLine(res);
                if (res > 0)
                {
                    MessageBox.Show("修改成功！", "提示");
                    oleDb.Close();
                    this.Close();
                    return;
                }

            }
            MessageBox.Show("用户名密码错误!", "提示");
            return;
        }
    }
}
