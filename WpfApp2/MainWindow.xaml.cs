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
using WpfApp2.ybrfr;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ToysList.ItemsSource = DbConnection.Oksi.Toy.ToList();
        }

        private void SortField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            IEnumerable<Toy> filter = DbConnection.Oksi.Toy;
            if (SortField.SelectedIndex == 1)
            {
                filter = filter.OrderBy(x => x.Cost);
            }
            if (SortField.SelectedIndex == 2)
            {
                filter = filter.OrderByDescending(x => x.Cost);
            }
            if (SearchField.Text.Length > 0)
            {
                filter = filter.Where(x => x.Name.ToLower().StartsWith(SearchField.Text.ToLower()) || x.Description.ToLower().StartsWith(SearchField.Text.ToLower()));
            }
            ToysList.ItemsSource = filter.ToList();


        }

        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void Admbt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Введит пароль", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Passwordfield.Visibility = Visibility.Visible;
            Chbt.Visibility = Visibility.Visible;
        }
        private void ChekBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Passwordfield.Text == "0000")
            {
                MessageBox.Show("Вы теперь админ");
                Addbt.Visibility = Visibility.Visible;
                Edbt.Visibility = Visibility.Visible;
                Rolefield.Text = "Бог";
            }
            else
            {
                MessageBox.Show("Вы ввели неправльный пароль");
            }

        }

        private void Clibt_Click(object sender, RoutedEventArgs e)
        {
            Passwordfield.Visibility = Visibility.Collapsed;
            Chbt.Visibility = Visibility.Collapsed;
            Addbt.Visibility = Visibility.Collapsed;
            Edbt.Visibility = Visibility.Collapsed;
            Rolefield.Text = "Холоп";
        }

        private void Addbt_Click(object sender, RoutedEventArgs e)
        {
            new AddEditPage(Toy); 
        }
    }
}
