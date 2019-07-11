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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请填写完整！", "提示");
                return;
            }
            if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("密码不一致！", "提示");
                return;
            }
            OleDbConnection oleDb=null;
            OleDbCommand oleDbCommand;
            int res = 0;
            try
            {
                oleDb = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\Csharp\WindowsFormsApp1\WindowsFormsApp1\res\App1.mdb");
                oleDb.Open();
                string sql = "insert into login_sheet ([user],[pass],[role]) values('" + textBox1.Text + "','" + textBox2.Text + "','1')";
                Console.WriteLine(sql);
                oleDbCommand = new OleDbCommand(sql, oleDb);
                res = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            
            Console.WriteLine(res);
            if (res <= 0)
            {
                MessageBox.Show("用户名已经存在 注册失败！", "提示");
                oleDb.Close();
                return;
            }
            MessageBox.Show("注册成功！", "提示");
            oleDb.Close();
            this.Close();
        }
    }
}
