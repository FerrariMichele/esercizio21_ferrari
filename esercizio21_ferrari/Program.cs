using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace esercizio21_ferrari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[100];    //dichiarazione dell'array array1
            int c, n, p;                    //dichiarazione delle variabili c, n, p; rispettivamente la variabile della posizione dell'ultimo valore, la variabile che degli gli input e la variabile della posizione ricevuta in input
            bool r = false;                 //variabile booleana per l'uscita dal ciclo do while
            do                              //ciclo do while che verifica che l'input ricevuto sia compreso tra 0 e 25(per questione di comodità)
            {
                Console.WriteLine("Inserire numero di elementi iniziale: (0 < N < 25)");    //output del messaggio "Inserire numero di elementi iniziale: (0 < N < 25)"
                c = int.Parse(Console.ReadLine());                                          //assegnazione a c del valore ricevuto in input dall'utente
            } while (c < 0 || c > 25);                                                      //codizione che verifica che c sia <0 o >25 per ripetere il ciclo
            for (byte i = 0; i < c; i++)                                                    //ciclo for per chiedere all'utente l'input c volte
            {
                Console.WriteLine($"Inserire elemento iniziale in posizione {i}: ");        //output del messaggio "Inserire elemento iniziale in posizione {i}: " con {i} sostituito dal valore di i
                array1[i] = int.Parse(Console.ReadLine());                                  //salvataggio in array1[i] del valore ricevuto in input
            }
            Console.Clear();    //reset della console
            do                  //ciclo do while che verifica se ripetere il programma o chiuderlo
            {
                Console.WriteLine("Inserire la lettera associata alla funzione per selezionarla: \r\na - Aggiungere un elemento in coda all'array\r\nv - Visualizzare l'array che restituisca la stringa in HTML\r\nr - Ricerca un numero all'interno dell'array\r\nc - Cancellazione di un elemento nell'array\r\ni - Inserimento di un valore in una posizione dell'array\r\ns - Stampa dell'array aggiornato\r\nu - Uscita dal programma"); //output delle indicazioni
                switch (Console.ReadLine())         //switch che verifica l'input ricevuto
                {
                    case "a":                                                       //istruzioni da eseguire se l'input ricevuto è "a"
                        Console.WriteLine("Inserire elemento in coda: ");                       //output del messaggio "Inserire elemento in coda: "
                        n = int.Parse(Console.ReadLine());                                      //assegnazione a n del valore ricevuto in input dall'utente
                        if (Coda(array1, n, ref c) == true)                                     //condizione che verifica se la funzione Coda() restituisce valore true
                        {
                            Console.WriteLine("Elemento inserito correttamente");               //output del messaggio "Elemento inserito correttamente"
                        }
                        else                                                                    //istruzioni da eseguire se la condizione non è verificata                                     
                        {
                            Console.WriteLine("Array pieno");                                   //output del messaggio "Array pieno"
                        }
                        break;                                                                  //termina lo switch
                    case "v":                                                       //istruzioni da eseguire se l'input ricevuto è "v"
                        Console.WriteLine(Html(array1, ref c));                                 //output della stringa restituita dalla funzione Html()
                        break;                                                                  //termina lo switch
                    case "r":                                                       //istruzioni da eseguire se l'input ricevuto è "r"
                        Console.WriteLine("Inserire numero da ricercare: ");                    //output del messaggio "Inserire numero da ricercare: "
                        n = int.Parse(Console.ReadLine());                                      //assegnazione a n del valore ricevuto in input dall'utente
                        p = Posi(array1, n, ref c);                                             //assegnazione a p del valore restituito dalla dunzione Posi()
                        Console.WriteLine($"Il numero {n} si trova in posizione {p}");
                        break;                                                                  //termina lo switch
                    case "c":                                                       //istruzioni da eseguire se l'input ricevuto è "c"
                        Console.WriteLine("Inserire elemento da cancellare: ");                 //output del messaggio "Inserire elemento da cancellare: "
                        n = int.Parse(Console.ReadLine());                                      //assegnazione a n del valore ricevuto in input dall'utente
                        if ((Canc(array1, n, ref c)))                                           //condizione che verifica se la funzione Canc() restituisce valore true
                        {
                            Console.WriteLine("Elemento cancellato correttamente");             //output del messaggio "Elemento inserito correttamente"
                        }
                        else                                                                    //istruzioni da eseguire se la condizione non è verificata
                        {
                            Console.WriteLine("Array vuoto");                                   //output del messaggio "Array vuoto"
                        }
                        break;                                                                  //termina lo switch
                    case "i":                                                       //istruzioni da eseguire se l'input ricevuto è "i"
                        Console.WriteLine("Inserire elemento: ");                               //output del messaggio "Inserire elemento: "
                        n = int.Parse(Console.ReadLine());                                      //assegnazione a n del valore ricevuto in input dall'utente
                        Console.WriteLine("Inserire posizione dove aggiungere l'elemento: ");   //output del messaggio "Inserire posizione dove aggiungere l'elemento: "
                        p = int.Parse(Console.ReadLine());                                      //assegnazione a p del valore ricevuto in input dall'utente
                        if (Inse(array1, n, p, ref c) == true)                                  //condizione che verifica se la funzione Inse() restituisce valore true
                        {
                            Console.WriteLine("Elemento inserito correttamente");               //output del messaggio "Elemento inserito correttamente"
                        }
                        else                                                                    //istruzioni da eseguire se la condizione non è verificata
                        {
                            Console.WriteLine("Array pieno");                                   //output del messaggio "Array pieno"
                        }
                        break;                                                                  //termina lo switch
                    case "s":                                                       //istruzioni da eseguire se l'input ricevuto è "s"
                        for (int i = 0; i < c; i++)                                             //ciclo che stampa gli elementi presi in considerazione
                        {
                            Console.Write(array1[i] + " ");                                     //output di array1[i] seguito da uno spazio
                        }
                        Console.WriteLine();                                                    //a capo
                        break;                                                                  //termina lo switch
                    case "u":                                                       //istruzioni da eseguire se l'input ricevuto è "u"
                        r = true;                                                               //assegnazione a r il valore true
                        break;                                                                  //termina lo switch
                    default: Console.WriteLine("Opzione non valida");             //istruzioni da eseguire se l'input non è tra le opzioni precedenti
                        break;                                                                  //termina lo switch
                }
                Console.WriteLine("Premere un tasto per continuare");       //output del messaggio "Premere un tasto per continuare"
                Console.ReadKey();                                          //input di un carattere per continuare
                Console.Clear();                                            //reset della console
            } while (r == false);       //condizione che verifica se r è == a false per ripetere il cilo do while
        }
        static bool Coda(int[] array, int numero, ref int indice)                       //funzione che aggiunge in coda un elemento all'array (interi)
        {
            bool inserito = true;               //variabile inserito di tipo bool, per comunicare l'eventuale funzionamento della funzione, alla quale viene assegnato il valore true
            if (indice < array.Length)          //condizione che verifica se l'indice è < della lunghezza dell'array
            {
                array[indice] = numero;         //assegnazione ad array[indice] del valore di numero
                indice++;                       //incremento di indice
            }
            else                                //istruzioni da eseguire se la condizione non è verificata
            {
                inserito = false;               //assegnazione a inserito del valore false
            }
            return inserito;                    //ritorna il valore di inserito
        }
        static string Html(int[] array, ref int indice)                                 //funzione che genera il codice html necessario a mostrare l'array
        {
            string s;                                                               //dichiarazione della variabile locale s, di tipo string
            s = "<!DOCTYPE html>\r\n<html lang=\"it\">\r\n    <head>\r\n        <title>Visualizzazione dell'array</title>\r\n    </head>\r\n    <body>\r\n        <table>\r\n            <tr>";      //assegnazione della stringa precedente ad s
            for (int i = 0; i < indice; i++)                                        //ciclo che concatena ad s i valori nell'array, ponenodli in <td></td>
             {
               s += $"<td>{array[i]}</td>";                                         //concatena ad s "<td>{array[i]}</td>" dove al posto di {array[i]} si trova il valore di array[i]
            }
            s += "</tr>\r\n        </table>\r\n    </body>\r\n</html>";             //concatena ad s "</tr>\r\n        </table>\r\n    </body>\r\n</html>"
            return s;                                                               //ritorna la stringa s
        } 
        static bool Canc(int[] array, int numero, ref int indice)                       //funzione che cancella un numero ricevuto in input dall'array
        {
            bool inserito = true;                           //variabile inserito di tipo bool, per comunicare l'eventuale funzionamento della funzione, alla quale viene assegnato il valore true
            if (indice > 0)                                 //condizione che verifica se indice è > 0
            {
                for (int i = 0; i < indice; i++)            //ciclo che verifica se array[i] == numero per ogni valore da 0 a indice
                {
                    if (array[i] == numero)                 //condizione che verifica se array[i] == numero
                    {
                        for (; i < indice - 1; i++)         //ciclo che sostituisce ad ogni array[i] il valore successivo nell'array
                        {
                            array[i] = array[i + 1];        //assegnazione del valore array[i + 1] ad array[i]
                        }
                        indice--;                           //decremento dell'indice
                        break;                              //termina il ciclo
                    }
                }
            }
            else                                            //istruzioni da eseguire se la condizione non è verificata 
            {
                inserito = false;                           //assegnazione a inserito del valore false
            }
            return inserito;                                //ritorna il valore di inserito
        }
        static int Posi(int[] array, int numero, ref int indice)                        //funzione che restituisce la posizione del valore ricevuto in input
        {
            int posizione = -1;                         //variabile di tipo int, alla quale viene assegnato il valore -1, che indica la posizione del numero
            for (int i = 0; i < indice; i++)            //ciclo for che controlla tutti i valori con indice da 0 a indice
            {
                if (array[i] == numero)                 //condizione che verifica se array[i] == numero
                {
                    posizione = i;                      //assegnazione a posizione del valore di i
                }
            }
            return posizione;                           //ritorna il valore di posizione
        }
        static bool Inse(int[] array, int numero, int posizione, ref int indice)        //funzione che aggiunge in una posizione ricevuta in input un elemento all'array (interi)
        {
            bool inserito = true;                               //variabile inserito di tipo bool, per comunicare l'eventuale funzionamento della funzione, alla quale viene assegnato il valore true
            if (indice < array.Length)                          //condizione che verifica se l'indice è < della lunghezza dell'array
            {
                indice++;                                       //incremento di indice
                for (int i = indice; i > posizione; i--)        //ciclo che assegna il valore array[i - 1] a array[i] per le i > di posizione, decrementanto la i
                {
                    array[i] = array[i - 1];                    //assegnazione ad array[i] del valore di array[i - 1], ovvero il valore nella posizione precedente
                }
                array[posizione] = numero;                      //assegnazione ad array[posizione] del valore di numero
            }
            else                                                //istruzioni da eseguire se la condizione non è verificata
            {
                inserito = false;                               //assegnazione a inserito del valore false
            }
            return inserito;                                    //ritorna il valore di inserito
        }
    }
}