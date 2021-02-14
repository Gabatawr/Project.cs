namespace WPF_EFCore_1.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region int : MainWindowsMinWidthParameter

        private double _MainWindowsMinWidthParameter;
        public double MinWidthParameter
        {
            get => _MainWindowsMinWidthParameter;
            set => Set(ref _MainWindowsMinWidthParameter, value);
        }

        #endregion int : MainWindowsMinWidthParameter
        //---------------------------------------------------------------------
        #region int : MainWindowsMinHeightParameter

        private double _MainWindowsMinHeightParameter;
        public double MinHeightParameter
        {
            get => _MainWindowsMinHeightParameter;
            set => Set(ref _MainWindowsMinHeightParameter, value);
        }

        #endregion int : MainWindowsMinHeightParameter
        //---------------------------------------------------------------------
    }
}
