using System.Windows;
using System.Windows.Controls;

namespace ADONET_WPF.Infrastructure.Assistants
{
    internal static class PasswordBoxAssistant
    {
        public static readonly DependencyProperty TextPassword = DependencyProperty.RegisterAttached
        (
            "TextPassword", typeof(string), typeof(PasswordBoxAssistant),
            new PropertyMetadata(string.Empty, OnTextPasswordChanged)
        );
        public static string GetTextPassword(DependencyObject dp) => (string)dp.GetValue(TextPassword);
        public static void SetTextPassword(DependencyObject dp, string value) => dp.SetValue(TextPassword, value);

        //---------------------------------------------------------------------

        public static readonly DependencyProperty BindPassword = DependencyProperty.RegisterAttached
        (
            "BindPassword", typeof(bool), typeof(PasswordBoxAssistant),
            new PropertyMetadata(false, OnBindPasswordChanged)
        );
        public static void SetBindPassword(DependencyObject dp, bool value) => dp.SetValue(BindPassword, value);
        public static bool GetBindPassword(DependencyObject dp) => (bool)dp.GetValue(BindPassword);

        //---------------------------------------------------------------------

        private static readonly DependencyProperty UpdatingPassword = DependencyProperty.RegisterAttached
        (
            "UpdatingPassword", typeof(bool), typeof(PasswordBoxAssistant),
            new PropertyMetadata(false)
        );
        private static bool GetUpdatingPassword(DependencyObject dp) => (bool)dp.GetValue(UpdatingPassword);
        private static void SetUpdatingPassword(DependencyObject dp, bool value) => dp.SetValue(UpdatingPassword, value);

        //---------------------------------------------------------------------

        private static void OnTextPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (dp is PasswordBox box && GetBindPassword(dp) is true)
            {
                box.PasswordChanged -= HandlePasswordChanged;
                {
                    if (GetUpdatingPassword(box) is false)
                        box.Password = (string)e.NewValue;
                }
                box.PasswordChanged += HandlePasswordChanged;
            }
        }

        private static void OnBindPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (dp is PasswordBox box)
            {
                if ((bool)(e.OldValue)) box.PasswordChanged -= HandlePasswordChanged;
                if ((bool)(e.NewValue)) box.PasswordChanged += HandlePasswordChanged;
            }
        }

        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox box)
            {
                SetUpdatingPassword(box, true);
                {
                    SetTextPassword(box, box.Password);
                }
                SetUpdatingPassword(box, false);
            }
        }
    }
}
