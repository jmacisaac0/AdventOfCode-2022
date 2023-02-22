/*
 * Juliet M
 * Advent of Code Day 1 Puzzle 2
 * https://adventofcode.com/2022/day/1#part2
 */

//located in bin/debug
const string INPUT_FILE = "input.txt";
const int TOP_VALUES = 3;

int counter = 0;
int total = 0;
//storing three highest values
//highest value is in final element
var topCalorieList = new LinkedList<int>();
topCalorieList.AddFirst(0);

try
{
    //using keyword used to dispose of StreamReader object when done
    using (StreamReader fileReader = new StreamReader(INPUT_FILE))
    {
        //iterates through text file until final line is reached, where StreamReader returns null
        string? line;
        while ((line = fileReader.ReadLine()) != null)
        {

            //file only contains blank lines and numbers
            //if line is not blank, adds number to counter variable
            if (line != "") { counter += int.Parse(line); }
            //repeats until blank line, where counter value is checked against max value found then reset
            else
            {
                //iterate through top values in list
                //most values will be lower than the highest values, so the lowest is checked first to avoid unecessary checks
                bool valueSwapped = false;

                for (LinkedListNode<int>? top = topCalorieList.First; top != null && !valueSwapped; top = top.Next)
                {
                    if (counter >= top.Value)
                    {
                        if (top.Next == null || counter <= top.Next.Value)
                        {
                            topCalorieList.AddAfter(top, counter);
                            valueSwapped = true;
                        }
                    }
                }
                counter = 0;
                if (topCalorieList.Count > TOP_VALUES) { topCalorieList.RemoveFirst(); }
            }

        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}


for (LinkedListNode<int>? top = topCalorieList.First; top != null; top = top.Next)
{
    Console.WriteLine(top.Value);
    total += top.Value;
}

Console.WriteLine("Total calories carried by the " + TOP_VALUES + " elves carrying the most is " +
     total + " calories.");



