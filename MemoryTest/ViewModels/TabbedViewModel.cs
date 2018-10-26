using System;

using MemoryTest.Helpers;

namespace MemoryTest.ViewModels
{
    public class TabbedViewModel : Observable
    {
        public TabbedViewModel()
        {
            InitializeCommands();
        }

        #region Events

        public event Action CloseRequired;
        public event Action AddRequired;

        #endregion 

        #region Commands
        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            CloseCommand = new RelayCommand(Close);
            AddCommand = new RelayCommand(Add);
        }
        private void Close()
        {
            CloseRequired?.Invoke();
        }

        private void Add()
        {
            AddRequired?.Invoke();
        }

        #endregion
    }
}
