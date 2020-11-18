using MVVMUnaidded.Common;
using MVVMUnaidded.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMUnaidded.ViewModels
{
    public class ShellViewModel:ViewModelBase
    {

        #region Constructors
        public ShellViewModel()
        {
            InitCommands();
            InitTree();
        }

       
        #endregion

        #region Types
        #endregion

        #region Fields
        private string _name;
        private ObservableCollection<ItemNode> _children = new ObservableCollection<ItemNode>();
        #endregion

        #region Properties
        public string Name { get=>_name; set { _name = value; OnPropertyChanged(nameof(Name)); }}
        public ICommand BtnClickCommand { get; private set; }
        public ICommand SelectedItemChangedCommand { get; private set; }
        public ObservableCollection<ItemNode> Children
        {
            get { return _children; }
            set { _children = value; OnPropertyChanged(nameof(Children)); }
        }

        #endregion

        #region Methods
        private void InitCommands()
        {
            BtnClickCommand = new RelayCommand(o=>SetName(), o=>true);
            SelectedItemChangedCommand = new RelayCommand(o=> OnSelectedItemChanged(o), o=>true);
        }

        private void SetName()
        {
            Name = "NoBoday";
        }

        private void InitTree()
        {
            var parentNode1 = new ItemNode { DisplayName = "Parent1" };
            parentNode1.Children.Add(new ItemNode { DisplayName = "Child1" });
            var parentNode2 = new ItemNode { DisplayName = "Parent2" };
            parentNode2.Children.Add(new ItemNode { DisplayName = "Child2" });
            Children.Add(parentNode1);
            Children.Add(parentNode2);
        }

        private void OnSelectedItemChanged(object item)
        {
            if(item is ItemNode node)
                node.DisplayName = "NewChildName";
        }
        #endregion

    }
}
