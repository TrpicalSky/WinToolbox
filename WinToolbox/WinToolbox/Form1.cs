using Microsoft.Win32;
using System.Windows.Forms;

namespace WinToolbox
{
    
    public partial class Form1 : Form
    {
        string computerName = System.Environment.MachineName;
        public Form1()
        {
            InitializeComponent();
            label3.Text = $"Current Computer Name: {computerName}";
            var Index = comboBox1.SelectedIndex = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedIndex = comboBox1.SelectedIndex;

            if (selectedIndex == 0 ) 
            {
                string command = "/C ping " + "8.8.8.8";
                System.Diagnostics.Process.Start("CMD.exe", command);
                var Index = comboBox1.SelectedIndex = 4;
            } else if (selectedIndex == 1 ) {
                string command = "/C ping " + "9.9.9.9";
                System.Diagnostics.Process.Start("CMD.exe", command);
                var Index = comboBox1.SelectedIndex = 4;

            } else if (selectedIndex == 2 )
            {
                string command = "/C ping " + "1.1.1.1";
                System.Diagnostics.Process.Start("CMD.exe", command);
                var Index = comboBox1.SelectedIndex = 4;
            } else if (selectedIndex == 3 )
            {
                string command = "/C ping " + "208.67.222.222";
                System.Diagnostics.Process.Start("CMD.exe", command);
                var Index = comboBox1.SelectedIndex = 4;
            } else if (selectedIndex == 4) {
                if (textBox1.Text.Length == 0)
                {
                    return;
                }
                else
                {
                    string command = "/C ping " + textBox1.Text;
                    System.Diagnostics.Process.Start("CMD.exe", command);
                }
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static bool SetMachineName(string newMachineName)
        {
            RegistryKey registryKey= Registry.LocalMachine;

            string activeComputerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";

            RegistryKey activeCmpName = registryKey.CreateSubKey(activeComputerName);

            activeCmpName.SetValue("ComputerName", newMachineName);
            activeCmpName.Close();

            string computerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName";

            RegistryKey cmpName = registryKey.CreateSubKey(computerName);

            cmpName.SetValue("ComputerName", newMachineName);
            cmpName.Close();
            string _hostName = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters\\";
            RegistryKey hostName = registryKey.CreateSubKey(_hostName);
            hostName.SetValue("Hostname", newMachineName);
            hostName.SetValue("NV Hostname", newMachineName);
            hostName.Close();
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                SetMachineName(textBox2.Text);
            } else
            {
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}