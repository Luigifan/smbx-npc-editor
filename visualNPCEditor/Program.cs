﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace visualNPCEditor
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summar>
        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-debug")
                {
                    Console.WriteLine("Running in debug mode");
                    ShowConsoleWindow();
                }
            }

            if (IsLinux)
            {
                MessageBox.Show("Warning, you are running this under Linux so you will not be able to take advantage of the NPC-Config things I've implemented");
            }
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            Main main = new Main();
            main.Show();
            Application.Run();
        }

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
    }
}
