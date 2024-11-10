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

namespace AviViewer
{
    public partial class MainWindow : Window
    {
        private WaveOutEvent waveOut;
        private AudioFileReader audioFileReader;
        private bool isPaused = false;

        public MainWindow()
        {
            InitializeComponent();
            playPauseButton.Content = "pause";
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
            // Воспроизведение видео
            mediaElement.Source = new Uri(filePath);
            mediaElement.Volume = VolumeSlider.Value;
            mediaElement.Play();

            // Воспроизведение аудио
            PlayAudio(filePath);
        }

        private void PlayAudio(string filePath)
        {
            waveOut = new WaveOutEvent();
            audioFileReader = new AudioFileReader(filePath);
            waveOut.Init(audioFileReader);
            waveOut.Volume = (float)VolumeSlider.Value;
            waveOut.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut == null)
            {
                return;
            }
            if (isPaused)
            {
                // Возобновление видео
                mediaElement.Play();

                // Возобновление аудио
                waveOut.Play();
            }
            else
            {
                // Пауза видео
                mediaElement.Pause();

                // Пауза аудио
                waveOut.Pause();
            }

            if (isPaused)
            {
                playPauseButton.Content = "pause";
            } else
            {
                playPauseButton.Content = "play";
            }
            isPaused = !isPaused;
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Устанавливаем громкость видео
            mediaElement.Volume = VolumeSlider.Value;

            // Устанавливаем громкость аудио
            if (waveOut != null)
            {
                waveOut.Volume = (float)VolumeSlider.Value;
            }
        }


        private void RemoveVideoButton_Click(object sender, RoutedEventArgs e)
        {
            // Удаление видео
            mediaElement.Source = null;

            // Остановка и освобождение ресурсов аудио
            waveOut?.Stop();
            waveOut?.Dispose();
            audioFileReader?.Dispose();
            waveOut = null;
            audioFileReader = null;
        }

        protected override void OnClosed(EventArgs e)
        {
            // Освобождение ресурсов при закрытии приложения
            waveOut?.Stop();
            waveOut?.Dispose();
            audioFileReader?.Dispose();
            base.OnClosed(e);
        }

    }
}
