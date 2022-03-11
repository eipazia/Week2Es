using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Week2Esercitazione.Entities;

namespace Week2Esercitazione
{
    internal class GestoreAgenda
    {
        internal static Tasks InserisciTasks()
        {
            Tasks tasks = new Tasks();


            Console.WriteLine("Inserisci descrizione");
            tasks.Descrizione = Console.ReadLine();
            Console.WriteLine("Inserisci anno");
            tasks.Anno = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci Priorità");
            tasks.Priorità = VerificaInputIntero();

            return tasks;
        }
        public static Tasks Cercatasks(ArrayList listaTasks)
        {
            Console.Write("Inserisci priorità: ");
            string priorità = Console.ReadLine();

            foreach (Tasks tasks in listaTasks)
            {
                if (tasks.Priorità.Equals(priorità))
                {
                    return tasks;
                }
            }
            return null;
        }


        public static int VerificaInputIntero()
        {
            int valoreIntero;
            bool conversion = Int32.TryParse(Console.ReadLine(), out valoreIntero);
            while (!conversion || valoreIntero < 0)
            {
                Console.WriteLine("Inserisci un valore corretto");
                conversion = Int32.TryParse(Console.ReadLine(), out valoreIntero);
            }
            return valoreIntero;
        }
        public static void EliminaTasks(ArrayList listaTasks)
        {
            Tasks tasksDaCancellare = Cercatasks(listaTasks);
            if (tasksDaCancellare != null)
            {
                listaTasks.Remove(tasksDaCancellare);
                Console.WriteLine("Cancellazione avvenuta con successo");
            }
            else
            {
                Console.WriteLine("Tasks non trovato");
            }
        }
        public static void StampaTasks(Tasks tasks)
        {
            Console.WriteLine(tasks);
        }
        public static void StampalistaTasks(ArrayList listaTasks)
        {
            foreach (Tasks tasks in listaTasks)
            {
                StampaTasks(tasks);
            }
        }
        public static void StampaTasksSuFile(ArrayList veicoli)
        {

            Console.Write("Stampa tasks "); string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tasxs.txt");
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Tasks tasksDaStampareSuFile in veicoli)
                {
                    sw.WriteLine($"Deacrizione: {tasksDaStampareSuFile.Descrizione} - " +
                        $"Scadenza: {tasksDaStampareSuFile.Anno} - " +
                        $"Priorità: {tasksDaStampareSuFile.Priorità} - ");
                    sw.WriteLine(tasksDaStampareSuFile);
                }
            }
        }
    }
}
