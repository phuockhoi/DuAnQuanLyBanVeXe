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
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dl = new DataClasses1DataContext();
        private void button1_Click(object sender, EventArgs e)
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
        private void clearNguoiDung()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            richTextBox1.Text = null;
            textBox1.Focus();
        }
        private void clearXe()
        {
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox5.Focus();
        }
        private void clearTuyenXe()
        {
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox9.Focus();
        }
        private void clearThoiDiem()
        {
            textBox13.Text = null;
            textBox14.Text = null;
            dateTimePicker2.Text = DateTime.Now.ToString();
            textBox13.Focus();
        }
        private void clearChuyenXe()
        {
            textBox16.Text = null;
            textBox16.Focus();
        }
        private void load_comboNguoiDung()
        {
            var lcb = from lnd in dl.LoaiNguoiDungs

                      select lnd.IdLoaiND;
            //Ten = lnd.TenLoaiND

            comboBox1.DataSource = lcb.ToList();
            //comboBox1.DisplayMember = "Ten";
            //comboBox1.ValueMember = "Id";
        }
        private void load_comboTuyenXe()
        {
            var lcb = from lnd in dl.TuyenXes

                      select lnd.IdTuyen;

            comboBox2.DataSource = lcb.ToList();
        }
        private void load_comboSoXeChuyenXe()
        {
            var lcb = from lnd in dl.Xes

                      select lnd.So_Xe;

            comboBox4.DataSource = lcb.ToList();
        }
        private void load_comboTuyenXeChuyenXe()
        {
            var lcb = from lnd in dl.TuyenXes

                      select lnd.IdTuyen;

            comboBox3.DataSource = lcb.ToList();
        }
        private bool kiemTraKhoaChinhNguoiDung(string ten)
        {
            var nguoidung = from id in dl.NguoiDungs
                            where id.IdNguoiDung == textBox1.Text
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
        private bool kiemTraKhoaNgoaiThoiDiem(string ten)
        {
            var nguoidung = from id in dl.ChiTietTuyens
                            where id.IdThoiDiem == textBox13.Text
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
        private bool kiemTraKhoaNgoaiXe(string ten)
        {
            var nguoidung = from id in dl.ChuyenXes
                            where id.So_Xe == textBox5.Text
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
        private bool kiemTraKhoaNgoaiTuyenXe(string ten)
        {
            var nguoidung = from id in dl.ChuyenXes
                            where id.IdTuyen == textBox9.Text
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

        private bool kiemTraKhoaChinhXe(string ten)
        {
            var nguoidung = from id in dl.Xes
                            where id.So_Xe == textBox5.Text
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
        private bool kiemTraKhoaChinhTuyenXe(string ten)
        {
            var nguoidung = from id in dl.TuyenXes
                            where id.IdTuyen == textBox9.Text
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
        private bool kiemTraKhoaChinhThoiDiem(string ten)
        {
            var nguoidung = from id in dl.ThoiDiems
                            where id.IdThoiDiem == textBox13.Text
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
        private bool kiemTraGanThoiDiem(string idthoidiem, string idtuyen)
        {
            var nguoidung = from id in dl.ChiTietTuyens
                            where id.IdThoiDiem == textBox13.Text
                            where id.IdTuyen == comboBox2.Text
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
        private bool kiemTraKhoaChinhChuyenXe(string idtuyen)
        {
            var nguoidung = from id in dl.ChuyenXes
                            where id.IdChuyen == textBox16.Text

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
        private void loadDataNguoiDung()
        {
            dataGridView1.DataSource = from nd in dl.NguoiDungs
                                       select new
                                       {
                                           nd.IdNguoiDung,
                                           nd.PassND,
                                           nd.HoTen,
                                           nd.NgaySinh,
                                           nd.GioiTinh,
                                           nd.DiaChi,
                                           nd.SoDT,
                                           nd.IdLoaiND
                                       };
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loadDaTaXe()
        {
            dataGridView2.DataSource = dl.Xes.ToList();
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loadDaTaTuyenXe()
        {
            dataGridView3.DataSource = dl.TuyenXes.ToList();
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loadDataThoiDiem()
        {
            dataGridView4.DataSource = dl.ThoiDiems.ToList();
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loadDataChuyenXe()
        {
            dataGridView5.DataSource = from nd in dl.ChuyenXes
                                       select new
                                       {
                                           nd.IdChuyen,
                                           nd.IdTuyen,
                                           nd.NgayDi,
                                           nd.Gio,
                                           nd.So_Xe
                                       };
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loadThongKe()
        {

            //CrystalReport1 rp = new CrystalReport1();
            //crystalReportViewer1.ReportSource = rp;
            //crystalReportViewer1.DisplayStatusBar = false;
            //crystalReportViewer1.DisplayToolbar = true;
            //crystalReportViewer1.Refresh();
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            load_comboNguoiDung();
            loadDataNguoiDung();
            loadDaTaXe();
            loadDaTaTuyenXe();
            loadDataThoiDiem();
            load_comboTuyenXe();
            load_comboSoXeChuyenXe();
            load_comboTuyenXeChuyenXe();
            loadDataChuyenXe();
            loadThongKe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value.ToString() == "Nam")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                comboBox1.Text = row.Cells[7].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                richTextBox1.Text = row.Cells[5].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (textBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Tên đăng nhập không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(textBox2.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Mật khẩu không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox3.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Họ tên không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (radioButton1.Checked==false&&radioButton2.Checked==false)
                {
                    MessageBox.Show("Phải chọn giới tính", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox4.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Số điện thoại không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kiemTraKhoaChinhNguoiDung(textBox1.Text) == false)
                {
                    var isValidInput = new Regex(@"^\d{9,11}$");
                    var regexItem = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
                    NguoiDung nd = new NguoiDung();
                    nd.IdNguoiDung = textBox1.Text;
                    if(regexItem.IsMatch(textBox2.Text))
                    {
                        nd.PassND = textBox2.Text;
                    }
                    else
                    {
                        MessageBox.Show("Password phải 8 ký tự, có ít nhất 1 số, ít nhất 1 ký tự thường, ít nhất 1 ký tự hoa", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    nd.HoTen = textBox3.Text;
                    nd.NgaySinh = DateTime.Parse(dateTimePicker1.Text).Date;
                    if (radioButton1.Checked == true)
                    {
                        nd.GioiTinh = "Nam";
                    }
                    else
                    {
                        nd.GioiTinh = "Nữ";
                    }
                    nd.DiaChi = richTextBox1.Text;
                    if(isValidInput.IsMatch(textBox4.Text))
                    {
                        nd.SoDT = textBox4.Text;
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ phải từ 9 - 11 số", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    nd.IdLoaiND = comboBox1.Text;
                    dl.NguoiDungs.InsertOnSubmit(nd);
                    dl.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataNguoiDung();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string id = dataGridView1.SelectedCells[0].Value.ToString();
                NguoiDung delete = dl.NguoiDungs.Single(ten => ten.IdNguoiDung.Equals(id));
                dl.NguoiDungs.DeleteOnSubmit(delete);
                dl.SubmitChanges();
                MessageBox.Show("Xóa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearNguoiDung();
                loadDataNguoiDung();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dl.NguoiDungs.Where(tk => tk.IdLoaiND.Equals(comboBox1.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadDataNguoiDung();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn sửa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                NguoiDung nd = dl.NguoiDungs.Single(i => i.IdNguoiDung.Equals(textBox1.Text));

                nd.PassND = textBox2.Text;
                nd.HoTen = textBox3.Text;
                nd.NgaySinh = DateTime.Parse(dateTimePicker1.Text).Date;
                if (radioButton1.Checked == true)
                {
                    nd.GioiTinh = "Nam";
                }
                else
                {
                    nd.GioiTinh = "Nữ";
                }
                nd.DiaChi = richTextBox1.Text;
                nd.SoDT = textBox4.Text;
                nd.IdLoaiND = comboBox1.Text;
                dl.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataNguoiDung();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                textBox5.Text = row.Cells[0].Value.ToString();
                textBox6.Text = row.Cells[1].Value.ToString();
                textBox7.Text = row.Cells[2].Value.ToString();
                textBox8.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (textBox5.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Số xe không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox6.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Hiệu xe không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox7.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Đời xe không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox8.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Số chỗ ngồi không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kiemTraKhoaChinhXe(textBox5.Text) == false)
                {
                    Xe x = new Xe();
                    x.So_Xe = textBox5.Text;
                    x.Hieu_Xe = textBox6.Text;
                    x.Doi_Xe = textBox7.Text;
                    x.So_Cho_Ngoi = int.Parse(textBox8.Text);
                    dl.Xes.InsertOnSubmit(x);
                    dl.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDaTaXe();
                }
                else
                {
                    MessageBox.Show("Số xe đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn sửa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Xe x = dl.Xes.Single(i => i.So_Xe.Equals(textBox5.Text));
                x.Hieu_Xe = textBox6.Text;
                x.Doi_Xe = textBox7.Text;
                x.So_Cho_Ngoi = int.Parse(textBox8.Text);
                dl.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDaTaXe();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (kiemTraKhoaNgoaiXe(textBox5.Text) == false)
                {
                    string id = dataGridView2.SelectedCells[0].Value.ToString();
                    Xe delete = dl.Xes.Single(ten => ten.So_Xe.Equals(id));
                    dl.Xes.DeleteOnSubmit(delete);
                    dl.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearXe();
                    loadDaTaXe();
                }
                else
                {
                    MessageBox.Show("Mã số xe đang tồn tại trong bảng Chuyến Xe", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = dl.Xes.Where(tk => tk.So_Cho_Ngoi.Equals(textBox8.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            loadDaTaXe();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (textBox9.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Mã số tuyến không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox10.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Tên tuyến không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox11.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Địa điểm đi không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox12.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Địa điểm đến không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kiemTraKhoaChinhTuyenXe(textBox9.Text) == false)
                {
                    TuyenXe tx = new TuyenXe();
                    tx.IdTuyen = textBox9.Text;
                    tx.TenTuyen = textBox10.Text;
                    tx.DiaDiemDi = textBox11.Text;
                    tx.DiaDiemDen = textBox12.Text;
                    dl.TuyenXes.InsertOnSubmit(tx);
                    dl.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDaTaTuyenXe();
                }
                else
                {
                    MessageBox.Show("Id tuyến xe đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                textBox9.Text = row.Cells[0].Value.ToString();
                textBox10.Text = row.Cells[1].Value.ToString();
                textBox11.Text = row.Cells[2].Value.ToString();
                textBox12.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (kiemTraKhoaNgoaiTuyenXe(textBox9.Text) == false)
                {
                    string id = dataGridView3.SelectedCells[0].Value.ToString();
                    TuyenXe delete = dl.TuyenXes.Single(ten => ten.IdTuyen.Equals(id));
                    dl.TuyenXes.DeleteOnSubmit(delete);
                    dl.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTuyenXe();
                    loadDaTaTuyenXe();
                }
                else
                {
                    MessageBox.Show("Id tuyến xe đang tồn tại trong bảng Chuyến Xe", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn sửa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TuyenXe x = dl.TuyenXes.Single(i => i.IdTuyen.Equals(textBox9.Text));
                x.TenTuyen = textBox10.Text;
                x.DiaDiemDi = textBox12.Text;
                x.DiaDiemDen = textBox11.Text;
                dl.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDaTaTuyenXe();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = dl.TuyenXes.Where(tk => tk.DiaDiemDen.Equals(textBox12.Text));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            loadDaTaTuyenXe();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Form_ChiTietTuyenXe f = new Form_ChiTietTuyenXe();
            f.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (textBox13.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Mã thời điểm không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox14.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Giờ khởi hành không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kiemTraKhoaChinhThoiDiem(textBox13.Text) == false)
                {
                    if (DateTime.Parse(dateTimePicker2.Text).Date < DateTime.Now.Date)
                    {
                        MessageBox.Show("Ngày khởi hành không thể nhỏ hơn ngày hiện tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ThoiDiem tx = new ThoiDiem();
                        tx.IdThoiDiem = textBox13.Text;
                        tx.Ngay = DateTime.Parse(dateTimePicker2.Text).Date;
                        tx.Gio = textBox14.Text;
                        dl.ThoiDiems.InsertOnSubmit(tx);
                        dl.SubmitChanges();
                        MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataThoiDiem();
                    }
                }
                else
                {
                    MessageBox.Show("Id thời điểm đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (kiemTraKhoaNgoaiThoiDiem(textBox13.Text) == false)
                {
                    string id = dataGridView4.SelectedCells[0].Value.ToString();
                    ThoiDiem delete = dl.ThoiDiems.Single(ten => ten.IdThoiDiem.Equals(id));
                    dl.ThoiDiems.DeleteOnSubmit(delete);
                    dl.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearThoiDiem();
                    loadDataThoiDiem();
                }
                else
                {
                    MessageBox.Show("Id thời điểm đang tồn tại trong bảng Chi Tiết Tuyến Xe", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                textBox13.Text = row.Cells[0].Value.ToString();
                dateTimePicker2.Text = row.Cells[1].Value.ToString();
                textBox14.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn sửa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (DateTime.Parse(dateTimePicker2.Text).Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày khởi hành không thể nhỏ hơn ngày hiện tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ThoiDiem x = dl.ThoiDiems.Single(i => i.IdThoiDiem.Equals(textBox13.Text));
                    x.Ngay = DateTime.Parse(dateTimePicker2.Text).Date;
                    x.Gio = textBox14.Text;
                    dl.SubmitChanges();
                    MessageBox.Show("Sửa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataThoiDiem();
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = dl.ThoiDiems.Where(tk => tk.Ngay.Equals(dateTimePicker2.Text));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            loadDataThoiDiem();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox15.Text = dl.TuyenXes.Where(id => id.IdTuyen == comboBox2.Text).FirstOrDefault().TenTuyen;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn gán thời điểm này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (kiemTraGanThoiDiem(textBox13.Text, comboBox2.Text) == false)
                {
                    ChiTietTuyen tx = new ChiTietTuyen();
                    tx.IdTuyen = comboBox2.Text;
                    tx.IdThoiDiem = textBox13.Text;
                    dl.ChiTietTuyens.InsertOnSubmit(tx);
                    dl.SubmitChanges();
                    MessageBox.Show("Gán thời điểm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tuyến đã được gán thời điểm này rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Text = dl.TuyenXes.Where(id => id.IdTuyen == comboBox3.Text).FirstOrDefault().TenTuyen;
            comboBox5.DataSource = null;
            comboBox6.DataSource = null;
            comboBox5.DataSource = dl.ChiTietTuyens.Where(id => id.IdTuyen == comboBox3.Text).Select(x => x.ThoiDiem.Ngay).Distinct();
            comboBox6.DataSource = dl.ChiTietTuyens.Where(id => id.IdTuyen == comboBox3.Text).Select(x => x.ThoiDiem.Gio).Distinct();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (textBox16.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Mã số chuyến không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBox5.Text == string.Empty&&comboBox6.Text==string.Empty)
                {
                    MessageBox.Show("Tuyến xe này chưa có ngày và giờ đi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kiemTraKhoaChinhChuyenXe(textBox16.Text) == false)
                {

                    ChuyenXe tx = new ChuyenXe();
                    tx.IdChuyen = textBox16.Text;
                    tx.IdTuyen = comboBox3.Text;
                    tx.NgayDi = DateTime.Parse(comboBox5.Text).Date;
                    tx.Gio = comboBox6.Text;
                    tx.So_Xe = comboBox4.Text;
                    dl.ChuyenXes.InsertOnSubmit(tx);
                    dl.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataChuyenXe();

                }
                else
                {
                    MessageBox.Show("Id chuyến đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ChuyenXe delete = dl.ChuyenXes.Single(ten => ten.IdChuyen.Equals(textBox16.Text));
                dl.ChuyenXes.DeleteOnSubmit(delete);
                dl.SubmitChanges();
                MessageBox.Show("Xóa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearChuyenXe();
                loadDataChuyenXe();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc muốn sửa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                ChuyenXe x = dl.ChuyenXes.Single(i => i.IdChuyen.Equals(textBox16.Text));
                x.IdTuyen = comboBox3.Text;
                x.NgayDi = DateTime.Parse(comboBox5.Text).Date;
                x.Gio = comboBox6.Text;
                x.So_Xe = comboBox4.Text;
                dl.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataChuyenXe();

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = from nd in dl.ChuyenXes
                                       where nd.IdTuyen == comboBox3.Text
                                       select new
                                       {
                                           nd.IdChuyen,
                                           nd.IdTuyen,
                                           nd.NgayDi,
                                           nd.Gio,
                                           nd.So_Xe
                                       };
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            loadDataChuyenXe();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.DataSource = null;
            comboBox6.DataSource = dl.ChiTietTuyens.Where(id => id.IdTuyen == comboBox3.Text).Where(id2 => id2.ThoiDiem.Ngay == DateTime.Parse(comboBox5.Text)).Select(x => x.ThoiDiem.Gio).Distinct();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            clearNguoiDung();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            clearXe();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            clearTuyenXe();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            clearThoiDiem();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            clearChuyenXe();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                textBox16.Text = row.Cells[0].Value.ToString();
                comboBox3.Text = row.Cells[1].Value.ToString();
                comboBox5.Text = row.Cells[2].FormattedValue.ToString();
                comboBox6.Text = row.Cells[3].Value.ToString();
                comboBox4.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
