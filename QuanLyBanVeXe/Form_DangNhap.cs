using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanVeXe
{
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dl = new DataClasses1DataContext();
        private void load_comboNguoiDung()
        {
            var lcb = from lnd in dl.LoaiNguoiDungs

                      select lnd.IdLoaiND;

            comboBox1.DataSource = lcb.ToList();
        }
        private bool kiemTraDangNhap(string ten, string mk,string idloai)
        {
            var regexItem = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
            var nguoidung = from id in dl.NguoiDungs
                            where id.IdNguoiDung == textBox1.Text && id.PassND == textBox2.Text &&id.IdLoaiND==comboBox1.Text
                            select id;
            if (nguoidung.Any()&&regexItem.IsMatch(textBox2.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (kiemTraDangNhap(textBox1.Text,textBox2.Text,comboBox1.Text)==true&&comboBox1.Text=="Admin")
            {
                MessageBox.Show("Đăng nhập thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Visible = false;
                Form_Main f = new Form_Main();
                f.Show();
            }
            else if (kiemTraDangNhap(textBox1.Text, textBox2.Text,comboBox1.Text) == true && comboBox1.Text == "Nhan_Vien")
            {
                MessageBox.Show("Đăng nhập thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Visible = false;
                Form_BanVe f = new Form_BanVe();
                f.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu hoặc option không chính xác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            load_comboNguoiDung();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
