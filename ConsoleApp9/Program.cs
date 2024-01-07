namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] winningNumbers = GenerateWinningNumbers();
            int maxTries = 5;
            int tries = 0;

            Console.WriteLine("Welcome to the Lottery Game!");
            Console.WriteLine("You have 5 tries to match the winning numbers.");
            Console.WriteLine();

            while (tries < maxTries)
            {
                Console.Write($"Attempt {tries + 1}: Enter 5 numbers (1-50) separated by spaces: ");
                string input = Console.ReadLine();

                string[] inputNumbers = input.Split(' ');

                if (inputNumbers.Length != 5)
                {
                    Console.WriteLine("Invalid input. Please enter exactly 5 numbers.");
                    continue;
                }

                int[] userNumbers = new int[5];

                bool validInput = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!int.TryParse(inputNumbers[i], out userNumbers[i]) || userNumbers[i] < 1 || userNumbers[i] > 50)
                    {
                        Console.WriteLine("Invalid input. Please enter 5 valid numbers between 1 and 50.");
                        validInput = false;
                        break;
                    }
                }

                if (!validInput)
                {
                    continue;
                }

                int matchedNumbers = CountMatchingNumbers(winningNumbers, userNumbers);

                Console.WriteLine($"Matching numbers: {matchedNumbers}");

                if (matchedNumbers == 5)
                {
                    Console.WriteLine("Congratulations! You've won the lottery!");
                    break;
                }

                tries++;
            }

            if (tries == maxTries)
            {
                Console.WriteLine("Sorry, you've used all your tries. The winning numbers were:");
                PrintArray(winningNumbers);
            }
        }

        static int[] GenerateWinningNumbers()
        {
            Random random = new Random();
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = random.Next(1, 51); // Generates random numbers between 1 and 50
            }
            return numbers;
        }

        static int CountMatchingNumbers(int[] winningNumbers, int[] userNumbers)
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (winningNumbers[i] == userNumbers[i])
                {
                    count++;
                }
            }
            return count;
        }

        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
    }
