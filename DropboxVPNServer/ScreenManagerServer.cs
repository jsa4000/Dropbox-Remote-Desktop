using System;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using DropboxVPNServer.Utils;

namespace DropboxVPNServer
{
    class ScreenManagerServer
    {
        public bool DisabeAERODesktop = false;
        public bool DisableWallpaper = false;
        public string ImagePath = String.Empty;
        public int FrameRate = 500; //milliseconds

        private string _wallpaperPath = String.Empty;
        private ImageFormat _imageFormat = ImageFormat.Jpeg;
        private long _imageQuality = 20L;
        private string _prefixImageName = "Screenshot";
        private bool _isRunning = false;
        private Thread _myThread = null;
               
        public bool IsRunning
        {
            get { return _isRunning; }
        }
                
        public void Start()
        {
            //Check if the buffer has started
            if (_myThread != null) Stops();
            //Enable the thread to Start the buffer processing
            _isRunning = true;

            // MyThread = New System.Threading.Thread(AddressOf MyprocessThread2)
            _myThread = new Thread(MyprocessThread);
            _myThread.IsBackground = true;
            _myThread.Priority = ThreadPriority.AboveNormal; // Set bigger priority than the other threads.
            _myThread.Start();
        }
        
        public void Stops()
        {
            //Stops the buffer
            _isRunning = false;
            _myThread.Join();
            _myThread = null;
        }

        private void MyprocessThread()
        {
            //Disable desktop features 
            EnableDesktopFeatures(false);

            //Start the loop for the thread until the thread stops
            while (IsRunning)
            {
                try
                {
                    //Make an Screenshot of the screen   
                    CaptureScreen();
                    //Sleep untile the next 100 milliseconds
                    Thread.Sleep(FrameRate);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("ERROR: " + ex.Message);
                }

            }

           //Enable again desktop features'
           EnableDesktopFeatures(true);
        }
        
        public void EnableDesktopFeatures(bool Enabled)
        {

            //Disable components from the desktop
            if (DisabeAERODesktop)
            {
                //Disable the aero desktop
                ScreenOperations.DwmEnableComposition(Enabled);
            }

            //string wallpaperPath = String.Empty;
            if (DisableWallpaper)
            {
                if (!Enabled)
                {
                    //Get wallpapper
                    _wallpaperPath = ScreenOperations.GetWallpaper();
                    //Set black wallpaper
                    ScreenOperations.SetWallpaper(String.Empty);
                }
                else
                {
                    //Return to the default wallpaper
                    ScreenOperations.SetWallpaper(_wallpaperPath);
                }
               
            }

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private static Bitmap ConvertTo16bpp(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            }

            return bmp;
        }

        public void CaptureScreen()
        {
            //Bitmap to store the image
            Bitmap memoryImage = ScreenOperations.CaptureScreen(true);
            //Get the encoder
            ImageCodecInfo encoder = GetEncoder(_imageFormat);
            if (encoder != null)
            {
                //Set the parameters of'
                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, _imageQuality);
                encoderParameters.Param[0] = encoderParameter;
                // Save the image using this encoder parameter   
                memoryImage.Save(ImagePath + "\\" + _prefixImageName + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "." + _imageFormat.ToString().ToLower(), encoder, encoderParameters);
            }
            else {
                //Save withount enconde the image
                memoryImage.Save(ImagePath + "\\" + _prefixImageName + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "." + _imageFormat.ToString().ToLower(), _imageFormat);
            }

   
        }

    }
}
