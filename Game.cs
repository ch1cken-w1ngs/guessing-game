using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class Game
    {
        public bool right_ans = false;

        public static string Check(int num, float target, int max)
        {
            string s_num = num.ToString();
            if (num == target)
            {
                return s_num + " ist richtig!";
                Game game = new Game();
                game.right_ans = true;
            }
            else if (num < 0 | num > max * max)
            {
                return s_num + " ist ganz falsch.";
            }
            else if (num == target - 1 | num == target + 1)
            {
                return s_num + " ist ganz nahe dran!";
            }
            else
            {
                return s_num + " ist falsch";
            }
        }

        /* obsolete - directly implemented into MainWindow.xaml.cs
        public static void task(int a, int b, string operation)
        {
            int c;
            if (operation == "addition") { c = a + b; Console.WriteLine($"Task: {a} + {b}"); }
            
            else if (operation == "subtraction")
            {
                if (a >= b) { c = a - b; Console.WriteLine($"Task: {a} - {b}"); }
                else { c = b - a; Console.WriteLine($"Task: {b} - {a}"); }
            }

            else if(operation == "multiplication") {c = a * b; Console.WriteLine($"Task: {a} * {b}"); }

            else if(operation == "division")
            {
                if (a >= b) { c = a / b; Console.WriteLine($"Task: {a} / {b}"); }
                else { c = b / a; Console.WriteLine($"Task: {b} / {a}"); }
            }
            int guesses = 0;

        }
        */
    }
}
