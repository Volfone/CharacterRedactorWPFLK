using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<Item> items = new List<Item>();
        List<Skill> skills = new List<Skill>();
        bool redactingCharacter = false;
        int currentLevel = 1;
        int currentExp = 0;
        int points = 5;
        string redactCharacterName = "";
        int availableSkillsAmount = 0;
        int acquiredSkillsCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadCB();
            SelectedCharacter = new Warrior((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text);
            CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            TotalPointsTB.Text = points.ToString();
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
            catch(NullReferenceException) { }
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
            catch(NullReferenceException) { }
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
                            points = value;
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
                            points = value;
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
                            points = value;
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
                            points = value;
                        }
                        if (IntStatTB.Text != "" && value < 0)
                        {
                            IntSlider.Value = int.Parse(IntStatTB.Text);
                        }
                        IntStatTB.Text = ((int)IntSlider.Value).ToString();
                        break;
                    default: break;
                }
                switch (currentTabName)
                {
                    case "WarriorTab":
                        SelectedCharacter = new Warrior((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                            items, skills, acquiredSkillsCount, currentLevel, currentExp); break;
                    case "RogueTab":
                        SelectedCharacter = new Rogue((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                            items, skills, acquiredSkillsCount, currentLevel, currentExp); break;
                    case "WizardTab":
                        SelectedCharacter = new Wizard((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                            items, skills, acquiredSkillsCount, currentLevel, currentExp); break;
                    default: break;
                }
                TotalPointsTB.Text = points.ToString();
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            }
            catch (NullReferenceException) { }
        }

        private void CharacterTab_GotFocus(object sender, RoutedEventArgs e)
        {
            currentTabName = (sender as TabItem).Name;
            if (!redactingCharacter)
            {
                switch (currentTabName)
                {
                    case "WarriorTab":
                        SelectedCharacter = new Warrior();
                        CharacterNameTBox.Text = "Warrior"; break;
                    case "RogueTab":
                        SelectedCharacter = new Rogue();
                        CharacterNameTBox.Text = "Rogue"; break;
                    case "WizardTab":
                        SelectedCharacter = new Wizard();
                        CharacterNameTBox.Text = "Wizzard"; break;
                    case "CharacterFinderTab":
                        SelectedCharacter = new Character();
                        points = 0;
                        TotalPointsTB.Text = points.ToString();
                        CharacterNameTBox.Text = ""; break;
                    default: break;
                }
                RedactBtn.Visibility = Visibility.Hidden;
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
            SkillChooserBtn.Visibility = Visibility.Hidden;
            ItemTB.Text = "";
            AmountTB.Text = "";
            items = new List<Item>();
            skills = new List<Skill>();
            acquiredSkillsCount = 0;
            availableSkillsAmount = 0;
            currentExp = 0;
            currentLevel = 1;
            StrSlider.Value = int.Parse(StrMinV.Text);
            DexSlider.Value = int.Parse(DexMinV.Text);
            ConSlider.Value = int.Parse(ConMinV.Text);
            IntSlider.Value = int.Parse(IntMinV.Text);
            points = 5;
            TotalPointsTB.Text = points.ToString();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterNameTBox.Text == "")
            {
                MessageBox.Show("You didn't name your character");
                return;
            }
            try
            {
                Character character = MongoExamples.Find(CharacterNameTBox.Text);
                if (character != null)
                {
                    MessageBox.Show("Character with this name already existing");
                    return;
                }
            }
            catch (NullReferenceException) { }
            switch (currentTabName)
            {
                case "WarriorTab": SelectedCharacter = new Warrior((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                            items, skills, acquiredSkillsCount, currentLevel, currentExp);
                    break;
                case "RogueTab": SelectedCharacter = new Rogue((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                            items, skills, acquiredSkillsCount, currentLevel, currentExp);
                    break;
                case "WizardTab": SelectedCharacter = new Wizard((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                            items, skills, acquiredSkillsCount, currentLevel, currentExp);
                    break;
                case "CharacterFinderTab": MessageBox.Show("You can't do that");
                    return;
                default: break;
            }
            MessageBox.Show(SelectedCharacter.ToString());
            MongoExamples.AddToDB(SelectedCharacter);
            LoadCB();
        }

        private void FindCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            Character character = MongoExamples.Find(FinderCharacterCB.Text);
            string currentStat = "";
            string name = "";
            foreach (Skill item in character.Skills)
            {
                name = item.Name;
                currentStat = "" + name[0] + name[1];
                switch (currentStat)
                {
                    case "HP":
                        character.Health -= item.Stats;
                        break;
                    case "AT":
                        character.Attack -= item.Stats;
                        break;
                    case "PD":
                        character.PDef -= item.Stats;
                        break;
                    case "MP":
                        character.Mana -= item.Stats;
                        break;
                    default: break;
                }
            }
            CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            try
            {
                CharacterFinderTextBox.Text = character.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullCharacterName");
            }
        }

        private void FindAllCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Character> characters = MongoExamples.FindAll();
            CharacterFinderTextBox.Text = "";

            foreach (var item in characters)
            {
                CharacterFinderTextBox.Text += item +
                    "\n||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n";
            }
        }

        private void LoadCB()
        {
            FinderCharacterCB.Items.Clear();
            List<Character> characters = MongoExamples.FindAll();
            CharacterFinderTextBox.Text = "";
            string name = "";

            foreach (var item in characters)
            {
                name = item.Name;
                FinderCharacterCB.Items.Add(name);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentTabName == "CharacterFinderTab")
                {
                    MessageBox.Show("You can't do that");
                    ItemTB.Text = "";
                    AmountTB.Text = "";
                    return;
                }
                items.Add(new Item(ItemTB.Text, int.Parse(AmountTB.Text)));
                SelectedCharacter.Items = items;
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            Character character = MongoExamples.Find(FinderCharacterCB.Text);
            redactingCharacter = true;
            SelectedCharacter = character;
            switch (character.GetType().Name)
            {
                case "Rogue": CharacterTabControl.Items.MoveCurrentToPosition(1); break;
                case "Wizard": CharacterTabControl.Items.MoveCurrentToPosition(2); break;
                case "Warrior": CharacterTabControl.Items.MoveCurrentToPosition(0); break;
                default: break;
            }
            SelectedCharacter = character;
            RedactBtn.Visibility = Visibility.Visible;
            currentExp = SelectedCharacter.Expirience;
            currentLevel = SelectedCharacter.Level;
            points = 5 * currentLevel;
            TotalPointsTB.Text = points.ToString();
            items = SelectedCharacter.Items;
            skills = SelectedCharacter.Skills;
            redactCharacterName = SelectedCharacter.Name;
            CharacterNameTBox.Text = SelectedCharacter.Name;
            acquiredSkillsCount = SelectedCharacter.AcquiredSkillsAmount;
            availableSkillsAmount = (currentLevel / 5) - SelectedCharacter.AcquiredSkillsAmount;
            if (availableSkillsAmount > 0)
            {
                SkillChooserBtn.Visibility = Visibility.Visible;
            }
            else
            {
                SkillChooserBtn.Visibility = Visibility.Hidden;
            }
            StrSlider.Value = (int)(character.Strength);
            DexSlider.Value = (int)(character.Dexterity);
            ConSlider.Value = (int)(character.Constitution);
            IntSlider.Value = (int)(character.Intelligence);
            points = 5 * currentLevel;
            points -=
                (int)(StrSlider.Value - StrSlider.Minimum) +
                (int)(DexSlider.Value - DexSlider.Minimum) +
                (int)(ConSlider.Value - ConSlider.Minimum) +
                (int)(IntSlider.Value - IntSlider.Minimum);
            TotalPointsTB.Text = points.ToString();
            redactingCharacter = false;
            CharacterNameTBox.Text = character.Name;
            CharacterFinderTextBox.Text = SelectedCharacter.ToString();
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            MongoExamples.ReplaceByName(redactCharacterName, SelectedCharacter);
            MessageBox.Show("Character redacted");
            redactCharacterName = "";
        }

        private void CharacterNameTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SelectedCharacter.Name = CharacterNameTBox.Text;
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            }
            catch (NullReferenceException) { }
        }

        private void ExpirienceAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentTabName == "CharacterFinderTab")
            {
                MessageBox.Show("You can't do that");
                return;
            }
            currentExp += 100000;
            SelectedCharacter.Expirience = currentExp;
            if (SelectedCharacter.Level > currentLevel)
            {
                points += 5 * (SelectedCharacter.Level - currentLevel);
                currentLevel = SelectedCharacter.Level;
                currentExp = SelectedCharacter.Expirience;
            }
            availableSkillsAmount = currentLevel / 5 - SelectedCharacter.AcquiredSkillsAmount;
            if (availableSkillsAmount > 0)
            {
                SkillChooserBtn.Visibility = Visibility.Visible;
            }
            else
            {
                SkillChooserBtn.Visibility = Visibility.Hidden;
            }
            TotalPointsTB.Text = points.ToString();
            SelectedCharacter.Name = CharacterNameTBox.Text;
            CharacterFinderTextBox.Text = SelectedCharacter.ToString();
        }

        private void SkillChooserBtn_Click(object sender, RoutedEventArgs e)
        {
            SkillSelectorWindow skillSelectorWindow = new SkillSelectorWindow();
            if (skillSelectorWindow.ShowDialog().Value)
            {
                skills.Add(skillSelectorWindow.SelectedSkill);
                SelectedCharacter.Skills = skills;
                availableSkillsAmount -= 1;
                acquiredSkillsCount += 1;
                SelectedCharacter.AcquiredSkillsAmount = acquiredSkillsCount;
                if (availableSkillsAmount > 0)
                {
                    SkillChooserBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    SkillChooserBtn.Visibility = Visibility.Hidden;
                }
                switch (currentTabName)
                {
                    case "WarriorTab":
                        SelectedCharacter = new Warrior((int)StrSlider.Value, (int)DexSlider.Value,
                 (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                 items, skills, acquiredSkillsCount, currentLevel, currentExp);
                        break;
                    case "RogueTab":
                        SelectedCharacter = new Rogue((int)StrSlider.Value, (int)DexSlider.Value,
                   (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                   items, skills, acquiredSkillsCount, currentLevel, currentExp);
                        break;
                    case "WizardTab":
                        SelectedCharacter = new Wizard((int)StrSlider.Value, (int)DexSlider.Value,
                  (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text,
                  items, skills, acquiredSkillsCount, currentLevel, currentExp);
                        break;
                    default: break;
                }
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            }
        }
    }
}
