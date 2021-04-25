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
using ContactsApps.Classes;
using SQLite;

namespace ContactsApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow instance = new NewContactWindow();
            instance.ShowDialog();
            ReadDatabase();
        }

        void ReadDatabase()
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = (connection.Table<Contact>().ToList()).OrderBy(contact => contact.contactName).ToList();
            }

            if (contacts != null)
            {
                ContactListView.ItemsSource = contacts;
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = contacts.Where(contact => contact.contactName.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            ContactListView.ItemsSource = filteredList;
        }

        private void ContactListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedItem = (Contact) ContactListView.SelectedItem;
            if (selectedItem != null)
            {
                ContactDetailsWindow newContactDetailsWindow = new ContactDetailsWindow(selectedItem);
                newContactDetailsWindow.ShowDialog();
                ReadDatabase();
            }
        }
    }
}
