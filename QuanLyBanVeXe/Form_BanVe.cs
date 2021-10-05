using QuanLyBanVeXe.Properties;
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
    public partial class Form_BanVe : Form
    {
        public Form_BanVe()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dl = new DataClasses1DataContext();
        private void clearBanVe()
        {
            textBox1.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox3.Text = null;
            comboBox2.Text = string.Empty;
            textBox1.Focus();
        }
        private bool kiemTraKhoaChinhBanVe(string ten)
        {
            var nguoidung = from id in dl.BanVes
                            where id.IdVe == textBox1.Text
                            select id;
            if (nguoidung.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void loadcombo()
        {
            var lcb = from lnd in dl.ChuyenXes

                      select lnd.IdChuyen;

            comboBox1.DataSource = lcb.ToList();
        }
        private void loadDataBanVe()
        {
            dataGridView1.DataSource = from nd in dl.BanVes
                                       select new
                                       {
                                           nd.IdVe,
                                           nd.IdChuyen,
                                           nd.ChuyenXe.TuyenXe.TenTuyen,
                                           nd.TenHanhKhach,
                                           nd.SDTHanhKhach,
                                           nd.ChuyenXe.So_Xe,
                                           nd.ChuyenXe.NgayDi,
                                           nd.ChuyenXe.Gio,
                                           nd.SoLuongMua,
                                           nd.GiaVe,
                                           nd.ThanhTien
                                       };
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn đăng xuất không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Visible = false;
                Form_DangNhap f = new Form_DangNhap();
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Mã vé không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox4.Text == string.Empty)
                {
                    MessageBox.Show("Tên khách không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox5.Text == string.Empty)
                {
                    MessageBox.Show("Số điện thoại không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox6.Text == string.Empty)
                {
                    MessageBox.Show("Số lượng mua không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBox2.Text == string.Empty)
                {
                    MessageBox.Show("Giá vé không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kiemTraKhoaChinhBanVe(textBox1.Text) == false)
                {
                    var isValidInput = new Regex(@"^\d{9,11}$");
                    BanVe tx = new BanVe();
                    tx.IdVe = textBox1.Text;
                    tx.IdChuyen = comboBox1.Text;
                    tx.TenHanhKhach = textBox4.Text;
                    if (isValidInput.IsMatch(textBox5.Text))
                    {
                        tx.SDTHanhKhach = textBox5.Text;
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ phải từ 9 - 11 số", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tx.SoLuongMua = int.Parse(textBox6.Text);
                    tx.GiaVe = int.Parse(comboBox2.Text);
                    tx.ThanhTien = int.Parse(textBox6.Text) * int.Parse(comboBox2.Text);
                    dl.BanVes.InsertOnSubmit(tx);
                    dl.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataBanVe();
                }
                else
                {
                    MessageBox.Show("Mã vé đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Form_BanVe_Load(object sender, EventArgs e)
        {
            loadcombo();
            loadDataBanVe();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = dl.ChuyenXes.Where(id => id.IdChuyen == comboBox1.Text).First().NgayDi.ToString();
            textBox7.Text = dl.ChuyenXes.Where(id => id.IdChuyen == comboBox1.Text).First().Gio;
            textBox2.Text = dl.ChuyenXes.Where(id => id.IdChuyen == comboBox1.Text).First().So_Xe;
            textBox8.Text = dl.ChuyenXes.Where(id => id.IdChuyen == comboBox1.Text).First().TuyenXe.TenTuyen;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tt = int.Parse(textBox6.Text) * int.Parse(comboBox2.Text);
            textBox3.Text = tt.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Thông tin vé xe", 700, 300);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        
            Image image = Resources.bus_icon;
            e.Graphics.DrawString("Thông Tin Vé Xe", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new Point(300, 0));
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                e.Graphics.DrawString("Tên tuyến: " + row.Cells[2].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 50));
                e.Graphics.DrawString("Tên khách: " + row.Cells[3].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 80));
                e.Graphics.DrawString("Số điện thoại: " + row.Cells[4].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 110));
                e.Graphics.DrawString("Ngày đi: " + row.Cells[6].FormattedValue.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 140));
                e.Graphics.DrawString("Giờ khởi hành: " + row.Cells[7].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 170));
                e.Graphics.DrawString("Số xe: " + row.Cells[5].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 200));
                e.Graphics.DrawString("Số lượng vé: " + row.Cells[8].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 230));
                e.Graphics.DrawString("Thành tiền: " + row.Cells[9].Value.ToString(), new Font("Times new Roman", 16, FontStyle.Regular), Brushes.Black, new Point(300, 260));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox1.Text = row.Cells[1].Value.ToString();
                textBox8.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                dateTimePicker1.Text = row.Cells[6].FormattedValue.ToString();
                textBox7.Text = row.Cells[7].Value.ToString();
                textBox2.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                comboBox2.Text = row.Cells[9].Value.ToString();
                textBox3.Text = row.Cells[10].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string id = dataGridView1.SelectedCells[0].Value.ToString();
                BanVe delete = dl.BanVes.Single(ten => ten.IdVe.Equals(id));
                dl.BanVes.DeleteOnSubmit(delete);
                dl.SubmitChanges();
                MessageBox.Show("Xóa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearBanVe();
                loadDataBanVe();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearBanVe();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
