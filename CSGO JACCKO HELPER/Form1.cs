using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

//This file is part of CSGO Inject tool.
//
//    CSGO Inject tool is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    CSGO Inject tool is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with CSGO Inject tool.  If not, see<http://www.gnu.org/licenses/>.

namespace CSGO_TOOL_FOR_DEBUG
{
    public partial class Form1 : Form
    {
        debug_console debug = new debug_console();
        bool injected = false;
        bool readytoinject = false;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(CSGO_TOOL_FOR_DEBUG.Properties.Resources.done);
        public Form1()
        {
            InitializeComponent();
            update.Interval = (500); // 1 secs
            update.Tick += new EventHandler(updater);
            update.Start();
            comboBox1.SelectedIndex = 0;
            comboBox2.Enabled = false;
            comboBox2.Items.Clear();
            comboBox2.Items.Add("csgo");
            comboBox2.SelectedIndex = 0;
            comboBox1.Enabled = false; //Only LoadLibrary atm
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //prevent typing into process combo list   
            debug.listBox1.Items.Add("Init.");
        }

        private void updater(object sender, EventArgs e)
        {
            Status();
        }

        private void listofprocess()
        {
            debug.listBox1.Items.Add("Checking all running processes.");
            comboBox2.Items.Clear();
            Process[] MyProcess = Process.GetProcesses();
            for (int i = 0; i < MyProcess.Length; i++)
                comboBox2.Items.Add(MyProcess[i].ProcessName);
        }

        private void Status()
        {
            Process[] isrunning = Process.GetProcessesByName("csgo");
            if (isrunning.Length == 0)
            {
                label2.Text = "CSGO ISN'T RUNNING!";
                label2.ForeColor = System.Drawing.Color.Red;
                readytoinject = false;
            }
            else
            {
                label2.Text = "CSGO IS RUNNING!";
                label2.ForeColor = System.Drawing.Color.Green;
            }
            try
            {
                string selected_process = comboBox2.SelectedItem.ToString();
                Process[] isrunning1 = Process.GetProcessesByName(selected_process);
                if (isrunning1.Length == 0)
                {
                    injected = false;
                    readytoinject = false;
                }
                else
                {
                    if (checkBox2.Checked == true && textBox1.TextLength > 1)
                    {
                        if (selected_process != "csgo")
                            readytoinject = true;

                        if (!injected)
                            Inject();
                    }
                }
            }
            catch(Exception ex)
            {
                debug.listBox1.Items.Add("Error while getting status: " + ex.Message.ToString());
                //don't do anything if it crash
            }
            if (injected)
            {
                label7.Text = "INJECTED!";
                label7.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label7.Text = "NOT INJECTED!";
                label7.ForeColor = System.Drawing.Color.Red;
            }
        }

        public Int32 GetProcessId(String proc)
        {
            Process[] ProcList;
            ProcList = Process.GetProcessesByName(proc);
            return ProcList[0].Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KillCSGO();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startCSGO();
        }

        private void KillCSGO()
        {
            Process[] pname = Process.GetProcessesByName("csgo");
            if (pname.Length != 0)
            {
                try
                {
                    Process[] procs = Process.GetProcessesByName("csgo");
                    foreach (Process p in procs) { p.Kill(); }
                    player.Play();
                    debug.listBox1.Items.Add("Process csgo.exe killed.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error with killing the process!");
                    debug.listBox1.Items.Add("Error with killing process: " + ex.Message.ToString());
                }
            }
        }

