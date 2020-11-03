using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HashesApp.Views.Pages;
using HashesApp.Interfaces;
using HashesApp.Models;
using System.Collections.ObjectModel;

namespace HashesApp.VMs
{
    class MainVMClass : BindableBase
    {
        private HashVMClass _hashVM = new HashVMClass();
        private Page _selectedPage;
        private IHash _selectedHash;

        public IHash SelectedHash
        { 
            get
            {
                return _selectedHash;
            }
            set
            {
                _selectedHash = value;
                _hashVM.Hash = SelectedHash;
                _hashVM.ClearAll();
                RaisePropertyChanged(nameof(SelectedHash));
            }
        }
        public ObservableCollection<IHash> Hashes { get; set; }

        public Page SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                _selectedPage = value;
                RaisePropertyChanged(nameof(SelectedPage));
            }
        }
        public MainVMClass()
        {
            #region add hashes to list

            Hashes = new ObservableCollection<IHash>
            {
                new MD5(),
                new SHA1()
            };
            RaisePropertyChanged(nameof(Hashes));
            SelectedHash = Hashes.First();

            #endregion

            SelectedPage = new HashPage();

            SelectedPage.DataContext = _hashVM;
        }
    }
}
