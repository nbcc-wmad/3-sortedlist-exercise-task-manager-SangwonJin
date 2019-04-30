using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SortedList<string, string> list = new SortedList<string, string>();
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string date = dtpTaskDate.Value.ToString("d/MM/yyyy");

            if(txtTask.Text == string.Empty)
            {
                MessageBox.Show("you must enter a task", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (list.ContainsKey(date))
            {
                MessageBox.Show("Only one task per date is allowed","Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                list.Add(date, txtTask.Text);
                ShowList(date);
                txtTask.Text = string.Empty;
            }
        }
        private void ShowList(string a)
        {
            lstTasks.Items.Add(a);
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(lstTasks.SelectedItem);

            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("you must select a task to remove", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                list.Remove(a);
                lstTasks.Items.Remove(a);
                lblTaskDetails.Text = string.Empty;
            }

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach(var a in list)
            {
                message += a.Key + " " + a.Value+Environment.NewLine;
            }
            MessageBox.Show(message);
        }


        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex!=-1)
            {
                lblTaskDetails.Text = string.Empty;
                string a = list[lstTasks.SelectedItem.ToString()];
                lblTaskDetails.Text = a;
            }

        }
    }
}
