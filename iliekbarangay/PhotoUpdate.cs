using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DarrenLee.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace iliekbarangay
{
    public partial class PhotoUpdate : Form
    {
        public PhotoUpdate()
        {
            InitializeComponent();
            myCamera.OnFrameArrived += MyCamera_OnFrameArrived;
            capture.Visible = false;
            capture.SendToBack();
            openCam.Visible = true;
            openCam.BringToFront();
        }

        int count = 0;
        Camera myCamera = new Camera();
       

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            resImage.Image = img;
        }

        public String FormName
        {
            get { return formName.Text; }
            set { formName.Text = value; }
        }

        public String GetID
        {
            get { return id.Text; }
            set { id.Text = value; }
        }

        private void clsBtn_Click(object sender, EventArgs e)
        {
            myCamera.Stop();
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            myCamera.Start();
            capture.Visible = true;
            capture.BringToFront();
            openCam.Visible = false;
            openCam.SendToBack();
        }

        private void capture_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\" + "Image" + count.ToString();
            myCamera.Capture(filename);
            count++;
            myCamera.Stop();
            capture.Visible = false;
            capture.SendToBack();
            openCam.Visible = true;
            openCam.BringToFront();
            MessageBox.Show("Image Captured");
            openCam.Focus();
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE RESIDENT SET RESIDENT_IMAGE = @pic WHERE RESIDENT_ID = '" + id.Text.Trim() + "'";
                cmd.Connection = Connection.con;
                MemoryStream stream = new MemoryStream();

                if(resImage.Image != null)
                {
                    resImage.Image = resizeImage(resImage.Image, new Size(177, 151));
                    resImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    cmd.Parameters.AddWithValue("@pic", pic);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Resident Image has beed saved!");
                    tab_update.Instance.DisplayData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please take a Photo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
                myCamera.Stop();
            }
        }
    }
}
