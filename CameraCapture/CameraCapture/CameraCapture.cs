using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace CameraCapture
{
    public partial class CameraCapture : Form
    {
        //declaring global variables
        //private Capture capture;        //takes images from camera as image frames
        private List<Capture> captures = new List<Capture>();
        private int cameras = 3;
        private bool captureInProgress;
        private bool saveToFile;

        private string saveToPath = @"C:\tmp\";
        private int frameWidth = 1280;
        private int frameHeight = 720;
        private int fps = 1;

        public CameraCapture()
        {
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
                Mat ImageFrame = capture.QueryFrame();
                if (cameraIndex == 0) CamImageBox0.Image = ImageFrame;
                if (cameraIndex == 1) CamImageBox1.Image = ImageFrame;
                if (cameraIndex == 2) CamImageBox2.Image = ImageFrame;
                if (saveToFile)
                {
                    ImageFrame.Save(String.Concat(saveToPath, timeStamp, "_cam_", cameraIndex.ToString(), ".jpg"));
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
                foreach(var capture in captures)
                {
                    capture.Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveToFile = !saveToFile;
        }
    }
}
