using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;

namespace DropboxVPNClient
{
    class InputManagerClient
    {

        [Flags]
        public enum MouseActions
        {
            None = 0,
            Left = 1,
            Middle = 2,
            Right = 3,
            DoubleClick = 4
        }

        private class InputParameters
        {
            public Point MousePosition = Point.Empty;
            public MouseActions MouseAction = MouseActions.None;

            public void Initialize()
            {
                //MousePosition = Point.Empty;
                MouseAction = MouseActions.None;
            }

            public override string ToString()
            {
                return MousePosition.X + ";" + MousePosition.Y + ";" + (int)MouseAction;
            }
        }

        public string InputFilePath = String.Empty;
        private string _prefixImageName = "input";
        private Object _thisLock = new Object();
        private InputParameters _inputs = new InputParameters();
        //Queue with the images already loaded

        public int _threadRate = 500; //milliseconds
        private bool _isRunning = false;

        public bool IsRunning
        {
            get { return _isRunning; }
        }

        private Thread _myThread = null;

        public InputManagerClient()
        {

        }

        private void MyprocessThread()
        {

            //Start the loop for the thread until the thread stops
            while (IsRunning)
            {
                try
                {
                    // Suyn the courrent inputs and create a file for the server side
                    GenerateInputs();
                    //Sleep untile the next 100 milliseconds
                    Thread.Sleep(_threadRate);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("ERROR: " + ex.Message);
                }
            }
        }

        private void GenerateInputs()
        {
            //Create the files with the updated inputs for the server
            lock (_thisLock)
            {
                //Create the file with the inputs updated
                string FileOupPut = InputFilePath + "\\" + _prefixImageName + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + ".txt";
                StreamWriter myWriter = new System.IO.StreamWriter(FileOupPut);
                myWriter.WriteLine(_inputs);
                myWriter.Close();
                myWriter.Dispose();

                //Initialize the inputs
                _inputs.Initialize();
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

        public void UpdateMousePosition(Point position)
        {
            //Update the mouse position
            lock (_thisLock)
            {
                _inputs.MousePosition = position;
            }
        }

        public void UpdateMouseACtion(MouseActions action)
        {
            //Update the mouse position
            lock (_thisLock)
            {
                _inputs.MouseAction = action;
            }
        }

    }
}
