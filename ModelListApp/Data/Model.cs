using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelListApp.Constants.Enums;

namespace ModelListApp.Data
{
    public abstract class Model
    {
        private long _id;
        private Types _type;
        private static long count = 0;
        private static ObservableCollection<Error> _listErrors = new ObservableCollection<Error>();

        /// <summary>
        /// Unique identificator of model
        /// </summary>
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Type of model
        /// </summary>
        public Types Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public Model ()
        {
            _id = ++count;
        }

        /// <summary>
        /// List to save validation errors
        /// </summary>
        public static ObservableCollection<Error> ListErrors
        {
            get { return _listErrors; }
            set { _listErrors = value; }
        }

        /// <summary>
        /// Validate Property Changes
        /// </summary>
        internal void ValidatePropChanged()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            ListErrors.Where(x => x.ModelId == this.Id).ToList().All(i => ListErrors.Remove(i));

            if (!Validator.TryValidateObject(this, context, results, true))
                foreach (var error in results)
                {
                    ListErrors.Add(new Error()
                    {
                        ModelId = this.Id,
                        FieldName = error.MemberNames.FirstOrDefault(),
                        Description = error.ErrorMessage
                    });
                }
        }
    }
}
