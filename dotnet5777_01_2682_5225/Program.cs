using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Ido Harel - ID:203865225
//Yohanan Haik - ID:036902682
namespace dotnet5777_01_2682_5225
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("For guessing number game, please enter 1\nFor magic square game, please enter 2.\nFor exit, enter 0\n");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        randomGame();//both of the random option are include in the function
                        break;
                    case 2:
                        magicSquare();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR, try again!");//just make sure there's no wrong input
                        break;
                }
            } while (choice != 0);//while choice=0, the program exit
        }

        static void randomGame()
        {
            Random r = new Random();//define the random number
            int[] rand = new int[100];
            for (int i = 0; i < 100; i++)
            {
                rand[i] = r.Next(1001);//random number between 0-1000
            }
            int choice;
            do
            {
                Console.WriteLine("For guessing one number, please enter 1\nFor guessing number range, please enter 2.\nFor exit, enter 0\n");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        guessOneNumber(rand);//guess one number from the array
                        break;
                    case 2:
                        guessNumRange(rand);//gues how many numbers within the range
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR, try again!");
                        break;
                }
            } while (choice != 0);
        }

        private static void guessNumRange(int[] rand)
        {
            Console.WriteLine("Please insert 3 numbers:\nFirst 2 numbers for numbers range, and another for how many numbers you guess in that range.");
            int min = Convert.ToInt32(Console.ReadLine());
            int max = Convert.ToInt32(Console.ReadLine());
            int num = Convert.ToInt32(Console.ReadLine());
            if (max < min)//swap the numbers if needed
            {
                int temp = max;
                max = min;
                min = temp;
            }
            int counter = 0;
            foreach (var item in rand)
            {
                if (item >= min && item <= max)
                    counter++;//sum the appearances in the range
            }
            if (counter == num)
                Console.WriteLine("Your guess is correct!");
            else Console.WriteLine("Your guess is wrong!");
        }

        private static void guessOneNumber(int[] rand)
        {
            Console.WriteLine("Insert number between 0-1000");
            int guess = Convert.ToInt32(Console.ReadLine());

            bool flag = false;
            foreach (int item in rand)
            {
                if (guess == item)
                {
                    flag = true;
                    break;
                }

            }
            if (flag == true)
                Console.WriteLine("Your guess is correct!\nThe number {0} appear in the array!", guess);
            else
                Console.WriteLine("Your guess is wrong!\nThe number {0} isn't appear in the array!", guess);
        }

        static void magicSquare()
        {
            int[,] square = new int[5, 5];//define two-dimensional array
            Console.WriteLine("Please enter 25 square numbers, seperate by enter between each row\n");
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    square[i, j] = Convert.ToInt32(Console.ReadLine());
            //define help vars:
            bool magic = true;
            int sum = 0;
            int sumTemp;
            //check #0 - define the sum
            for (int i = 0; i < 5; i++)
                sum += square[0, i];
            //check #1 - rows check
            for (int i = 1; i < 5; i++)
            {
                sumTemp = 0;
                for (int j = 0; j < 5; j++)
                    sumTemp += square[i, j];
                if (sumTemp != sum)
                {
                    magic = false;
                    break;
                }
            }
            if (magic == false)
            {
                Console.WriteLine("This is not magic square!");
                return;//if this is no magic square there's no need to continue the checks
            }
            //check #2 - columns check
            for (int i = 0; i < 5; i++)
            {
                sumTemp = 0;
                for (int j = 0; j < 5; j++)
                    sumTemp += square[j, i];
                if (sumTemp != sum)
                {
                    magic = false;
                    break;
                }
            }
            if (magic == false)
            {
                Console.WriteLine("This is not magic square!");
                return;
            }
            sumTemp = 0;
            //check #3 - diagonal first check
            for (int i = 0; i < 5; i++)
            {
                sumTemp += square[i, i];
               
            }
            if (sumTemp != sum)
            {
                Console.WriteLine("This is not magic square!");
                return;
            }
            sumTemp = 0;
            //check #4 - diagonal second check
            for (int i =4, j=0; i >=0|| j<5 ; j++,i--)
            {
                    sumTemp += square[i, j];
            }
            if (sumTemp != sum)
            {
                Console.WriteLine("This is not magic square!");
                return;
            }
            Console.WriteLine("Behold the magic square! Hoozah!");
            return;
        }
    }
}

