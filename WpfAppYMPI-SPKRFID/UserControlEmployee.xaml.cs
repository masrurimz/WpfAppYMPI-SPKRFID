using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;

namespace WpfAppYMPI_SPKRFID
{
    /// <summary>
    /// Interaction logic for UserControlEmployee.xaml
    /// </summary>
    public partial class UserControlEmployee : UserControl
    {
        OleDbConnection con;
        DataTable dt;

        public UserControlEmployee()
        {
            InitializeComponent();

            //Connect your access database
            con = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\EmpDB.mdb"
            };
            BindGrid();
        }

        //Display records in grid
        private void BindGrid()
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from tbEmp";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gvData.ItemsSource = dt.AsDataView();

            if (dt.Rows.Count > 0)
            {
                lblCount.Visibility = System.Windows.Visibility.Hidden;
                gvData.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                lblCount.Visibility = System.Windows.Visibility.Visible;
                gvData.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //Add records in grid
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;

            if (txtEmpId.Text != "")
            {
                if (txtEmpId.IsEnabled == true)
                {
                    if (ddlGender.Text != "Select Gender")
                    {
                        cmd.CommandText = "insert into tbEmp(EmpId,EmpName,Gender,Contact,Address) Values(" + txtEmpId.Text + ",'" + txtEmpName.Text + "','" + ddlGender.Text + "'," + txtContact.Text + ",'" + txtAddress.Text + "')";
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        MessageBox.Show("Employee Added Successfully...");
                        ClearAll();

                    }
                    else
                    {
                        MessageBox.Show("Please Select Gender Option....");
                    }
                }
                else
                {
                    cmd.CommandText = "update tbEmp set EmpName='" + txtEmpName.Text + "',Gender='" + ddlGender.Text + "',Contact=" + txtContact.Text + ",Address='" + txtAddress.Text + "' where EmpId=" + txtEmpId.Text;
                    cmd.ExecuteNonQuery();
                    BindGrid();
                    MessageBox.Show("Employee Details Updated Succesffully...");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please Add Employee Id.......");
            }
        }

        //Clear all records from controls
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtEmpId.Text = "";
            txtEmpName.Text = "";
            ddlGender.SelectedIndex = 0;
            txtContact.Text = "";
            txtAddress.Text = "";
            btnAdd.Content = "Add";
            txtEmpId.IsEnabled = true;
        }

        //Edit records
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (gvData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvData.SelectedItems[0];
                txtEmpId.Text = row["EmpId"].ToString();
                txtEmpName.Text = row["EmpName"].ToString();
                ddlGender.Text = row["Gender"].ToString();
                txtContact.Text = row["Contact"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtEmpId.IsEnabled = false;
                btnAdd.Content = "Update";
            }
            else
            {
                MessageBox.Show("Please Select Any Employee From List...");
            }
        }

        //Delete records from grid
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gvData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvData.SelectedItems[0];

                OleDbCommand cmd = new OleDbCommand();
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from tbEmp where EmpId=" + row["EmpId"].ToString();
                cmd.ExecuteNonQuery();
                BindGrid();
                MessageBox.Show("Employee Deleted Successfully...");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Please Select Any Employee From List...");
            }
        }

        //Exit
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
