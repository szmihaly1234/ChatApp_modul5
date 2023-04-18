using ChatApp_backend.Logic;
using ChatApp_backend.Model;
using ChatApp_backend.Services;
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

namespace ChatApp_frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChatLogic logic;
        
        public MainWindow()
        {
            InitializeComponent();
            logic = new ChatLogic();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChatObject obj = new ChatObject(sender_name.Text, message.Text);
            logic.AddMessage(obj);
            chat.Text = logic.ReadAllChat();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
