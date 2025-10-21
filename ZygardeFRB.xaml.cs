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
using Windows.System;
using Windows.UI.Core;
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
    public sealed partial class ZygardeFRB : UserControl, iPokemon
    {
        DispatcherTimer dtTimeRed;
        DispatcherTimer dtTimeYellow;
        MediaPlayer mpSonidos = new MediaPlayer();

        public double Vida
        {
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }
        private bool verVida = true;
        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida)
                    this.gridGeneral.RowDefinitions[0].Height = new GridLength(0);
                else
                    this.gridGeneral.RowDefinitions[0].Height = new GridLength(50, GridUnitType.Pixel);
            }
        }
        public double Energia
        {
            get { return this.pbEnergia.Value; }
            set { this.pbEnergia.Value = value; }
        }
        private bool verEnergia = true;
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia)
                    this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
                else
                    this.gridGeneral.RowDefinitions[1].Height = new GridLength(50, GridUnitType.Pixel);
            }
        }
        public string Nombre { get; set; } = "Zygarde (Forma Completa)";
        public string Categoría { get; set; } = "Equilibrio";
        public string Tipo { get; set; } = "Dragón / Tierra";
        public double Altura { get; set; } = 4.5;
        public double Peso { get; set; } = 610.0;
        public string Evolucion { get; set; } = "No evoluciona";
        public string Descripcion { get; set; } = "Cuando el ecosistema de Kalos se encuentra en peligro, aparece y revela su poder secreto. Nace cuando todas las células de Zygarde se han reunido, utilizando su fuerza para neutralizar a aquellos que dañan el ecosistema. Tiene suficiente poder para imponerse incluso a Xerneas o Yveltal.";

        public ZygardeFRB()
        {
            this.InitializeComponent();
        }

        public void verFondo(bool ver)
        {
            Visibility estado = ver ? Visibility.Visible : Visibility.Collapsed;

            Fondo.Visibility = estado;
        }

        public void verFilaVida(bool ver)
        {
            VerVida = ver;
        }

        public void verFilaEnergia(bool ver)
        {
            VerEnergia = ver;
        }

        public void verPocionVida(bool ver)
        {
            Visibility estado = ver ? Visibility.Visible : Visibility.Collapsed;

            imgPocVida.Visibility = estado;
        }

        public void verPocionEnergia(bool ver)
        {
            Visibility estado = ver ? Visibility.Visible : Visibility.Collapsed;

            imgPocEnergia.Visibility = estado;
        }

        public void verNombre(bool ver)
        {
            Visibility estado = ver ? Visibility.Visible : Visibility.Collapsed;

            txtPokemon.Visibility = estado;
        }

        public void verEscudo(bool ver)
        {
            Visibility estado = ver ? Visibility.Visible : Visibility.Collapsed;

            CEscudo.Visibility = estado;

            HexagonoCentro.Visibility = estado;
            Hexagono1.Visibility = estado;
            Hexagono11.Visibility = estado;
            Hexagono12.Visibility = estado;
            Hexagono13.Visibility = estado;
            Hexagono14.Visibility = estado;
            Hexagono15.Visibility = estado;
            HexagonoFuera.Visibility = estado;
            HexagonoFuera1.Visibility = estado;
            HexagonoFuera2.Visibility = estado;
            HexagonoFuera3.Visibility = estado;
            HexagonoFuera4.Visibility = estado;
            HexagonoFuera5.Visibility = estado;
            HexagonoFuera6.Visibility = estado;
            HexagonoFuera7.Visibility = estado;
            HexagonoFuera8.Visibility = estado;
            HexagonoFuera9.Visibility = estado;
            HexagonoFuera10.Visibility = estado;
            HexagonoFuera11.Visibility = estado;
        }

        private bool IdleEnEjecucion = false;
        private bool hexIdleEnEjecucion = false;
        public void activarAniIdle(bool activar)
        {
            if (activar)
            {
                AnimHexIdle.Begin();
                AnimIdle.Begin();
                IdleEnEjecucion = true;
                hexIdleEnEjecucion = true;
            }
            else
            {
                AnimHexIdle.Stop();
                AnimIdle.Stop();
                IdleEnEjecucion = false;
                hexIdleEnEjecucion = false;
            }
        }

        public void animacionAtaqueFlojo()
        {
            AnimAtDebil.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/thousandArrows.mp3"));
            mpSonidos.PlaybackSession.PlaybackRate = 2.6;
            mpSonidos.Play();
        }

        public void animacionAtaqueFuerte()
        {
            AnimAtFuerte.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/coreEnforcer.mp3"));
            mpSonidos.PlaybackSession.PlaybackRate = 2.5;
            mpSonidos.Play();
            EventHandler<object> handler = null;
            handler = (s, e) =>
            {
                if (IdleEnEjecucion)
                {
                    AnimIdle.Stop();
                    AnimIdle.Begin();
                }
                AnimAtFuerte.Completed -= handler;
            };
            AnimAtFuerte.Completed += handler;
        }

        public void animacionDefensa()
        {
            CEscudo.Visibility = Visibility.Visible;
            AnimEscudo.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/escudo.mp3"));
            mpSonidos.Play();
        }

        public async void animacionDescasar()
        {
            AnimCuracion.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/restaurar.mp3"));
            mpSonidos.Play();
            await Task.Delay(TimeSpan.FromSeconds(2));
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/cura.mp3"));
            mpSonidos.Play();
        }

        public void animacionCansado()
        {
            AnimCansado.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/zygarde.wav"));
            mpSonidos.PlaybackSession.PlaybackRate = 0.7;
            mpSonidos.Play();
        }

        public void animacionNoCansado()
        {
            AnimCansado.Stop();
        }

        public void animacionHerido()
        {
            AnimHerido.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/herido.mp3"));
            mpSonidos.Play();
        }

        public void animacionNoHerido()
        {
            AnimHerido.Stop();
            if (hexIdleEnEjecucion)
            {
                AnimHexIdle.Stop();
                AnimHexIdle.Begin();
            }
        }

        public async void animacionDerrota()
        {
            AnimDerrotado.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/zygardeComplete.wav"));
            mpSonidos.PlaybackSession.PlaybackRate = 1.5;
            mpSonidos.Play();
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/explosion.mp3"));
            mpSonidos.Play();
            await Task.Delay(TimeSpan.FromSeconds(2.5));
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsZygardeFRB/muelto.mp3"));
            mpSonidos.Play();
        }

    }
}
