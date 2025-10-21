using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class MimikyuCBM : UserControl, iPokemon
    {
        DispatcherTimer dtTimeVida;
        DispatcherTimer dtTimeEergia;

        public double Vida
        {
            get { return this.BarraVida.Value; }
            set { this.BarraVida.Value = value; }
        }

        public double energia
        {
            get { return this.BarraEnergia.Value; }
            set { this.BarraEnergia.Value = value; }
        }

        double iPokemon.Vida
        {
            get { return this.Vida; }
            set { this.Vida = value; }
        }

        double iPokemon.Energia
        {
            get { return this.energia; }
            set { this.energia = value; }
        }

        string iPokemon.Nombre
        {
            get { return "Mimikyu"; }
            set {  }
        }

        string iPokemon.Categoría
        {
            get { return "Disfraz"; }
            set { }
        }

        string iPokemon.Tipo
        {
            get { return "Fantasma/Hada"; }
            set { }
        }

        double iPokemon.Altura
        {
            get { return 0.2; } 
            set { }
        }

        double iPokemon.Peso
        {
            get { return 0.7; } 
            set { }
        }

        string iPokemon.Evolucion
        {
            get { return "No evoluciona"; }
            set { }
        }

        string iPokemon.Descripcion
        {
            get { return "Mimikyu se disfraza de Pikachu para hacerse querer. Si alguien ve su verdadero cuerpo, podría sufrir una terrible maldición."; }
            set { }
        }

        public MimikyuCBM()
        {
            this.InitializeComponent();
            this.IsTabStop = true;
        }

        private void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    Storyboard sb = (Storyboard)this.Resources["StMovimiento"];
                    sb.Begin();
                    break;
                case Windows.System.VirtualKey.Number2:
                    Storyboard sb1 = (Storyboard)this.Resources["StGarra"];
                    sb1.Begin();
                    MediaPlayer mpSonidosGarra = new MediaPlayer();
                    mpSonidosGarra.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/garra.mp3"));
                    mpSonidosGarra.Play();
                    break;
                case Windows.System.VirtualKey.Number3:
                    Storyboard sb2 = (Storyboard)this.Resources["StBola"];
                    sb2.Begin();
                    MediaPlayer mpSonidosBola = new MediaPlayer();
                    mpSonidosBola.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/bola.mp3"));
                    mpSonidosBola.Play();
                    break;
                case Windows.System.VirtualKey.Number4:
                    Storyboard sb3 = (Storyboard)this.Resources["StDefensa"];
                    sb3.Begin();
                    MediaPlayer mpSonidosDefensa = new MediaPlayer();
                    mpSonidosDefensa.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/escudo.mp3"));
                    mpSonidosDefensa.Play();
                    break;
                case Windows.System.VirtualKey.Number5:
                    Storyboard sb4 = (Storyboard)this.Resources["StRecuperacion"];
                    sb4.Begin();
                    MediaPlayer mpSonidosRecuperacion = new MediaPlayer();
                    mpSonidosRecuperacion.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/recuperacion.mp3"));
                    mpSonidosRecuperacion.Play();
                    break;
                case Windows.System.VirtualKey.Number6:
                    Storyboard sb5 = (Storyboard)this.Resources["StHerido"];
                    sb5.Begin();
                    break;
                case Windows.System.VirtualKey.Number7:
                    Storyboard sb6 = (Storyboard)this.Resources["StCansado"];
                    sb6.Begin();
                    break;
                case Windows.System.VirtualKey.Number8:
                    Storyboard sb7 = (Storyboard)this.Resources["StDerrotado"];
                    sb7.Begin();
                    break;
            }
        }

        private void usarPocimaVida(object sender, PointerRoutedEventArgs e)
        {
            dtTimeVida = new DispatcherTimer();
            dtTimeVida.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeVida.Tick += incrementarVida;
            dtTimeVida.Start();
            this.ImagenPocionRoja.Visibility = Visibility.Collapsed;
        }

        private void incrementarVida(object sender, object e)
        {
            if (BarraVida.Value < 100)
            {
                BarraVida.Value++;
            }
            else
            {
                this.dtTimeVida.Stop();
            }
        }

        private void usarPocionEnergia(object sender, PointerRoutedEventArgs e)
        {
            dtTimeEergia = new DispatcherTimer();
            dtTimeEergia.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeEergia.Tick += incrementarEnergia;
            dtTimeEergia.Start();
            this.ImagenPocionAmarilla.Visibility = Visibility.Collapsed;
        }

        private void incrementarEnergia(object sender, object e)
        {
            if (BarraEnergia.Value < 100)
            {
                BarraEnergia.Value++;
            }
            else
            {
                this.dtTimeEergia.Stop();
            }
        }

        public void verFondo(bool ver)
        {
            if (ver)
            {
                FondoPantalla.Opacity = 100;
            }
            else
            {
                FondoPantalla.Opacity = 0;
            }
        }

        public void verFilaVida(bool ver)
        {
            if (ver)
            {
                BarraVida.Opacity = 100;
                ImagenCorazon.Opacity = 100;
            }
            else
            {
                BarraVida.Opacity = 0;
                ImagenCorazon.Opacity = 0;
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if (ver)
            {
                BarraEnergia.Opacity = 100;
                ImagenEnergia.Opacity = 100;
            }
            else
            {
                BarraEnergia.Opacity = 0;
                ImagenEnergia.Opacity = 0;
            }
        }

        public void verPocionVida(bool ver)
        {
            if (ver)
            {
                ImagenPocionRoja.Opacity = 100;
            }
            else
            {
                ImagenPocionRoja.Opacity = 0;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver)
            {
                ImagenPocionAmarilla.Opacity = 100;
            }
            else
            {
                ImagenPocionAmarilla.Opacity = 0;
            }
        }

        public void verNombre(bool ver)
        {
            if (ver)
            {
                NombrePokemon.Opacity = 100;
            }
            else
            {
                NombrePokemon.Opacity = 0;
            }
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                SombraCabeza.Opacity = 100;
                SombraCola.Opacity = 100;
                SombraCuerpo.Opacity = 100;
                SombraOrejaDrc.Opacity = 100;
                SombraOrejaIzq.Opacity = 100;
            }
            else
            {
                SombraCabeza.Opacity = 0;
                SombraCola.Opacity = 0;
                SombraCuerpo.Opacity = 0;
                SombraOrejaDrc.Opacity = 0;
                SombraOrejaIzq.Opacity = 0;
            }
        }

        public void activarAniIdle(bool activar)
        {
            StMovimiento.Begin();
        }

        public void animacionAtaqueFlojo()
        {
            StGarra.Begin();
            MediaPlayer mpSonidosGarra = new MediaPlayer();
            mpSonidosGarra.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/garra.mp3"));
            mpSonidosGarra.Play();
        }

        public void animacionAtaqueFuerte()
        {
            StBola.Begin();
            MediaPlayer mpSonidosBola = new MediaPlayer();
            mpSonidosBola.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/bola.mp3"));
            mpSonidosBola.Play();
        }

        public void animacionDefensa()
        {
            StDefensa.Begin();
            MediaPlayer mpSonidosDefensa = new MediaPlayer();
            mpSonidosDefensa.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/escudo.mp3"));
            mpSonidosDefensa.Play();
        }

        public void animacionDescasar()
        {
            StRecuperacion.Begin();
            MediaPlayer mpSonidosRecuperacion = new MediaPlayer();
            mpSonidosRecuperacion.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsMimikyuCBM/recuperacion.mp3"));
            mpSonidosRecuperacion.Play();
        }

        public void animacionCansado()
        {
            StCansado.Begin();
        }

        public void animacionNoCansado()
        {
            StCansado.Stop();
        }

        public void animacionHerido()
        {
            StHerido.Begin();
        }

        public void animacionNoHerido()
        {
            StHerido.Stop();
        }

        public void animacionDerrota()
        {
            StDerrotado.Begin();
        }
    }
}
