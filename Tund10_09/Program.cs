using System;
using System.Security.Cryptography.X509Certificates;

namespace project
{
    internal class Program
    {
        static void Main()
        {

            {

                //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

                //var evenNumbers = array.Where(x => x % 2 == 0).ToArray();

                //if (evenNumbers.Length > 0)
                //{
                //    Console.WriteLine("Miniimalne number: " + string.Join(", ", evenNumbers));


                //    int sum = evenNumbers.Sum();
                //    Console.WriteLine("Summ: " + sum);


                //    int minEven = evenNumbers.Min();
                //    Console.WriteLine("Maksimaalne number: " + minEven);

                //    int maxEven = evenNumbers.Max();
                //    Console.WriteLine("Maksimalne even number: " + maxEven);
                //}
                //else
                //{
                //    Console.WriteLine("not number");
                //}


                //põhilised matematiilised tehted
                int liitmine = 1 + 1;// liitmine, kaks arvu liidetakse kokku
                int lahutamine = 1 - 1; //lahutamine , kus esimeste  arvust lahutatakse maha teine
                double korrutamine = 1 * 2;  //korutamine, kus teine arv korrutatakse esimine arvu kordi
                double jagamine = 1 / 2; // jagamine. esimene arv jagatakse teise arvuga
                double astendamine = Math.Pow(2, 2); // ruutujur, parameetrite juuritav arv
                double juurimine = Math.Sqrt(2); //ruutujur, parameetrina juuitav arv

                // muutuja nimed
                int arv = 0;
                string sõne = "abc";// sobib

                // muutuja nimeks ei sobi järgnevad sõnad
                //abstract,as ,base, bool, break, byte, case,
                //defult, delegate, do, double, else, enum, event
                //ecpliction , extern , false, finally, fixed, foat, for
                //is, lock, long, namespase, new, null, object, operator
                //ref, return, sbyte, seald, shoert, sizeof, stackalloc
                //static, string, struct, switch, this, throw, try, typeof
                //uint, uling, uncheckd, unsafe, ushort, using, virtual
                //viod, volatile, ,while.

                //3 kalkulator ifi  ja elseifdega
                Console.WriteLine("Tere. Sisesta esimine arv");

                Console.WriteLine("Здравствуйте. Введите первую цифру");
                int arv1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите вторую цифру");
                int arv2 = int.Parse(Console.ReadLine());
                Console.WriteLine("введите знак: / * + -");
                string tipe = Console.ReadLine();

                int result = 0;
                if (tipe == "+")
                {
                    result = arv1 + arv2;

                }
                else if (tipe == "-")
                {
                    result = arv1 - arv2;

                }
                else if (tipe == "/")
                {
                    result = arv1 / arv2;

                }
                else if (tipe == "*")
                {
                    result = arv1 * arv2;

                }
                else if (tipe == "*")
                {
                    result = (int)Math.Pow(arv1, arv2);

                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите, что может сделать калькулятор.");
                }
                if (result != 0)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Результат — 0, или вы попытались сделать что-то, что калькулятор не распознает.");
                }


            }
        }
    }
}


