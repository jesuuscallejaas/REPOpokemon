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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class GardevoirAPM : UserControl, iPokemon
    {
        public GardevoirAPM()
        {
            this.InitializeComponent();
        }

        public double Vida
        {
            get => BarraVida.Value; 
            set => BarraVida.Value = value;
        }
        public double Energia
        {
            get => BarraEnergia.Value;
            set => BarraEnergia.Value = value;
        }
        public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Altura { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Peso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Evolucion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void activarAniIdle(bool activar)
        {
            if (activar == true)
            {
                Estática.Begin();
            }
            else
            {
                Estática.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/AtaqueFuerteSOund.mp3"));
            mpSonidos.Play();
            AtaqueDebil.Begin();
        }

        public void animacionAtaqueFuerte()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/impact-sound-effect-240901.mp3"));
            mpSonidos.Play();

            AtaqueFuerte.Begin();
        }

        public void animacionCansado()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/gotaCansado.mp3"));
            mpSonidos.Play();

            Cansado.Begin();
        }

        public void animacionDefensa()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/space-attack-sound-effect-309133 (mp3cut.net).mp3"));
            mpSonidos.Play();

            Defensiva.Begin();
        }

        public void animacionDerrota()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/marimba-lose-250960.mp3"));
            mpSonidos.Play();

            Derrotado.Begin();
        }

        public void animacionNoDerrota()
        {
            Derrotado.Stop();
        }

        public void animacionDescasar()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/dreamy-bells-47721.mp3"));
            mpSonidos.Play();

            Descanso.Begin();
        }

        public void animacionHerido()
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/hurt_c_08-102842.mp3"));
            mpSonidos.Play();

            Herido.Begin();
        }

        public void animacionNoCansado()
        {
            Cansado.Stop();
        }

        public void animacionNoHerido()
        {
            Herido.Stop();
        }

        public void verEscudo(bool ver)
        {
            if (ver == true)
            {
                MediaPlayer mpSonidos = new MediaPlayer();
                mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGardevoirAPM/shield.mp3"));
                mpSonidos.Play();

                Escudo.Begin();
            }
            else
            {
                Escudo.Stop();
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if(ver == true)
            {
                BarraEnergia.Visibility = Visibility.Visible;
            }
            else
            {
                BarraEnergia.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaVida(bool ver)
        {
            if(ver == true)
            {
                BarraVida.Visibility = Visibility.Visible;
            }
            else
            {
                BarraVida.Visibility = Visibility.Collapsed;
            }
        }

        public void verFondo(bool ver)
        {
            if (ver == true)
            {
                fondo.Visibility = Visibility.Visible;
            }
            else
            {
                fondo.Visibility = Visibility.Collapsed;
            }
        }

        public void verNombre(bool ver)
        {
            if(ver == true)
            {
                Name.Visibility = Visibility.Visible;
            }
            else
            {
                Name.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver == true)
            {
                YellowPoti.Visibility = Visibility.Visible;
            }
            else
            {
                YellowPoti.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionVida(bool ver)
        {
            if (ver == true)
            {
                redPoti.Visibility = Visibility.Visible;
            }
            else
            {
                redPoti.Visibility = Visibility.Collapsed;
            }
        }
    }
}
