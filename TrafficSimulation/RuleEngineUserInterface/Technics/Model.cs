using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Technics
{
    public abstract class Model : INotifyPropertyChanged, IDataErrorInfo
    {

        #region ------ IDataErrorInfo

        public string Error
        {
            get
            {
                return "Data Error";
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

        #region ----- INotifyPropertyChanged Methods

        /// <summary>
        /// Property event handler for User Interface updates
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Updates the User Interface property
        /// </summary>
        /// <param name="propertyName">not needed</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates the variable (called from XAML)
        /// </summary>
        /// <typeparam name="TProperty">XAML internal use</typeparam>
        /// <param name="projection">XAML internal use</param>
        protected virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var memberExpression = (MemberExpression)projection.Body;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }

        #endregion
    }
}
