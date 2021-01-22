using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ADONET_WPF.Infrastructure.Commands.Input
{
    class MouseCommands
    {
        #region Click

        public static readonly DependencyProperty ClickProperty = DependencyProperty.RegisterAttached
        (
            "Click", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(ClickChanged))
        );
        private static void ClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((Button)d).Click += element_Click;
        static void element_Click(object sender, RoutedEventArgs e)
            => GetClick((Button)sender).Execute(e);
        public static void SetClick(UIElement element, ICommand value)
            => element.SetValue(ClickProperty, value);
        public static ICommand GetClick(UIElement element)
            => (ICommand)element.GetValue(ClickProperty);

        #endregion

        #region MouseUp

        public static readonly DependencyProperty MouseUpProperty = DependencyProperty.RegisterAttached
        (
            "MouseUp", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseUpChanged))
        );
        private static void MouseUpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseUp += element_MouseUp;
        static void element_MouseUp(object sender, MouseButtonEventArgs e)
            => GetMouseUp((FrameworkElement)sender).Execute(e);
        public static void SetMouseUp(UIElement element, ICommand value)
            => element.SetValue(MouseUpProperty, value);
        public static ICommand GetMouseUp(UIElement element)
            => (ICommand)element.GetValue(MouseUpProperty);

        #endregion

        #region MouseDown

        public static readonly DependencyProperty MouseDownProperty = DependencyProperty.RegisterAttached
        (
            "MouseDown", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseDownChanged))
        );
        private static void MouseDownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseDown += element_MouseDown;
        static void element_MouseDown(object sender, MouseButtonEventArgs e)
            => GetMouseDown((FrameworkElement)sender).Execute(e);
        public static void SetMouseDown(UIElement element, ICommand value)
            => element.SetValue(MouseDownProperty, value);
        public static ICommand GetMouseDown(UIElement element)
            => (ICommand)element.GetValue(MouseDownProperty);

        #endregion

        #region MouseLeave

        public static readonly DependencyProperty MouseLeaveProperty = DependencyProperty.RegisterAttached
        (
            "MouseLeave", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseLeaveChanged))
        );
        private static void MouseLeaveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseLeave += new MouseEventHandler(element_MouseLeave);
        static void element_MouseLeave(object sender, MouseEventArgs e)
            => GetMouseLeave((FrameworkElement)sender).Execute(e);
        public static void SetMouseLeave(UIElement element, ICommand value)
            => element.SetValue(MouseLeaveProperty, value);
        public static ICommand GetMouseLeave(UIElement element)
            => (ICommand)element.GetValue(MouseLeaveProperty);

        #endregion

        #region MouseLeftButtonDown

        public static readonly DependencyProperty MouseLeftButtonDownProperty = DependencyProperty.RegisterAttached
        (
            "MouseLeftButtonDown", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseLeftButtonDownChanged))
        );
        private static void MouseLeftButtonDownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseLeftButtonDown += element_MouseLeftButtonDown;
        static void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => GetMouseLeftButtonDown((FrameworkElement)sender).Execute(e);
        public static void SetMouseLeftButtonDown(UIElement element, ICommand value)
            => element.SetValue(MouseLeftButtonDownProperty, value);
        public static ICommand GetMouseLeftButtonDown(UIElement element)
            => (ICommand)element.GetValue(MouseLeftButtonDownProperty);

        #endregion

        #region MouseLeftButtonUp

        public static readonly DependencyProperty MouseLeftButtonUpProperty = DependencyProperty.RegisterAttached
        (
            "MouseLeftButtonUp", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseLeftButtonUpChanged))
        );

        private static void MouseLeftButtonUpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseLeftButtonUp += element_MouseLeftButtonUp;
        static void element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            => GetMouseLeftButtonUp((FrameworkElement)sender).Execute(e);
        public static void SetMouseLeftButtonUp(UIElement element, ICommand value)
            => element.SetValue(MouseLeftButtonUpProperty, value);
        public static ICommand GetMouseLeftButtonUp(UIElement element)
            => (ICommand)element.GetValue(MouseLeftButtonUpProperty);

        #endregion

        #region MouseMove

        public static readonly DependencyProperty MouseMoveProperty = DependencyProperty.RegisterAttached
        (
            "MouseMove", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseMoveChanged))
        );
        private static void MouseMoveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseMove += new MouseEventHandler(element_MouseMove);
        static void element_MouseMove(object sender, MouseEventArgs e)
            => GetMouseMove((FrameworkElement)sender).Execute(e);
        public static void SetMouseMove(UIElement element, ICommand value)
            => element.SetValue(MouseMoveProperty, value);
        public static ICommand GetMouseMove(UIElement element)
            => (ICommand)element.GetValue(MouseMoveProperty);

        #endregion

        #region MouseRightButtonDown

        public static readonly DependencyProperty MouseRightButtonDownProperty = DependencyProperty.RegisterAttached(
            "MouseRightButtonDown", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseRightButtonDownChanged))
        );
        private static void MouseRightButtonDownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseRightButtonDown += element_MouseRightButtonDown;
        static void element_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
            => GetMouseRightButtonDown((FrameworkElement)sender).Execute(e);
        public static void SetMouseRightButtonDown(UIElement element, ICommand value)
            => element.SetValue(MouseRightButtonDownProperty, value);
        public static ICommand GetMouseRightButtonDown(UIElement element)
            => (ICommand)element.GetValue(MouseRightButtonDownProperty);

        #endregion

        #region MouseRightButtonUp

        public static readonly DependencyProperty MouseRightButtonUpProperty = DependencyProperty.RegisterAttached
        (
            "MouseRightButtonUp", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseRightButtonUpChanged))
        );
        private static void MouseRightButtonUpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseRightButtonUp += element_MouseRightButtonUp;
        static void element_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
            => GetMouseRightButtonUp((FrameworkElement)sender).Execute(e);
        public static void SetMouseRightButtonUp(UIElement element, ICommand value)
            => element.SetValue(MouseRightButtonUpProperty, value);
        public static ICommand GetMouseRightButtonUp(UIElement element)
            => (ICommand)element.GetValue(MouseRightButtonUpProperty);

        #endregion

        #region MouseWheel

        public static readonly DependencyProperty MouseWheelProperty = DependencyProperty.RegisterAttached
        (
            "MouseWheel", typeof(ICommand), typeof(MouseCommands),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseWheelChanged))
        );
        private static void MouseWheelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((FrameworkElement)d).MouseWheel += new MouseWheelEventHandler(element_MouseWheel);
        static void element_MouseWheel(object sender, MouseWheelEventArgs e)
            => GetMouseWheel((FrameworkElement)sender).Execute(e);
        public static void SetMouseWheel(UIElement element, ICommand value)
            => element.SetValue(MouseWheelProperty, value);
        public static ICommand GetMouseWheel(UIElement element)
            => (ICommand)element.GetValue(MouseWheelProperty);

        #endregion
    }
}
