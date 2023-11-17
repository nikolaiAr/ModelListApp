using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelListApp.Data
{
    public class ParcelModel : Model
    {
        private string _number;
        private string _location;

        /// <summary>
        /// Number of parcel
        /// </summary>
        [Required]
        public string Number
        {
            get { return _number; }
            set 
            { 
                _number = value;
                ValidatePropChanged();
            }
        }

        /// <summary>
        /// Location description of parcel
        /// </summary>
        [Required]
        public string Location
        {
            get { return _location; }
            set 
            { 
                _location = value;
                ValidatePropChanged();
            }
        }

        public ParcelModel()
        {
            this.Type = Constants.Enums.Types.Parcel;
        }
    }
}
