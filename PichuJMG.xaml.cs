using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class PichuJMG : UserControl, iPokemon
    {
        DispatcherTimer dtTimeVida;
        DispatcherTimer dtTimeEergia;

        public double Vida {
            get { return this.BarraVida.Value; }
            set { this.BarraVida.Value = value;} 
        }

        public double Energia {
            get { return this.BarraEnergia.Value; }
            set { this.BarraEnergia.Value = value; }
        }

        private bool verEnergia = true;
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[1].Height = new GridLength(50, GridUnitType.Pixel);
            }
        }

        public string Nombre { get => "Pichu"; set => throw new NotImplementedException(); }
        public string Categoría { get => "Ratoncito"; set => throw new NotImplementedException(); }
        public string Tipo { get => "Electrico"; set => throw new NotImplementedException(); }
        public double Altura { get => 0.3; set => throw new NotImplementedException(); }
        public double Peso { get => 2.0; set => throw new NotImplementedException(); }
        public string Evolucion { get => "Pichu -> Pikachu -> Raichu"; set => throw new NotImplementedException(); }
        public string Descripcion { get => "Pichu descarga energía cuando se emociona. Como aún no puede controlarla bien, puede llegar a electrocutarse a sí mismo."; set => throw new NotImplementedException(); }



        public PichuJMG()
        {
            this.InitializeComponent();
            this.IsTabStop = true;
        }
        private async void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    Storyboard sb = (Storyboard)this.Resources["StMovimiento"];
                    sb.Begin();
                    break;
                case Windows.System.VirtualKey.Number2:
                    Storyboard sb1 = (Storyboard)this.MofleteIzq.Resources["MofleteIzqColorKey"];
                    sb1.Begin();
                    Storyboard sb2 = (Storyboard)this.MofleteDrc.Resources["MofleteDrcColorKey"];
                    sb2.Begin();
                    Storyboard sb3 = (Storyboard)this.Resources["StRayosMofletes"];
                    sb3.Begin();
                    Storyboard sb4 = (Storyboard)this.Resources["StCaraEnfado"];
                    sb4.Begin();
                    Storyboard sb5 = (Storyboard)this.Cola.Resources["ColaColorKey"];
                    sb5.Begin();
                    Storyboard sb6 = (Storyboard)this.Resources["StColaFerrea"];
                    sb6.Begin();
                    MediaPlayer mpSonidos = new MediaPlayer();
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Cortocircuito.mp3"));
                    mpSonidos.Play();
                    break;
                case Windows.System.VirtualKey.Number3:
                    Storyboard sb7 = (Storyboard)this.Resources["StCargando"];
                    sb7.Begin();
                    MediaPlayer mpSonidos2 = new MediaPlayer();
                    mpSonidos2.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Cargar.mp3"));
                    mpSonidos2.Play();
                    break;
                case Windows.System.VirtualKey.Number4:
                    Storyboard sb8 = (Storyboard)this.Resources["StEscudo"];
                    sb8.Begin();
                    MediaPlayer mpSonidos3 = new MediaPlayer();
                    await Task.Delay(1000);
                    mpSonidos3.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Escudo.mp3"));
                    mpSonidos3.Play();
                    break;
                case Windows.System.VirtualKey.Number5:
                    Storyboard sb9 = (Storyboard)this.Resources["StDescanso"];
                    sb9.Begin();
                    MediaPlayer mpSonidos4 = new MediaPlayer();
                    mpSonidos4.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Descanso.mp3"));
                    mpSonidos4.Play();
                    break;
                case Windows.System.VirtualKey.Number6:
                    Storyboard sb10 = (Storyboard)this.Resources["StHerido"];
                    sb10.Begin();
                    break;
                case Windows.System.VirtualKey.Number7:
                    Storyboard sb11 = (Storyboard)this.Resources["StCansado"];
                    sb11.Begin();
                    break;
                case Windows.System.VirtualKey.Number8:
                    Storyboard sb12 = (Storyboard)this.Resources["StDerrotado"];
                    sb12.Begin();
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
                Escudo.Opacity = 100;
            } 
            else
            {
                Escudo.Opacity = 0;
            }

        }

        public void activarAniIdle(bool activar)
        {
            if (activar){
                StMovimiento.Begin();
            }
            else
            {
                StMovimiento.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard sb1 = (Storyboard)this.MofleteIzq.Resources["MofleteIzqColorKey"];
            sb1.Begin();
            Storyboard sb2 = (Storyboard)this.MofleteDrc.Resources["MofleteDrcColorKey"];
            sb2.Begin();
            StRayosMofletes.Begin();
            StCaraEnfado.Begin();
            Storyboard sb5 = (Storyboard)this.Cola.Resources["ColaColorKey"];
            sb5.Begin();
            StColaFerrea.Begin();
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Cortocircuito.mp3"));
            mpSonidos.Play();
        }

        public void animacionAtaqueFuerte()
        {
            StCargando.Begin();
            MediaPlayer mpSonidos2 = new MediaPlayer();
            mpSonidos2.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Cargar.mp3"));
            mpSonidos2.Play();
        }

        public async void animacionDefensa()
        {
            StEscudo.Begin();
            MediaPlayer mpSonidos3 = new MediaPlayer();
            await Task.Delay(1000);
            mpSonidos3.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Escudo.mp3"));
            mpSonidos3.Play();
        }

        public void animacionDescasar()
        {
            StDescanso.Begin();
            MediaPlayer mpSonidos4 = new MediaPlayer();
            mpSonidos4.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPichuJMG/Descanso.mp3"));
            mpSonidos4.Play();
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
