using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using ModelListApp.Data;

namespace ModelListApp.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        #region Properties
        private Model _selectedItem;
        private Error _selectedError;
        private BaseViewModel _currentVM;

        /// <summary>
        /// Collection of main items
        /// </summary>
        public ObservableCollection<Model> Items { get; set; }

        /// <summary>
        /// Collection of validation errors
        /// </summary>
        public ObservableCollection<Error> Errors { get; set; }
        
        /// <summary>
        /// Selected item
        /// </summary>
        public Model SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                SelectCurrentVM(value);

                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        /// <summary>
        /// Selected validation error
        /// </summary>
        public Error SelectedError
        {
            get { return _selectedError; }
            set
            {
                _selectedError = value;
                if (value != null)
                    SelectedItem = Items.FirstOrDefault(x => x.Id == value?.ModelId);
                OnPropertyChanged(nameof(SelectedError));
            }
        }

        /// <summary>
        /// Current View Moodel to show
        /// </summary>
        public BaseViewModel CurrentVM 
        { 
            get { return _currentVM; } 
            set 
            { 
                _currentVM = value;
                OnPropertyChanged(nameof(CurrentVM));
            } 
        }
        #endregion

        #region Commands
        private Command addBuildingCommand;
        public Command AddBuildingCommand
        {
            get
            {
                return addBuildingCommand ??
                  (addBuildingCommand = new Command(obj =>
                  {
                      Model newItem = new BuildingModel();
                      AddItem(newItem);
                  }));
            }
        }

        private Command addParcelCommand;
        public Command AddParcelCommand
        {
            get
            {
                return addParcelCommand ??
                  (addParcelCommand = new Command(obj =>
                  {
                      Model newItem = new ParcelModel();
                      AddItem(newItem);
                  }));
            }
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            Items = new ObservableCollection<Model>();
            Errors = Model.ListErrors;
        }
        #endregion

        /// <summary>
        /// Add new model to Items
        /// </summary>
        /// <param name="newItem">new model to add</param>
        private void AddItem(Model newItem)
        {
            Items.Add(newItem);
            SelectedItem = newItem;

            newItem.ValidatePropChanged();
        }

        /// <summary>
        /// Select current view model to show
        /// </summary>
        /// <param name="model"></param>
        private void SelectCurrentVM(Model model)
        {
            if (model.Type == Constants.Enums.Types.Building)
                CurrentVM = new BuildingViewModel((BuildingModel)model);
            else if (model.Type == Constants.Enums.Types.Parcel)
                CurrentVM = new ParcelViewModel((ParcelModel)model);
        }
    }
}
