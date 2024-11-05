# Mastermind

**An ASCII implementation of the simple guessing game, mastermind.**

This is my first [Java project](https://github.com/WeeScottishPuffin/MasterMind), rewritten in C#.


## How it works

It is function the same as the Java version:

After starting up the program `MainProg.cs`, a simple splash screen will display. Pressing `<RETURN>` on your keyboard will start the game. In the code, there are two `final` variables controlling the length of the code and the amount of guesses you get to crack said code.

At the start of the game, the computer randomly generates a code consisting of random colours (which are stored in the `Colours.cs` file). After this, you will be able to submit your guesses every turn by entering the first letter of any of the colours.

After every turn, the computer will show you how accurate your guess is. It will display this in the form of yellow and green pins. A yellow pin means that the colour at the given positions occurs at least once in the code, but not on this specific position. A green pin is place when the colour occurs at that specific position. That colour may however occur more times in the complete code.

If you correctly guess the code within the turn limit, you win.

## File Structure

```
REPO                                    #
├MasterMind                             #
│    ├MasterMind.csproj                 #   Standard .csproj file
│    ├Colours.cs                        #   Stores the values of all possible colours
│    ├Visualiser.cs                     #   Method to visualise the board using ANSI/ascii art
│    └MainProg.cs                       #   Main code
├readme.md                              #   README
├MasterMind.sln                         #   VS Solution File
└.gitignore                             #   Standard .gitignore

```
