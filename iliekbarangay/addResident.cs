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
using AForge.Video;
using AForge.Video.DirectShow;
using DarrenLee.Media;
using System.IO;

namespace iliekbarangay
{
    public partial class addResident : UserControl, DPFP.Capture.EventHandler
    {
        private static addResident _instance;
        public static addResident Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new addResident();
                return _instance;
            }
        }

        public addResident()
        {
            InitializeComponent();
            myCamera.OnFrameArrived += MyCamera_OnFrameArrived;
            timer1.Start();
            Enroller = new DPFP.Processing.Enrollment();
            identification.Parent = addbody;
        }

        public Panel Body
        {
            get { return addbody; }
            set { addbody = value; }
        }

        private string fids;
        public String FID
        {
            get { return fids; }
            set { fids = value; }
        }

        private string ids;
        public String ID
        {
            get { return ids; }
            set { ids = value; }
        }

        public void DisplayID()
        {
            identification.Text = ID;
        }

        int count = 0;
        Camera myCamera = new Camera();


        DPFP.Capture.SampleConversion sp = new DPFP.Capture.SampleConversion();
        DPFP.Capture.Capture cp = new DPFP.Capture.Capture();
        DPFP.Sample sample = new DPFP.Sample();

        private DPFP.Processing.Enrollment Enroller;

        public delegate void OnTemplateEventHandler(DPFP.Template template);

        public event OnTemplateEventHandler OnTemplate;

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
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

        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {

            Image img = e.GetFrame();
            res_Image.Image = img;
        }

        private void saveResBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string healthStat = "";
                string healthProb = "";
                string vaccine = "";
                if (fname.Text == "" || lname.Text == "" || YrLvl.Text == "" || skill.Text == "")
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
                            SqlCommand cmdP = new SqlCommand();
                            SqlCommand cmdF = new SqlCommand();
                            SqlCommand cmdFP = new SqlCommand();
                            SqlCommand scmd = new SqlCommand();
                            cmd.CommandText = "INSERT INTO resident(RESIDENT_FNAME,RESIDENT_MNAME,RESIDENT_LNAME,RESIDENT_CNUM,RESIDENT_DOB,RESIDENT_CIVIL_REGESTERED,RESIDENT_MARITAL,RESIDENT_POSITION,RESIDENT_FAMILY_HEAD,RESIDENT_GENDER,RESIDENT_EDUC_STATUS,RESIDENT_EDUC_LVL,RESIDENT_EDUC_GRADE,RESIDENT_SPECIALSKILL,RESIDENT_SOURCE_OF_FUND,RESIDENT_JOB_TYPE,RESIDENT_INCOME,RESIDENT_HEALTH_PROBLEM,RESIDENT_HEALTH_STATUS,RESIDENT_VACCINE,RESIDENT_IMAGE,RESIDENT_FINGERPRINT,STAFF_ID,FAMILY_ID) " +
                                "VALUES(@fname,@mname,@lname,@cnum,@dob,@civilReg,@marital,@position,@head,@gender,@eduStatus,@eduLevel,@gradeLevel,@skill,@sof,@job,@income,@healthProb,@healthStat,@vaccine,@pic,@finger,@sid,@fid)";
                            

                            cmdP.CommandText = "INSERT INTO resident(RESIDENT_FNAME,RESIDENT_MNAME,RESIDENT_LNAME,RESIDENT_CNUM,RESIDENT_DOB,RESIDENT_CIVIL_REGESTERED,RESIDENT_MARITAL,RESIDENT_POSITION,RESIDENT_FAMILY_HEAD,RESIDENT_GENDER,RESIDENT_EDUC_STATUS,RESIDENT_EDUC_LVL,RESIDENT_EDUC_GRADE,RESIDENT_SPECIALSKILL,RESIDENT_SOURCE_OF_FUND,RESIDENT_JOB_TYPE,RESIDENT_INCOME,RESIDENT_HEALTH_PROBLEM,RESIDENT_HEALTH_STATUS,RESIDENT_VACCINE,RESIDENT_FINGERPRINT,STAFF_ID,FAMILY_ID) " +
                                "VALUES(@fname,@mname,@lname,@cnum,@dob,@civilReg,@marital,@position,@head,@gender,@eduStatus,@eduLevel,@gradeLevel,@skill,@sof,@job,@income,@healthProb,@healthStat,@vaccine,@finger,@sid,@fid)";

                            cmdF.CommandText = "INSERT INTO resident(RESIDENT_FNAME,RESIDENT_MNAME,RESIDENT_LNAME,RESIDENT_CNUM,RESIDENT_DOB,RESIDENT_CIVIL_REGESTERED,RESIDENT_MARITAL,RESIDENT_POSITION,RESIDENT_FAMILY_HEAD,RESIDENT_GENDER,RESIDENT_EDUC_STATUS,RESIDENT_EDUC_LVL,RESIDENT_EDUC_GRADE,RESIDENT_SPECIALSKILL,RESIDENT_SOURCE_OF_FUND,RESIDENT_JOB_TYPE,RESIDENT_INCOME,RESIDENT_HEALTH_PROBLEM,RESIDENT_HEALTH_STATUS,RESIDENT_VACCINE,RESIDENT_IMAGE,STAFF_ID,FAMILY_ID) " +
                                "VALUES(@fname,@mname,@lname,@cnum,@dob,@civilReg,@marital,@position,@head,@gender,@eduStatus,@eduLevel,@gradeLevel,@skill,@sof,@job,@income,@healthProb,@healthStat,@vaccine,@pic,@sid,@fid)";

                            cmdFP.CommandText = "INSERT INTO resident(RESIDENT_FNAME,RESIDENT_MNAME,RESIDENT_LNAME,RESIDENT_CNUM,RESIDENT_DOB,RESIDENT_CIVIL_REGESTERED,RESIDENT_MARITAL,RESIDENT_POSITION,RESIDENT_FAMILY_HEAD,RESIDENT_GENDER,RESIDENT_EDUC_STATUS,RESIDENT_EDUC_LVL,RESIDENT_EDUC_GRADE,RESIDENT_SPECIALSKILL,RESIDENT_SOURCE_OF_FUND,RESIDENT_JOB_TYPE,RESIDENT_INCOME,RESIDENT_HEALTH_PROBLEM,RESIDENT_HEALTH_STATUS,RESIDENT_VACCINE,STAFF_ID,FAMILY_ID) " +
                                "VALUES(@fname,@mname,@lname,@cnum,@dob,@civilReg,@marital,@position,@head,@gender,@eduStatus,@eduLevel,@gradeLevel,@skill,@sof,@job,@income,@healthProb,@healthStat,@vaccine,@sid,@fid)";

                            scmd.CommandText = "update resident set resident_age = datediff(YY, resident_dob,GETDATE())";
                            cmd.Connection = Connection.con;
                            cmdP.Connection = Connection.con;
                            cmdF.Connection = Connection.con;
                            cmdFP.Connection = Connection.con;
                            scmd.Connection = Connection.con;


                           
                            if (cnum.Text.Length > 11)
                            {
                                MessageBox.Show("Check your Contact Number!");
                                cnum.Focus();
                            }
                            else if (mi.Text.Length > 1)
                            {
                                MessageBox.Show("Initials should be 1 character!");
                                mi.Focus();
                            }
                            else if (DOB.Value >= DateTime.Now.AddYears(-2))
                            {
                                MessageBox.Show("System is available only for 3 years old and above!");
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
                            else if (fingerPrint1.Image == null && res_Image.Image == null)
                            {
                                try
                                {

                                    //MemoryStream stream = new MemoryStream();
                                    //fingerprint.Position = (0);
                                    //res_Image.Image = resizeImage(res_Image.Image, new Size(177, 151));
                                    //res_Image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    //byte[] pic = stream.ToArray();
                                    cmdFP.Parameters.AddWithValue("@fname", fname.Text);
                                    cmdFP.Parameters.AddWithValue("@mname", mi.Text);
                                    cmdFP.Parameters.AddWithValue("@lname", lname.Text);
                                    cmdFP.Parameters.AddWithValue("@cnum", cnum.Text);
                                    cmdFP.Parameters.AddWithValue("@dob", DOB.Value);
                                    cmdFP.Parameters.AddWithValue("@gender", gender.Text);
                                    cmdFP.Parameters.AddWithValue("@civilReg", civilRegStat.Text);
                                    cmdFP.Parameters.AddWithValue("@marital", maritalStatus.Text);
                                    cmdFP.Parameters.AddWithValue("@position", familyPos.Text);
                                    cmdFP.Parameters.AddWithValue("@head", familyHead.Text);
                                    cmdFP.Parameters.AddWithValue("@eduStatus", eduStat.Text);
                                    cmdFP.Parameters.AddWithValue("@eduLevel", eduLvl.Text);
                                    cmdFP.Parameters.AddWithValue("@gradeLevel", YrLvl.Text);
                                    cmdFP.Parameters.AddWithValue("@skill", skill.Text);
                                    cmdFP.Parameters.AddWithValue("@income", monthlyIncome.Text);
                                    cmdFP.Parameters.AddWithValue("@sof", sourceOfFund.Text);
                                    cmdFP.Parameters.AddWithValue("@job", jobType.Text);
                                    cmdFP.Parameters.AddWithValue("@healthProb", healthProb);
                                    cmdFP.Parameters.AddWithValue("@healthStat", healthStat);
                                    cmdFP.Parameters.AddWithValue("@vaccine", vaccine);
                                    //cmd.Parameters.AddWithValue("@finger", bytes);
                                    //cmd.Parameters.AddWithValue("@pic", pic);
                                    cmdFP.Parameters.AddWithValue("@sid", ID);
                                    cmdFP.Parameters.AddWithValue("@fid", FID);
                                    cmdFP.ExecuteNonQuery();
                                    scmd.ExecuteNonQuery();
                                    MessageBox.Show("Resident Added Successfully");

                                    FMPIclear();
                                    myCamera.Stop();
                                    res_Image.Image = null;
                                    fingerPrint1.Image = null;

                                    Reset();
                                    this.Controls.Clear();
                                    tab_residents tr = new tab_residents();
                                    this.Controls.Add(tr);
                                    // tr.ID = this.ID.Trim();
                                    tr.ID = ID.Trim();

                                    tr.Dock = DockStyle.Fill;
                                    tr.Show();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + ex.ToString());
                                    Reset();
                                }
                            }
                            else if (res_Image.Image == null)
                            {
                                if (prompts.Text != "Done.")
                                {
                                    MessageBox.Show("Unclear Fingerprint Captured!");
                                    Reset();
                                }
                                else
                                {
                                    UpdateStatus();
                                    switch (Enroller.TemplateStatus)
                                    {
                                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                                            {
                                                MemoryStream fingerprint = new MemoryStream();
                                                Enroller.Template.Serialize(fingerprint);
                                                fingerprint.Position = 0;
                                                BinaryReader br = new BinaryReader(fingerprint);
                                                byte[] bytes = br.ReadBytes((Int32)fingerprint.Length);

                                                try
                                                {

                                                    //MemoryStream stream = new MemoryStream();
                                                    //fingerprint.Position = (0);
                                                    //res_Image.Image = resizeImage(res_Image.Image, new Size(177, 151));
                                                    //res_Image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                                    //byte[] pic = stream.ToArray();
                                                    cmdP.Parameters.AddWithValue("@fname", fname.Text);
                                                    cmdP.Parameters.AddWithValue("@mname", mi.Text);
                                                    cmdP.Parameters.AddWithValue("@lname", lname.Text);
                                                    cmdP.Parameters.AddWithValue("@cnum", cnum.Text);
                                                    cmdP.Parameters.AddWithValue("@dob", DOB.Value);
                                                    cmdP.Parameters.AddWithValue("@gender", gender.Text);
                                                    cmdP.Parameters.AddWithValue("@civilReg", civilRegStat.Text);
                                                    cmdP.Parameters.AddWithValue("@marital", maritalStatus.Text);
                                                    cmdP.Parameters.AddWithValue("@position", familyPos.Text);
                                                    cmdP.Parameters.AddWithValue("@head", familyHead.Text);
                                                    cmdP.Parameters.AddWithValue("@eduStatus", eduStat.Text);
                                                    cmdP.Parameters.AddWithValue("@eduLevel", eduLvl.Text);
                                                    cmdP.Parameters.AddWithValue("@gradeLevel", YrLvl.Text);
                                                    cmdP.Parameters.AddWithValue("@skill", skill.Text);
                                                    cmdP.Parameters.AddWithValue("@income", monthlyIncome.Text);
                                                    cmdP.Parameters.AddWithValue("@sof", sourceOfFund.Text);
                                                    cmdP.Parameters.AddWithValue("@job", jobType.Text);
                                                    cmdP.Parameters.AddWithValue("@healthProb", healthProb);
                                                    cmdP.Parameters.AddWithValue("@healthStat", healthStat);
                                                    cmdP.Parameters.AddWithValue("@vaccine", vaccine);
                                                    cmdP.Parameters.AddWithValue("@finger", bytes);
                                                    //cmdP.Parameters.AddWithValue("@pic", pic);
                                                    cmdP.Parameters.AddWithValue("@sid", ID);
                                                    cmdP.Parameters.AddWithValue("@fid", FID);
                                                    cmdP.ExecuteNonQuery();
                                                    scmd.ExecuteNonQuery();
                                                    MessageBox.Show("Resident Added Successfully");

                                                    FMPIclear();
                                                    myCamera.Stop();
                                                    res_Image.Image = null;
                                                    fingerPrint1.Image = null;

                                                    Reset();
                                                    this.Controls.Clear();
                                                    tab_residents tr = new tab_residents();
                                                    this.Controls.Add(tr);
                                                    // tr.ID = this.ID.Trim();
                                                    tr.ID = ID.Trim();

                                                    tr.Dock = DockStyle.Fill;
                                                    tr.Show();

                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message + ex.ToString());
                                                    Reset();
                                                }
                                                break;
                                            }

                                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                                            {
                                                Enroller.Clear();
                                                cp.StopCapture();
                                                UpdateStatus();
                                                OnTemplate(null);
                                                cp.StartCapture();
                                                break;
                                            }
                                    }
                                }


                            }
                            else if (fingerPrint1.Image == null)
                            {
                                try
                                {

                                    MemoryStream stream = new MemoryStream();
                                    //fingerprint.Position = (0);
                                    res_Image.Image = resizeImage(res_Image.Image, new Size(177, 151));
                                    res_Image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    byte[] pic = stream.ToArray();
                                    cmdF.Parameters.AddWithValue("@fname", fname.Text);
                                    cmdF.Parameters.AddWithValue("@mname", mi.Text);
                                    cmdF.Parameters.AddWithValue("@lname", lname.Text);
                                    cmdF.Parameters.AddWithValue("@cnum", cnum.Text);
                                    cmdF.Parameters.AddWithValue("@dob", DOB.Value);
                                    cmdF.Parameters.AddWithValue("@gender", gender.Text);
                                    cmdF.Parameters.AddWithValue("@civilReg", civilRegStat.Text);
                                    cmdF.Parameters.AddWithValue("@marital", maritalStatus.Text);
                                    cmdF.Parameters.AddWithValue("@position", familyPos.Text);
                                    cmdF.Parameters.AddWithValue("@head", familyHead.Text);
                                    cmdF.Parameters.AddWithValue("@eduStatus", eduStat.Text);
                                    cmdF.Parameters.AddWithValue("@eduLevel", eduLvl.Text);
                                    cmdF.Parameters.AddWithValue("@gradeLevel", YrLvl.Text);
                                    cmdF.Parameters.AddWithValue("@skill", skill.Text);
                                    cmdF.Parameters.AddWithValue("@income", monthlyIncome.Text);
                                    cmdF.Parameters.AddWithValue("@sof", sourceOfFund.Text);
                                    cmdF.Parameters.AddWithValue("@job", jobType.Text);
                                    cmdF.Parameters.AddWithValue("@healthProb", healthProb);
                                    cmdF.Parameters.AddWithValue("@healthStat", healthStat);
                                    cmdF.Parameters.AddWithValue("@vaccine", vaccine);
                                    //cmdF.Parameters.AddWithValue("@finger", bytes);
                                    cmdF.Parameters.AddWithValue("@pic", pic);
                                    cmdF.Parameters.AddWithValue("@sid", ID);
                                    cmdF.Parameters.AddWithValue("@fid", FID);
                                    cmdF.ExecuteNonQuery();
                                    scmd.ExecuteNonQuery();
                                    MessageBox.Show("Resident Added Successfully");

                                    FMPIclear();
                                    myCamera.Stop();
                                    res_Image.Image = null;
                                    fingerPrint1.Image = null;

                                    Reset();
                                    this.Controls.Clear();
                                    tab_residents tr = new tab_residents();
                                    this.Controls.Add(tr);
                                    // tr.ID = this.ID.Trim();
                                    tr.ID = ID.Trim();

                                    tr.Dock = DockStyle.Fill;
                                    tr.Show();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + ex.ToString());
                                    Reset();
                                }
                            }
                          
                            else
                            {
                                if (prompts.Text != "Done.")
                                {
                                    MessageBox.Show("Unclear Fingerprint Captured!");
                                    Reset();
                                }
                                else
                                {
                                    UpdateStatus();
                                    switch (Enroller.TemplateStatus)
                                    {
                                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                                            {


                                                //  byte[] btarr = null;
                                                // Enroller.Template.Serialize(ref btarr);
                                                MemoryStream fingerprint = new MemoryStream();
                                                Enroller.Template.Serialize(fingerprint);
                                                fingerprint.Position = 0;
                                                BinaryReader br = new BinaryReader(fingerprint);
                                                byte[] bytes = br.ReadBytes((Int32)fingerprint.Length);



                                                try
                                                {

                                                    MemoryStream stream = new MemoryStream();
                                                    fingerprint.Position = (0);
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
                                                    cmd.Parameters.AddWithValue("@finger", bytes);
                                                    cmd.Parameters.AddWithValue("@pic", pic);
                                                    cmd.Parameters.AddWithValue("@sid", ID);
                                                    cmd.Parameters.AddWithValue("@fid", FID);
                                                    cmd.ExecuteNonQuery();
                                                    scmd.ExecuteNonQuery();
                                                    MessageBox.Show("Resident Added Successfully");

                                                    FMPIclear();
                                                    myCamera.Stop();
                                                    res_Image.Image = null;
                                                    fingerPrint1.Image = null;

                                                    Reset();
                                                    this.Controls.Clear();
                                                    tab_residents tr = new tab_residents();
                                                    this.Controls.Add(tr);
                                                    // tr.ID = this.ID.Trim();
                                                    tr.ID = ID.Trim();

                                                    tr.Dock = DockStyle.Fill;
                                                    tr.Show();

                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message + ex.ToString());
                                                    Reset();
                                                }
                                                break;
                                            }

                                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                                            {
                                                Enroller.Clear();
                                                cp.StopCapture();
                                                UpdateStatus();
                                                OnTemplate(null);
                                                cp.StartCapture();
                                                break;
                                            }
                                    }

                                }

                            }


                        }

                        else
                        {
                            MessageBox.Show("Dont leave empty spaces");
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

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            try
            {
                Connection con = new Connection();
                con.Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select resident_fingerprint from resident where resident_fingerprint is not null";
                cmd.Connection = Connection.con;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    byte[] _img = (byte[])dr["resident_fingerprint"];
                    //string id = dr["RESIDENT_ID"].ToString();                                                         
                    MemoryStream ms = new MemoryStream(_img);
                    DPFP.Template Template = new DPFP.Template();
                    Template.DeSerialize(ms);
                    DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();

                    //Process(Sample);

                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                    if (features != null)
                    {
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verificator.Verify(features, Template, ref result);
                        // UpdateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            MessageBox.Show("This Resident is already Registered!!!");
                            Reset();
                            FMPIclear();
                            break;

                        }
                        else if (scans.Text != "0 scans left")
                        {
                            MakeReport("fingerprint captured.");
                            SetPrompt("Scan fingerprint again");
                            Process(Sample);
                        }
                        else
                        {
                            cp.StopCapture();
                            break;
                        }


                    }
                    else
                    {

                    }

                }
            }
            catch
            {

            }

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("fingerprint removed.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumbe)
        {
            MakeReport("fingerprint reader touched.");

        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("fingerprint reader connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("fingerprint reader disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MessageBox.Show("Good");
            else
                MessageBox.Show("Bad");
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            myCamera.Start();
            takePhotoBtn.Visible = true;
            takePhotoBtn.BringToFront();
            openCamera.Visible = false;
            openCamera.SendToBack();
        }

        private void takePhotoBtn_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\" + "Image" + count.ToString();
            myCamera.Capture(filename);
            count++;
            myCamera.Stop();
            takePhotoBtn.Visible = false;
            takePhotoBtn.SendToBack();
            openCamera.Visible = true;
            openCamera.BringToFront();
            MessageBox.Show("Image Captured");
            openCamera.Focus();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            FMPIclear();
            this.Refresh();
            Reset();
            this.Controls.Clear();
            tab_residents tr = new tab_residents();
            this.Controls.Add(tr);
            // tr.ID = this.ID.Trim();
            tr.ID = ID.Trim();
            
            tr.Dock = DockStyle.Fill;
            tr.Show();
        }

        private void fingerSave_Click(object sender, EventArgs e)
        {
            cp.StartCapture();
            cp.EventHandler = this;
        }
        public void Reset()
        {
            Enroller.Clear();
            UpdateStatus();
            SetPrompt("Give fingerprint samples again.");
            fingerPrint1.Image = null;
            cp.StopCapture();
        }

        private void UpdateStatus()
        {
            // Show number of samples needed.
            SetStatus(String.Format("{0} scans left", Enroller.FeaturesNeeded));
        }
        protected void SetStatus(string status)
        {
            this.Invoke((Action)(delegate ()
            {
                scans.Text = status;
            }));
        }

        public void SetPrompt(string prompt)
        {
            this.Invoke((Action)(delegate () {
                prompts.Text = prompt;
            }));
        }

        protected void MakeReport(string message)
        {
            this.Invoke((Action)(delegate ()
            {
                StatusLine.Text = message;
            }));
        }

        public void DrawPicture(Bitmap bitmap)
        {
            this.Invoke((Action)(delegate ()
            {
                fingerPrint1.Image = new Bitmap(bitmap, fingerPrint1.Size);
            }));
        }
        protected virtual void Process(DPFP.Sample Sample)
        {
            // draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            DPFP.Capture.SampleConversion ToByte = new DPFP.Capture.SampleConversion();


            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);

                }
                finally
                {
                    UpdateStatus();


                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                                                                        //OnTemplate(Enroller.Template);

                            SetPrompt("Done.");


                            cp.StopCapture();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            cp.StopCapture();
                            UpdateStatus();
                            // OnTemplate(null);
                            cp.StartCapture();
                            break;
                    }

                }
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();
            Bitmap bitmap = null;
            Convertor.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
    }
}
