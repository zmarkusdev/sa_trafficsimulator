using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Technics
{
    public abstract class Model : INotifyPropertyChanged, IDataErrorInfo
    {
        #region IDataErrorInfo

        public string Error
        {
            get
            {
                return "in errorfunction";
            }
        }

        public virtual string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        protected virtual string Validate(string propertyName)
        {
            return "Errorhandling not implemented for this field.";
        }

        #endregion

        #region INotifyPropertyChanged Methods

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var memberExpression = (MemberExpression)projection.Body;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }

        #endregion
    }
}
