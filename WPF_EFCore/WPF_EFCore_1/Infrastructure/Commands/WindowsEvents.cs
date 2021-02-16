using System;
using System.Windows;
using System.Windows.Input;

namespace WPF_EFCore_1.Infrastructure.Commands
{
    class WindowEvents
    {
        #region SourceInitializedProperty

        public static readonly DependencyProperty SourceInitializedProperty = DependencyProperty.RegisterAttached
        (
            "SourceInitialized", typeof(ICommand), typeof(WindowEvents),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(SourceInitializedChanged))
        );
        private static void SourceInitializedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((Window)d).SourceInitialized += element_SourceInitialized;
        public static ICommand GetSourceInitialized(UIElement element)
            => (ICommand)element.GetValue(SourceInitializedProperty);
        static void element_SourceInitialized(object sender, EventArgs e)
            => GetSourceInitialized((Window)sender).Execute(e);
        public static void SetSourceInitialized(UIElement element, ICommand value)
            => element.SetValue(SourceInitializedProperty, value);

        #endregion SourceInitializedProperty
    }
}
