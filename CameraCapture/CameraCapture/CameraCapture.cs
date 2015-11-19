using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace CameraCapture
{
    public partial class CameraCapture : Form
    {
        //declaring global variables
        private List<Capture> captures = new List<Capture>();
        private int cameras = 3;
        private bool captureInProgress;
        private bool saveToFile;

        private string saveToPath = @"C:\tmp\";
        private int frameWidth = 640;
        private int frameHeight = 480;
        private int fps = 1;

        public CameraCapture()
        {
            //initialize user settings
            saveToPath = Properties.Settings.Default.OutputPath;
            frameWidth = Properties.Settings.Default.FrameSize.Width;
            frameHeight = Properties.Settings.Default.FrameSize.Height;
            fps = Properties.Settings.Default.Fps;

            InitializeComponent();
        }
        //------------------------------------------------------------------------------//
        //Process Frame() below is our user defined function in which we will create an EmguCv 
        //type image called ImageFrame. capture a frame from camera and allocate it to our 
        //ImageFrame. then show this image in ourEmguCV imageBox
        //------------------------------------------------------------------------------//
        private void ProcessFrame(object sender, EventArgs arg)
        {
            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var cameraIndex = 0;

            foreach (var capture in captures)
            {
                Mat imageFrame = capture.QueryFrame();
                if (imageFrame != null)
                {
                    if (saveToFile)
                    {
                        imageFrame.Save(String.Concat(saveToPath, timeStamp, "_cam_", cameraIndex.ToString(), ".jpg"));
                    }

                    Emgu.CV.UI.ImageBox imgBox = null;
                    if (cameraIndex == 0) imgBox = CamImageBox0;
                    if (cameraIndex == 1) imgBox = CamImageBox1;
                    if (cameraIndex == 2) imgBox = CamImageBox2;
                    if (cameraIndex == 3) imgBox = CamImageBox3;

                    if (imgBox != null)
                    {
                        Mat resizedImage = new Mat(imageFrame, new Rectangle(new Point(0,0), imgBox.Size));
                        CvInvoke.Resize(imageFrame, resizedImage, imgBox.Size);
                        imgBox.Image = resizedImage;
                    }
                }
                cameraIndex++;
            }

            if (saveToFile)
            {
                saveToFile = !saveToFile;
            }
        }

        //btnStart_Click() function is the one that handles our "Start!" button' click 
        //event. it creates a new capture object if its not created already. e.g at first time
        //starting. once the capture is created, it checks if the capture is still in progress,
        //if so the
        private void btnStart_Click(object sender, EventArgs e)
        {
            #region if capture is not created, create it now
            if (captures.Count == 0)
            {
                try
                {
                    for (var cameraIndex = 0; cameraIndex < cameras; cameraIndex++)
                    {
                        var capture = new Capture(cameraIndex);
                        capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, fps);
                        capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, frameHeight);
                        capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, frameWidth);

                        captures.Add(capture);
                    }
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (captures.Count > 0)
            {
                if (captureInProgress)
                {  //if camera is getting frames then stop the capture and set button Text
                   // "Start" for resuming capture
                    btnStart.Text = "Start!"; //
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    btnStart.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }

                captureInProgress = !captureInProgress;
            }
        }

        private void ReleaseData()
        {
            if (captures.Count > 0)
            {
                foreach (var capture in captures)
                {
                    capture.Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveToFile = !saveToFile;
        }

        private void CameraCapture_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip btnSaveToolTip = new System.Windows.Forms.ToolTip();
            btnSaveToolTip.SetToolTip(this.btnSavePath, saveToPath);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select path to save images";
            folderBrowserDialog1.SelectedPath = saveToPath;

            DialogResult dialogresult = folderBrowserDialog1.ShowDialog();

            if (dialogresult == DialogResult.OK && saveToPath != folderBrowserDialog1.SelectedPath)
            {
                saveToPath = folderBrowserDialog1.SelectedPath;

                Properties.Settings.Default.OutputPath = saveToPath;
                Properties.Settings.Default.Save();
            }
        }
    }
}