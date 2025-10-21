using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

    public sealed partial class SwabluSCP : UserControl, iPokemon
    {
        private double _vida = 100; // VIDA INICIAL A 100
        private double _energia = 100;
        DispatcherTimer dtTime;
        DispatcherTimer dtTime2;

        public SwabluSCP()
        {
            this.InitializeComponent();
        }

        public double Vida
        {
            get => _vida;
            set
            {
                _vida = value;
                pbHealth.Value = _vida;
            }
        }
        public double Energia
        {
            get => _energia;
            set
            {
                _energia = value;
                EnergiaProgressBar.Value = _energia;
            }
        }

        public string Nombre
        {
            get => "Swablu";
            set => PokemonNameTextBlock.Text = value;
        }

        public string Categoría
        {
            get => "Pájaro Algodón";
            set { }
        }

        public string Tipo
        {
            get => "Normal / Volador";
            set { }
        }

        public double Altura
        {
            get => 0.4;
            set { }
        }

        public double Peso
        {
            get => 1.2;
            set { }
        }

        public string Evolucion
        {
            get => "Altaria";
            set { }
        }

        public string Descripcion
        {
            get => "Tiene alas cubiertas de una suave pluma que parecen nubes. Le encanta posarse en la cabeza de la gente.";
            set { }
        }

        public void activarAniIdle(bool activar)
        {

            if (activar)
            {
                Movimiento_estático.Begin();
            }
            else
            {
                Movimiento_estático.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            esfera_ataque_debil.Visibility = Visibility.Visible;
            Ataque_Débil.Begin();
            media.Source = new Uri("ms-appx:///AssetsSwabluSCP/Débil.mp3");

            // Al terminar, ejecutar la inversa
            Ataque_Débil.Completed += (s, e) =>
            {
                Ataque_Débil_Inverso.Begin();
            };

        }

        public void animacionAtaqueFuerte()
        {
            Tornado.Visibility = Visibility.Visible;
            NUBES.Visibility = Visibility.Visible;
            media.Source = new Uri("ms-appx:///AssetsSwabluSCP/Viento.mp3");
            Ataque_fuerte.Begin();
        }

        public void animacionCansado()
        {
            Cansado.Begin();
        }

        public void animacionDefensa()
        {
            Escudo.Visibility = Visibility.Visible;
            Escudo1.Begin();
        }

        public void animacionDerrota()
        {
            ojo_cerrado_derecho.Visibility = Visibility.Visible;
            ojo_cerrado_izquierdo.Visibility = Visibility.Visible;
            media.Source = new Uri("ms-appx:///AssetsSwabluSCP/Derrotado.mp3");
            Derrotado.Begin();
        }

        public void animacionDescasar()
        {
            {
                Aro_curación.Visibility = Visibility.Visible;
                Recuperación.Begin();
                media.Source = new Uri("ms-appx:///AssetsSwabluSCP/Recuperación.mp3");
                media.Play();
            }
        }

            public void animacionHerido()
        {
            Corte.Visibility = Visibility.Visible;
            Corte1.Visibility = Visibility.Visible;
            Herido.Begin();
            ojo_der_Copiar.Visibility = Visibility.Visible;
            ojo_der_Copiar.Opacity = 1;
        }

        public void animacionNoCansado()
        {
            Cansado_Invertir.Begin();
        }

        public void animacionNoHerido()
        {
            Herido.Stop();
            Corte.Visibility = Visibility.Collapsed;
            Corte1.Visibility = Visibility.Collapsed;
            Corte.Opacity = 0;
            Corte1.Opacity = 0;
            ojo_der_Copiar.Visibility = Visibility.Collapsed;
            ojo_der_Copiar.Opacity = 0;
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                Escudo.Visibility = Visibility.Visible;
                Escudo.Opacity = 1;
                Escudo1.Begin();
                media.Source = new Uri("ms-appx:///AssetsSwabluSCP/Escudo.mp3");
            }
            else
            {
                Escudo1.Stop();
                Escudo.Opacity = 0;
                Escudo.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaEnergia(bool ver)
        {
            EnergiaProgressBar.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            pbHealth.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFondo(bool ver)
        {
            Grid_Swablu.Background.Opacity = ver ? 1 : 0;
        }

        public void verNombre(bool ver)
        {
            PokemonNameTextBlock.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            Pocion_energia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            Pocion_vida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.Pocion_vida.Visibility = Visibility.Collapsed;
        }

        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime2 = new DispatcherTimer();
            dtTime2.Interval = TimeSpan.FromMilliseconds(100);
            dtTime2.Tick += increaseEnergy;
            dtTime2.Start();
            this.Pocion_energia.Visibility = Visibility.Collapsed;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.5;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }
        private void increaseEnergy(object sender, object e)
        {
            this.EnergiaProgressBar.Value += 0.5;
            if (EnergiaProgressBar.Value >= 100)
            {
                this.dtTime2.Stop();
            }
        }
    }
}
