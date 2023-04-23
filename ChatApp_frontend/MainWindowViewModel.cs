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

        private string sender;
        public string Sender
        {
            get { return sender; }
            set
            {
                if (!string.Equals(this.sender, value))
                {
                    sender = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                if(!string.Equals(this.content, value))
                {
                    content = value;
                    this.OnPropertyChanged();
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
            if(!IsInDesignMode)
            {
                Messages = new RestCollection<Message>("http://localhost:5000/", "message", "hub");
                SendMessage = new RelayCommand(() =>
                {
                    
                    Messages.Add(new Message()
                    {
                        Sender = sender,
                        Content = content,
                        Date = DateTime.Now.ToString()
                    });
                });
            }
        }
    }
}
