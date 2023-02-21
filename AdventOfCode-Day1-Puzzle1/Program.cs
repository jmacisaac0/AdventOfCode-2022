/*
 * Juliet M
 * Advent of Code Day 1 Puzzle 1
 * https://adventofcode.com/2022/day/1
 */

//located in bin/debug
const string INPUT_FILE = "input.txt";

try
{
    int counter = 0;
    int max = 0;

    //using keyword used to dispose of StreamReader object when done
    using (StreamReader fileReader = new StreamReader(INPUT_FILE))
    {
        //iterates through text file until final line is reached, where StreamReader returns null
        string? line;
        while ((line = fileReader.ReadLine()) != null ) {

            //file only contains blank lines and numbers
            //if line is not blank, adds number to counter variable
            if (line != "") { counter += int.Parse(line); }
            //repeats until blank line, where counter value is checked against max value found then reset
            else
            {
                if (counter > max) { max = counter; }
                counter = 0;
            }

        }
    }
    Console.WriteLine( "Total calories carried by Elf carrying the most is " +
        max + " calories.");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}



