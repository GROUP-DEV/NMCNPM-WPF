
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// Espacio de nombres de la clase DispatcherTimer.
using System.Windows.Threading;

namespace DoAn.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class mucsic : UserControl
    {
        // Campos auxiliares.

        ListBoxItem currentTrack;
        ListBoxItem PreviousTrack;
        Brush currentTrackIndicator;
        Brush TrackColor;
        DispatcherTimer timer;
        bool isDragging;

        public mucsic()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
            currentTrack = null;
            PreviousTrack = null;
            currentTrackIndicator = Brushes.Blue;
            TrackColor = listaDeReproduccion.Foreground; // ListBoxItem.Foreground es diferente

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Tick se dispara cada segundo.
            timer.Tick += new EventHandler(timer_Tick);

            isDragging = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging) // Si NO hay operación de arrastre en el sliderTimeLine, su posición se actualiza cada segundo.
            {
                SliderTimeLine.Value = MEmusicPlayer.Position.TotalSeconds;
            }
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

        private void listBox1_Drop(object sender, DragEventArgs e)
        {

            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string fileName in s)
            {
                if (System.IO.Path.GetExtension(fileName) == ".mp3" ||
                    System.IO.Path.GetExtension(fileName) == ".MP3")
                {
                    ListBoxItem lstItem = new ListBoxItem();
                    lstItem.Content = System.IO.Path.GetFileNameWithoutExtension(fileName);
                    lstItem.Tag = fileName;
                    listaDeReproduccion.Items.Add(lstItem);
                }
            }
            if (currentTrack == null)//es el primer drag and drop.
            {
                listaDeReproduccion.SelectedIndex = 0;
                PlayTrack();
            }
        }

        private void MEmusicPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (MEmusicPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = MEmusicPlayer.NaturalDuration.TimeSpan;
                SliderTimeLine.Maximum = ts.TotalSeconds;
                SliderTimeLine.SmallChange = 1;
            }

            timer.Start();
        }

        private void MEmusicPlayer_MediaEnded(object sender, RoutedEventArgs e) // Se dispara cuando se termina de reproducir una canción pero no cuando se hace click en Stop
        {
            SliderTimeLine.Value = 0;
            MoveToNextTrack();
        }

        private void MoveToNextTrack()
        {
            if (listaDeReproduccion.Items.IndexOf(currentTrack) < listaDeReproduccion.Items.Count - 1)
            {
                listaDeReproduccion.SelectedIndex = listaDeReproduccion.Items.IndexOf(currentTrack) + 1;
                PlayTrack();
                return;
            }
            else if (listaDeReproduccion.Items.IndexOf(currentTrack) == listaDeReproduccion.Items.Count - 1)
            {
                listaDeReproduccion.SelectedIndex = 0;
                PlayTrack();
                return;
            }

        }

        private void MoveToPrecedentTrack()
        {
            if (listaDeReproduccion.Items.IndexOf(currentTrack) > 0)
            {
                listaDeReproduccion.SelectedIndex = listaDeReproduccion.Items.IndexOf(currentTrack) - 1;
                PlayTrack();
            }
            else if (listaDeReproduccion.Items.IndexOf(currentTrack) == 0)
            {
                listaDeReproduccion.SelectedIndex = listaDeReproduccion.Items.Count - 1;
                PlayTrack();
            }

        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (listaDeReproduccion.HasItems)
            {
                MEmusicPlayer.Pause();
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (listaDeReproduccion.HasItems)
            {
                PlayTrack();
            }
        }

        private void PlayTrack()// Se puede hacer un "tipo" de PerformClick en el botón Play pero lo dejaré así por que es más sencillo.
        {
            if (listaDeReproduccion.SelectedItem != currentTrack)
            {
                if (currentTrack != null)
                {
                    PreviousTrack = currentTrack;
                    PreviousTrack.Foreground = TrackColor;
                }
                currentTrack = (ListBoxItem)listaDeReproduccion.SelectedItem;
                currentTrack.Foreground = currentTrackIndicator;
                MEmusicPlayer.Source = new Uri(currentTrack.Tag.ToString());
                SliderTimeLine.Value = 0; // esto es por un problema de retraso, el slider no vuelve completamente al principio inmediatamente aun no doy por qué.
                MEmusicPlayer.Play();
            }
            else
            {
                MEmusicPlayer.Play();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (listaDeReproduccion.HasItems)
            {
                MEmusicPlayer.Stop();
                SliderTimeLine.Value = 0; // esto es por un problema de retraso, el slider no vuelve completamente al principio inmediatamente aun no doy por qué.
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // this.DragMove();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        private void SliderTimeLine_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // isDragging = false;
            //MEmusicPlayer.Position =
            //    TimeSpan.FromSeconds(SliderTimeLine.Value);// La posición del MediaElement se actualiza para que coincida con el progreso del sliderTimeLine.

            //int sliderValue = (int)SliderTimeLine.Value;
            //TimeSpan ts = new TimeSpan(0, 0, 0, 0, sliderValue);
            //MEmusicPlayer.Position = ts;
        }

        private void SliderTimeLine_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isDragging = true;
        }

        private void SliderTimeLine_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging = false;
            MEmusicPlayer.Position =
                TimeSpan.FromSeconds(SliderTimeLine.Value);// La posición del MediaElement se actualiza para que coincida con el progreso del sliderTimeLine.
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (listaDeReproduccion.HasItems)
            {
                MoveToNextTrack();
            }
        }

        private void btnPrecedent_Click(object sender, RoutedEventArgs e)
        {
            if (listaDeReproduccion.HasItems)
            {
                MoveToPrecedentTrack();
            }
        }

        private void SliderTimeLine_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MEmusicPlayer.Position =
                TimeSpan.FromSeconds(SliderTimeLine.Value);
        }

    }
}