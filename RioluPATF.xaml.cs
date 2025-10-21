using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace IPOkemonApp
{
    public sealed partial class RioluPATF : UserControl, iPokemon
    {
        public event EventHandler<double> VidaActualizada;
        public event EventHandler<double> EnergiaActualizada;

        private DispatcherTimer dtTime;
        private DispatcherTimer dtTime2;
        public RioluPATF()
        {
            this.InitializeComponent();
            EnergyBar.Value = Energia;
            HealthBar.Value = Vida;
            verPocionEnergia(false);
            verPocionVida(false);
            verFondo(false);
            verNombre(false);
            verFilaEnergia(false);
            verFilaVida(false);
        }
        private double vida = 100;
        public double Vida
        {
            get => vida;
            set
            {
                vida = value;
                HealthBar.Value = vida; // Sincroniza el valor de HealthBar con Vida
            }
        }
        private double energia = 100;
        public double Energia
        { 
            get => energia;
            set
            {
                energia = value;
                EnergyBar.Value = energia; // Sincroniza el valor de EnergyBar con Energia
            }
        }
        private string nombre = "Riolu";
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        private string categoria = "Emanación";
        public string Categoría 
        {
            get => categoria;
            set => categoria = value; 
        }
        private string tipo = "Lucha";
        public string Tipo 
        { 
            get => tipo; 
            set => tipo = value; 
        }
        private double altura = 0.7;
        public double Altura 
        {
            get => altura; 
            set => altura = value;
        }
        private double peso = 20.2;
        public double Peso 
        { 
            get => peso; 
            set => peso = value;
        }
        private string evolucion = "Lucario";
        public string Evolucion 
        { 
            get => evolucion; 
            set => evolucion = value;
        }
        private string descripcion = "Riolu es un Pokémon de tipo lucha introducido en la cuarta generación. Es la forma bebé de Lucario. Es un Pokémon muy amistoso, leal y valiente, y no duda en enfrentarse a Pokémon más grandes que él.";
        public string Descripcion {
            get => descripcion;
            set => descripcion = value;
        }

        private void imgEnergyPot_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dtTime2 = new DispatcherTimer();
            dtTime2.Interval = TimeSpan.FromMilliseconds(100);
            dtTime2.Tick += IncreaseEnergy;
            dtTime2.Start();
            this.imgEnergyPot.Visibility = Visibility.Collapsed;

        }

        private void UsePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseHealth;
            dtTime.Start();
            this.imgHealthPot.Visibility = Visibility.Collapsed;

        }

        private void IncreaseHealth(object sender, object e)
        {
            this.HealthBar.Value += 0.5;
            VidaActualizada?.Invoke(this, this.HealthBar.Value);
            if (HealthBar.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }
        private void IncreaseEnergy(object sender, object e)
        {
            this.EnergyBar.Value += 0.5;
            EnergiaActualizada?.Invoke(this, this.EnergyBar.Value);
            if (EnergyBar.Value >= 100)
            {
                this.dtTime2.Stop();
            }
        }


        public void activarAniIdle(bool activar)
        {
            if (activar)
            {
                   Storyboard sb = (Storyboard)this.Resources["Idle"];
                sb.RepeatBehavior = RepeatBehavior.Forever;
                sb.Begin();
            }
            else
            {
                Storyboard sb = (Storyboard)this.Resources["Idle"];
                sb.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard sb = (Storyboard)this.Resources["Ataque_oseo"];
            sb.Begin();

            Task.Delay(100).ContinueWith(async _ =>
            {
                var mediaElement = new MediaElement();
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("AssetsRioluPATF");
                var file = await folder.GetFileAsync("boomerang.mp3");
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    mediaElement.SetSource(stream, file.ContentType);
                    mediaElement.Play();
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void animacionAtaqueFuerte()
        {
            Storyboard sb = (Storyboard)this.Resources["Ataque_fuerte"];
            sb.Begin();

            Task.Delay(800).ContinueWith(async _ =>
            {
                var mediaElement = new MediaElement();
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("AssetsRioluPATF");
                var file = await folder.GetFileAsync("espada-som.mp3");
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    mediaElement.SetSource(stream, file.ContentType);
                    mediaElement.Play();
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void animacionCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["Cansado"];
            sb.Begin();
        }

        public void animacionDefensa()
        {
            Storyboard sb = (Storyboard)this.Resources["Accion_Defensiva"];
            sb.Begin();

            Task.Delay(500).ContinueWith(async _ =>
            {
                var mediaElement = new MediaElement();
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("AssetsRioluPATF");
                var file = await folder.GetFileAsync("Wind1.mp3");
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                mediaElement.SetSource(stream, file.ContentType);
                mediaElement.Play();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void animacionDerrota()
        {
            Storyboard sb = (Storyboard)this.Resources["Derrotado"];
            sb.Begin();

            mediaDerrota.Source = new Uri("ms-appx:///AssetsRioluPATF/447Cry.ogg");
            mediaDerrota.Play();
        }

        public void animacionDescasar()
        {
            Storyboard sb = (Storyboard)this.Resources["Descanso"];
            sb.Begin();

            Task.Delay(150).ContinueWith(async _ =>
            {
                var mediaElement = new MediaElement();
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("AssetsRioluPATF");
                var file = await folder.GetFileAsync("healing-pokemon-sound.mp3");
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    mediaElement.SetSource(stream, file.ContentType);
                    mediaElement.Play();
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void animacionHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["Herido"];
            sb.Begin();
        }

        public void animacionNoCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["No_Cansado"];
            sb.Begin();
        }

        public void animacionNoHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["No_Herido"];
            sb.Begin();
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                Storyboard sb = (Storyboard)this.Resources["Mostrar_Escudo"];
                sb.Begin();
            }
            else
            {
                Storyboard sb = (Storyboard)this.Resources["Quitar_Escudo"];
                sb.Begin();
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if(ver)
            {
                EnergyBar.Visibility = Visibility.Visible;
                imgEnergy.Visibility = Visibility.Visible;
            }
            else
            {
                EnergyBar.Visibility = Visibility.Collapsed;
                imgEnergy.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaVida(bool ver)
        {
            if(ver)
            {
                HealthBar.Visibility = Visibility.Visible;
                imgHealth.Visibility = Visibility.Visible;
            }
            else
            {
                HealthBar.Visibility = Visibility.Collapsed;
                imgHealth.Visibility = Visibility.Collapsed;
            }
        }

        public void verFondo(bool ver)
        {
            if(ver)
            {
                GridRiolu.Background.Opacity = 1;
            }
            else
            {
                GridRiolu.Background.Opacity = 0;
            }
        }

        public void verNombre(bool ver)
        {
            if (ver)
            {
                TxtBoxNombre.Visibility = Visibility.Visible;
            }
            else
            {
                TxtBoxNombre.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver)
            {
                imgEnergyPot.Visibility = Visibility.Visible;
            }
            else
            {
                imgEnergyPot.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionVida(bool ver)
        {
            if (ver)
            {
                imgHealthPot.Visibility = Visibility.Visible;
            }
            else
            {
                imgHealthPot.Visibility = Visibility.Collapsed;
            }
        }

    }
}
