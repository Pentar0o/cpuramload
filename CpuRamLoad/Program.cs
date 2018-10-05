using System;
using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace CpuLoad
{
    class Program
    {
        private static int GetGpuUsage()
        {
            Computer pc = new Computer();
            pc.GPUEnabled = true;
            pc.Open();
            float ChargeGPU;
            ChargeGPU = pc.Hardware[0].Sensors[5].Value.GetValueOrDefault();

            return Convert.ToInt16(ChargeGPU);
        }

        static void Main(string[] args)
        {
            //On éclaire tout en Bleu
            Chroma.Instance.SetAll(ColoreColor.Blue);

            //On définit les touches à allumer pour le GPU
            List<Key> GpuKeys = new List<Key>();
            GpuKeys.Add(Key.A);
            GpuKeys.Add(Key.Z);
            GpuKeys.Add(Key.E);
            GpuKeys.Add(Key.R);
            GpuKeys.Add(Key.T);
            GpuKeys.Add(Key.Y);
            GpuKeys.Add(Key.U);
            GpuKeys.Add(Key.I);
            GpuKeys.Add(Key.O);
            GpuKeys.Add(Key.P);

            //On définit les touches à allumer pour le CPU
            List<Key> CpuKeys = new List<Key>();
            CpuKeys.Add(Key.F1);
            CpuKeys.Add(Key.F2);
            CpuKeys.Add(Key.F3);
            CpuKeys.Add(Key.F4);
            CpuKeys.Add(Key.F5);
            CpuKeys.Add(Key.F6);
            CpuKeys.Add(Key.F7);
            CpuKeys.Add(Key.F8);
            CpuKeys.Add(Key.F9);
            CpuKeys.Add(Key.F10);

            //On définit les touches à allumer pour la RAM
            List<Key> RamKeys = new List<Key>();
            RamKeys.Add(Key.D1);
            RamKeys.Add(Key.D2);
            RamKeys.Add(Key.D3);
            RamKeys.Add(Key.D4);
            RamKeys.Add(Key.D5);
            RamKeys.Add(Key.D6);
            RamKeys.Add(Key.D7);
            RamKeys.Add(Key.D8);
            RamKeys.Add(Key.D9);
            RamKeys.Add(Key.D0);

            //On définit les couleurs des 10 touches utilisées du bleu au rouge
            List<ColoreColor> Couleurs = new List<ColoreColor>();
            Couleurs.Add(new ColoreColor(0, 0, 250));
            Couleurs.Add(new ColoreColor(0, 100, 200));
            Couleurs.Add(new ColoreColor(0, 150, 150));
            Couleurs.Add(new ColoreColor(0, 200, 100));
            Couleurs.Add(new ColoreColor(0, 250, 50));
            Couleurs.Add(new ColoreColor(50, 250, 50));
            Couleurs.Add(new ColoreColor(100, 200, 0));
            Couleurs.Add(new ColoreColor(150, 100, 0));
            Couleurs.Add(new ColoreColor(250, 50, 0));
            Couleurs.Add(new ColoreColor(250, 0, 0));


            //On initialise les variables pour récupérer les valeurs CPU, GPU, RAM
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            float CpuLoad;
            float RamUsage;
            int GpuUsage;

            while (true)
            {
                CpuLoad = cpuCounter.NextValue();
                RamUsage = ramCounter.NextValue();
                GpuUsage = GetGpuUsage();

                //On affiche le tout comme un bourrin
                Eclairage(Convert.ToInt16(CpuLoad), CpuKeys, Couleurs);
                Eclairage(Convert.ToInt16(RamUsage), RamKeys, Couleurs);
                Eclairage(Convert.ToInt16(GpuUsage), GpuKeys, Couleurs);
            
                //On attends 100ms
                System.Threading.Thread.Sleep(100);
            }
        }

        private static void Eclairage(int charge, List<Key> Touches, List<ColoreColor> Couleurs)
        {
            int compteur = 0;

            if (charge == 100) compteur = 9;
            if (charge < 10) compteur = 1;
            if (charge > 10 && charge < 100) compteur = (charge / 10);

            for (int i=0; i<compteur; i++)
            {
                Chroma.Instance.Keyboard.SetKey(Touches[i], Couleurs[i]);
            }
            for (int i=compteur; i<=9; i++)
            {
                Chroma.Instance.Keyboard.SetKey(Touches[i], ColoreColor.White);
            }
        }
         
    }
}
