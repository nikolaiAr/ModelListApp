using ModelListApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelListApp.ViewModel
{
    public class BuildingViewModel : BaseViewModel
    {
        private BuildingModel _building;

        public BuildingModel Building
        {
            get { return _building; }
            set { _building = value; }
        }

        public BuildingViewModel(BuildingModel model)
        {
            this.Building = model;
        }
    }
}
