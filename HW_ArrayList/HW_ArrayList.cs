using System;
using System.Reflection;
using System.Windows.Forms;
using Lists;

namespace HW_ArrayList
{
    public partial class ArrayForm : Form
    {
        public ArrayForm()
        {
            InitializeComponent();
        }

        List list = new ArrayList(5);

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string name = FillBox.Text;
            if (name != null && name != "") // ตรวจสอบว่าชื่อไม่ว่างเปล่า
            {
                list.add(name);
                FillBox.Clear();
                MessageBox.Show($"คุณได้เพิ่ม {name} เข้ามาในรายการแล้ว");
            }
            else
            {
                FillBox.Clear();
                MessageBox.Show("โปรดใส่ข้อความ");
            }
            ListLabel.Text = list.size().ToString();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            string FindName = FillBox.Text;
            if (list.contains(FindName))
            {
                MessageBox.Show($"พบชื่อ {FindName} ในรายการ");
            }
            else
            {
                MessageBox.Show($"ไม่พบชื่อ {FindName} ในรายการ");
            }
            FillBox.Clear();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            string DelName = FillBox.Text;
            if (list.contains(DelName))
            {
                list.remove(DelName);
                MessageBox.Show($"ลบชื่อ {DelName} สำเร็จ");
            }
            else
            {
                MessageBox.Show($"ไม่พบชื่อ {DelName} ในรายการ");
            }
            FillBox.Clear();
            ListLabel.Text = list.size().ToString();
        }

        private void FindIndexBtn_Click(object sender, EventArgs e)
        {
            int MyIndex;
            IndexEditBox.Clear();

            if (int.TryParse(FindIndexBox.Text, out MyIndex))
            {
                MyIndex--;

                if (MyIndex >= 0 && MyIndex < list.size())
                {
                    // แสดงข้อมูลใน index ที่ระบุ
                    IndexEditBox.Text = list.get(MyIndex).ToString();
                } else
                {
                    MessageBox.Show($"ไม่พบรายชื่อลำดับที่ {FindIndexBox.Text} ในรายการ");
                }
            } else
            {
                MessageBox.Show($"โปรดใส่ลำดับของรายชื่อให้ถูกต้อง");
            }
            FindIndexBox.Clear();
        }

        private void NameEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void ListShowBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
