using ModelListApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelListApp.ViewModel
{
    public class ParcelViewModel : BaseViewModel
    {
        private ParcelModel _parcel;

        public ParcelModel Parcel
        {
            get { return _parcel; }
            set { _parcel = value; }
        }

        public ParcelViewModel(ParcelModel model)
        {
            this.Parcel = model;
        }
    }
}
