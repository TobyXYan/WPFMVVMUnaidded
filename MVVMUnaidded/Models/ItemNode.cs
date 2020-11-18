using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMUnaidded.Models
{
    public class ItemNode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ItemNode> _children = new ObservableCollection<ItemNode>();

        public ObservableCollection<ItemNode> Children
        {
            get { return _children; }
            set { _children = value;  OnPropertyChanged(nameof(Children)); }
        }

        private string _displayName = string.Empty;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName =  value; OnPropertyChanged(nameof(DisplayName)); }
        }


    }
}
