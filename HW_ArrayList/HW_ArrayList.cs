﻿using System;
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
            int FindIndex = int.Parse(FindIndexBox.Text);
            IndexEditBox.Clear();

            if (list.get(FindIndex))
            {
                list.indexOf(FindIndex);
                string IndexName = list.get(FindIndex).ToString();
            } else
            {
                IndexEditBox.Enabled = false;
            }
        }

        private void NameEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void ListShowBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
