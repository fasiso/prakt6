using LiquidClass;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace LiquidWPFApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Liquid> Liquids { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Liquids = new ObservableCollection<Liquid>();
            DataContext = this;
        }

        private void AddLiquid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = жидкость.Text;
                double density = double.Parse(Плотность.Text);
                double volume = double.Parse(Обьем.Text);

                if (string.IsNullOrEmpty(name)) throw new ArgumentException("Название не может быть пустым");
                if (density <= 0) throw new ArgumentException("Плотность должна быть больше нуля");
                if (volume <= 0) throw new ArgumentException("Объем должен быть больше нуля");

                Liquids.Add(new Liquid { Name = name, Density = density, Volume = volume });
                Обьем.Clear();
                Плотность.Clear();
                жидкость.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void IncreaseVolume_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Liquid liquid)
            {
                liquid++;
                // Обновление DataGrid 
                dataGridLiquids.Items.Refresh();

            }
        }

        private void DecreaseVolume_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Liquid liquid)
            {
                liquid.DecreaseVolume();
                dataGridLiquids.Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        Liquid liquid=  dataGridLiquids.SelectedItem as Liquid;
            liquid++;
                dataGridLiquids.Items.Refresh();
            
        }
    }
}