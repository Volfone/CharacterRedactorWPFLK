using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
        public static Character SelectedCharacter = new Warrior();
        string currentStat = "";
        List<Item> items = new List<Item>();
        List<Item> equipment = new List<Item>();
        List<Skill> skills = new List<Skill>();
        bool redactingCharacter = false;
        int currentLevel = 1;
        int currentExp = 0;
        int points = 50;
        string redactCharacterName = "";
        int availableSkillsAmount = 0;
        int acquiredSkillsCount = 0;
        int cash = 500;
        string mode = "";
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
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                            items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp); break;
                    case "RogueTab":
                        SelectedCharacter = new Rogue((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                            items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp); break;
                    case "WizardTab":
                        SelectedCharacter = new Wizard((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                            items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp); break;
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
            /*if(redactingCharacter)
            {
                RedactBtn.Visibility = Visibility.Visible;
                currentExp = SelectedCharacter.Expirience;
                currentLevel = SelectedCharacter.Level;
                points = 5 * SelectedCharacter.Level;
                TotalPointsTB.Text = points.ToString();
                items = SelectedCharacter.Items;
                skills = SelectedCharacter.Skills;
                redactCharacterName = SelectedCharacter.Name;
                CharacterNameTBox.Text = SelectedCharacter.Name;
                availableSkillsAmount = (currentLevel / 5) - SelectedCharacter.AcquiredSkillsAmount;
                if (availableSkillsAmount > 0)
                {
                    SkillChooserBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    SkillChooserBtn.Visibility = Visibility.Hidden;
                }
                StrSlider.Value = (int)(SelectedCharacter.Strength);
                DexSlider.Value = (int)(SelectedCharacter.Dexterity);
                ConSlider.Value = (int)(SelectedCharacter.Constitution);
                IntSlider.Value = (int)(SelectedCharacter.Intelligence);
                points -= 
                    (int)(StrSlider.Value - StrSlider.Minimum) +
                    (int)(DexSlider.Value - DexSlider.Minimum) +
                    (int)(ConSlider.Value - ConSlider.Minimum) +
                    (int)(IntSlider.Value - IntSlider.Minimum);
                TotalPointsTB.Text = points.ToString();
                redactingCharacter = false;
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
                return;
            }*/
            SkillChooserBtn.Visibility = Visibility.Hidden;
            items = new List<Item>();
            equipment = new List<Item>();
            skills = new List<Skill>();
            acquiredSkillsCount = 0;
            availableSkillsAmount = 0;
            currentExp = 0;
            currentLevel = 1;
            StrSlider.Value = int.Parse(StrMinV.Text);
            DexSlider.Value = int.Parse(DexMinV.Text);
            ConSlider.Value = int.Parse(ConMinV.Text);
            IntSlider.Value = int.Parse(IntMinV.Text);
            points = 50;
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
            catch (Exception ex) { }
            switch (currentTabName)
            {
                case "WarriorTab": SelectedCharacter = new Warrior((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                            items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp);
                    break;
                case "RogueTab": SelectedCharacter = new Rogue((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                            items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp);
                    break;
                case "WizardTab": SelectedCharacter = new Wizard((int)StrSlider.Value, (int)DexSlider.Value,
                            (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                            items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp);
                    break;
                case "CharacterFinderTab": MessageBox.Show("You can't do that");
                    return;
                default: break;
            }
            MessageBox.Show(SelectedCharacter.ToString());
            MongoExamples.AddToDB(SelectedCharacter);
            LoadCB();
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
            SkillChooserBtn.Visibility = Visibility.Hidden;
            items = new List<Item>();
            equipment = new List<Item>();
            skills = new List<Skill>();
            cash = 500;
            acquiredSkillsCount = 0;
            availableSkillsAmount = 0;
            currentExp = 0;
            currentLevel = 1;
            StrSlider.Value = int.Parse(StrMinV.Text) + 1;
            StrSlider.Value = int.Parse(StrMinV.Text) - 1;
            DexSlider.Value = int.Parse(DexMinV.Text);
            ConSlider.Value = int.Parse(ConMinV.Text);
            IntSlider.Value = int.Parse(IntMinV.Text);
            points = 50;
            TotalPointsTB.Text = points.ToString();
        }

        private void FindCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(FinderCharacterCB.SelectedIndex == -1)
            {
                return;
            }
            Character character = MongoExamples.Find(FinderCharacterCB.Text);
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
                    "\n-------------------------------------------------\n";
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
            switch (currentTabName)
            {
                case "CharacterFinderTab":
                    MessageBox.Show("You can't do that");
                    return;
                default: break;
            }
            ItemsWindow itemWindiw = new ItemsWindow();
            SelectedCharacter.Items.Clear();
            SelectedCharacter.Equipment.Clear();
            if(itemWindiw.ShowDialog().Value)
            {
                cash = SelectedCharacter.Cash;
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
                StrSlider.Value = SelectedCharacter.Strength - 1;
                StrSlider.Value = SelectedCharacter.Strength + 1;
            }
            /*try
            {
                items.Add(new Item(ItemTB.Text, int.Parse(AmountTB.Text)));
                SelectedCharacter.Items = items;
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }*/
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
            equipment = SelectedCharacter.Equipment;
            skills = SelectedCharacter.Skills;
            cash = SelectedCharacter.Cash;
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
            switch (currentTabName)
            {
                case "CharacterFinderTab":
                    MessageBox.Show("You can't do that");
                    return;
                default: break;
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
                 (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                 items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp);
                        break;
                    case "RogueTab":
                        SelectedCharacter = new Rogue((int)StrSlider.Value, (int)DexSlider.Value,
                   (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                   items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp);
                        break;
                    case "WizardTab":
                        SelectedCharacter = new Wizard((int)StrSlider.Value, (int)DexSlider.Value,
                  (int)ConSlider.Value, (int)IntSlider.Value, CharacterNameTBox.Text, cash,
                  items, equipment, skills, acquiredSkillsCount, currentLevel, currentExp);
                        break;
                    default: break;
                }
                CharacterFinderTextBox.Text = SelectedCharacter.ToString();
            }
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            LauncherTabControl.Items.MoveCurrentToPosition(1);
        }

        private void PlayCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            LauncherTabControl.Items.MoveCurrentToPosition(0);
        }

        private void LauncherPlayFindBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Character> characterList = MongoExamples.FindAll();
            int amount = 0;
            switch(mode)
            {
                case "5x5":
                    L1p1.Items.Clear();
                    amount = 5; break;
                case "4x4":
                    L1p1.Items.Clear();
                    amount = 4; break;
                case "3x3":
                    L1p1.Items.Clear();
                    amount = 3; break;
                case "2x2":
                    L1p1.Items.Clear();
                    amount = 2; break;
                case "1x1":
                    L1p1.Items.Clear();
                    amount = 1; break;
            }
            if(characterList.Count < amount * 2)
            {
                MessageBox.Show("Тot enough players to create a lobby");
                return;
            }
            LauncherTabControl.Items.MoveCurrentToPosition(2);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mode = (sender as RadioButton).Content.ToString();
        }

        private void FormLobbyBtn_Click(object sender, RoutedEventArgs e)
        {
            L1p1.Items.Clear();
            L1p2.Items.Clear();
            int i = 0;
            List<int> indexes = new List<int>();
            List<Character> characterList = MongoExamples.FindAll();
            Random random = new Random();
            int amount = 0;
            switch (mode)
            {
                case "5x5":
                    amount = 5; break;
                case "4x4":
                    amount = 4; break;
                case "3x3":
                    amount = 3; break;
                case "2x2":
                    amount = 2; break;
                case "1x1":
                    amount = 1; break;
            }
            i = 0;
            int num = random.Next(characterList.Count);
            foreach (Character character in characterList)
            {
                if(i == num)
                {
                    L1p1.Items.Clear();
                    L1p1.Items.Add(characterList[num] as Character);
                }
                i++;
            }
            indexes.Add(num);
            i = -1;
            bool IsCharacterAdded = false;
            foreach (Character character in characterList)
            {
                num = random.Next(characterList.Count);
                int cycle = 0;
                while (indexes.Contains(num))
                {
                    cycle++;
                    num = random.Next(characterList.Count);
                    if (cycle > characterList.Count * 5)
                    {
                        MessageBox.Show($"Cannot create lobby for {(L1p1.Items.GetItemAt(0) as Character).ToString()}");
                    }
                }
                if (characterList.ElementAt<Character>(num).Level >= (L1p1.Items.GetItemAt(0) as Character).Level - 5 &&
                    characterList.ElementAt<Character>(num).Level <= (L1p1.Items.GetItemAt(0) as Character).Level + 5 &&
                    i % 2 != 0 && L1p1.Items.Count < amount)
                {
                    L1p1.Items.Add((characterList.ElementAt<Character>(num) as Character));
                    indexes.Add(num);
                    IsCharacterAdded = true;
                }
                if (characterList.ElementAt<Character>(num).Level >= (L1p1.Items.GetItemAt(0) as Character).Level - 5 &&
                    characterList.ElementAt<Character>(num).Level <= (L1p1.Items.GetItemAt(0) as Character).Level + 5 &&
                    i % 2 == 0 && L1p2.Items.Count < amount)
                {
                    L1p2.Items.Add((characterList.ElementAt<Character>(num) as Character));
                    indexes.Add(num);
                    IsCharacterAdded = true;
                }
                i++;
            }
            if(L1p2.Items.Count < amount || L1p1.Items.Count < amount)
            {
                MessageBox.Show($"Cannot create lobby for {(L1p1.Items.GetItemAt(0) as Character).ToString()}");
                L1p1.Items.Clear();
                L1p2.Items.Clear();
            }
        }

        private void L1p1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((L1p1.SelectedItem as Character).ToString());
        }

        private void L1p2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((L1p2.SelectedItem as Character).ToString());
        }

        private void CharacterFinderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(CharacterTabControl.SelectedIndex == 3)
            {
                return;
            }
            CharacterFinderTextBox.Text = SelectedCharacter.ToString();
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
