using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelListApp.Data
{
    public class BuildingModel : Model
    {
        private int _floorCount;
        private string _address;
        private bool _isLiving = false;

        /// <summary>
        /// Count of floor in building
        /// </summary>
        [Required]
        [Range(1, 100)]
        public int FloorCount
        {
            get { return _floorCount; }
            set 
            { 
                _floorCount = value; 
                ValidatePropChanged();
            }
        }
        
        /// <summary>
        /// Address of building
        /// </summary>
        [Required]
        public string Address
        {
            get { return _address; }
            set 
            { 
                _address = value; 
                ValidatePropChanged(); 
            }
        }

        /// <summary>
        /// Sign of a residential building
        /// </summary>
        public bool IsLiving
        {
            get { return _isLiving; }
            set { _isLiving = value; }
        }


        public BuildingModel()
        {
            this.Type = Constants.Enums.Types.Building;
        }

    }
}
