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
using CharacterRedactorLK;

namespace CharacterRedactorWPFLK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentTabName = "WarriorTab";
        private Character SelectedCharacter = new Warrior();
        string currentStat = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = (sender as Button).Name;
                currentStat = "" + name[0] + name[1] + name[2];

                switch (currentStat)
                {
                    case "Str":
                        if (int.Parse(StrStatTB.Text) < SelectedCharacter.MinStr + 1)
                        {
                            return;
                        }
                        StrSlider.Value = StrSlider.Value - 1;
                        break;
                    case "Dex":
                        if (int.Parse(DexStatTB.Text) < SelectedCharacter.MinDex + 1)
                        {
                            return;
                        }
                        DexSlider.Value = DexSlider.Value - 1;
                        break;
                    case "Con":
                        if (int.Parse(ConStatTB.Text) < SelectedCharacter.MinCon + 1)
                        {
                            return;
                        }
                        ConSlider.Value = ConSlider.Value - 1;
                        break;
                    case "Int":
                        if (int.Parse(IntStatTB.Text) < SelectedCharacter.MinInt + 1)
                        {
                            return;
                        }
                        IntSlider.Value = IntSlider.Value - 1;
                        break;
                    default: break;
                }
            }
            catch { }
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = (sender as Button).Name;
                currentStat = "" + name[0] + name[1] + name[2];

                switch (currentStat)
                {
                    case "Str":
                        if (int.Parse(StrStatTB.Text) > SelectedCharacter.MaxStr - 1)
                        {
                            return;
                        }
                        StrSlider.Value = StrSlider.Value + 1;
                        break;
                    case "Dex":
                        if (int.Parse(DexStatTB.Text) > SelectedCharacter.MaxDex - 1)
                        {
                            return;
                        }
                        DexSlider.Value = DexSlider.Value + 1;
                        break;
                    case "Con":
                        if (int.Parse(ConStatTB.Text) > SelectedCharacter.MaxCon - 1)
                        {
                            return;
                        }
                        ConSlider.Value = ConSlider.Value + 1;
                        break;
                    case "Int":
                        if (int.Parse(IntStatTB.Text) > SelectedCharacter.MaxInt - 1)
                        {
                            return;
                        }
                        IntSlider.Value = IntSlider.Value + 1;
                        break;
                    default: break;
                }
            }
            catch { }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                string name = (sender as Slider).Name;
                currentStat = "" + name[0] + name[1] + name[2];
                int value = int.Parse(TotalPointsTB.Text);

                switch (currentStat)
                {
                    case "Str":
                        if (StrStatTB.Text != "")
                        {
                            value = (int.Parse(TotalPointsTB.Text) - (((int)StrSlider.Value) - int.Parse(StrStatTB.Text)));
                        }
                        if (StrStatTB.Text != "" && value >= 0)
                        {
                            TotalPointsTB.Text = value.ToString();
                        }
                        if (StrStatTB.Text != "" && value < 0)
                        {
                            StrSlider.Value = int.Parse(StrStatTB.Text);
                        }
                        StrStatTB.Text = (StrSlider.Value).ToString();
                        break;
                    case "Dex":
                        if (DexStatTB.Text != "")
                        {
                            value = (int.Parse(TotalPointsTB.Text) - (((int)DexSlider.Value) - int.Parse(DexStatTB.Text)));
                        }
                        if (DexStatTB.Text != "" && value >= 0)
                        {
                            TotalPointsTB.Text = value.ToString();
                        }
                        if (DexStatTB.Text != "" && value < 0)
                        {
                            DexSlider.Value = int.Parse(DexStatTB.Text);
                        }
                        DexStatTB.Text = ((int)DexSlider.Value).ToString();
                        break;
                    case "Con":
                        if (ConStatTB.Text != "")
                        {
                            value = (int.Parse(TotalPointsTB.Text) - (((int)ConSlider.Value) - int.Parse(ConStatTB.Text)));
                        }
                        if (ConStatTB.Text != "" && value >= 0)
                        {
                            TotalPointsTB.Text = value.ToString();
                        }
                        if (ConStatTB.Text != "" && value < 0)
                        {
                            ConSlider.Value = int.Parse(ConStatTB.Text);
                        }
                        ConStatTB.Text = ((int)ConSlider.Value).ToString();
                        break;
                    case "Int":
                        if (IntStatTB.Text != "")
                        {
                            value = (int.Parse(TotalPointsTB.Text) - (((int)IntSlider.Value) - int.Parse(IntStatTB.Text)));
                        }
                        if (IntStatTB.Text != "" && value >= 0)
                        {
                            TotalPointsTB.Text = value.ToString();
                        }
                        if (IntStatTB.Text != "" && value < 0)
                        {
                            IntSlider.Value = int.Parse(IntStatTB.Text);
                        }
                        IntStatTB.Text = ((int)IntSlider.Value).ToString();
                        break;
                    default: break;
                }
            }
            catch { }
        }

        private void CharacterTab_GotFocus(object sender, RoutedEventArgs e)
        {
            currentTabName = (sender as TabItem).Name;
            switch (currentTabName)
            {
                case "WarriorTab": SelectedCharacter = new Warrior();
                                   CharacterNameTBox.Text = "Warrior"; break;
                case "RogueTab": SelectedCharacter = new Rogue();
                                   CharacterNameTBox.Text = "Rogue"; break;
                case "WizardTab": SelectedCharacter = new Wizard();
                                   CharacterNameTBox.Text = "Wizzard"; break;
                default: break;
            }
            StrMaxV.Text = SelectedCharacter.MaxStr.ToString();
            StrMinV.Text = SelectedCharacter.MinStr.ToString();
            DexMaxV.Text = SelectedCharacter.MaxDex.ToString();
            DexMinV.Text = SelectedCharacter.MinDex.ToString();
            ConMaxV.Text = SelectedCharacter.MaxCon.ToString();
            ConMinV.Text = SelectedCharacter.MinCon.ToString();
            IntMaxV.Text = SelectedCharacter.MaxInt.ToString();
            IntMinV.Text = SelectedCharacter.MinInt.ToString();
            StrSlider.Maximum = int.Parse(StrMaxV.Text);
            StrSlider.Minimum = int.Parse(StrMinV.Text);
            DexSlider.Maximum = int.Parse(DexMaxV.Text);
            DexSlider.Minimum = int.Parse(DexMinV.Text);
            ConSlider.Maximum = int.Parse(ConMaxV.Text);
            ConSlider.Minimum = int.Parse(ConMinV.Text);
            IntSlider.Maximum = int.Parse(IntMaxV.Text);
            IntSlider.Minimum = int.Parse(IntMinV.Text);
            StrSlider.Maximum = int.Parse(StrMaxV.Text);
            StrSlider.Value = int.Parse(StrMinV.Text);
            DexSlider.Value = int.Parse(DexMinV.Text);
            ConSlider.Value = int.Parse(ConMinV.Text);
            IntSlider.Value = int.Parse(IntMinV.Text);
            TotalPointsTB.Text = "200";
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterNameTBox.Text == "")
            {
                MessageBox.Show("You didn't name your character");
                return;
            }
            switch (currentTabName)
            {
                case "WarriorTab": SelectedCharacter = new Warrior(int.Parse(StrStatTB.Text),
                    int.Parse(DexStatTB.Text), int.Parse(ConStatTB.Text), int.Parse(IntStatTB.Text), CharacterNameTBox.Text); 
                    break;
                case "RougeTab": SelectedCharacter = new Rogue(int.Parse(StrStatTB.Text),
                    int.Parse(DexStatTB.Text), int.Parse(ConStatTB.Text), int.Parse(IntStatTB.Text), CharacterNameTBox.Text); 
                    break;
                case "WizardTab": SelectedCharacter = new Wizard(int.Parse(StrStatTB.Text),
                    int.Parse(DexStatTB.Text), int.Parse(ConStatTB.Text), int.Parse(IntStatTB.Text), CharacterNameTBox.Text); 
                    break;
                default: break;
            }
            MessageBox.Show(SelectedCharacter.ToString());
            MongoExamples.AddToDB(SelectedCharacter);
        }

        private void CharacterFinderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FindCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            Character character = MongoExamples.Find(FindCharacterTB.Text);
            try
            {
                CharacterFinderTextBox.Text = character.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Character not found");
            }
        }

        private void FindAllCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            FinderCharacterCB.Items.Clear();
            List<Character> characters = MongoExamples.FindAll();
            CharacterFinderTextBox.Text = "";

            foreach (var item in characters)
            {
                FinderCharacterCB.Items.Add(item.Name);
            }
        }

        private void DataGrid_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("qwe");
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            MessageBox.Show("qwe");
        }

        private void FinderCharacterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(FinderCharacterCB.Text);
        }
    }
}
