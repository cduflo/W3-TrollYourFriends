using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using TrollYourFriends.Core.Domain;
using TrollYourFriends.Core.Services;
using TrollYourFriends.Core;
using unirest_net.http;
using RestSharp.Extensions.MonoHttp;
using Newtonsoft.Json.Linq;
using System.IO;
using WpfAnimatedGif;

namespace TrollYourFriends
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBoxRepeat.ItemsSource = Quantity.quantity;
            comboBoxinterval.ItemsSource = IntervalList.iList;
            comboBoxinterval.DisplayMemberPath = "UOM";            
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox != null && comboBoxRepeat.SelectedItem != null && comboBoxinterval != null && textBox1.Text != null)
                {
                    Interval x = (Interval)comboBoxinterval.SelectedValue;
                    string message;
                    textBlockTrollCount.Text = "Troll Count: 0";
                    for (var i = 0; i < Convert.ToInt32(comboBoxRepeat.Text); i++)
                    {
                        RandomResponse o = RandomGen.RandomChuck();
                        string joke = o.value.joke.ToString();
                        message = joke;

                        if (checkBox1337.IsChecked == true)
                        {
                            var joke1337 = LEET.LEETFY(joke);
                            message = joke1337;
                        }
                        string sending = HttpUtility.HtmlDecode(message);
                        //for testing only:  MessageBox.Show(sending);
                        SmsService.SendSms(textBox.Text, sending);

                        textBlockTrollCount.Text = $"Troll Count: {i + 1}";
                        System.Threading.Thread.Sleep(Convert.ToInt32(textBox1.Text) * x.multiplier);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a phone number and number of times to repeat");
                }
            }
            catch
            {
                MessageBox.Show("Error: Please check your entered data for completeness and retry.");
            }
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = new TimeSpan(0, 0, 1);
            mediaElement.Play();
        }
    }
}