        private async void startCSGO()
        {
            Process[] pname = Process.GetProcessesByName("csgo");
            if (pname.Length == 0)
            {
                Process.Start((textBox2.Text.Length > 4) ? "steam://rungameid/730//" + textBox3.Text + " +map " + textBox2.Text : "steam://rungameid/730" + textBox3.Text);
                player.Play();

                await Task.Delay(15000); //CSGO crash if the game doesn't loded completly and we inject so we're waiting 15secs and then we go for inject
                readytoinject = true; //tell injector that we can inject!
                debug.listBox1.Items.Add("Process csgo.exe started.");

            }
            else
            {
                MessageBox.Show("The game is already running!");
                debug.listBox1.Items.Add("Error while starting the game:The game is already running!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox2.Enabled = false;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("csgo");
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                listofprocess();
                comboBox2.SelectedIndex = 0;
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            listofprocess();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inject();
        }

        private async void Inject()
        {
            debug.listBox1.Items.Add("Starting Inject!");
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("You need to select DLL before injecting!");
                debug.listBox1.Items.Add("Error while injection: Dll not selected!");
            }
            else
            {
                debug.listBox1.Items.Add("Dll file selected");
                if (injected)
                {
                    if (checkBox2.Checked == true)
                        return;
                    else
                        MessageBox.Show("You already injected!");
                    debug.listBox1.Items.Add("Error while injection: You can inject only once per sesion!");
                }
                else
                {
                    if (checkBox2.Checked == true && comboBox2.SelectedItem.ToString() == "csgo" && readytoinject || checkBox2.Checked == false || comboBox2.SelectedItem.ToString() != "csgo")
                    {
                        if (comboBox1.SelectedIndex == 0) // LoadLibrary
                        {
                            string path2 = textBox1.Text;
                            string path = path2.Replace(@"\", @"\\");
                            String strDLLName = path;
                            string selected_process = comboBox2.SelectedItem.ToString();
                            String strProcessName = selected_process;

                            Int32 ProcID = GetProcessId(strProcessName);
                            if (ProcID >= 0)
                            {
                                IntPtr hProcess = (IntPtr)OpenProcess(0x1F0FFF, 1, ProcID);
                                if (hProcess == null)
                                {
                                    MessageBox.Show("Process " + strProcessName + " isn't running!");
                                    debug.listBox1.Items.Add("Error while injection: Process " + strProcessName + " isn't running!");
                                }
                                else
                                {
                                    InjectLoadLibrary(hProcess, strDLLName);
                                    player.Play();
                                    injected = true;
                                    debug.listBox1.Items.Add("Injected!");
                                    if (checkBox3.Checked == true)
                                    {
                                        await Task.Delay(2000);
                                        System.Windows.Forms.Application.Exit();
                                        System.Environment.Exit(1);
                                    }
                                }
                            }
                            else
                            {
                                debug.listBox1.Items.Add("Error while injection: Process id is invalid!");
                            }
                        }
                        else if (comboBox1.SelectedIndex == 1) // Manual Mapping
                        {
                            MessageBox.Show("Comming soon!");
                        }
                    }
                    else
                    {
                        debug.listBox1.Items.Add("Delay 1 Sec.");
                        await Task.Delay(1000);
                        Inject();
                        return;
                    }
                }
            }
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void button3_Click(object sender, EventArgs e)
        {
            ofd.Filter = "DLL|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button4.Enabled = false;
            }
            else
                button4.Enabled = true;
        }

        private void InjectLoadLibrary(IntPtr hProcess, String strDLLName)
        {
            IntPtr bytesout;

            // Length of string containing the DLL file name +1 byte padding
            Int32 LenWrite = strDLLName.Length + 1;
            // Allocate memory within the virtual address space of the target process
            IntPtr AllocMem = (IntPtr)VirtualAllocEx(hProcess, (IntPtr)null, (uint)LenWrite, 0x1000, 0x40); //allocation pour WriteProcessMemory

            // Write DLL file name to allocated memory in target process
            WriteProcessMemory(hProcess, AllocMem, strDLLName, (UIntPtr)LenWrite, out bytesout);
            // Function pointer "Injector"
            UIntPtr Injector = (UIntPtr)GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            if (Injector == null)
            {
                MessageBox.Show(" Injector Error! \n ");
                // return failed
                return;
            }

            // Create thread in target process, and store handle in hThread
            IntPtr hThread = (IntPtr)CreateRemoteThread(hProcess, (IntPtr)null, 0, Injector, AllocMem, 0, out bytesout);
            // Make sure thread handle is valid
            if (hThread == null)
            {
                //incorrect thread handle ... return failed
                MessageBox.Show(" hThread [ 1 ] Error! \n ");
                return;
            }
            // Time-out is 10 seconds...
            int Result = WaitForSingleObject(hThread, 10 * 1000);
            // Check whether thread timed out...
            if (Result == 0x00000080L || Result == 0x00000102L || Result == 0xFFFFFFFF)
            {
                /* Thread timed out... */
                MessageBox.Show(" hThread [ 2 ] Error! \n ");
                // Make sure thread handle is valid before closing... prevents crashes.
                if (hThread != null)
                {
                    //Close thread in target process
                    CloseHandle(hThread);
                }
                return;
            }
            // Sleep thread for 1 second
            Thread.Sleep(1000);
            // Clear up allocated space ( Allocmem )
            VirtualFreeEx(hProcess, AllocMem, (UIntPtr)0, 0x8000);
            // Make sure thread handle is valid before closing... prevents crashes.
            if (hThread != null)
            {
                //Close thread in target process
                CloseHandle(hThread);
            }
            // return succeeded
            return;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void debugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debug.Show();
        }

        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(
          IntPtr hProcess,
          IntPtr lpThreadAttributes,
          uint dwStackSize,
          UIntPtr lpStartAddress, // raw Pointer into remote process
          IntPtr lpParameter,
          uint dwCreationFlags,
          out IntPtr lpThreadId
        );

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            UInt32 dwDesiredAccess,
            Int32 bInheritHandle,
            Int32 dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(
        IntPtr hObject
        );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            UIntPtr dwSize,
            uint dwFreeType
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern UIntPtr GetProcAddress(
            IntPtr hModule,
            string procName
            );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect
            );

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            string lpBuffer,
            UIntPtr nSize,
            out IntPtr lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(
            string lpModuleName
            );

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        internal static extern Int32 WaitForSingleObject(
            IntPtr handle,
            Int32 milliseconds
            );


    }
}
