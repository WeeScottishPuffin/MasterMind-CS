using System;
using System.Drawing;
using System.IO;

namespace MasterMind
{
    public class MainProg
    {
        private static void Clear()
        {
            for (int j = 0; j < 50; ++j)
            {
                Console.WriteLine();
            }
        }

        static void Main()
        {
            //Constants
            const string SPLASH = "\u001B[31m8b    d8 \u001B[32m   db    \u001B[33m.dP\"Y8 \u001B[34m888888 \u001B[35m888888 \u001B[36m88\"\"Yb\u001B[0m 8b    d8 88 88b 88 8888b.\n\u001B[31m88b  d88 \u001B[32m  dPYb   \u001B[33m`Ybo.\" \u001B[34m  88   \u001B[35m88__   \u001B[36m88__dP\u001B[0m 88b  d88 88 88Yb88  8I  Yb\n\u001B[31m88YbdP88 \u001B[32m dP__Yb  \u001B[33mo.`Y8b \u001B[34m  88   \u001B[35m88\"\"   \u001B[36m88\"Yb\u001B[0m  88YbdP88 88 88 Y88  8I  dY\n\u001B[31m88 YY 88 \u001B[32mdP\"\"\"\"Yb \u001B[33m8bodP' \u001B[34m  88   \u001B[35m888888 \u001B[36m88  Yb\u001B[0m 88 YY 88 88 88  Y8 8888Y\"  ";
            const int TURNS = 10;
            const int LENGTH = 4;
            //Flags
            bool win = false, quit = false;
            //Arrs
            string[] solution = new string[LENGTH];
            string[] guess = new string[LENGTH];
            string[][] results = new string[TURNS][];
            string[][] guesses = new string[TURNS][];
            for (int i = 0; i < TURNS; i++)
            {
                results[i] = new string[LENGTH];
                guesses[i] = new string[LENGTH];
            }
            //Misc variables
            string guesslog;
            int guessnum = -1;
            string[] coloursShort = [.. Colours.ColourPairs().Keys];

            //Generate the solution
            Random random = new();
            for (int i = 0; i < LENGTH; i++)
            {
                solution[i] = coloursShort[random.Next(1, coloursShort.Length)];
            }
            //Test
            //Console.WriteLine(solution[0] + solution[1] + solution[2] + solution[3]);
            //Splash screen
            Clear();
            Console.WriteLine(SPLASH);
            Console.WriteLine("\nBy ScottishPuffin (Naut van der Winden)");
            Console.Write("Press <RETURN> to start");
            Console.ReadLine();
            Clear();
            //Mainloop
            for (int guessn = 0; guessn < TURNS; guessn++)
            {
                //Print old guesses
                for (int j = 0; j < LENGTH; j++)
                {
                    string guess_ = "";
                    guesslog = Visualiser.VisualisedGuess(LENGTH, guesses, results, guessn);
                    while (!coloursShort.Contains(guess_) && !"e".Equals(guess_))
                    {
                        Clear();
                        Console.WriteLine(guesslog);
                        Console.WriteLine("Guess " + (guessn + 1) + "/" + TURNS + ":");
                        Console.WriteLine("What colour for position " + (j + 1) + " (\u001B[31m[R]ed, \u001B[32m[G]reen, \u001B[33m[Y]ellow, \u001B[34m[B]lue, \u001B[35m[M]agenta, \u001B[36m[C]yan\u001B[0m or [E]xit):");
                        guess_ = Console.ReadLine().ToLower();
                    }
                    if ("e".Equals(guess_))
                    {
                        quit = true;
                        break;
                    }
                    guess[j] = guess_;
                    guesses[guessn][j] = guess_;
                }
                if (quit) { break; }
                //Check
                win = true;
                for (int i = 0; i < LENGTH; i++)
                {
                    if (guess[i].Equals(solution[i]))
                    {
                        results[guessn][i] = Colours.ColourPairs()["g"];
                    }
                    else if (solution.Contains(guess[i]))
                    {
                        win = false;
                        results[guessn][i] = Colours.ColourPairs()["y"];
                    }
                    else
                    {
                        results[guessn][i] = "o";
                        win = false;
                    }
                }
                guessnum = guessn + 1;
                if (win)
                {
                    break;
                }
                Console.WriteLine();
            }
            //Check if you won or lost
            Clear();
            guesslog = Visualiser.VisualisedGuess(LENGTH, guesses, results, guessnum);
            Console.WriteLine(guesslog);
            if (win)
            {
                Console.WriteLine("You won!");
                Console.WriteLine("Guesses used: " + guessnum);
            }
            else
            {
                Console.WriteLine("You lose!");
                Console.WriteLine("The code was:");
                foreach (string p in solution)
                {
                    Console.Write(Colours.ColourPairs()[p]);
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

