using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanVeXe
{
    public partial class Form_ChiTietTuyenXe : Form
    {
        public Form_ChiTietTuyenXe()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dl = new DataClasses1DataContext();
        private void clearChiTietTuyenXe()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }
        private bool kiemTraKhoaNgoaiChiTietTuyenXe(string ten,string ngay,string gio)
        {
            var nguoidung = from id in dl.ChuyenXes
                            where id.IdTuyen == textBox3.Text
                            where id.NgayDi==DateTime.Parse(dateTimePicker1.Text)
                            where id.Gio==textBox4.Text
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
        private void loadChiTietTuyen()
        {
            dataGridView1.DataSource = from ct in dl.ChiTietTuyens
                                       from t in dl.TuyenXes
                                       from td in dl.ThoiDiems
                                       where ct.IdThoiDiem == td.IdThoiDiem
                                       where ct.IdTuyen == t.IdTuyen
                                       select new
                                       {
                                           t.IdTuyen,
                                           td.IdThoiDiem,
                                           td.Ngay,
                                           td.Gio,
                                           t.TenTuyen
                                       };
        }
        private void Form_ChiTietTuyenXe_Load(object sender, EventArgs e)
        {
            loadChiTietTuyen();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox1.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thoát không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from ct in dl.ChiTietTuyens
                                       from t in dl.TuyenXes
                                       from td in dl.ThoiDiems
                                       where ct.IdThoiDiem == td.IdThoiDiem
                                       where ct.IdTuyen == t.IdTuyen
                                       where td.Ngay==DateTime.Parse(dateTimePicker1.Text)
                                       select new
                                       {
                                           t.IdTuyen,
                                           td.IdThoiDiem,
                                           td.Ngay,
                                           td.Gio,
                                           t.TenTuyen
                                       };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadChiTietTuyen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (kiemTraKhoaNgoaiChiTietTuyenXe(textBox3.Text,dateTimePicker1.Text,textBox4.Text) == false)
                {
                    string id = dataGridView1.SelectedCells[0].Value.ToString();
                    string id2 = dataGridView1.SelectedCells[1].Value.ToString();
                    ChiTietTuyen delete = dl.ChiTietTuyens.Where(x => x.IdTuyen == id).Where(x1 => x1.IdThoiDiem == id2).FirstOrDefault();
                    dl.ChiTietTuyens.DeleteOnSubmit(delete);
                    dl.SubmitChanges();
                    clearChiTietTuyenXe();
                    loadChiTietTuyen();
                }
                else
                {
                    MessageBox.Show("Id tuyến và thời điểm đang tồn tại trong bảng Chuyến Xe", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
