using System;
using System.Collections;

namespace Week2Esercitazione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList listaTasks = new ArrayList();
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();

                switch (scelta)
                {
                    case 1:

                        listaTasks.Add(GestoreAgenda.InserisciTasks());
                        break;
                    case 2:

                        GestoreAgenda.StampalistaTasks(listaTasks);
                        break;

                    case 3:
                        GestoreAgenda.EliminaTasks(listaTasks);
                        break;

                    case 4:
                        GestoreAgenda.StampaTasksSuFile(listaTasks);
                        break;


                }
            }

        }

        public static int SchermoMenu()
        {
            Console.WriteLine("1. Aggiungi tasks");
            Console.WriteLine("2. Visualizza tasks");
            Console.WriteLine("3. Rimuovi tasks");
            //Console.WriteLine("4. Filtra importanza tasks");
            Console.WriteLine("4. Stampa file tasks.txt");
            Console.WriteLine("Qualsiasi altro valore per uscire");
            Console.Write("Scelta: >");
            Int32.TryParse(Console.ReadLine(), out int scelta);
            return scelta;
        }
    }
}


