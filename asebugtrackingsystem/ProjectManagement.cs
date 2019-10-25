using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessLogicLayer;

namespace asebugtrackingsystem
{
    public partial class ProjectManagement : Form
    {
        public ProjectManagement()
        {
            InitializeComponent();
        }
        BusinessLogicClass blc = new BusinessLogicClass();
        Getalldatatables get = new Getalldatatables();
        public int id;



        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtdescription.Text == "")
            {
                MessageBox.Show("Please Provide Description");
            }
            else if (txtprojectname.Text == "")
            {
                MessageBox.Show("Provide Project");
            }
            else if (dtpstartdate == dtpenddate)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure the project will complete in a single day", "Consider the Project Interval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    dtpenddate.Focus();

                }





                try
                {
                    bool result = blc.manageProjects(0, txtprojectname.Text, Convert.ToDateTime(dtpstartdate.Text), Convert.ToDateTime(dtpenddate.Text), txtdescription.Text, 1);
                    if (result == true)
                    {
                        MessageBox.Show("New Project Successfully created");
                        dgvprojectmanagement.DataSource = get.getAllProjects();
                        HelperClass.MakeFieldBlank(panel1);
                    }
                    else
                    {
                        MessageBox.Show("Error on Creating Project");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ProjectManagement_Load(object sender, EventArgs e)
        {
            dgvprojectmanagement.DataSource = get.getAllProjects();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = blc.manageProjects(id, txtprojectname.Text, Convert.ToDateTime(dtpstartdate.Text), Convert.ToDateTime(dtpenddate.Text), txtdescription.Text, 2);
                if (result == true)
                {
                    MessageBox.Show("Project Successfully created Updated");
                    dgvprojectmanagement.DataSource = get.getAllProjects();
                    HelperClass.MakeFieldBlank(panel1);
                }
                else
                {
                    MessageBox.Show("Error on Creating Project");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = blc.manageProjects(id, txtprojectname.Text, Convert.ToDateTime(dtpstartdate.Text), Convert.ToDateTime(dtpenddate.Text), txtdescription.Text, 3);
                if (result == true)
                {
                    MessageBox.Show("Project successfully deleted");
                    dgvprojectmanagement.DataSource = get.getAllProjects();
                    HelperClass.MakeFieldBlank(panel1);
                }
                else
                {
                    MessageBox.Show("Error on Deleting Project");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvprojectmanagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvprojectmanagement.SelectedRows[0].Cells["projectId"].Value.ToString());
                txtprojectname.Text= dgvprojectmanagement.SelectedRows[0].Cells["projectName"].Value.ToString();
                dtpstartdate.Text = dgvprojectmanagement.SelectedRows[0].Cells["projectStartDate"].Value.ToString();
                dtpenddate.Text = dgvprojectmanagement.SelectedRows[0].Cells["projectEndDate"].Value.ToString();
                txtdescription.Text = dgvprojectmanagement.SelectedRows[0].Cells["projectDescription"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
