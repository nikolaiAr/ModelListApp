using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelListApp.Data
{
    public class Error
    {
        private long _modelId;
        private string _fieldName;
        private string _description;

        /// <summary>
        /// Id of model that has error
        /// </summary>
        public long ModelId
        {
            get { return _modelId; }
            set { _modelId = value; }
        }

        /// <summary>
        /// Field of model that has error
        /// </summary>
        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        /// <summary>
        /// Description of error
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
