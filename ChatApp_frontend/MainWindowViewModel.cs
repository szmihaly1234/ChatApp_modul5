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
                        Content = value.Content,
                        Date = DateTime.Now.ToString()
                    };
                    OnPropertyChanged();
                    (SendMessage as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand SendMessage { get; set; }
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
            if (!IsInDesignMode)
            {
                Messages = new RestCollection<Message>("http://localhost:19333/", "message", "hub");
                SendMessage = new RelayCommand(() =>
                {

                    Messages.Add(new Message()
                    {
                        Sender = Current.Sender,
                        Content = Current.Content,
                        Date = Current.Date,
                    });
                });
            }
        }
    }
}
