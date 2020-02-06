using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace iliekbarangay
{
    public partial class tab_update : UserControl
    {


        private static tab_update _instance;
        public static tab_update Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new tab_update();
                return _instance;
            }
        }
        public tab_update()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            Connection con = new Connection();
            con.Connect();
            SqlDataAdapter pa = new SqlDataAdapter("select CONCAT(RESIDENT_LNAME,', ',RESIDENT_FNAME,' ',RESIDENT_MNAME) AS NAME,RESIDENT_AGE AS Age,RESIDENT_MARITAL AS Civil_Status, RESIDENT_GENDER AS Gender, RESIDENT_ID AS II from resident where family_id is not null and RESIDENT_IMAGE is null", Connection.con);

            SqlCommandBuilder cd = new SqlCommandBuilder(pa);
            DataTable dt = new DataTable();

            pa.Fill(dt);
            photoData.DataSource = dt;
            //photoData.AutoSizeColumnsMode =
            //DataGridViewAutoSizeColumnsMode.Fill;


            SqlDataAdapter fa = new SqlDataAdapter("select CONCAT(RESIDENT_LNAME,', ',RESIDENT_FNAME,' ',RESIDENT_MNAME) AS NAME,RESIDENT_AGE AS Age,RESIDENT_MARITAL AS Civil_Status, RESIDENT_GENDER AS Gender, RESIDENT_ID AS II from resident where family_id is not null and RESIDENT_FINGERPRINT is null", Connection.con);

            SqlCommandBuilder cd2 = new SqlCommandBuilder(fa);
            DataTable dt2 = new DataTable();

            fa.Fill(dt2);
            fingerData.DataSource = dt2;
            fingerData.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == metroTabPage1)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = photoData.DataSource;
                bs.Filter = "NAME like '%" + searchBox.Text + "%'";
                photoData.DataSource = bs;
            }
            else if (metroTabControl1.SelectedTab == metroTabPage2)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = fingerData.DataSource;
                bs.Filter = "NAME like '%" + searchBox.Text + "%'";
                fingerData.DataSource = bs;
            }
        }

        private void searchBox_OnValueChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == metroTabPage1)
            {
                if (searchBox.Text == "")
                {
                    SqlDataAdapter pa = new SqlDataAdapter("select CONCAT(RESIDENT_LNAME,', ',RESIDENT_FNAME,' ',RESIDENT_MNAME) AS NAME,RESIDENT_AGE AS Age,RESIDENT_MARITAL AS Civil_Status, RESIDENT_GENDER AS Gender, RESIDENT_ID AS II from resident where family_id is not null and RESIDENT_IMAGE is null", Connection.con);

                    SqlCommandBuilder cd = new SqlCommandBuilder(pa);
                    DataTable dt = new DataTable();
                    pa.Fill(dt);
                    photoData.DataSource = dt;
                    photoData.AutoSizeColumnsMode =
                   DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            else if (metroTabControl1.SelectedTab == metroTabPage2)
            {
                if (searchBox.Text == "")
                {
                    SqlDataAdapter fa = new SqlDataAdapter("select CONCAT(RESIDENT_LNAME,', ',RESIDENT_FNAME,' ',RESIDENT_MNAME) AS NAME,RESIDENT_AGE AS Age,RESIDENT_MARITAL AS Civil_Status, RESIDENT_GENDER AS Gender, RESIDENT_ID AS II from resident where family_id is not null and RESIDENT_FINGERPRINT is null", Connection.con);
                    SqlCommandBuilder cf = new SqlCommandBuilder(fa);
                    DataTable dx = new DataTable();
                    fa.Fill(dx);
                    fingerData.DataSource = dx;
                    fingerData.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "Search";
                searchBox.ForeColor = Color.DarkGray;
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {

            if (searchBox.Text == "Search")
            {
                searchBox.Text = "";
                searchBox.ForeColor = Color.Black;
            }
        }

        string name;
        string pid;
        string fid;

        private void photoData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                pid = (photoData.Rows[e.RowIndex].Cells[4].Value.ToString());
                Connection con = new Connection();
                con.Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT CONCAT(RESIDENT_FNAME,' ',RESIDENT_MNAME,' ',RESIDENT_LNAME) AS NAME FROM RESIDENT WHERE RESIDENT_ID = '" + pid + "' ";
                cmd.Connection = Connection.con;
                cmd.ExecuteScalar();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    name = rdr["NAME"].ToString();
                }
                rdr.Close();

                PhotoUpdate pu = new PhotoUpdate();
                pu.FormName = this.name.Trim();
                pu.GetID = this.pid.Trim();


                pu.ShowDialog();

            }
        }

        private void fingerData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                fid = (fingerData.Rows[e.RowIndex].Cells[4].Value.ToString());
                Connection con = new Connection();
                con.Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT CONCAT(RESIDENT_FNAME,' ',RESIDENT_MNAME,' ',RESIDENT_LNAME) AS NAME FROM RESIDENT WHERE RESIDENT_ID = '" + fid + "' ";
                cmd.Connection = Connection.con;
                cmd.ExecuteScalar();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    name = rdr["NAME"].ToString();
                }
                rdr.Close();

                FingerUpdate fu = new FingerUpdate();
                fu.FormName = this.name.Trim();


                fu.ShowDialog();

            }
        }

        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            DisplayData();
        }
    }
}
