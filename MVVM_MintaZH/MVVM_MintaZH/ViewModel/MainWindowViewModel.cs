using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using MVVM_MintaZH.Logic;
using MVVM_MintaZH.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_MintaZH.ViewModel
{
    public class MainWindowViewModel:ObservableRecipient
    {
        IArmyLogic logic;
        public ObservableCollection<Trooper> Barrack { get; set; }
        public ObservableCollection<Trooper> Army { get; set; }

        public ICommand AddtoArmyCommand { set; get; }
        public ICommand RemoveFromArmyCommand { set; get; }
        public ICommand EditTropperCommand { set; get; }

        private Trooper selectedFromBarrack;
        private Trooper selectedFromArmy;

        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (AddtoArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditTropperCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public Trooper SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }
        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel():this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {

        }
        public MainWindowViewModel(IArmyLogic logic)
        {
            this.logic = logic;
            Barrack = new ObservableCollection<Trooper>();
            Army = new ObservableCollection<Trooper>();

            Barrack.Add(new Trooper() { Type="Sniper", Power=8, Speed=2});
            Barrack.Add(new Trooper() { Type = "Parachuter", Power = 7, Speed = 6 });
            Barrack.Add(new Trooper() { Type = "Infantry", Power = 8, Speed = 8 });
            Barrack.Add(new Trooper() { Type = "Marine", Power = 9, Speed = 5 });
            Barrack.Add(new Trooper() { Type = "Major", Power = 5, Speed = 5 });

            Army.Add(Barrack[2].GetCopy());
            Army.Add(Barrack[2].GetCopy());

            logic.SetupCollections(Barrack, Army);

            AddtoArmyCommand = new RelayCommand(
                () => logic.AddToArmy(SelectedFromBarrack),
                () => selectedFromBarrack != null
                );
            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => selectedFromArmy != null
                );
            EditTropperCommand = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarrack),
                () => selectedFromBarrack != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
              {
                  OnPropertyChanged("AllCost");
                  OnPropertyChanged("AVGPower");
                  OnPropertyChanged("AVGSpeed");
              });
        }
    }
}
