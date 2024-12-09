using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using NAudio.Wave;
using System.Windows.Threading;

namespace AviViewer
{
    public partial class MainWindow : Window
    {
        private WaveOutEvent waveOut;
        private AudioFileReader audioFileReader;
        private bool isPaused = false;
        private DispatcherTimer timer; 


        public MainWindow()
        {
            InitializeComponent();

            
            mediaElement.MediaEnded += MediaElement_MediaEnded;

            pauseIcon.Visibility = Visibility.Collapsed;
            playIcon.Visibility = Visibility.Visible;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void OpenAviButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "AVI Files (*.avi)|*.avi"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                PlayAvi(openFileDialog.FileName);
            }
        }

        private void PlayAvi(string filePath)
        {
           
            mediaElement.Source = new Uri(filePath);
            mediaElement.Volume = VolumeSlider.Value;
            mediaElement.Play();
           
            PlayAudio(filePath);

            
            timer.Start();
        }

        private void PlayAudio(string filePath)
        {
            waveOut = new WaveOutEvent();
            audioFileReader = new AudioFileReader(filePath);
            waveOut.Init(audioFileReader);
            waveOut.Volume = (float)VolumeSlider.Value;
            waveOut.Play();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
           
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut == null)
            {
                return;
            }
            if (isPaused)
            {
               
                mediaElement.Play();
                waveOut.Play();
                timer.Start(); 
            }
            else
            {
               
                mediaElement.Pause();
                waveOut.Pause();
                timer.Stop(); 
            }

            isPaused = !isPaused;
            if (!isPaused)
            {
                playIcon.Visibility = Visibility.Collapsed;
                pauseIcon.Visibility = Visibility.Visible;
            } else
            {
                playIcon.Visibility = Visibility.Visible;
                pauseIcon.Visibility = Visibility.Collapsed;
            }




           
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            mediaElement.Volume = VolumeSlider.Value;
            VolumeText.Text = (VolumeSlider.Value * 100).ToString();



            if (waveOut != null)
            {
                waveOut.Volume = (float)VolumeSlider.Value;
            }
        }

        private void RemoveVideoButton_Click(object sender, RoutedEventArgs e)
        {
            
            mediaElement.Source = null;

           
            waveOut?.Stop();
            waveOut?.Dispose();
            audioFileReader?.Dispose();
            waveOut = null;
            audioFileReader = null;

            
            timer.Stop();
            PositionSlider.Value = 0;
            CurrentPositionText.Text = "0:00";
            TotalDurationText.Text = "0:00";
        }

        protected override void OnClosed(EventArgs e)
        {
            
            waveOut?.Stop();
            waveOut?.Dispose();
            audioFileReader?.Dispose();
            timer?.Stop();
            base.OnClosed(e);
        }

        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mediaElement.NaturalDuration.HasTimeSpan)
            {
                PositionSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                PositionSlider.Value = mediaElement.Position.TotalSeconds;
               
                CurrentPositionText.Text = mediaElement.Position.ToString(@"mm\:ss");
                TotalDurationText.Text = mediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
            }
        }

       
        private void PositionSlider_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            timer.Stop();
        }

        
        private void PositionSlider_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(PositionSlider.Value); 
            timer.Start(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            PositionSlider.Value = 0;
            timer.Stop();
            mediaElement.Position = TimeSpan.FromSeconds(0);
            timer.Start();
        }

        private void speedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.SpeedRatio == 2)
            {
                mediaElement.SpeedRatio = 1;
            } else
            {
                mediaElement.SpeedRatio = 2;
            }
        }

        private void speed125Btn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.SpeedRatio == 1.25)
            {
                mediaElement.SpeedRatio = 1;
            }
            else
            {
                mediaElement.SpeedRatio = 1.25;
            }
        }

        private void rewindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Position.TotalSeconds > 0)
            {
                mediaElement.Position = mediaElement.Position.Subtract(TimeSpan.FromSeconds(0.05));
            } else
            {
                mediaElement.Position = TimeSpan.Zero;
            }
        }
    }
}
