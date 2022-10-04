using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GuessingGame.Game;

namespace GuessingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool light_mode = false;
        public bool right_guess = false;
        public bool submitbuttonpressed = false;
        public int max_guesses = 5;
        public float solution;
        public int min, max;
        private int guesses = 1;
        private string op;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void DarkModeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!light_mode)
            {
                Grid.Background = Brushes.White;
                light_mode = true;
            }
            else
            {
                Grid.Background = Brushes.Black;
                light_mode = false;
            }
        }

        private void TaskSubmitButton_Click(object sender, RoutedEventArgs e)
        {       
            try
            {
                right_guess = false;
                program_return.Text = "";
                Random random = new Random();
                TaskSubmitButton.IsEnabled = false;
                TaskSubmitButton.Foreground = new SolidColorBrush(Colors.DarkGray);

                min = Int32.Parse(tb_min.Text);
                max = Int32.Parse(tb_max.Text);
                op = tb_op.Text;

                int a = random.Next(min, max), b = random.Next(min, max);
                if (op == "Addition")
                {
                    solution = a + b;
                    tb_task.Text = $"{a} + {b}";
                }
                else if (op == "Subtraktion")
                {
                    if (a >= b)
                    {
                        solution = a - b;
                        tb_task.Text = $"{a} - {b}";
                    }
                    else
                    {
                        solution = b - a;
                        tb_task.Text = $"{b} - {a}";
                    }
                }
                else if (op == "Multiplikation")
                {
                    solution = a * b;
                    tb_task.Text = $"{a} * {b}";
                }
                else { throw new FormatException("Keine unterstützte Rechenoperation"); }

            }
            catch (System.FormatException exc)
            {
                MessageBox.Show($"Eine oder mehrere Eingaben fehlen oder sind falsch. ({exc.Message})");
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (guesses <= max_guesses && !right_guess)
                {
                    int user_inp = Int32.Parse(Uin.Text);
                    string check = Game.Check(user_inp, solution, max);
                    program_return.Text = check;
                    if (Game.Check(user_inp, solution, max) == Uin.Text + " ist richtig!")
                    {
                        right_guess = true;
                        SubmitButton.Content = "Weiter";
                    }
                    else
                    {
                        guesses++;
                    }
                }
                else if (right_guess)
                {
                    program_return.Text = $"Du hast die richtige Antwort und dafür {guesses} Versuche gebraucht!";
                    TaskSubmitButton.IsEnabled = true;
                    TaskSubmitButton.Foreground = new SolidColorBrush(Colors.Cyan);
                    SubmitButton.Content = "Bestätigen";
                }
                else
                {
                    program_return.Text = "Du hast die Aufgabe leider nicht geschafft.";
                    TaskSubmitButton.IsEnabled = true;
                    TaskSubmitButton.Foreground = new SolidColorBrush(Colors.Cyan);
                }
                
                
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ungültiger Eingabe");
            }
        }
    }
}