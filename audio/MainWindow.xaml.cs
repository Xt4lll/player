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

namespace audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPlaying = true;
        private int num;
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
                string[] files = Directory.GetFiles(dialog.FileName);
                /*List<string> music = new List<string>();
                for(int k = 0; k < files.Length; k++)
                {
                music.Add(files[k]);
                }
                for (int i = 0; i < files.Length - 1; i++)
                {
                files[i].ToCharArray();
                string ext = files[i].Substring(files[i].Length - 4);
                if (ext != ".mp3")
                {
                music.RemoveAt(i);
                }
                }*/
                listBox.ItemsSource = files;
                num = 0;
                mediaPlayer.Source = new Uri(files[num].ToString());
                mediaPlayer.Play();
                mediaPlayer.Volume = 0.1;
                /*Thread thread = new Thread(_ =>
                {
                int sec = 0;
                int min = 0;
                while(true)
                {
                if(sec == 60)
                {
                min++;
                sec = 0;
                }
                mediaPlayerTimer.Text = Convert.ToString(min + ":" + sec);
                sec++;
                }
                });
                thread.Start();*/
            }
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
    }
}