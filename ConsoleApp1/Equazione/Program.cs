using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equazione
{
    class Program
    {
        static void Main(string[] args)
        {
            //risoluzione di (3+2)-8*(4-6)/2-3

            //variabili
            int parentesi1 = 0;
            int parentesi2 = 0;
            int moltiplicazione = 0;
            int divisione = 0;
            int somma = 0;
            int sottrazione = 0;

            //parentesi
            //prima parentesi
            Task par1 = Task.Factory.StartNew(() =>
            {
                parentesi1= 3 + 2;
            });
            
            //seconda parentesi
            Task par2 = Task.Factory.StartNew(() =>
            {
                parentesi2 = 4-6;
            });

            //moltiplicazoini e divisioni
            Task.WaitAll(par1, par2);
            //moltiplicazione
            Task molt = Task.Factory.StartNew(() =>
            {
                moltiplicazione = -8 * parentesi2;
            });

            //divisione
            Task div = Task.Factory.StartNew(() =>
            {
                divisione = moltiplicazione / 2;
            });

            //somma e sottrazione
            Task.WaitAll(molt, div);
            //somma
            Task som = Task.Factory.StartNew(() =>
            {
                somma = parentesi1 + divisione;
            });

            //sottrazione
            Task sot = Task.Factory.StartNew(() =>
            {
                sottrazione = somma - 3;
            });

            Task.WaitAll(som, sot);
            Console.WriteLine($"(3+2)-8*(4-6)/2-3={sottrazione}");
            Console.ReadLine();
        }
    }
}
