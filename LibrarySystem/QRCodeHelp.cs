using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ZXing;

namespace LibrarySystem
{
    internal class QRCodeHelper
    {
        public static Bitmap GenerateQRCode(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new Bitmap(400, 400);

            BarcodeWriter writer =
                new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,

                    Options =
                        new ZXing.QrCode.QrCodeEncodingOptions
                        {
                            Width = 400,
                            Height = 400,

                            Margin = 2,

                            CharacterSet = "UTF-8"
                        }
                };

            return writer.Write(value);
        }

        // SAVE QR IMAGE
        public static string SaveQRCode(Bitmap qrImage, string fileName)
        {
            //bookqr nga folder
            string folderPath = Path.Combine(Application.StartupPath, @"..\..\BookQR");

            // mo create ug folder if ever wapa ni exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            // kompleto nga pathsa file
            string fullPath = Path.Combine(folderPath, fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            // pag save sa image
            qrImage.Save(fullPath, ImageFormat.Png);

            return fullPath;
        }
        // SAVE STUDENT QR IMAGE
        public static string SaveStudentQRCode(Bitmap qrImage, string fileName)
        {
            string folderPath = Path.Combine(Application.StartupPath, @"..\..\StudentQR");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fullPath = Path.Combine(
                folderPath,
                fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png"
            );

            qrImage.Save(fullPath, ImageFormat.Png);

            return fullPath;
        }
    }
}
