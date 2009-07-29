using System;
using System.ComponentModel;
using System.Linq.Expressions;
using XPSGeneration.Extensions;

namespace XPSGeneration.Foundation
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged<T>(T viewModel, Expression<Func<T, object>> expr)
        {
            var propertyName = expr.GetPropertyName();

            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}