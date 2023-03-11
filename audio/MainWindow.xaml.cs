using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Controls.Primitives;

namespace audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPlaying = true;
        private int num;
        List<string> music = new List<string>();
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                string[] mp3 = Directory.GetFiles(dialog.FileName, "*.mp3");
                string[] wav = Directory.GetFiles(dialog.FileName, "*.wav");
                string[] m4a = Directory.GetFiles(dialog.FileName, "*.m4a");
                //string[] files = Directory.GetFiles(dialog.FileName, "*.mp3");
                List<string> files = new List<string>();
                files.AddRange(mp3);
                files.AddRange(m4a);
                files.AddRange(wav);
                listBox.ItemsSource = files;
                num = 0;
                mediaPlayer.Source = new Uri(files[num].ToString());
                mediaPlayer.Play();
                mediaPlayer.Volume = 0.1;
            }
            Thread thread = new Thread(_ =>
            {
                while (true)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        if (mediaPlayer.Position.Seconds <= 9)
                        {
                            mediaPlayerTimer.Text = Convert.ToString(mediaPlayer.Position.Minutes) + ":0" + Convert.ToString(mediaPlayer.Position.Seconds);
                            //timeLeft.Text = "-" + Convert.ToString((Math.Floor(mediaPlayer.NaturalDuration.TimeSpan.TotalMinutes)) - mediaPlayer.Position.Minutes) + ":0" + Convert.ToString((Math.Floor(mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds) % 60) - mediaPlayer.Position.Seconds);
                        }
                        else
                        {
                            mediaPlayerTimer.Text = Convert.ToString(mediaPlayer.Position.Minutes) + ":" + Convert.ToString(mediaPlayer.Position.Seconds);
                            //timeLeft.Text = "-" + Convert.ToString((Math.Floor(mediaPlayer.NaturalDuration.TimeSpan.TotalMinutes)) - mediaPlayer.Position.Minutes) + Convert.ToString((Math.Floor(mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds) % 60) - mediaPlayer.Position.Seconds);
                        }
                        slider.Value = mediaPlayer.Position.Ticks;
                    }));
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (isPlaying == false)
            {
                mediaPlayer.Play();
                isPlaying = true;
            }
            else if (isPlaying == true)
            {
                mediaPlayer.Pause();
                isPlaying = false;
            }

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = new TimeSpan(Convert.ToInt64(slider.Value));
        }

        private void mediaPlayer_MediaOpened(object sender, EventArgs e)
        {
            slider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.Ticks;
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            if (num >= 0)
                num--;
            mediaPlayer.Source = new Uri(listBox.Items[num].ToString());
            mediaPlayer.Play();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (num < listBox.Items.Count)
                num++;
            mediaPlayer.Source = new Uri(listBox.Items[num].ToString());
            mediaPlayer.Play();
        }

        private void repeat_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void shuffle_Click(object sender, RoutedEventArgs e)
        {

        }

        /*private TimeSpan GetWavFileDuration(string fileName)
        {
            WaveFileReader wf = new WaveFileReader(fileName);
            return wf.TotalTime;
        }*/



        private void mediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (num < listBox.Items.Count)
                num++;
            mediaPlayer.Source = new Uri(listBox.Items[num].ToString());
            mediaPlayer.Play();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}