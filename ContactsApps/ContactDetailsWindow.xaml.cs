using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContactsApps.Classes;
using SQLite;

namespace ContactsApps
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            nameTextBox.Text = contact.contactName;
            emailTextBox.Text = contact.contactEmail;
            phoneTextBox.Text = contact.contactPhone;
        }


        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            contact.contactName = nameTextBox.Text;
            contact.contactEmail = emailTextBox.Text;
            contact.contactPhone = phoneTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
            Close();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            Close();
        }
    }
}
