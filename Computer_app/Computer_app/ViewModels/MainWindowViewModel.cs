using Computer_app.Logic;
using Computer_app.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Computer_app.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<ComponentAsset> Storage { get; set; }
        public ObservableCollection<ComponentAsset> Basket { get; set; }
        IComponentLogic logic;

        public ICommand AddToBasket { get; set; }
        public ICommand RemoveFromBasket { get; set; }
        public ICommand LoadData { get; set; }
        public ICommand UpdatePrice { get; set; }

        public ICommand InvoiceList { get; set; }

        private ComponentAsset selectedFromStorage;

        public ComponentAsset SelectedFromStorage
        {
            get { return selectedFromStorage; }
            set
            {
                SetProperty(ref selectedFromStorage, value);
                (UpdatePrice as RelayCommand).NotifyCanExecuteChanged();
                (AddToBasket as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private ComponentAsset selectedFromBasket;

        public ComponentAsset SelectedFromBasket
        {
            get { return selectedFromBasket; }
            set
            { 
                SetProperty(ref selectedFromBasket, value);
                (RemoveFromBasket as RelayCommand).NotifyCanExecuteChanged();
                (InvoiceList as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public double AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.
                    FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IComponentLogic>())
        {

        }
        public MainWindowViewModel(IComponentLogic logic)
        {
            this.logic = logic;
            Storage = new ObservableCollection<ComponentAsset>();
            Basket = new ObservableCollection<ComponentAsset>();

            logic.SetupCollections(Storage, Basket);
            LoadData = new RelayCommand(
                () => logic.loadData(),
                () => Storage.ToArray().Length == 0
                );

            AddToBasket = new RelayCommand(
                () => logic.AddToBasket(SelectedFromStorage),
                () => SelectedFromStorage != null
                );
            RemoveFromBasket = new RelayCommand(
                () => logic.RemoveFromBasket(SelectedFromBasket),
                () => SelectedFromBasket != null
                );

            InvoiceList = new RelayCommand(
                () => logic.Invoice(Basket),
                () => Basket.Count != null
                );

            UpdatePrice = new RelayCommand(
                () => SelectedFromStorage.Price = logic.UpdatePrice(SelectedFromStorage),
                () => SelectedFromStorage != null
                );
            Messenger.Register<MainWindowViewModel, string, string>(this, "ComponentInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
            });
        }
    }
}
