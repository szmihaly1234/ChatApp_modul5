using ChatApp_backend.Model;
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
        public RestCollection<ChatObject> ChatObjects { get; set; }
        private ChatObject current;
        public ChatObject Current
        {
            get { return current; }
            set
            {
                if (value != null)
                {
                    current = new ChatObject()
                    {
                        Name = value.Name,
                        Message = value.Message
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
            if(!IsInDesignMode)
            {
                ChatObjects = new RestCollection<ChatObject>("https://localhost:7120/", "Chat", "hub");
                SendMessage = new RelayCommand(() =>
                {
                    ChatObjects.Add(new ChatObject()
                    {
                        Name = Current.Name,
                        Message = Current.Message
                    });
                });
            }
        }
    }
}
