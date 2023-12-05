// Login = Nazwa
// Password = Password
// Zarejestruj = Zarejestruj
//Zaloguj = Login
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zarejestruj_Click(object sender, RoutedEventArgs e)
        {
            string log = Nazwa.Text;
            string pass = Password.Text;
            string hashedPassword = HashPassword(pass);
            string path = "C:/tmp/plik.txt";
            string path1 = "C:/tmp/plik1.txt";
            static string HashPassword(string pass)
            {
                using(SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(log);
                }
                using (StreamWriter sw = new StreamWriter(path1))
                {
                    sw.Write(hashedPassword);
                }
                MessageBox.Show("Dane zapisane");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd" + ex.Message);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string hashedPassword = HashPassword(Password.Text);
            static string HashPassword(string pass)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
            using (StreamReader sr = new("C:/tmp/plik.txt"))
            {
                if(sr.ReadLine() == Nazwa.Text)
                {
                    using (StreamReader sr1 = new("C:/tmp/plik1.txt"))
                    {
                        if (sr1.ReadLine() == hashedPassword)
                        {
                            Window1 win1 = new Window1();
                            win1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Dupa hasło niepoprawne");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("DUpa login niepoprawny");
                }
            }
            
        }

        private void Nazwa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
