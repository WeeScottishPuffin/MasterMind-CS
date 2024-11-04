using System;
using System.Drawing;
namespace MasterMind;

public class Visualiser
{
    public static string VisualisedGuess(int length, string[][] guesses, string[][] results, int currentGuess)
    {
        String guess_log = "";
        guess_log += "┌";
        guess_log += new string('─', 2 * length + 3);
        guess_log += "┐\n";
        int index = 0;
        for (int j = 0; j < guesses.GetLength(0); j++)
        {
            string[] g = guesses[j];
            // if (index == currentGuess){break;}
            guess_log += "│";
            for (int i = 0; i < length; i++)
            {
                guess_log += (g[i] != null) ? Colours.ColourPairs()[g[i]] : "o";
            }
            guess_log += " " + ((index + 1) % 10) + " ";
            for (int i = 0; i < length; i++)
            {
                guess_log += (results[index][i] != null) ? results[index][i] : "o";
            }
            guess_log += "│\n";
            index++;
        }
        guess_log += "└";
        guess_log += new string(new char[(2 * length + 3)]).Replace("\0", "─");
        guess_log += "┘";
        return guess_log;
    }
}
