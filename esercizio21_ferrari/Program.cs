using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio21_ferrari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[100];
            int n, p = 0;
            bool r = false;
            do
            {
                Console.WriteLine("Inserire numero di elementi iniziale: (0 < N < 25)");
                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > 25);
            int c = n;
            for (byte i = 0; i < n; i++)
            {
                Console.WriteLine($"Inserire elemento iniziale in posizione {i}: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            do
            {
                Console.WriteLine("Inserire la lettera associata alla funzione per selezionarla: ");
                Console.WriteLine("a - Aggiungere un elemento in coda all'array");
                Console.WriteLine("v - Visualizzare l'array che restituisca la stringa in HTML");
                Console.WriteLine("r - Ricerca un numero all'interno dell'array");
                Console.WriteLine("c - Cancellazione di un elemento nell'array");
                Console.WriteLine("i - Inserimento di un valore in una posizione dell'array");
                Console.WriteLine("s - Stampa dell'array aggiornato");
                Console.WriteLine("u - Uscita dal programma");
                string s = Console.ReadLine();
                switch(s){
                    case "a":
                        Console.WriteLine("Inserire numero in coda: ");
                        n = int.Parse(Console.ReadLine());
                        c = Coda(c, n, a);
                        break;
                    case "v":

                        break;
                    case "r":
                        Console.WriteLine("Inserire numero da ricercare: ");
                        n = int.Parse(Console.ReadLine());
                        p = Pos(p, c, n, a);
                        Console.WriteLine($"Il numero {n} si trova in posizione {p}");
                        p = 0;
                        break;
                    case "c":
                        Console.WriteLine("Inserire numero da cancellare: ");
                        n = int.Parse(Console.ReadLine());
                        c = Can(c, n, a);
                        break;
                    case "i":
                        break;
                    case "s":
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(a[i]+" ");
                        }
                        Console.WriteLine();
                        break;
                    case "u":
                        r = true;
                        break;
                }
            } while (r == false);
        }
        public static int Coda(int c, int n, int[] a)
        {
            if (c < a.Length)
            {
                a[c] = n;
                c++;
            }
            return c;
        }
        public static void Html()
        {

        }
        public static int Pos(int p, int c, int n, int[] a)
        {
            for (int i = 0; i < c; i++)
            {
                if (a[i] == n)
                {
                    p = i;
                }
                if (p == 0)
                {
                    p = -1;
                }
            }
            return p;
        }
        public static int Can(int c, int n, int[] a)
        {
            if (c > 1)
            {
                for (int i = 0; i < c; i++)
                {
                    if (a[i] == n)
                    {
                            for (; i < c - 1; i++)
                            {
                                a[i] = a[i + 1];
                            }
                            break;
                    }
                }
                c--;
            }
            return c;
        }
        public static int Insp()
        {
            return 0;
        }
        public static string Sta()
        {
            return "";
        }
    }
}