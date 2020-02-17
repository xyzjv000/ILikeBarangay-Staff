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
using DarrenLee.Media;
using System.IO;

namespace iliekbarangay
{
    public partial class EditResident : UserControl
    {
        private static EditResident _instance;
        public static EditResident Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EditResident();
                return _instance;
            }
        }
        private String ids;
        public String ID
        {
            get { return ids; }
            set { ids = value; }
        }

        private String rids;
        public String RID
        {
            get { return rids; }
            set { rids = value; }
        }

        Camera myCamera = new Camera();//Camera 
        int count = 0;
        string pasd;
        byte[] imageBytes;
        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            res_Image.Image = img;
        }

        public EditResident()
        {
            InitializeComponent();
            myCamera.OnFrameArrived += MyCamera_OnFrameArrived;
            myCamera.Stop();
        }

        public void DisplayID()
        {
            this.identification.Text = ID;
        }

        


        public void DisplayData()
        {
            Connection con = new Connection();
            con.Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Resident where RESIDENT_ID = '" + RID + "'";
            cmd.Connection = Connection.con;

            DataTable dt = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                try
                {
                    fname.Text = reader["RESIDENT_FNAME"].ToString();
                    lname.Text = reader["RESIDENT_LNAME"].ToString();
                    mi.Text = reader["RESIDENT_MNAME"].ToString();
                    cnum.Text = reader["RESIDENT_CNUM"].ToString();
                    DOB.Value = Convert.ToDateTime(reader["RESIDENT_DOB"]);
                    gender.Text = reader["RESIDENT_GENDER"].ToString();
                    civilRegStat.Text = reader["RESIDENT_CIVIL_REGESTERED"].ToString();
                    maritalStatus.Text = reader["RESIDENT_MARITAL"].ToString();
                    familyPos.Text = reader["RESIDENT_POSITION"].ToString();
                    familyHead.Text = reader["RESIDENT_FAMILY_HEAD"].ToString();
                    eduStat.Text = reader["RESIDENT_EDUC_STATUS"].ToString();
                    eduLvl.Text = reader["RESIDENT_EDUC_LVL"].ToString();
                    YrLvl.Text = reader["RESIDENT_EDUC_GRADE"].ToString();
                    skill.Text = reader["RESIDENT_SPECIALSKILL"].ToString();
                    sourceOfFund.Text = reader["RESIDENT_SOURCE_OF_FUND"].ToString();
                    jobType.Text = reader["RESIDENT_JOB_TYPE"].ToString();
                    monthlyIncome.Text = reader["RESIDENT_INCOME"].ToString();
                    imageBytes = reader["RESIDENT_IMAGE"] as byte[];

                    //Health Problem cheked item
                    string[] s = new string[] { };
                    s = reader["RESIDENT_HEALTH_PROBLEM"].ToString().Split(',');
                    int length = s.Length;
                    for(int i = 0; i < length; i++)
                    {
                        string fetr = s[i];
                        for (int j = 0; j <= healthProblems.Items.Count ; j++)
                        {
                            if (healthProblems.Items[j].ToString() == s[i])
                            {
                                healthProblems.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }
                    //end of health problem


                    //health status checked item
                    string[] s2 = new string[] { };
                    s2 = reader["RESIDENT_HEALTH_STATUS"].ToString().Split(',');
                    int length2 = s2.Length;
                    for (int i = 0; i < length2; i++)
                    {
                        string fetr = s2[i];
                        for (int j = 0; j <= healthStatus.Items.Count; j++)
                        {
                            if (healthStatus.Items[j].ToString() == s2[i])
                            {
                                healthStatus.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }
                    //end of health status 


                    //vacine checked item
                    string[] s3 = new string[] { };
                    s3 = reader["RESIDENT_VACCINE"].ToString().Split(',');
                    int length3 = s3.Length;
                    for (int i = 0; i < length3; i++)
                    {
                        string fetr = s3[i];
                        for (int j = 0; j <= vaccineTaken.Items.Count; j++)
                        {
                            if (vaccineTaken.Items[j].ToString() == s3[i])
                            {
                                vaccineTaken.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }
                    //end of vacine

                    if (imageBytes != null)
                    {
                        using (var stream = new MemoryStream(imageBytes))
                            res_Image.Image = Image.FromStream(stream);

                    }

                }
                catch
                {

                }
                reader.Close();
            }
            else
            {

            }
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            myCamera.Start();
            openCamera.Visible = false;
            openCamera.SendToBack();
            takePhotoBtn.Visible = true;
            takePhotoBtn.BringToFront();
        }

        private void takePhotoBtn_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\" + "Image" + count.ToString();
            myCamera.Capture(filename);
            count++;
            myCamera.Stop();
            MessageBox.Show("Image Captured !");
            openCamera.Visible = true;
            openCamera.BringToFront();
            takePhotoBtn.Visible = false;
            takePhotoBtn.SendToBack();
        }
        public void FMPIclear()
        {//Clearing Fields for registration.
            fname.Text = null;
            lname.Text = null;
            mi.Text = null;
            cnum.Text = null;
            DOB.Value = DateTime.Now;
            gender.Text = null;
            civilRegStat.Text = null;
            maritalStatus.Text = null;
            familyPos.Text = null;
            eduStat.Text = null;
            eduLvl.Text = null;
            sourceOfFund.Text = null;
            jobType.Text = null;
            monthlyIncome.Text = null;
            familyHead.Text = null;
            YrLvl.Text = null;
            skill.Text = null;
            while (healthProblems.CheckedIndices.Count > 0)
            {
                healthProblems.SetItemChecked(healthProblems.CheckedIndices[0], false);
            }
            while (vaccineTaken.CheckedIndices.Count > 0)
            {
                vaccineTaken.SetItemChecked(vaccineTaken.CheckedIndices[0], false);
            }
            while (healthStatus.CheckedIndices.Count > 0)
            {
                healthStatus.SetItemChecked(healthStatus.CheckedIndices[0], false);
            }
            res_Image.Image = null;

        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            FMPIclear();
            this.Refresh();
            this.Controls.Clear();
            tab_residents tr = new tab_residents();
            this.Controls.Add(tr);
            // tr.ID = this.ID.Trim();
            tr.ID = ID.Trim();
            tr.Dock = DockStyle.Fill;
            tr.Show();
        }

        private void FMPI_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveResBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string healthStat = "";
                string healthProb = "";
                string vaccine = "";
                if (fname.Text == "" || lname.Text == "")
                {
                    MessageBox.Show("Please fill up all forms");
                }
                else
                {
                    try
                    {
                        if (healthProblems.CheckedItems.Count > 0 && healthStatus.CheckedItems.Count > 0 && vaccineTaken.CheckedItems.Count > 0)
                        {
                            for (int i = 0; i < healthProblems.CheckedItems.Count; i++)
                            {
                                if (healthProb == "")
                                {
                                    healthProb = healthProblems.CheckedItems[i].ToString();
                                }
                                else
                                {
                                    healthProb += ", " + healthProblems.CheckedItems[i].ToString();
                                }
                            }
                            for (int i = 0; i < healthStatus.CheckedItems.Count; i++)
                            {
                                if (healthStat == "")
                                {
                                    healthStat = healthStatus.CheckedItems[i].ToString();
                                }
                                else
                                {
                                    healthStat += ", " + healthStatus.CheckedItems[i].ToString();
                                }
                            }
                            for (int i = 0; i < vaccineTaken.CheckedItems.Count; i++)
                            {
                                if (vaccine == "")
                                {
                                    vaccine = vaccineTaken.CheckedItems[i].ToString();
                                }
                                else
                                {
                                    vaccine += ", " + vaccineTaken.CheckedItems[i].ToString();
                                }
                            }
                            Connection con = new Connection();
                            con.Connect();
                            SqlCommand cmd = new SqlCommand();
                            SqlCommand cmd2 = new SqlCommand();
                            SqlCommand scmd = new SqlCommand();

                            cmd2.CommandText = "UPDATE RESIDENT SET RESIDENT_FNAME = @fname,RESIDENT_MNAME = @mname,RESIDENT_LNAME = @lname ,RESIDENT_CNUM = @cnum,RESIDENT_DOB = @dob,RESIDENT_CIVIL_REGESTERED = @civilReg,RESIDENT_MARITAL =@marital ,RESIDENT_POSITION =@position,RESIDENT_FAMILY_HEAD = @head,RESIDENT_GENDER = @gender,RESIDENT_EDUC_STATUS=@eduStatus ,RESIDENT_EDUC_LVL =@eduLevel,RESIDENT_EDUC_GRADE=@gradeLevel,RESIDENT_SPECIALSKILL =@skill,RESIDENT_SOURCE_OF_FUND = @sof ,RESIDENT_JOB_TYPE = @job,RESIDENT_INCOME = @income,RESIDENT_HEALTH_PROBLEM = @healthProb ,RESIDENT_HEALTH_STATUS = @healthStat,RESIDENT_VACCINE = @vaccine ,STAFF_ID = @sid WHERE RESIDENT_ID = '" + RID + "' ";

                            cmd.CommandText = "UPDATE RESIDENT SET RESIDENT_FNAME = @fname,RESIDENT_MNAME = @mname,RESIDENT_LNAME = @lname ,RESIDENT_CNUM = @cnum,RESIDENT_DOB = @dob,RESIDENT_CIVIL_REGESTERED = @civilReg,RESIDENT_MARITAL =@marital ,RESIDENT_POSITION =@position,RESIDENT_FAMILY_HEAD = @head,RESIDENT_GENDER = @gender,RESIDENT_EDUC_STATUS=@eduStatus ,RESIDENT_EDUC_LVL =@eduLevel,RESIDENT_EDUC_GRADE=@gradeLevel,RESIDENT_SPECIALSKILL =@skill,RESIDENT_SOURCE_OF_FUND = @sof ,RESIDENT_JOB_TYPE = @job,RESIDENT_INCOME = @income,RESIDENT_HEALTH_PROBLEM = @healthProb ,RESIDENT_HEALTH_STATUS = @healthStat,RESIDENT_VACCINE = @vaccine,RESIDENT_IMAGE = @pic ,STAFF_ID = @sid WHERE RESIDENT_ID = '" + RID + "' ";


                            scmd.CommandText = "update resident set resident_age = datediff(YY, resident_dob,GETDATE())";
                            cmd.Connection = Connection.con;
                            cmd2.Connection = Connection.con;
                            scmd.Connection = Connection.con;

                            if(cnum.Text.Length > 11)
                            {
                                MessageBox.Show("Check your Contact Number!");
                                cnum.Focus();
                            }
                            else if (DOB.Value >= DateTime.Now)
                            {
                                MessageBox.Show("Check your Date of Birth!");
                            }
                            else if (mi.Text.Length > 1)
                            {
                                MessageBox.Show("Initials should be 1 character!");
                                mi.Focus();
                            }
                            else if (healthStatus.CheckedItems.Count >= 2)
                            {
                                MessageBox.Show("Only choose 1 health status!");
                                healthStatus.Focus();
                            }
                            else if (healthProblems.CheckedItems.Count > 3)
                            {
                                MessageBox.Show("Only choose 5 health problems!");
                                healthProblems.Focus();
                            }
                            else if (res_Image.Image == null)
                            {
                                cmd2.Parameters.AddWithValue("@fname", fname.Text);
                                cmd2.Parameters.AddWithValue("@mname", mi.Text);
                                cmd2.Parameters.AddWithValue("@lname", lname.Text);
                                cmd2.Parameters.AddWithValue("@cnum", cnum.Text);
                                cmd2.Parameters.AddWithValue("@dob", DOB.Value);
                                cmd2.Parameters.AddWithValue("@gender", gender.Text);
                                cmd2.Parameters.AddWithValue("@civilReg", civilRegStat.Text);
                                cmd2.Parameters.AddWithValue("@marital", maritalStatus.Text);
                                cmd2.Parameters.AddWithValue("@position", familyPos.Text);
                                cmd2.Parameters.AddWithValue("@head", familyHead.Text);
                                cmd2.Parameters.AddWithValue("@eduStatus", eduStat.Text);
                                cmd2.Parameters.AddWithValue("@eduLevel", eduLvl.Text);
                                cmd2.Parameters.AddWithValue("@gradeLevel", YrLvl.Text);
                                cmd2.Parameters.AddWithValue("@skill", skill.Text);
                                cmd2.Parameters.AddWithValue("@income", monthlyIncome.Text);
                                cmd2.Parameters.AddWithValue("@sof", sourceOfFund.Text);
                                cmd2.Parameters.AddWithValue("@job", jobType.Text);
                                cmd2.Parameters.AddWithValue("@healthProb", healthProb);
                                cmd2.Parameters.AddWithValue("@healthStat", healthStat);
                                cmd2.Parameters.AddWithValue("@vaccine", vaccine);
                                cmd2.Parameters.AddWithValue("@sid", ID);

                                cmd2.ExecuteNonQuery();
                                scmd.ExecuteNonQuery();
                                MessageBox.Show("Saved");
                                FMPIclear();
                                this.Refresh();
                                myCamera.Stop();
                                this.Controls.Clear();
                                tab_residents tr = new tab_residents();
                                this.Controls.Add(tr);
                                // tr.ID = this.ID.Trim();
                                tr.ID = ID.Trim();
                                tr.Dock = DockStyle.Fill;
                                tr.Show();
                            }
                            else
                            {
                                MemoryStream stream = new MemoryStream();
                                res_Image.Image = resizeImage(res_Image.Image, new Size(177, 151));
                                res_Image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                //fingerPrint1.Image.Save(fingerprint, System.Drawing.Imaging.ImageFormat.Jpeg);
                                byte[] pic = stream.ToArray();
                                // byte[] fic = br.ReadBytes((Int32)fingerprint.Length);
                                cmd.Parameters.AddWithValue("@fname", fname.Text);
                                cmd.Parameters.AddWithValue("@mname", mi.Text);
                                cmd.Parameters.AddWithValue("@lname", lname.Text);
                                cmd.Parameters.AddWithValue("@cnum", cnum.Text);
                                cmd.Parameters.AddWithValue("@dob", DOB.Value);
                                cmd.Parameters.AddWithValue("@gender", gender.Text);
                                cmd.Parameters.AddWithValue("@civilReg", civilRegStat.Text);
                                cmd.Parameters.AddWithValue("@marital", maritalStatus.Text);
                                cmd.Parameters.AddWithValue("@position", familyPos.Text);
                                cmd.Parameters.AddWithValue("@head", familyHead.Text);
                                cmd.Parameters.AddWithValue("@eduStatus", eduStat.Text);
                                cmd.Parameters.AddWithValue("@eduLevel", eduLvl.Text);
                                cmd.Parameters.AddWithValue("@gradeLevel", YrLvl.Text);
                                cmd.Parameters.AddWithValue("@skill", skill.Text);
                                cmd.Parameters.AddWithValue("@income", monthlyIncome.Text);
                                cmd.Parameters.AddWithValue("@sof", sourceOfFund.Text);
                                cmd.Parameters.AddWithValue("@job", jobType.Text);
                                cmd.Parameters.AddWithValue("@healthProb", healthProb);
                                cmd.Parameters.AddWithValue("@healthStat", healthStat);
                                cmd.Parameters.AddWithValue("@vaccine", vaccine);
                                cmd.Parameters.AddWithValue("@pic", pic);
                                cmd.Parameters.AddWithValue("@sid", ID);

                                cmd.ExecuteNonQuery();
                                scmd.ExecuteNonQuery();
                                MessageBox.Show("Saved");
                                FMPIclear();
                                this.Refresh();
                                myCamera.Stop();
                                this.Controls.Clear();
                                tab_residents tr = new tab_residents();
                                this.Controls.Add(tr);
                                // tr.ID = this.ID.Trim();
                                tr.ID = ID.Trim();
                                tr.Dock = DockStyle.Fill;
                                tr.Show();
                            }

                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.ToString());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
               
            }
        }
    }
    
}
