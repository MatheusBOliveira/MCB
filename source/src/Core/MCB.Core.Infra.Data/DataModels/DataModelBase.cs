using MCB.Core.Infra.Data.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MCB.Core.Infra.Data.DataModels
{
    public abstract class DataModelBase
        : IDataModel,
        INotifyPropertyChanged
    {
        private readonly Stack<string> _propertyChangedStack;

        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected DataModelBase()
        {
            _propertyChangedStack = new Stack<string>();

            PropertyChanged += (s, e) => {
                AddPropertyChanged(e.PropertyName);
            };
        }

        private void AddPropertyChanged(string propertyName)
        {
            if (_propertyChangedStack.Contains(propertyName))
                return;

            _propertyChangedStack.Push(propertyName);
        }
        public IEnumerable<string> GetPropertyChangedCollection()
        {
            return _propertyChangedStack.Where(q => 
                !q.Equals(nameof(Id)))
            .AsEnumerable();
        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DataModelBase;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo is null)
                return false;

            return Id.Equals(compareTo.Id);
        }
        public static bool operator ==(DataModelBase a, DataModelBase b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(DataModelBase a, DataModelBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id='{Id}']";
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


