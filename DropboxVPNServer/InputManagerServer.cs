using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using DropboxVPNServer.Utils;
using System.Drawing;

namespace DropboxVPNServer
{
    class InputManagerServer
    {
    
        public class InputLoaded
        {
            public string FilePath = String.Empty;
            public Point MousePosition = Point.Empty;
            public MouseInput.MouseActions MouseAction = MouseInput.MouseActions.None;

            public InputLoaded(string pFilePath)
            {
                FilePath = pFilePath;
                ReadInputs(pFilePath);
            }

            private void ReadInputs(string pFilePath)
            {
                //Read inpts from file path
                StreamReader myReader = new StreamReader(pFilePath);
                string line = myReader.ReadLine();
                //Read the first line with th inputs
                string[] values= line.Split(';');
                if (values.Length >= 3)
                {
                    MousePosition.X = Int32.Parse(values[0]);
                    MousePosition.Y = Int32.Parse(values[1]);
                    switch (Int32.Parse(values[2]))
                    {
                        case 0:
                            MouseAction = MouseInput.MouseActions.None;
                            break;
                        case 1:
                            MouseAction = MouseInput.MouseActions.Left;
                            break;
                        case 2:
                            MouseAction = MouseInput.MouseActions.Middle;
                            break;
                        case 3:
                            MouseAction = MouseInput.MouseActions.Right;
                            break;
                        case 4:
                            MouseAction = MouseInput.MouseActions.DoubleClick;
                            break;
                    }
                }
               //Close the file
                myReader.Close();
            }

            public void Remove()
            {
                //Delete the old file 
                ForceDeleteFile(FilePath);
            }
        }

        // Image filter used to load all the inputs
        private string tempFolder = AppDomain.CurrentDomain.BaseDirectory + "TemporaryFiles";
        private Object _thisLock = new Object();
        //Queue with the inputs already loaded
        private Queue<InputLoaded> _inputs = new Queue<InputLoaded>();
        public int _threadRate = 20; //milliseconds
        private bool _isRunning = false;
        private InputLoaded lastInput = null;
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        private Thread _myThread = null;

        //Inputs path to upolad the inputs
        public string InputsPath = String.Empty;


        public InputManagerServer(string pInputsPath) : this()
        {
            InputsPath = pInputsPath;
        }

        public InputManagerServer()
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

            //Delete all the old inputs filtered with txt extension
            DirectoryInfo di = new DirectoryInfo(tempFolder);
            foreach (FileInfo file in di.GetFiles("*.txt"))
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
                    LoadInputss(InputsPath);
                    //Sleep untile the next 100 milliseconds
                    Thread.Sleep(_threadRate);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("ERROR: " + ex.Message);
                }
            }
        }

        private void LoadInputss(string pImagesPath)
        {
            //Get all he files in the folder
            DirectoryInfo dir = new DirectoryInfo(pImagesPath);
            FileInfo[] files = dir.GetFiles("*.txt");
            //User Enumerable.OrderBy to sort the files array and get a new array of sorted files
            FileInfo[] sortedFiles = files.OrderBy(r => r.Name).ToArray();
            //Load the images into the queue
            foreach (FileInfo file in sortedFiles)
            {
                lock (_thisLock)
                {
                    //Enqueue the input to be loaded in order of appereance
                    File.Copy(file.FullName, tempFolder + "\\" + file.Name, true);
                    _inputs.Enqueue(new InputLoaded(tempFolder + "\\" + file.Name));
                    //Force seevral time to original file
                    ForceDeleteFile(file.FullName);
                }
            }
        }

        public static void ForceDeleteFile(string file)
        {
            for (int i = 0; i <= 2; i++)
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

        public InputLoaded GetNextInput()
        {
            InputLoaded result = null;
            lock (_thisLock)
            {
                if (_inputs.Count != 0)
                {
                    while (result == null)
                    {
                        //Enqueue the image to be loaded in order of appereance
                        InputLoaded tempInput = _inputs.Dequeue();
                        
                        //Chech if the qeue image is older that the current one.
                        if (lastInput == null || tempInput.FilePath.CompareTo(lastInput.FilePath) >= 0)
                        {
                            if (lastInput != null)
                            {
                                //Dispose the last input
                                //lastInput.Remove();
                            }
                            //Set the new last input and return
                            lastInput = tempInput;
                            result = lastInput;
                        }
                        else
                        {
                            //Remove the old file 
                            tempInput.Remove();
                        }

                        //Check if there is no more elment in the qeue
                        if (_inputs.Count == 0)
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
