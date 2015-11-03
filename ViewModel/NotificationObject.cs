using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MMLib.SHotkey.ViewModel
{
    public abstract class NotificationObject : INotifyPropertyChanged
    {

        #region Private Constants

        private const string PROPERT_SET_PREFIX = "set_";

        #endregion


        #region INotifyPropertyChanged Members

        /// <summary>        
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>        
        /// Raise PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of property which was changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        /// <summary>        
        /// Raise PropertyChanged event.
        /// </summary>
        /// <param name="exp">The name of property which was changed.</param>
        protected void OnPropertyChanged<T>(Expression<Func<T>> exp)
        {
            MemberExpression memberExpression = (MemberExpression)exp.Body;
            string propertyName = memberExpression.Member.Name;

            OnPropertyChanged(propertyName);
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Set property value to field.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="propertyExpression">Property expression for getting property name.</param>
        /// <param name="field">Field of property.</param>
        /// <param name="newValue">New value.</param>
        protected virtual void SetPropertyValue<T>(Expression<Func<T>> propertyExpression,
                                                                 ref T field,
                                                                     T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(propertyExpression);
            }
        }

        #endregion

        #region Debugging Aides

        /// <summary>        
        /// Check if property name exist in this object.
        /// </summary>
        [Conditional("DEBUG"), DebuggerStepThrough()]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name XYZ: " + propertyName;
                throw new Exception(msg);
            }
        }

        #endregion


        #region Private helpers

        private string CheckAndCorrectPropertyName(string propertyName)
        {
            if (propertyName.StartsWith(PROPERT_SET_PREFIX))
            {
                propertyName = propertyName.Replace(PROPERT_SET_PREFIX, "");
            }
            return propertyName;
        }

        #endregion
    }
}
