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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class SprigatitoJMBL : UserControl, iPokemon
    {
        public SprigatitoJMBL()
        {
            this.InitializeComponent();
        }
        DispatcherTimer dtTime_health;
        DispatcherTimer dtTime_energy;

        public double Vida
        {
            get { return this.pb_health.Value; }
            set { this.pb_health.Value = value; }
        }

        public double Energia
        {
            get { return this.pb_energy.Value; }
            set { this.pb_energy.Value = value; }
        }

        private bool verEnergia = true;
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[1].Height = new GridLength(10,
                GridUnitType.Star);
            }
        }

        
        public string Nombre
        {
            get { return this.tx_pok_name.Text; }
            set { this.tx_pok_name.Text = value; }
        }
        public string Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Altura { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Peso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Evolucion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime_health = new DispatcherTimer();
            dtTime_health.Interval = TimeSpan.FromMilliseconds(20);
            dtTime_health.Tick += increaseHealth;
            
        }
        private void increaseHealth(object sender, object e)
        {
            this.pb_health.Value += 0.5;
            if (pb_health.Value >= 100)
            {
                this.dtTime_health.Stop();
            }
        }

        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime_energy = new DispatcherTimer();
            dtTime_energy.Interval = TimeSpan.FromMilliseconds(20);
            dtTime_energy.Tick += increaseEnergy;
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pb_energy.Value += 0.5;
            if (pb_energy.Value >= 100)
            {
                this.dtTime_energy.Stop();
            }
        }

        private void reset_animaciones()
        {
            // Restablecer visibilidad de elementos
            enfado_bajo_izq_linea.Visibility = Visibility.Collapsed;
            enfado_bajo_der_linea.Visibility = Visibility.Collapsed;
            enfado_bajo_der.Visibility = Visibility.Collapsed;
            enfado_bajo_iz.Visibility = Visibility.Collapsed;
            img_escudo.Visibility = Visibility.Collapsed;
            herida_arañazo.Visibility = Visibility.Collapsed;
            //ojos_muerte.Visibility = Visibility.Collapsed;
            gotas1.Visibility = Visibility.Collapsed;
            gotas2.Visibility = Visibility.Collapsed;
            lagrimas.Visibility = Visibility.Collapsed;
            //marca_golpe.Visibility = Visibility.Collapsed;
            escudo_haz.Opacity = 0;

            // Restablecer opacidad
            img_energyheart_1.Opacity = 0;
            img_energyheart_2.Opacity = 0;
            img_energyheart_3.Opacity = 0;
            img_energyheart_4.Opacity = 0;
            img_energyheart_5.Opacity = 0;
            lagrimas.Opacity = 0;
            marca_golpe.Opacity = 0;
            ojos_muerte.Opacity = 0;
            aro_ataque_luz.Opacity = 0;

            // Restablecer elementos de ojos
            ellipse.Visibility = Visibility.Visible;
            ellipse2.Visibility = Visibility.Visible;
            color_ojo_der.Visibility = Visibility.Visible;
            color_ojo_izq.Visibility = Visibility.Visible;
            ojoder1.Visibility = Visibility.Visible;
            ojoiz_1.Visibility = Visibility.Visible;
            path2.Visibility = Visibility.Visible;
            path15.Visibility = Visibility.Visible;
            path16.Visibility = Visibility.Visible;
            sombraojo_iz.Visibility = Visibility.Visible;

            // Restablecer nariz
            nariz.Visibility = Visibility.Visible;

            // Restablecer transformaciones (ejemplo para algunos elementos clave)
            var transform = new CompositeTransform();

            // Restablecer transformaciones de path5 (boca)
            path5.RenderTransform = new CompositeTransform()
            {
                ScaleX = 1,
                ScaleY = 1,
                TranslateX = 0,
                TranslateY = 0,
                SkewX = 0
            };

            // Restablecer transformaciones de path8 (mejilla)
            path8.RenderTransform = new CompositeTransform()
            {
                ScaleX = 1,
                ScaleY = 1,
                TranslateX = 0,
                TranslateY = 0,
                Rotation = 0
            };

            // Restablecer colores originales
            cara_1.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD3, 0xE7, 0xBA));
            cara_2.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD3, 0xE7, 0xBA));
            path3.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD3, 0xE7, 0xBB));
            path9.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD3, 0xE7, 0xBB));
            oreja_iz_3.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD3, 0xE7, 0xBA));
            oreja_der_2.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD3, 0xE7, 0xBA));
            sombra_nariz.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0x53, 0xA1, 0x35));
            path11.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0x6F, 0xAF, 0x35));
            path11.Stroke = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xBE, 0xDA, 0xA5));
            path5.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xD0, 0x8D, 0xA4));
            color_ojo_der.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xC1, 0x69, 0x77));
            color_ojo_izq.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0xC1, 0x69, 0x77));
            path15.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0x26, 0x25, 0x25));
            path2.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 0x26, 0x25, 0x24));

            // Detener todas las animaciones
            enfado_bajo.Stop();
            animacion_escudo.Stop();
            recuperacion.Stop();
            herido.Stop();
            muerte.Stop();
            cansado.Stop();
            ataquefuerte.Stop();
        }


        public void verFondo(bool ver)
        {
            landscape.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            pb_health.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            pb_energy.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            im_health_potion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            im_energy_potion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            tx_pok_name.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                img_escudo.Visibility = Visibility.Visible;
                escudo_haz.Visibility = Visibility.Visible;
                escudo_haz.Opacity = 0.07;
            }
            else
            {
                img_escudo.Visibility = Visibility.Collapsed;
                escudo_haz.Opacity = 0;
            }
        }

        public void activarAniIdle(bool activar)
        {
            if (activar)
            {
                Storyboard sb_moverorejas = (Storyboard)this.Resources["mover_orejas"];
                sb_moverorejas.Begin();

                Storyboard sb_respirar = (Storyboard)this.Resources["respiracion"];
                sb_respirar.Begin();
            }
            else
            {
                mover_orejas.Stop();
                respiracion.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            reset_animaciones();
            Storyboard sb_enfado_bajo = (Storyboard)this.Resources["enfado_bajo"];
            enfado_bajo.Begin();
        }

        public void animacionAtaqueFuerte()
        {
            reset_animaciones();
            Storyboard sb_fuerte = (Storyboard)this.Resources["ataquefuerte"];
            sb_fuerte.AutoReverse = true;
            sb_fuerte.Begin();
        }

        public void animacionDefensa()
        {
            reset_animaciones();
            img_escudo.Visibility = Visibility.Visible;
            Storyboard sb_escudo = (Storyboard)this.Resources["animacion_escudo"];
            sb_escudo.Begin();
        }

        public void animacionDescasar()
        {
            reset_animaciones();
            Storyboard sb_escudo = (Storyboard)this.Resources["recuperacion"];
            sb_escudo.Begin();
        }

        public void animacionCansado()
        {
            reset_animaciones();
            Storyboard sb_cansado = (Storyboard)this.Resources["cansado"];
            sb_cansado.Begin();
        }

        public void animacionNoCansado()
        {
            reset_animaciones();
            cansado.Stop();
        }

        public void animacionHerido()
        {
            reset_animaciones();
            Storyboard sb_herido = (Storyboard)this.Resources["herido"];
            sb_herido.Begin();
        }

        public void animacionNoHerido()
        {
            reset_animaciones();
            herido.Stop();
        }

        public void animacionDerrota()
        {
            reset_animaciones();
            Storyboard sb_muerto = (Storyboard)this.Resources["muerte"];
            sb_muerto.Begin();
        }
    }

}