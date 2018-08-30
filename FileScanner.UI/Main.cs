using System;
using System.Windows.Forms;

namespace FileScanner.UI
{
    public partial class Main : Form
    {
        private FileScanResult scanResult;
        
        public Main()
        {
            InitializeComponent();
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            scanResult = new FileScanResult();
            chkShowLog.Enabled = false;
            txtLog.Text = "scanning in progress...";
            await FileScanner.ScanFolderForFilesAsync(txtPath.Text, scanResult);
            chkShowLog.Enabled = true;
            if (chkShowLog.Checked)
            {
                txtLog.Text = scanResult.Log.ToString();
            }
            else
            {
                txtLog.Text = "scan finished!";
                MessageBox.Show("Scan Finished!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (scanResult != null)
            {
                Clipboard.SetText(scanResult.Log.ToString());
            }
        }
    }
}