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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactsApps.Classes;

namespace ContactsApps.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        public Contact MyContact
        {
            get { return (Contact)GetValue(MyContactProperty); }
            set { SetValue(MyContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyContact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyContactProperty =
            DependencyProperty.Register("MyContact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact(), SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if (control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).contactName;
                control.emailTextBlock.Text = (e.NewValue as Contact).contactEmail;
                control.phoneTextBlock.Text = (e.NewValue as Contact).contactPhone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
