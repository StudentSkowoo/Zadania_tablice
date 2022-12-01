using System.Buffers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;

namespace Zadania_tablice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("podaj ciąg liczb oddzielonych spacjami: (ostatni wyraz ciągu służy jako N przy wybranych zadaniach!");
            string[] input = Console.ReadLine().Split(' ');
            int[] array = new int[input.Length];

            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    array[i] = int.Parse(input[i]);
                }
            }
            catch
            {
                Console.WriteLine("unable to parse one of input numbers");
                return;
            }

            int n = array[array.Length - 1]; //Last digit in input array will be the limit for additional tasks
            if ( n <= 0 )
            {
                Console.WriteLine("n musi być większe od zera!");
                return;
            }
            


            //Tasks
            Console.WriteLine("\nWyszukiwanie w tablicy:");
            Zad8_2_1(array);
            Zad8_2_2(array);
            Zad8_2_3(array);
            Zad8_2_4(array);
            Zad8_2_5(array);
            Zad8_2_6(array);
            Zad8_2_7(array);
            Zad8_2_8(array);
            Console.WriteLine("\nPrzetwarzanie elementów tablicy:");
            Zad8_3_1(array);
            Zad8_3_2(array);
            Zad8_3_3(array);
            Zad8_3_4(array);
            Console.WriteLine("\nPrzetwarzanie elementów tablicy o zadanych wartościach:");
            Zad8_4_1(array);
            Zad8_4_2(array);
            Zad8_4_3(array);
            Zad8_4_4(array);
            Zad8_4_5(array);
            Zad8_4_6(array);
            Zad8_4_7(array);
            Zad8_4_8(array);
            Console.WriteLine("\nPrzetwarzanie elementów tablicy o zadanych indeksach:");
            Zad8_5_1(array);
            Zad8_5_2(array);
            Console.WriteLine("\nRóżne:");
            Zad8_6_1(n);
            Zad8_6_2(n);
            Zad8_6_3(array);
            Zad8_6_4(n);

            return;
        }

        //Find:

        static void Zad8_2_1(int[] array) //Maksymalna wartość
        {
            int max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine("Zadanie 8.2.1:  Największa liczba to: " + max);
            return;
        }

        static void Zad8_2_2(int[] array) //Minimalna wartość
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine("Zadanie 8.2.2:  Najmniejsza liczba to: " + min);
            return;
        }

        static void Zad8_2_3(int[] array) //Max plus liczenie
        {
            int max = array[0];
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    counter = 1;
                }
                else if (array[i] == max)
                {
                    counter++;
                }
            }
            Console.WriteLine("Zadanie 8.2.3:  Największa liczba to {0}, wystąpiła {1} razy.", max, counter);
            return;
        }

        static void Zad8_2_4(int[] array) //Min plus liczenie
        {
            int min = array[0];
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    counter = 1;
                }
                else if (array[i] == min)
                {
                    counter++;
                }
            }
            Console.WriteLine("Zadanie 8.2.4:  Najmniejsza liczba to {0}, wystąpiła {1} razy.", min, counter);
            return;
        }

        static void Zad8_2_5(int[] array) //Secondmax
        {
            int max = array[0]; //Max value
            int secondMax = array[0]; //Second Max value

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    secondMax = max;
                    max = array[i];
                }
                else if ((secondMax == max & array[i] < max) | array[i] > secondMax & array[i] < max)
                {
                    secondMax = array[i];
                }
            }
            Console.WriteLine("Zadanie 8.2.5:  Druga największa liczba to: " + secondMax);
            return;
        }
        
        static void Zad8_2_6(int[] array) //Secondmin
        {
            int min = array[0];
            int secondMin = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    secondMin = min;
                    min = array[i];
                }
                else if ((min == secondMin & array[i] > min) | (array[i] > min & array[i] < secondMin))
                {
                    secondMin = array[i]; 
                }
            }

            Console.WriteLine("Zadanie 8.2.5:  Druga najmniejsza liczba to: " + secondMin);
            return;
        }

        static void Zad8_2_7(int[] array) //SecondMax with counter
        {
            int max = array[0];
            int secondMax = array[0];
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    secondMax = max;
                    max = array[i];
                }
                else if ((max == secondMax & array[i] < max) | (array[i] < max & array[i] > secondMax))
                {
                    secondMax = array[i];
                }
            }

            for (int j = 0; j < array.Length; j++)
                if (array[j] == secondMax)
                    counter++; //Second loop to count all secondMax

            Console.WriteLine("Zadanie 8.2.7:  Druga największa liczba to {0} i wystąpiła {1} razy.", secondMax, counter);
            return;
        }

        static void Zad8_2_8(int[] array) //SecondMin with counter
        {
            int min = array[0];
            int SecondMin = array[0];
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    SecondMin = min;
                    min = array[i];
                }
                else if ((min == SecondMin & array[i] > min) | (array[i] > min & array[i] < SecondMin))
                {
                    SecondMin = array[i];
                }
            }

            for (int j = 0; j < array.Length; j++)
                if (array[j] == SecondMin)
                    counter++; //Second loop to count all secondMins


            Console.WriteLine("Zadanie 8.2.8:  Druga najmniejsza liczba to {0} i wystąpiła {1} razy.", SecondMin, counter);
            return;
        }

        //Modify:

        static void Zad8_3_1(int[] array) //Do kwadratu
        {
            string output = "Zadanie 8.3.1:  Ciąg liczb podniesionych do kwadratu: ";

            int[] temp = new int[array.Length]; // temp array to don't mess with original values
            for (int j = 0; j < array.Length; j++)
            {
                temp[j] = array[j];
            }


            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = temp[i] * temp[i];
                output += temp[i].ToString() + ' ';
            }

            Console.WriteLine(output);
        }

        static void Zad8_3_2(int[] array) //Do 3 potęgi
        {
            string output = "Zadanie 8.3.2:  Ciąg liczb podniesionych do trzeciej potęgi: ";

            int[] temp1 = new int[array.Length]; // temp array to don't mess with original values
            for (int j = 0; j < array.Length; j++)
            {
                temp1[j] = array[j];
            }

            for (int i = 0; i < temp1.Length; i++)
            {
                temp1[i] = temp1[i] * temp1[i] * temp1[i];
                output += temp1[i].ToString() + ' ';
            }

            Console.WriteLine(output);
        }

        static void Zad8_3_3(int[] array) // +1
        {
            string output = "Zadanie 8.3.3:  Ciąg liczb powiększonych o jeden: ";


            int[] temp2 = new int[array.Length]; // temp array to don't mess with original values
            for (int j = 0; j < array.Length; j++)
            {
                temp2[j] = array[j];
            }

            for (int i = 0; i < temp2.Length; i++)
            {
                temp2[i] += 1;
                output += temp2[i].ToString() + ' ';
            }

            Console.WriteLine(output);
        }

        static void Zad8_3_4(int[] array) // * 2
        {
            string output = "Zadanie 8.3.4:  Ciąg liczb pomnożonych razy dwa: ";
            int[] temp3 = new int[array.Length]; // temp array to don't mess with original values
            for (int j = 0; j < array.Length; j++)
            {
                temp3[j] = array[j];
            }

            for (int i = 0; i < temp3.Length; i++)
            {
                temp3[i] *= 2;
                output += temp3[i].ToString() + ' ';
            }

            Console.WriteLine(output);
        }

        //Print out:

        static void Zad8_4_1(int[] array)
        {
            string output = "Zadanie 8.4.1:  Wypisane liczby parzyste: ";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }// Parity

        static void Zad8_4_2(int[] array) //Not parity
        {
            string output = "Zadanie 8.4.2:  Wypisane liczby nieparzyste: ";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }

        static void Zad8_4_3(int[] array) // Divided by 3
        {
            string output = "Zadanie 8.4.3:  Wypisane liczby podzielne przez 3: ";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 3 == 0)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }

        static void Zad8_4_4(int[] array) // [4:15>
        {
            string output = "Zadanie 8.4.4:  Wypisane liczby z przedziału [4:15>: ";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 4 & array[i] <= 15)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }

        static void Zad8_4_5(int[] array) //Wszystkie cyfry w liczbie są parzyste
        {
            string output = "Zadanie 8.4.5:  Wypisane liczby w których wszystkie cyfry w liczbie są parzyste: ";
            string temp;
            bool parity = true;

            for (int i = 0; i < array.Length; i++)
            {

                parity = true; //Reset bool

                temp = array[i].ToString(); //Convert value to string

                for (int j = 0; j < temp.Length; j++) //For every char in temp string
                {
                    if (((int)temp[j] - 48 ) % 2 != 0) //If number is NOT dividable by 2
                    {
                        parity = false; 
                        break;
                    }                    
                }

                if (parity)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }

        static void Zad8_4_6(int[] array) //Suma cyfr = 1
        {
            string output = "Zadanie 8.4.6:  Wypisane liczby w których suma wszystkich cyfr wynosi 1: ";
            int tempSum;
            string tempString;

            for (int i = 0; i < array.Length; i++)
            {
                tempString = array[i].ToString();
                tempSum = 0; //zeroing tempSum!

                for (int j = 0; j < tempString.Length; j++)
                {
                    if (tempString[j] != '-') // if char is not -
                    {
                        tempSum += (int)tempString[j] - 48; //Calculate sum of number
                    }                           
                }

                if (tempSum == 1)
                {
                    output += array[i].ToString() + ' ';
                }

            }

            Console.WriteLine(output);
        }

        static void Zad8_4_7(int[] array) // parity += 100
        {
            string output = "Zadanie 8.4.7:  Wypisany ciąg w którym do liczb parzystych dodano 100: ";
            int[] temp5 = new int[array.Length];
            for (int k = 0; k < array.Length; k++)
            {
                temp5[k] = array[k];
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (temp5[i] % 2 == 0)
                {
                    temp5[i] += 100;
                }
                output += temp5[i].ToString() + ' ';
            }

            Console.WriteLine(output);
        }

        static void Zad8_4_8(int[] array) // if number < 0, then replace by 0
        {
            string output = "Zadanie 8.4.8:  Wypisany ciąg w którym liczby ujemne zostały zastąpione zerami: ";
            int[] temp6 = new int[array.Length];
            for (int k = 0; k < array.Length; k++)
            {
                temp6[k] = array[k];
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (temp6[i] < 0)
                {
                    temp6[i] = 0;
                }
                output += temp6[i].ToString() + ' ';
            }

            Console.WriteLine(output);
        }

        // Processing array items by it's index

        static void Zad8_5_1(int[] array)
        {
            string output = "Zadanie 8.5.1:  Wypisane liczby o parzystym indeksie: ";

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }

        static void Zad8_5_2(int[] array)
        {
            string output = "Zadanie 8.5.2:  Wypisane liczby o indeksie który jest kwadratem liczby rzeczywistej: ";

            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Sqrt(i) % 1 == 0)
                {
                    output += array[i].ToString() + ' ';
                }
            }

            Console.WriteLine(output);
        }

        // Various

        static void Zad8_6_1(int n)
        {
            
            int[] EratosArray = new int[n + 2];
            int target = (int)Math.Floor(Math.Sqrt(n));

            //Fill the arrays with numbers
            for (int i = 1; i <= n; i++)
            {
                EratosArray[i] = i;
            }

            int j;
                        
            for (int i = 2; i <= target; i++) //For target starting from 2
            {
                if (EratosArray[i] != 0) //If number is not 0
                {
                    j = i + i;
                    while (j <= n)
                    {
                        EratosArray[j] = 0;
                        j += i;
                    }
                }
            }

            //Printout the output
            string output = "Zadanie 8.6.1:  Liczby pierwsze z zakresu od 2 do " + n + " to: ";
            for (int i = 2; i <= n; i++)
            {
                if (EratosArray[i] != 0)
                {
                    output += EratosArray[i].ToString() + ' ';
                }
            }
            Console.WriteLine(output);
                    
        } //Erastotanes

        static void Zad8_6_2(int n) //Fibonacci
        {
            string Ntemp = n.ToString();
            string output = "Zadanie 8.6.2:  " + Ntemp + " Wyrazów ciągu fibonacciego: 0 1 1 ";

            if (n== 1)
            {
                Console.WriteLine("Zadanie 8.6.2:  1 Wyraz ciągu fibonacciego: 0 ");
                return;
            }
            else if (n== 2)
            {
                Console.WriteLine("Zadanie 8.6.2:  2 Wyrazy ciągu fibonacciego: 0 1");
                return;
            }
            else if (n== 3)
            {
                Console.WriteLine("Zadanie 8.6.2:  2 Wyrazy ciągu fibonacciego: 0 1 1");
                return;
            }

            int[] fibo = new int[n];
            fibo[0] = 0; 
            fibo[1] = 1; 
            fibo[2] = 1;
            for (int i = 3; i < n; i++)
            {
                fibo[i] = fibo[i - 2] + fibo[i - 1];
                output+= fibo[i].ToString() + " ";
            }

            Console.WriteLine(output);
        }

        static void Zad8_6_3(int[] array)
        {
            int[] temp7 = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                temp7[i] = array[i]; //Creating new array to avoid chaning original input values

            int minIndex;
            int temp;

            //30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1

            for (int j = 0; j < temp7.Length / 2; j++)// Check all array
            {
                minIndex = j; //Reset minIndex value for nex place to sort

                for (int k = 0 + j; k < temp7.Length; k++) //Check all other places in array (add value from upper loop to avoid replications)
                {
                    if (temp7[minIndex] > temp7[k]) // If number is smaller than minimum
                    {
                        minIndex = k; //Replace the indexes
                    }
                }
                temp = temp7[j]; //Move number from first place of checked array to temp
                temp7[j] = temp7[minIndex]; //Replace firrst place with minimum number
                temp7[minIndex] = temp; // Move value from first place stored in temp to place after minimal value

                //string tempOutput = "Przejście: " + j;
                //for (int l = 0; l < temp7.Length; l++)
                //{
                //    tempOutput += temp7[l].ToString() + ' ';
                //}
                //Console.WriteLine(tempOutput); //Diagnostic printout of current status
            }

            string output = "Zadanie 8.6.3:  Posortowane metodą kolejnych minimów: ";
            for (int l = 0; l < temp7.Length; l++)
            {
                output += temp7[l].ToString() + ' ';
            }
            Console.WriteLine(output);
        }// Sortowanie kolejnych minimów

        static void Zad8_6_4(int n)//Filling with arrays
        {
            int[] ints = new int[n];
            string output = "Zadanie 8.6.4:  Tablica dla podpunktu A: ";
            //A
            for (int a = 0; a < n; a++)
            {
                ints[a] = a;
                output += ints[a].ToString() + ' ';
            }
            Console.WriteLine(output);

            //B
            output = "Zadanie 8.6.4:  Tablica dla podpunktu B: ";
            for (int a = 0; a < n; a++)
            {
                ints[a] = a + 7;
                output += ints[a].ToString() + ' ';
            }
            Console.WriteLine(output);

            //C
            output = "Zadanie 8.6.4:  Tablica dla podpunktu C: ";
            int temp = 4;
            for (int a = 0; a < n; a++)
            {
                ints[a] = temp;
                temp += 4;
                output += ints[a].ToString() + ' ';
            }
            Console.WriteLine(output);

            //D
            if (n == 1)
            {
                Console.WriteLine("Zadanie 8.6.4:  Tablica dla podpunktu D: 1");
                Console.WriteLine("Zadanie 8.6.4:  Tablica dla podpunktu E: 2");
                return;
            }
            else if (n == 2)
            {
                Console.WriteLine("Zadanie 8.6.4:  Tablica dla podpunktu D: 1 2 ");
                Console.WriteLine("Zadanie 8.6.4:  Tablica dla podpunktu E: 2 3");
                return;
            }

            output = "Zadanie 8.6.4:  Tablica dla podpunktu D: 1 2 ";
            ints[0] = 1;
            ints[1] = 2;
            for (int a = 2; a < n; a++)
            {
                ints[a] = ints[a-1] * 2;
                temp *= 2;
                output += ints[a].ToString() + ' ';
            }
            Console.WriteLine(output);

            //E
            output = "Zadanie 8.6.4:  Tablica dla podpunktu E: ";
            for (int a = 0; a < n; a++)
            {
                ints[a] = a + 2;
                output += ints[a].ToString() + ' ';
            }
            Console.WriteLine(output);
        }
    }
}