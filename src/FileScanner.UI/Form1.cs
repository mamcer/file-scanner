using System;
using System.Windows.Forms;

namespace FileScanner.UI
{
    public partial class Form1 : Form
    {
        private FileScanResult _scanResult;
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            _scanResult = new FileScanResult();
            chkShowLog.Enabled = false;
            txtLog.Text = "scanning in progress...";
            await FileScanner.ScanFolderForFilesAsync(txtPath.Text, _scanResult);
            chkShowLog.Enabled = true;
            if (chkShowLog.Checked)
            {
                txtLog.Text = _scanResult.Log.ToString();
            }
            else
            {
                txtLog.Text = "scan finished!";
                MessageBox.Show("Scan Finished!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_scanResult != null)
            {
                Clipboard.SetText(_scanResult.Log.ToString());
            }
        }
    }
}