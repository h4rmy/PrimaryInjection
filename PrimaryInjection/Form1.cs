using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimaryInjection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Color _textColor = Color.FromArgb(255, 255, 255);
        public Color _backgroundColor = Color.FromArgb(32, 32, 32);
        public Color _buttonBorder = Color.FromArgb(255, 255, 255);
        public Color _buttonHover = Color.FromArgb(55, 55, 55);
        public Color _buttonStatic = Color.FromArgb(45, 45, 45);

        public string SelectedDLL;
        public string SelectedProcess;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProcesses();
            InitializeSavedConfig();
        }
        private void InitializeSavedConfig()
        {
            _textColor = Properties.Settings.Default.textColor;
            _backgroundColor = Properties.Settings.Default.backgroundColor;
            _buttonBorder = Properties.Settings.Default.borderColor;
            _buttonHover = Properties.Settings.Default.hoverColor;
            _buttonStatic = Properties.Settings.Default.staticColor;


            processList.Text = Properties.Settings.Default.selectedProcess;

            if (Properties.Settings.Default.selectedDLL == String.Empty)
                button1.Text = "Выбрать DLL";
            else
                button1.Text = "DLL Выбрана!";

            SelectedDLL = Properties.Settings.Default.selectedDLL;

            this.Width = Properties.Settings.Default.width;
            this.Height = Properties.Settings.Default.height;

            InitializeConfig();
        }

        private void InitializeConfig()
        {
            this.buttonBorderColor.BackColor = _buttonBorder;
            this.buttonHoverColor.BackColor = _buttonHover;
            this.buttonStaticColor.BackColor = _buttonStatic;
            this.backgroundColor.BackColor = _backgroundColor;
            this.textColor.BackColor = _textColor;
            this.ForeColor = _textColor;
            this.BackColor = _backgroundColor;
            this.groupBox1.ForeColor = _textColor;
            this.groupBox1.ForeColor = _textColor;
            this.groupBox2.BackColor = _backgroundColor;
            this.groupBox2.BackColor = _backgroundColor;
            this.button1.ForeColor = _textColor;
            this.button1.BackColor = _buttonStatic;
            this.button1.FlatAppearance.BorderColor = _buttonBorder;
            this.button1.FlatAppearance.MouseDownBackColor = _buttonHover;
            this.button1.FlatAppearance.MouseOverBackColor = _buttonHover;
            this.button2.ForeColor = _textColor;
            this.button2.BackColor = _buttonStatic;
            this.button2.FlatAppearance.BorderColor = _buttonBorder;
            this.button2.FlatAppearance.MouseDownBackColor = _buttonHover;
            this.button2.FlatAppearance.MouseOverBackColor = _buttonHover;
            this.button3.ForeColor = _textColor;
            this.button3.BackColor = _buttonStatic;
            this.button3.FlatAppearance.BorderColor = _buttonBorder;
            this.button3.FlatAppearance.MouseDownBackColor = _buttonHover;
            this.button3.FlatAppearance.MouseOverBackColor = _buttonHover;
            this.button4.ForeColor = _textColor;
            this.button4.BackColor = _buttonStatic;
            this.button4.FlatAppearance.BorderColor = _buttonBorder;
            this.button4.FlatAppearance.MouseDownBackColor = _buttonHover;
            this.button4.FlatAppearance.MouseOverBackColor = _buttonHover;
            this.button5.ForeColor = _textColor;
            this.button5.BackColor = _buttonStatic;
            this.button5.FlatAppearance.BorderColor = _buttonBorder;
            this.button5.FlatAppearance.MouseDownBackColor = _buttonHover;
            this.button5.FlatAppearance.MouseOverBackColor = _buttonHover;
            this.processList.BackColor = _buttonStatic;
            this.processList.ForeColor = _textColor;
        }

        private void LoadProcesses()
        {
            processList.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process item in processes)
            {
                processList.Items.Add(item.ProcessName);
            }
        }

        private void UpdateList(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        #region ChangeTheme
        private void backgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.Color = _backgroundColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _backgroundColor = dialog.Color;
                InitializeConfig();
            }
        }

        private void textColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.Color = _textColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _textColor = dialog.Color;
                InitializeConfig();
            }
        }

        private void buttonBorderColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.Color = _buttonBorder;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _buttonBorder = dialog.Color;
                InitializeConfig();
            }
        }

        private void buttonHoverColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.Color = _buttonHover;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _buttonHover = dialog.Color;
                InitializeConfig();
            }
        }

        private void buttonStaticColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.Color = _buttonStatic;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _buttonStatic = dialog.Color;
                InitializeConfig();
            }
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            Properties.Settings.Default.textColor = _textColor;
            Properties.Settings.Default.backgroundColor = _backgroundColor;
            Properties.Settings.Default.hoverColor = _buttonHover;
            Properties.Settings.Default.staticColor = _buttonStatic;
            Properties.Settings.Default.borderColor = _buttonBorder;
            Properties.Settings.Default.Save();
        }

        private void LoadDefaultConfig(object sender, EventArgs e)
        {
            _textColor = Color.FromArgb(255, 255, 255);
            _backgroundColor = Color.FromArgb(32, 32, 32);
            _buttonBorder = Color.FromArgb(255, 255, 255);
            _buttonHover = Color.FromArgb(55, 55, 55);
            _buttonStatic = Color.FromArgb(45, 45, 45);
            InitializeConfig();
        }
        #endregion

        private void LoadDLLs(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "DLL File (*.dll)|*.dll";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {

                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;

                using (stream)
                {
                    SelectedDLL = opendialogfile.FileName;
                    button1.Text = "DLL Выбрана!";
                    Properties.Settings.Default.selectedDLL = SelectedDLL;
                    Properties.Settings.Default.Save();
                }
            }
            catch { }
        }

        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProcess = processList.Text;
            Properties.Settings.Default.selectedProcess = processList.Text;
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.width = this.Width;
            Properties.Settings.Default.height = this.Height;
            Properties.Settings.Default.Save();
        }

        private void Inject(object sender, EventArgs e)
        {
            string rawDLL = String.Empty;
            if (is64BitOperatingSystem)
                rawDLL = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), SelectedDLL);
            else
                rawDLL = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), SelectedDLL);
            Process proc = Process.GetProcessesByName(SelectedProcess)[0];
            inject(rawDLL, proc);
            isInjected = true;
        }
        #region Inject

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            uint dwCreationFlags,
            IntPtr lpThreadId);

        // privileges
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        public static bool isInjected = false;
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        public static int inject(string dllPath, Process tProcess)
        {
            Process targetProcess = tProcess;
            string dllName = dllPath;
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
            return 0;
        }
        public static Boolean isInjectedAlready()
        {
            if (isInjected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
