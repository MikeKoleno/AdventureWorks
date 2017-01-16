using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.ViewModels
{
    //private int id;
    //public int Id
    //{
    //    get { return this.id; }
    //    set { this.SetProperty(ref this.id, value, () => this.Id); }
    //}

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = this.PropertyChanged;

            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetProperty<T>(ref T backingField, T Value, Expression<Func<T>> propertyExpression)
        {
            var changed = !EqualityComparer<T>.Default.Equals(backingField, Value);

            if (changed)
            {
                backingField = Value;
                this.RaisePropertyChanged(ExtractPropertyName(propertyExpression));
            }

            return changed;
        }

        private static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExp = propertyExpression.Body as MemberExpression;

            if (memberExp == null)
            {
                throw new ArgumentException("Expression must be a MemberExpression.", "propertyExpression");
            }

            return memberExp.Member.Name;
        }
    }
}
