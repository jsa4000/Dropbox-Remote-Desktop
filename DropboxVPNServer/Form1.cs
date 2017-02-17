using System;
using System.Drawing;
using System.Windows.Forms;
using DropboxVPNServer.Utils;


namespace DropboxVPNServer
{
    public partial class Form1: Form
    {
        private bool IsRunning = false;
        private int _interval = 500;
        private ScreenManagerServer screenManager = new ScreenManagerServer();
        private InputManagerServer inputnManager = new InputManagerServer();

        public Form1()
        {
            InitializeComponent();
            
            //Disable features
            screenManager.DisabeAERODesktop = false;
            screenManager.DisableWallpaper = true;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog1.Reset();
            FolderBrowserDialog1.Description = "Select the folder for the Inputs";
            FolderBrowserDialog1.SelectedPath = txtPathSelected.Text;
            FolderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult FolderDialogResult = FolderBrowserDialog1.ShowDialog();
            if (FolderDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtPathSelected.Text = FolderBrowserDialog1.SelectedPath;
            }
            FolderBrowserDialog1.Dispose();
        }
              
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Chane the state of the Server
            ChangeStatus();
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            //Make an Screenshot of the screen  
            screenManager.ImagePath = txtPathSelected.Text;
            screenManager.CaptureScreen();
        }

        public void EnableControls(bool Enabled)
        {
            gbSelectPath.Enabled = Enabled;
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            ////Get the current Mouse Position
            //MouseOperations.MousePoint position = MouseOperations.GetCursorPosition();

            ////Set the poition of the muse and clck the left button
            //position.X += 60;
            //position.Y += 60;
            //MouseOperations.SetCursorPosition(position);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
        }

        private void ChangeStatus()
        {
            if (!IsRunning)
            {
                //Start the Server
                btnStart.Text = "Stop";
                lblStatus.Text = "Running";
                IsRunning = true;
                //Start the Screen CApture Manager
                screenManager.ImagePath = txtPathSelected.Text;
                screenManager.Start();
                //Start the Input  Manager
                inputnManager.InputsPath = txtPathSelected.Text;
                inputnManager.Start();
                //Start the timer for the inputs
                tmrInput.Interval = 20;
                tmrInput.Enabled = true;
                //Disable controls
                EnableControls(false);
            }
            else {
                //Stop the Server
                btnStart.Text = "Start";
                lblStatus.Text = "Inactive";
                IsRunning = false;
                //Stops the Threads
                screenManager.Stops();
                inputnManager.Stops();
                //Stops the timer for the inputs
                tmrInput.Enabled = false; 
                //Enable controls
                EnableControls(true);
            }
        }

        private void tmrInput_Tick(object sender, EventArgs e)
        {
            //Refresh the gui
            InputManagerServer.InputLoaded input = inputnManager.GetNextInput();
            if (input != null)
            {
                // run the inputs
                MouseInput.SetCursorPosition(input.MousePosition);
                MouseInput.SendAction(input.MousePosition, input.MouseAction);
            }

        }
    }
}
