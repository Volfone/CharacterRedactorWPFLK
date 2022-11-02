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
    /// Логика взаимодействия для ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        public ItemsWindow()
        {
            InitializeComponent();
            CashTB.Text = MainWindow.SelectedCharacter.Cash.ToString();
            ShopListView.Items.Clear();
            foreach (Item item in Helmet.HelmetList)
            {
                ShopListView.Items.Add(item);
            }
            foreach (Item item in Armor.ArmorList)
            {
                ShopListView.Items.Add(item);
            }
            foreach (Item item in Weapon.WeaponList)
            {
                ShopListView.Items.Add(item);
            }
            foreach (Item item in MainWindow.SelectedCharacter.Items)
            {
                InvetoryListView.Items.Add(item);
            }
            foreach (Item item in MainWindow.SelectedCharacter.Equipment)
            {
                EquipmentListView.Items.Add(item);
            }
        }

        private void ShopListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ShopListView.SelectedItem as Item) != null)
            {
                PurchaseBtn.IsEnabled = true;
                return;
            }
            PurchaseBtn.IsEnabled = false;
        }

        private void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(CashTB.Text) < (ShopListView.SelectedItem as Item).Cost)
            {
                MessageBox.Show("Not enough cash");
                return;
            }
            if (MainWindow.SelectedCharacter.Strength <= (ShopListView.SelectedItem as Item).Requirements["Strength"] ||
                MainWindow.SelectedCharacter.Dexterity <= (ShopListView.SelectedItem as Item).Requirements["Dexterity"] ||
                MainWindow.SelectedCharacter.Constitution <= (ShopListView.SelectedItem as Item).Requirements["Constitution"] ||
                MainWindow.SelectedCharacter.Intelligence <= (ShopListView.SelectedItem as Item).Requirements["Intelligence"])
            {
                MessageBox.Show("Does not meet requirements");
                return;
            }
            InvetoryListView.Items.Add((ShopListView.SelectedItem as Item));
            CashTB.Text = (int.Parse(CashTB.Text) - (ShopListView.SelectedItem as Item).Cost).ToString();
        }

        private void ItemsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((ShopListView.SelectedItem as Item).ToString());
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            InvetoryListView.Items.Remove((ShopListView.SelectedItem as Item));
            CashTB.Text = (int.Parse(CashTB.Text) + (ShopListView.SelectedItem as Item).Cost).ToString();
        }

        private void EquipBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(Item item in EquipmentListView.Items)
            {
                if(item.Type == (InvetoryListView.SelectedItem as Item).Type)
                {
                    MessageBox.Show($"{item.Type} already equiped");
                    return;
                }
            }
            EquipmentListView.Items.Add((InvetoryListView.SelectedItem as Item));
            InvetoryListView.Items.Remove((InvetoryListView.SelectedItem as Item));
        }

        private void InvetoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((InvetoryListView.SelectedItem as Item) != null)
            {
                EquipBtn.IsEnabled = true;
                RemoveBtn.IsEnabled = true;
                return;
            }
            EquipBtn.IsEnabled = true;
            RemoveBtn.IsEnabled = false;
        }

        private void UnequipBtn_Click(object sender, RoutedEventArgs e)
        {
            InvetoryListView.Items.Add((EquipmentListView.SelectedItem as Item));
            EquipmentListView.Items.Remove((EquipmentListView.SelectedItem as Item));
        }

        private void EquipmentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((EquipmentListView.SelectedItem as Item) != null)
            {
                UnequipBtn.IsEnabled = true;
                return;
            }
            UnequipBtn.IsEnabled = false;
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Item item in InvetoryListView.Items)
            {
                MainWindow.SelectedCharacter.Items.Add(item);
            }
            foreach (Item item in EquipmentListView.Items)
            {
                MainWindow.SelectedCharacter.Equipment.Add(item);
            }
            MainWindow.SelectedCharacter.Cash = int.Parse(CashTB.Text);
            this.DialogResult = true;
        }
    }
}
