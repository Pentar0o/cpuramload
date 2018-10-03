using System;
using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;
using OpenHardwareMonitor.Hardware;

namespace CpuLoad
{
    class Program
    {
        private static OpenHardwareMonitor.Hardware.IHardware InitGpuUsage()
        {
     
            Computer pc = new Computer();
            pc.GPUEnabled = true;
            pc.Open();
            return pc.Hardware[0];
        }

        private static float GetGPUUsage(IHardware hardware)
        {
            //Use NVApi for NVIDIA Cards & AMD Display Library for AMD Cards
            float ChargeGPU = 0;
            hardware.Update();
            for (int i = 0; i < hardware.Sensors.Length; i++)
            {
                if (hardware.Sensors[i].Name.Equals("GPU Core") && hardware.Sensors[i].SensorType == SensorType.Load)
                    ChargeGPU = hardware.Sensors[i].Value.GetValueOrDefault();
            }
            return ChargeGPU;
        }

        static void Main(string[] args)
        {
            Chroma.Instance.SetAll(ColoreColor.Blue);
            Chroma.Instance.Keyboard.SetKey(Key.F1, ColoreColor.White);
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            IHardware hardware;

            hardware = InitGpuUsage();

            float cpuload;
            float ramusage;
            int cpu;
            int ram;
            int gpu;

      
            while (true)
            {


                cpuload = cpuCounter.NextValue();
                ramusage = ramCounter.NextValue();


                cpu = Convert.ToInt16(cpuload);
                ram = Convert.ToInt16(ramusage);
                gpu = Convert.ToInt16(GetGPUUsage(hardware));


                //System.Console.Out.Flush();
                //System.Console.Out.WriteLine(string.Format("CPU : {0} / RAM : {1} / GPU : {2}", cpu, ram, gpu));

                //On affiche le tout comme un bourrin
                SetCpuColor(cpu);

                //On affiche la RAM
                SetRamColor(ram);

                //On affiche le GPU
                SetGpuColor(gpu);

                //On attends 500ms
                System.Threading.Thread.Sleep(500);

            }
        }

        private static void SetGpuColor(int gpu)
        {
            if (gpu >= 10)
            {
                Chroma.Instance.Keyboard.SetKey(Key.A, new ColoreColor(0, 0, 255));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.A, ColoreColor.White);

            if (gpu >= 20)
            {
                Chroma.Instance.Keyboard.SetKey(Key.Z, new ColoreColor(0, 50, 250));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.Z, ColoreColor.White);

            if (gpu >= 30)
            {
                Chroma.Instance.Keyboard.SetKey(Key.E, new ColoreColor(0, 100, 200));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.E, ColoreColor.White);

            if (gpu >= 40)
            {
                Chroma.Instance.Keyboard.SetKey(Key.R, new ColoreColor(0, 150, 150));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.R, ColoreColor.White);

            if (gpu >= 50)
            {
                Chroma.Instance.Keyboard.SetKey(Key.T, new ColoreColor(0, 200, 100));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.T, ColoreColor.White);

            if (gpu >= 60)
            {
                Chroma.Instance.Keyboard.SetKey(Key.Y, new ColoreColor(50, 255, 50));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.Y, ColoreColor.White);

            if (gpu >= 70)
            {
                Chroma.Instance.Keyboard.SetKey(Key.U, new ColoreColor(100, 200, 0));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.U, ColoreColor.White);

            if (gpu >= 80)
            {
                Chroma.Instance.Keyboard.SetKey(Key.I, new ColoreColor(150, 150, 0));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.I, ColoreColor.White);

            if (gpu >= 90)
            {
                Chroma.Instance.Keyboard.SetKey(Key.O, new ColoreColor(200, 100, 0));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.O, ColoreColor.White);

            if (gpu >= 99)
            {
                Chroma.Instance.Keyboard.SetKey(Key.P, new ColoreColor(255, 50, 0));
            }
            else Chroma.Instance.Keyboard.SetKey(Key.P, ColoreColor.White);
        }

        private static void SetRamColor(int ram)
        {
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
        }

        private static void SetCpuColor(int cpu)
        {
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
        }
    }
}
