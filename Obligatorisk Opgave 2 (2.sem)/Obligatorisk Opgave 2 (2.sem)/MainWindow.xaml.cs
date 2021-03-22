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
using Renci.SshNet;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace Obligatorisk_Opgave_2__2.sem_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string CentOShost = "95.179.187.146";
        string CentOSusername = "root";
        string CentOSpassword = "$s8PtAa)uEZW{H[2";

        string Ubuntuhost = "45.76.43.221";
        string Ubuntuusername = "root";
        string Ubuntupassword = "j}7E(Ma38tMg8_ux";

        string Debianhost = "45.32.232.37";
        string Debianusername = "root";
        string Debianpassword = "!Tz53@_BJ(RCdXk@";

        public MainWindow()
        {
            InitializeComponent();

            AuthenticationMethod method = new PasswordAuthenticationMethod(CentOSusername, CentOSpassword);
            ConnectionInfo connection = new ConnectionInfo(CentOShost, CentOSusername, method);
            var client = new SshClient(connection);
            client.Connect();
            char[] delimiterChars = { ' ' };
            var command = client.RunCommand("df -H /");
            string text = command.Result;
            string[] lines = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            string useddisk = lines[8];
            string totaldisk = lines[7];
            Console.WriteLine("{0} used of {1}", useddisk, totaldisk);






            if (!client.IsConnected)
            {
                Console.WriteLine("There was an error establishing the connection!");
                Debug.WriteLine("Error");
            }
            else
            {
                Console.WriteLine("We've connected!");
                Debug.WriteLine("Connected");
            }

           
            Console.WriteLine(command.Result);
            Console.ReadLine();

            try
            {
                Ping CentOS = new Ping();
                PingReply reply = CentOS.Send("95.179.187.146", 1000);
                if (reply != null)
                {
                    CentOSEllipse.Fill = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    CentOSEllipse.Fill = new SolidColorBrush(Colors.LightGreen);
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            Console.Read();

            try
            {
                Ping UbuntuPing = new Ping();
                PingReply reply = UbuntuPing.Send("45.76.43.221", 1000);
                if (reply != null)
                {                 
                    UbuntuEllipse.Fill = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    UbuntuEllipse.Fill = new SolidColorBrush(Colors.LightGreen);
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            Console.Read();

            try
            {
                Ping DebianPing = new Ping();
                PingReply reply = DebianPing.Send("45.32.232.37", 1000);
                if (reply != null)
                {
                    DebianEllipse.Fill = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    DebianEllipse.Fill = new SolidColorBrush(Colors.LightGreen);
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            Console.Read();



        }

        
        

        private void RebootCentOS(object sender, RoutedEventArgs e)
        {
            //Process.Start("shutdown.exe", "-r -t 0");
        }

        private void InfoCentOS(object sender, RoutedEventArgs e)
        {
            Window1 Win1 = new Window1();
            Win1.Show();
        }

      
        private void RebootUbuntu(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        private void InfoUbuntu(object sender, RoutedEventArgs e)
        {
            Window2 Win2 = new Window2();
            Win2.Show();
        }

        private void DebianReboot(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        private void DebianInfo(object sender, RoutedEventArgs e)
        {
            Window3 Win3 = new Window3();
            Win3.Show();
        }

    }
}
