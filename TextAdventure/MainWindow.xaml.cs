using System;
using System.Collections.Generic;
using System.Linq;
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
using TextAdventure.Game_Logic;

namespace TextAdventure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLogic game;
        private int LineCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            game = new GameLogic();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Added line
            this.LineCount++;

            // Game logic
            if (this.InputBox.Text.ToLower() == "clear")
            {
                this.OutputBox.Text = string.Empty;
            }

            if (this.LineCount == 1) // R
            {
                this.game.PlayerName = this.InputBox.Text;
            }
            else if (this.LineCount == 2)
            {
                int temp_gender;
                if (int.TryParse(this.InputBox.Text, out temp_gender)) {
                    switch (temp_gender)
                    {
                        case 1:
                            this.game.Gender = Gender.Male;
                            break;
                        case 2:
                            this.game.Gender = Gender.Female;
                            break;
                        default:
                            this.game.Gender = Gender.NonBinary;
                            break;
                    }
                }
                else
                {
                    this.game.Gender = Gender.NonBinary;
                }
            }
            

            // Display Logic
            this.OutputBox.Text = this.OutputBox.Text + " >>> " + this.InputBox.Text + "\n";
            this.InputBox.Text = string.Empty;

            if (this.LineCount == 3)
            {
                this.OutputBox.Text = this.OutputBox.Text + " >>> "
                    + string.Format("You are named {0}, your gender is {1}", this.game.PlayerName, this.game.Gender.ToString()) + "\n";
            }

            this.ScrollWindow.ScrollToBottom();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Enter)
            {
                this.SendButton_Click(null, new RoutedEventArgs());
            }
        }
    }
}
