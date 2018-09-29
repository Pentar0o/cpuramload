using System;
using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;

namespace CpuLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Chroma.Instance.SetAll(ColoreColor.Blue);
            Chroma.Instance.Keyboard.SetKey(Key.F1, ColoreColor.White);
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            float cpuload;
            float ramusage;
            int cpu;
            int ram;

            while (true)
            {
                cpuload = cpuCounter.NextValue();
                ramusage = ramCounter.NextValue();

                cpu = Convert.ToInt16(cpuload);
                ram = Convert.ToInt16(ramusage);

                //On affiche le tout comme un bourrin
                if (cpu >= 9)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F1, new ColoreColor(0, 0, 255));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F1, ColoreColor.White);

                if (cpu >= 18)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F2, new ColoreColor(0, 50, 250));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F2, ColoreColor.White);

                if (cpu >= 27)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F3, new ColoreColor(0, 100, 200));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F3, ColoreColor.White);

                if (cpu >= 36)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F4, new ColoreColor(0, 150, 150));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F4, ColoreColor.White);

                if (cpu >= 45)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F5, new ColoreColor(0, 200, 100));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F5, ColoreColor.White);

                if (cpu >= 54)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F6, new ColoreColor(50, 255, 50));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F6, ColoreColor.White);

                if (cpu >= 63)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F7, new ColoreColor(100, 200, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F7, ColoreColor.White);

                if (cpu >= 72)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F8, new ColoreColor(150, 150, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F8, ColoreColor.White);

                if (cpu >= 81)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F9, new ColoreColor(200, 100, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F9, ColoreColor.White);

                if (cpu >= 90)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F10, new ColoreColor(250, 50, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F10, ColoreColor.White);

                if (cpu >= 99)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.F11, new ColoreColor(255, 0, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.F11, ColoreColor.White);

                //On affiche la RAM
                if (ram >= 10)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D1, new ColoreColor(0, 0, 255));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D1, ColoreColor.White);

                if (ram >= 20)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D2, new ColoreColor(0, 50, 250));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D2, ColoreColor.White);

                if (ram >= 30)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D3, new ColoreColor(0, 100, 200));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D3, ColoreColor.White);

                if (ram >= 40)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D4, new ColoreColor(0, 150, 150));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D4, ColoreColor.White);

                if (ram >= 50)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D5, new ColoreColor(0, 200, 100));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D5, ColoreColor.White);

                if (ram >= 60)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D6, new ColoreColor(50, 255, 50));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D6, ColoreColor.White);

                if (ram >= 70)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D7, new ColoreColor(100, 200, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D7, ColoreColor.White);

                if (ram >= 80)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D8, new ColoreColor(150, 150, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D8, ColoreColor.White);

                if (ram >= 90)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D9, new ColoreColor(200, 100, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D9, ColoreColor.White);

                if (ram >= 99)
                {
                    Chroma.Instance.Keyboard.SetKey(Key.D0, new ColoreColor(255, 50, 0));
                }
                else Chroma.Instance.Keyboard.SetKey(Key.D0, ColoreColor.White);

                //On attends 500ms
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}
