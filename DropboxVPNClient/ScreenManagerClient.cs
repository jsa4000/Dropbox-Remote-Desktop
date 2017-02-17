using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;

namespace DropboxVPNClient
{
    class ScreenManagerClient
    {

        private class ImageLoaded
        {
            public string FilePath = String.Empty;
            public Image Image = null;
            
            public ImageLoaded(string pFilePath)
            {
                Image = Image.FromFile(pFilePath);
                FilePath = pFilePath;
            }

            public void Remove()
            {
                //Delete the old file 
                Image.Dispose();
                ForceDeleteFile(FilePath);
            }
        }

        // Image filter used to load all the images
        private string tempFolder = AppDomain.CurrentDomain.BaseDirectory + "TemporaryFiles";
        private ImageFormat _imageFormat = ImageFormat.Jpeg;
        private Object _thisLock = new Object();
        //Queue with the images already loaded
        private Queue<ImageLoaded> _images = new Queue<ImageLoaded>();
        public int _threadRate = 20; //milliseconds
        private bool _isRunning = false;
        private ImageLoaded lastImage = null; 
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        private Thread _myThread = null;

        //Image path to upolad the images
        public string ImagesPath = String.Empty;
        public Size ImageSize;


        public ScreenManagerClient(string pImagesPath) : this()
        {
            ImagesPath = pImagesPath;
        }

        public ScreenManagerClient()
        {
            //Check temporary folder exists
            CheckTemporaryFolder();
        }

        private void CheckTemporaryFolder()
        {
            //Chceck if we must create the folder
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            //Delete all the old images filtered with the image format
            DirectoryInfo di = new DirectoryInfo(tempFolder);
            foreach (FileInfo file in di.GetFiles("*." + _imageFormat.ToString().ToLower()))
            {
                file.Delete();
            }
        }
        
        private void MyprocessThread()
        {
        
            //Start the loop for the thread until the thread stops
            while (IsRunning)
            {
                try
                {
                    //Make an Screenshot of the screen   
                    LoadImages(ImagesPath);
                    //Sleep untile the next 100 milliseconds
                    Thread.Sleep(_threadRate);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("ERROR: " + ex.Message);
                }
            }
         }
        
        private void LoadImages(string pImagesPath)
        {
            //Get all he files in the folder
            DirectoryInfo dir = new DirectoryInfo(pImagesPath);
            FileInfo[] files = dir.GetFiles("*." + _imageFormat.ToString().ToLower());
            //User Enumerable.OrderBy to sort the files array and get a new array of sorted files
            FileInfo[] sortedFiles = files.OrderBy(r => r.Name).ToArray();
            //Load the images into the queue
            foreach (FileInfo file in sortedFiles)
            {
                lock (_thisLock)
                {
                    //Enqueue the image to be loaded in order of appereance
                    File.Copy(file.FullName, tempFolder + "\\" + file.Name,true);
                    _images.Enqueue(new ImageLoaded(tempFolder + "\\" + file.Name));
                    //Force seevral time to original file
                    ForceDeleteFile(file.FullName);
                }
            }
        }
        
        public static void ForceDeleteFile(string file)
        {
            for (int i = 0; i<=2; i ++)
            {
            //while (File.Exists(file)) {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("ERROR: " + ex.Message);
                    System.Threading.Thread.Sleep(1);
                }
            }
            
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

        public Image GetNextImage()
        {
            Image result = null;
            lock (_thisLock)
            {
                if (_images.Count != 0)
                {
                    while (result == null)
                    {
                        //Enqueue the image to be loaded in order of appereance
                        ImageLoaded tempImage = _images.Dequeue();

                        //Get the image and check the size of the image
                        ImageSize = tempImage.Image.Size;
                        
                        //Chech if the qeue image is older that the current one.
                        if (lastImage == null || tempImage.FilePath.CompareTo(lastImage.FilePath) >= 0 )
                        {
                            if (lastImage != null)
                            { 
                                //Dispose the last image
                                //lastImage.Remove();
                            }
                            //Set the new last image and return
                            lastImage = tempImage;
                            result = lastImage.Image;
                        }
                        else
                        {
                            //Remove the old file 
                            tempImage.Remove();
                        }

                        //Check if there is no more elment in the qeue
                        if (_images.Count == 0)
                        {
                            break;
                        }
                    }

                }
            }
            return result;
        }


    }
}
