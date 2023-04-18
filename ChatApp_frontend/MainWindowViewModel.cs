using Backend.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatApp_frontend
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                SetProperty(ref errorMessage, value);
            }
        }
        public RestCollection<Message> Messages { get; set; }

        private Message current;
        public Message Current
        {
            get { return current; }
            set
            {
                if (value != null)
                {
                    current = new Message()
                    {
                        Sender = value.Sender,
                        Content = value.Content
                    };
                    OnPropertyChanged();
                }
            }
        }
        public ICommand SendMessage {  get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            Messages = new RestCollection<Message>("http://localhost:19333/", "chat", "hub");

        }
    }
}
