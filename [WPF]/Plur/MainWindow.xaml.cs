using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace Plur
{
    

    public partial class MainWindow : Window
    {
        private readonly Binding _gridBottomBinding = new Binding("ActualHeight")
        {
            RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor)
            {
                AncestorType = typeof(Grid)
            }
        };

        private readonly MediaPlayer _player = new MediaPlayer() {Volume = 0.2};

        private readonly List<MediaElement> _playList = new List<MediaElement>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WinMainMove_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }
        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            WinMain.Close();
        }
        private void BtnMin_OnClick(object sender, RoutedEventArgs e)
        {
            WinMain.WindowState = WindowState.Minimized;
        }

        private void BtnOpenPlaylist_OnClick(object sender, RoutedEventArgs e)
        {
            if (IcoOpenPlaylist.Kind == PackIconKind.PlaylistEdit)
            {
                GridBottom.SetBinding(HeightProperty, _gridBottomBinding);
                IcoOpenPlaylist.Kind = PackIconKind.PlaylistRemove;
                GridPlaylist.Visibility = Visibility.Visible;
            }
            else if (IcoOpenPlaylist.Kind == PackIconKind.PlaylistRemove)
            {
                GridBottom.Height = 16;
                IcoOpenPlaylist.Kind = PackIconKind.PlaylistEdit;
                GridPlaylist.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnPlay_OnClick(object sender, RoutedEventArgs e)
        {
            if (IcoPlay.Kind == PackIconKind.PlayCircleOutline)
            {
                if (_player.HasAudio)
                {
                    //_player.Play();
                    if (_player.Clock.CurrentState == ClockState.Active) 
                        _player.Clock.Controller.Resume();

                    else _player.Clock.Controller.Begin();

                    IcoPlayShadow.Kind = IcoPlay.Kind = PackIconKind.PauseCircleOutline;
                }
                else BtnAddMusic_OnClick(null, null);
            }
            else if (IcoPlay.Kind == PackIconKind.PauseCircleOutline)
            {
                //_player.Pause();
                _player.Clock.Controller.Pause();
                IcoPlayShadow.Kind = IcoPlay.Kind = PackIconKind.PlayCircleOutline;
            }
        }

        private void BtnAddMusic_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true, 
                Filter = "Music (*.mp3)|*.mp3"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                Uri uri = new Uri(path);

                _playList.Add(new MediaElement() {Source = uri});

                int tmp = path.LastIndexOf('\\') + 1;
                string name = path.Substring(tmp, path.Length - tmp);

                TxtTitle.Text = name;
                TablePlayList.Items.Add(name);

                _player.Open(_playList[^1].Source);

                MediaTimeline mtl = new MediaTimeline(uri);
                mtl.CurrentTimeInvalidated += Mtl_CurrentTimeInvalidated;
                mtl.Completed += Mtl_Completed;

                _player.Clock = mtl.CreateClock(true) as MediaClock;
                _player.Clock.Controller.Begin();

                //_player.Play();

                IcoPlayShadow.Kind = IcoPlay.Kind = PackIconKind.PauseCircleOutline;

                while (true)
                {
                    if (_player.NaturalDuration.HasTimeSpan)
                    {
                        int min = _player.NaturalDuration.TimeSpan.Minutes;
                        int sec = _player.NaturalDuration.TimeSpan.Seconds;

                        string m = min < 10 ? "0" + min : min.ToString();
                        string s = sec < 10 ? "0" + sec : sec.ToString();

                        TxtTimeAll.Text = m + ':' + s;
                        break;
                    }
                }

                if (TablePlayList.Items.Count == 1) TablePlayList.SelectAll();
            }
        }
        private void Mtl_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            if (_player.Clock.CurrentState == ClockState.Active)
            {
                int min = _player.Clock.CurrentTime.Value.Minutes;
                int sec = _player.Clock.CurrentTime.Value.Seconds;

                string m = min < 10 ? "0" + min : min.ToString();
                string s = sec < 10 ? "0" + sec : sec.ToString();

                TxtTimeLeft.Text = m + ':' + s;

                double allTime;
                while (true)
                {
                    if (_player.Clock.NaturalDuration.HasTimeSpan)
                    {
                        allTime = _player.Clock.NaturalDuration.TimeSpan.Ticks;
                        break;
                    }
                }

                double curTime = _player.Clock.CurrentTime.Value.Ticks;

                foreach (GradientStop gs in ProgressBar.GradientStops) gs.Offset = curTime / allTime;
            }
        }
        private void Mtl_Completed(object sender, EventArgs e)
        {
            IcoPlayShadow.Kind = IcoPlay.Kind = PackIconKind.PlayCircleOutline;
            _player.Clock.Controller.Stop();

            TxtTimeLeft.Text = TxtTimeAll.Text;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_player.HasAudio)
            {
                double allTime;
                while (true)
                {
                    if (_player.NaturalDuration.HasTimeSpan)
                    {
                        allTime = _player.NaturalDuration.TimeSpan.Ticks;
                        break;
                    }
                }

                double percent = e.GetPosition(ProgressGrid).X / Width;
                _player.Clock.Controller.Seek(TimeSpan.FromTicks((long)(allTime * percent)), TimeSeekOrigin.BeginTime);
                foreach (GradientStop gs in ProgressBar.GradientStops) gs.Offset = percent;
            }
        }

        private void ValueGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            double percent = e.GetPosition(VolumeGrid).X / VolumeGrid.Width;
            foreach (GradientStop gs in VolumeBar.GradientStops) gs.Offset = percent;
            _player.Volume = percent;
        }
    }
}
