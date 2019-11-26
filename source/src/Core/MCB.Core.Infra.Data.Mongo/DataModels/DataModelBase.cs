using MCB.Core.Infra.Data.Mongo.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MCB.Core.Infra.Data.Mongo.DataModels
{
    /*
     * This class not inherits bom Data.DataModelBase because
     * The ID Property must be declared directly in mapped class.
     * In mongo library, only BindingFlag.DeclaredOnly are read and,
     * because this, inherited members not work
     */
    public abstract class DataModelBase
        : INotifyPropertyChanged
    {
        private readonly Stack<string> _propertyChangedStack;

#pragma warning disable CS0067
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
                !q.Equals(nameof(IMongoDataModel.Id))
                && !q.Equals(nameof(IMongoDataModel.DataModelId))
                )
            .AsEnumerable();
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


