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
using System.Windows.Shapes;
using CharacterRedactorLK;

namespace CharacterRedactorWPFLK
{
    /// <summary>
    /// Логика взаимодействия для SkillSelector.xaml
    /// </summary>
    public partial class SkillSelectorWindow : Window
    {
        public Skill SelectedSkill { get; set; }

        public SkillSelectorWindow()
        {
            InitializeComponent();
        }

        private void SkillChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            string currentTabName = (SkillTabControl.SelectedItem as TabItem).Name;
            switch (currentTabName)
            {
                case "HPSkillTab":
                    SelectedSkill = new Skill("HPSkill", 100); break;
                case "ATSkillTab":
                    SelectedSkill = new Skill("ATSkill", 100); break;
                case "PDSkillTab":
                    SelectedSkill = new Skill("PDSkill", 100); break;
                case "MPSkillTab":
                    SelectedSkill = new Skill("MPSkill", 100); break;
                default: break;
            }
            this.DialogResult = true;
            return;
        }
    }
}