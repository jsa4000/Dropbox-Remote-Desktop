using System;
using System.Drawing;
using System.Windows.Forms;

namespace DropboxVPNClient
{
    public partial class Form1 : Form
    {
        private ScreenManagerClient screenManager = new ScreenManagerClient();
        private InputManagerClient inputManager = new InputManagerClient();
        private bool IsRunning = false;
        private int _interval = 20;
        
        private Point LastPoint = new Point();
        private ToolTip tt = new ToolTip();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //Resize the splitter
            sContainer.SplitterDistance = this.Size.Height - 114;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Reset();
            folderBrowserDialog1.Description = "Select the folder for the Inputs";
            folderBrowserDialog1.SelectedPath = txtPathSelected.Text;
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult FolderDialogResult = folderBrowserDialog1.ShowDialog();
            if (FolderDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtPathSelected.Text = folderBrowserDialog1.SelectedPath;
            }
            folderBrowserDialog1.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Chane the state of the Server
            ChangeStatus();
        }

        private void ChangeStatus()
        {
            if (!IsRunning)
            {
                //Start the Server
                btnStart.Text = "Stop";
                lblStatus.Text = "Running";
                IsRunning = true;
                //Start the screen loader
                //screenManager.LoadImages(txtPathSelected.Text);
                screenManager.ImagesPath = txtPathSelected.Text;
                screenManager.Start();
                //Start Input manager
                inputManager.InputFilePath = txtPathSelected.Text;
                inputManager.Start();
                //Start the timer
                tmrUpdate.Interval = _interval;
                tmrUpdate.Enabled = true;
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
                inputManager.Stops();
                //Stop the timer
                tmrUpdate.Enabled = false;
                //Enable controls
                EnableControls(true);
            }
        }

        public void EnableControls(bool Enabled)
        {
            gbSelectPath.Enabled = Enabled;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            //Refresh the gui
            Image image = screenManager.GetNextImage();
            if (image != null)
            {
                //Load the image into the contrl
                pbVideo.Image = image;
                //updqte the control
                pbVideo.Update();
                pbVideo.Refresh();
            }
        }
        
        private void pbVideo_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            Point p1 = pbVideo.PointToClient(mousePosition);
            //Check if the position of the pointer has changed relative to the last time
            if (LastPoint.X != p1.X || LastPoint.Y != p1.Y)
            {
                //Set the last point
                LastPoint = p1;
                Point toolTipPos = p1;
                toolTipPos.X += 30;
                toolTipPos.Y += 30;

                //Get the position relative to the image size fo the screenshot from the server side
                Point screenPostion = new Point();
                screenPostion.X = (p1.X * screenManager.ImageSize.Width) / pbVideo.Size.Width;
                screenPostion.Y = (p1.Y * screenManager.ImageSize.Height) / pbVideo.Size.Height;
                inputManager.UpdateMousePosition(screenPostion);

                //Show the new tool tip
                IWin32Window win = this;
                tt.Show("x = " + screenPostion.X + "\n y=" + screenPostion.Y, win, toolTipPos);
            }

        }

        private void pbVideo_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    inputManager.UpdateMouseACtion(InputManagerClient.MouseActions.Left);
                    break;
                case MouseButtons.Right:
                    inputManager.UpdateMouseACtion(InputManagerClient.MouseActions.Right);
                    break;
                case MouseButtons.Middle:
                    inputManager.UpdateMouseACtion(InputManagerClient.MouseActions.Middle);
                    break;
            }
        }

        private void pbVideo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            inputManager.UpdateMouseACtion(InputManagerClient.MouseActions.DoubleClick);
        }
    }
}
