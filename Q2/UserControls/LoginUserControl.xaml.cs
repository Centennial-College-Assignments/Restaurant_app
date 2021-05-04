using System.Windows;
using System.Windows.Controls;

namespace Q2.UserControls
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        //dependency property for User Name
        public string User_Name
        {
            get { return (string)GetValue(User_NameProperty); }
            set { SetValue(User_NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty User_NameProperty =
            DependencyProperty.Register("User_Name", typeof(string), typeof(LoginUserControl), new PropertyMetadata(""));

        //dependency property for User Password
        public string User_Password
        {
            get { return (string)GetValue(User_PasswordProperty); }
            set { SetValue(User_PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty User_PasswordProperty =
            DependencyProperty.Register("User_Password", typeof(string), typeof(LoginUserControl), new PropertyMetadata(""));


    }
}
