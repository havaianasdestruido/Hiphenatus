/*

#################################################################################
#          ____  _____   _   _            _                    ______           #
#         |_   \|_   _| (_) / |_         (_)                 .' ____ \          # 
#           |   \ | |   __ `| |-'_ .--.  __   .---.  __   _  | (___ \_|         #
#           | |\ \| |  [  | | | [ `/'`\][  | / /'`\][  | | |  _.____`.          #
# _______  _| |_\   |_  | | | |, | |     | | | \__.  | \_/ |,| \____) | _______ #
#|_______||_____|\____|[___]\__/[___]   [___]'.___.' '.__.'_/ \______.'|_______|#
#                                                                               # 
#################################################################################

Copyright (c) 2025 UltimateQuack (PatoFlamejanteTV), CYBERWARE, MalwareLabs

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */

using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using static Hiphenatus.WinApi.APIs;

namespace Hiphenatus
{
    public class BytebeatStream
    {
        private const int SampleRate = 79825;
        private const int DurationSeconds = 5;
        private const int BufferSize = SampleRate * DurationSeconds;

        private static Func<int, int>[] formulas = new Func<int, int>[]
        {
                t => (t>>8&t>>16)*t>>4 ,


           t => (t % ((t >> 8 | t >> 16) | 1)),

           t =>t*(t>>(t>>13&t)),


        };

        private static byte[] GenerateBuffer(Func<int, int> formula)
        {
            byte[] buffer = new byte[BufferSize];
            for (int t = 0; t < BufferSize; t++)
            {
                buffer[t] = (byte)(formula(t) & 0xFF);
            }
            return buffer;
        }

        private static void SaveWav(byte[] buffer, string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(new[] { 'R', 'I', 'F', 'F' });
                bw.Write(36 + buffer.Length);
                bw.Write(new[] { 'W', 'A', 'V', 'E' });
                bw.Write(new[] { 'f', 'm', 't', ' ' });
                bw.Write(16);
                bw.Write((short)1);
                bw.Write((short)1);
                bw.Write(SampleRate);
                bw.Write(SampleRate);
                bw.Write((short)1);
                bw.Write((short)8);
                bw.Write(new[] { 'd', 'a', 't', 'a' });
                bw.Write(buffer.Length);
                bw.Write(buffer);
            }
        }

        private static void PlayBuffer(byte[] buffer)
        {
            string tempFilePath = Path.GetTempFileName();
            SaveWav(buffer, tempFilePath);
            using (SoundPlayer player = new SoundPlayer(tempFilePath))
            {
                player.PlaySync();
            }
            File.Delete(tempFilePath);
        }

        public static void PlayBytebeatAudio()
        {
            foreach (var formula in formulas)
            {
                byte[] buffer = GenerateBuffer(formula);
                PlayBuffer(buffer);
            }
        }
    }
    public class Bytebeats
    {
        public static Random rand = new Random();
        static IntPtr hWaveOut;
        public static void Beat1()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(t >> t | t / 8 | t / 12);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat2()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)((t >> 8 | t >> 2) * 80);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat3()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)((t >> 8 | t >> 2) * 8 | (t >> 8 | t >> 2) * 80);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat4()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)((t >> 8 | t >> 2) * 12 | (t >> 8 | t >> 2) * 120);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat5()
        {
            // used https://www.reddit.com/r/bytebeat/comments/1g57g96/the_perfect_c_compatible_drums/
            // along with my OC bytebeat
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    int mod = t % 4096;
                    sbuffer[t] = (byte)(((t >> 9 & 1) + (t >> 12 & 7) != 0 ? 0 : (mod != 0 ? 9001 / mod : 0) - (t / 9 & 8) != 0 ? -1 : 0) ^ (t >> 4 & t >> t | t / 8));
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat6()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)((t >> 8 | t >> 2) * 80);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat7()
        {
            // used https://www.reddit.com/r/bytebeat/comments/1g57g96/the_perfect_c_compatible_drums/
            // along with my OC bytebeat (again)
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    int mod = t % 4096;
                    sbuffer[t] = (byte)((((t >> 9) & 1) + (t >> 12 & 7) != 0 ? 0 : (t % 4096 != 0 ? 9001 / (t % 4096) : 0) - ((t / 9 & 8) != 0 ? -1 : 0)) ^ ((t >> 4) & (t * t >> 8)));
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat8()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    int mod = t % 4096;
                    sbuffer[t] = (byte)(Math.Sqrt(t) * 800);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);


                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0,
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat9()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)((int)(Math.Sqrt(t) * t) >> 8 | t | t >> 16 | (int)((Math.Tan(t) / 8) * t) | t >> (int)(Math.Sin(t) * 8));
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }
        }

        public static void Beat10()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 8000,
                    nAvgBytesPerSec = 8000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(((int)(Math.Sqrt(t) * (t / 800))) | ((int)(Math.Tan(t) / 8)));
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }


        }

        public static void Beat11()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 16000,
                    nAvgBytesPerSec = 16000,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(10 * (t >> 7 | t | t >> 6) + 4 * (t & t >> 13 | t >> 6) >> 2 | t & t >> 8);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }

        }

        public static void Beat11andhalf()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX
                {
                    wFormatTag = WAVE_FORMAT_PCM,
                    nChannels = 1,
                    nSamplesPerSec = 44100,
                    nAvgBytesPerSec = 44100,
                    nBlockAlign = 1,
                    wBitsPerSample = 8,
                    cbSize = 0
                };

                const uint WAVE_MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, WAVE_MAPPER, ref wfx, IntPtr.Zero, IntPtr.Zero, CALLBACK_NULL);

                byte[] sbuffer = new byte[17000 * 60];

                for (int t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(10 * (t >> 7 | t | t >> 6) + 4 * (t & t >> 13 | t >> 6) >> 2 | t & t >> 80 | t & t >> 4 | t / 16);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR
                {
                    lpData = handle.AddrOfPinnedObject(),
                    dwBufferLength = (uint)sbuffer.Length,
                    dwFlags = 0,
                    dwLoops = 0
                };

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    handle.Free();
                    waveOutClose(hWaveOut);
                    waveOutReset(hWaveOut);
                }
            }

        }
    }
}