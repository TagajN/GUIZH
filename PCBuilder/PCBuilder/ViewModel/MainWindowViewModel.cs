using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using PCBuilder.Logic;
using PCBuilder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PCBuilder.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IComputerLogic logic;
        public ObservableCollection<Part> Storage { get; set; }

        public ObservableCollection<Part> PC { get; set; }

        private Part selectedFromStorage;
        private Part selectedFromPC;

        public ICommand Load { get; set; }
        public ICommand AddToPC { get; set; }
        public ICommand RemoveFromPC { get; set; }
        public ICommand Sale { get; set; }
        public ICommand Recipe { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            :this(IsInDesignMode ? null : Ioc.Default.GetService<IComputerLogic>())
        {

        }

        public MainWindowViewModel(IComputerLogic logic) 
        {
            this.logic = logic;
            Storage = new ObservableCollection<Part>();
            PC = new ObservableCollection<Part>();

            logic.SetupCollection(Storage, PC);

            Load = new RelayCommand(() => logic.Load(), () => Storage.ToArray().Length == 0);
            AddToPC = new RelayCommand(() => logic.AddToPC(SelectedFromStorage), () => SelectedFromStorage != null);
            RemoveFromPC = new RelayCommand(() => logic.RemoveFromPC(SelectefFromPC), () => SelectefFromPC != null);
            Sale = new RelayCommand(() => logic.Sale(SelectedFromStorage), () => SelectedFromStorage != null);
            Recipe = new RelayCommand(() => logic.Recipe());


            Messenger.Register<MainWindowViewModel, string, string>(this, "PartInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
            });
        }

        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }

        public Part SelectedFromStorage
        {
            get { return selectedFromStorage; }
            set
            {
                SetProperty(ref selectedFromStorage, value);
                (AddToPC as RelayCommand).NotifyCanExecuteChanged();
                (Sale as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public Part SelectefFromPC
        {
            get { return selectedFromPC; }
            set
            {
                SetProperty(ref selectedFromPC, value);
                (RemoveFromPC as RelayCommand).NotifyCanExecuteChanged();
            }
        }
    }
}
