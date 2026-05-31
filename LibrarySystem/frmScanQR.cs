using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace LibrarySystem
{
    public partial class frmScanQR : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        public string QRCodeValue = "";
        public Image QRImage { get; set; }
        private bool isProcessing = false;
        private DateTime lastScanTime = DateTime.MinValue;
       // private Bitmap currentFrame;
        public frmScanQR()
        {
            InitializeComponent();
        }

        private void frmScanQR_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (filterInfoCollection.Count == 0)
            {
                MessageBox.Show("No camera detected!");
                return;
            }

            captureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);

            // use lower resolution para mas paspas mo scan
            if (captureDevice.VideoCapabilities.Length > 0)
            {
                captureDevice.VideoResolution = captureDevice.VideoCapabilities[0];
            }

            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
        }
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

                picCamera.Invoke(new MethodInvoker(delegate
                {
                    if (picCamera.Image != null)
                    {
                        picCamera.Image.Dispose();
                    }

                    picCamera.Image = (Bitmap)frame.Clone();
                    picCamera.SizeMode = PictureBoxSizeMode.Zoom;
                }));

                // scan every 300ms only
                if ((DateTime.Now - lastScanTime).TotalMilliseconds < 300)
                {
                    frame.Dispose();
                    return;
                }

                lastScanTime = DateTime.Now;

                if (!isProcessing)
                {
                    isProcessing = true;
                    ScanFrame(frame);
                }
                else
                {
                    frame.Dispose();
                }
            }
            catch
            {
            }
        }

        private void ScanFrame(Bitmap frame)
        {
            try
            {
                BarcodeReader reader = new BarcodeReader
                {
                    AutoRotate = true,
                    TryInverted = true,
                    Options = new ZXing.Common.DecodingOptions
                    {
                        TryHarder = true,
                        PossibleFormats = new List<BarcodeFormat>
                {
                    BarcodeFormat.QR_CODE
                }
                    }
                };

                Result result = reader.Decode(frame);

                if (result != null)
                {
                    QRCodeValue = result.Text;
                    QRImage = (Bitmap)frame.Clone();

                    StopCamera();

                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
            }
            catch
            {
            }
            finally
            {
                frame.Dispose();
                isProcessing = false;
            }
        }

       
        private void StopCamera()
        {
            try
            {
                if (captureDevice != null && captureDevice.IsRunning)
                {
                    captureDevice.NewFrame -= CaptureDevice_NewFrame;
                    captureDevice.SignalToStop();
                }

                captureDevice = null;
            }
            catch
            {
            }
        }
        private void frmScanQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void picCamera_Click(object sender, EventArgs e)
        {

        }
    }
}