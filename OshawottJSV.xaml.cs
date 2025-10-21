using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    public sealed partial class OshawottJSV : UserControl, iPokemon
    {

        DispatcherTimer dtTime;
        DispatcherTimer dtTime2;
        List<Storyboard> animaciones = new List<Storyboard>();
        private bool verEnergia = true;
        private string nombre = "Oshawott";
        private string categoria = "Nutria";
        private string tipo = "Agua";
        private double altura = 0.5;
        private double peso = 5.9;
        private string evolucion = "Dewott";
        private string descripcion = "Oshawott es un Pokémon con apariencia similar a una nutria marina. " +
            "Su cuerpo es mayormente azul claro, con una cabeza redonda y blanca, " +
            "ojos grandes y negros, y una pequeña nariz ovalada. Posee orejas pequeñas " +
            "y puntiagudas de color azul oscuro. Su característica" +
            " más distintiva es una concha amarilla llamada \"Scalchop\", u" +
            "bicada en su vientre, la cual usa como arma en combate y herramienta " +
            "en la vida diaria.";


        public double Vida
        {
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }
        public double Energia { get { return this.pbEnergia.Value; } set { this.pbEnergia.Value = value; } }
        public string Nombre { get { return nombre; } set => throw new NotImplementedException(); }
        public string Categoría { get { return categoria; } set => throw new NotImplementedException(); }
        public string Tipo { get { return tipo; } set => throw new NotImplementedException(); }
        public double Altura { get { return altura; } set => throw new NotImplementedException(); }
        public double Peso { get { return peso; } set => throw new NotImplementedException(); }
        public string Evolucion { get { return evolucion; } set => throw new NotImplementedException(); }
        public string Descripcion { get { return descripcion; } set => throw new NotImplementedException(); }

        public OshawottJSV()
        {
            this.InitializeComponent();

            this.IsTabStop = true;
        }

        private void vida()
        {

            sonido("ms-appx:///AssetsOshawottJSV/Atleti.mp3");
            Brazo_D2.Opacity = 0;
            Brazo_D.Opacity = 100;
            Boca_Feliz.Opacity = 0;
            poner("Zumo");
            lanzarAnimacion("vida_Os");
            animar(Humo_Os, "Opacity", 1600, 3 / 4, 0, 100, "A");
            animar(Humo_Os, "Y", 1000, 0, 0, 20, "Si");
            animar(Humo_Os, "X", 1000, 0, 0, 20, "Si");
            animar(Trompeta, "Opacity", 1600, 3 / 4, 0, 100, "A");
            movimiento();
        }

        private void cansado()
        {

            poner("Triste");
            OjoDMa.Opacity = 100;
            OjoIMa.Opacity = 100;


        }

        public void nocansado()
        {
            poner("Feliz");
            OjoDMa.Opacity = 0;
            OjoIMa.Opacity = 0;
        }

        public void herido()
        {
            poner("Triste");
            Nariza.Opacity = 100;
            Ras_Cabeza.Opacity = 100;
            Ras_Cabeza2.Opacity = 100;
        }

        public void noherido()
        {
            poner("Feliz");
            Nariza.Opacity = 0;
            Ras_Cabeza.Opacity = 0;
            Ras_Cabeza2.Opacity = 0;
        }

        private void AtaqueF()
        {

            sonido("ms-appx:///AssetsOshawottJSV/Ataque_F.mp3");
            movimiento();
            Brazo_D2.Opacity = 100;
            Brazo_D.Opacity = 0;
            lanzarAnimacion("Ataque_Fuerte");
            animar(Os, "Y", 400, 1 / 2, 0, -150, "A");
            animar(Os, "Y", 400, 1, 0, -150, "A");

            animar(Ola_2, "X", 1000, 0, 0, -100, "Si");
            animar(Ola_1, "X", 1000, 0, 0, 75, "Si");
            animar(Ola_3, "X", 1000, 0, 0, 50, "Si");
            animar(Ola_4, "X", 1000, 0, 0, -120, "Si");
            animar(Ola_2, "Opacity", 1200, 0, 0, 100, "A");
            animar(Ola_1, "Opacity", 300, 1, 0, 100, "A");
            animar(Ola_3, "Opacity", 400, 3 / 2, 0, 100, "A");
            animar(Ola_4, "Opacity", 1000, 1 / 2, 0, 100, "A");
            animar(Boca_Feliz, "Opacity", 100, 3 / 2, 0, 100, "No");
        }

        private void idle()
        {
            //sonido("ms-appx:///AssetsOshawottJSV/Oshawot.mp3");
            Brazo_D2.Opacity = 0;
            Brazo_D.Opacity = 100;
            poner("Feliz");
            lanzarAnimacion("Idle");
            lanzarAnimacion("Mover_Ojos");
            movimiento();
        }
        private void Escudo()
        {
            sonido("ms-appx:///AssetsOshawottJSV/Escudo.mp3");
            Brazo_D2.Opacity = 0;
            Brazo_D.Opacity = 100;
            lanzarAnimacion("Escudo2");
            animar(Os, "Y", 400, 1 / 2, 0, -150, "A");
            poner("Feliz");
            ponerEscudo();
        }

        private void eliminado()
        {
            poner("Triste");
            Ojos_Muerto.Opacity = 100;
            OjoD.Opacity = 0;
            OjoI.Opacity = 0;
            OjoDMa.Opacity = 0;
            OjoIMa.Opacity = 0;
            PupilaD.Opacity = 0;
            PupilaI.Opacity = 0;
        }

        private void noeliminado()
        {

            Ojos_Muerto.Opacity = 0;
            OjoD.Opacity = 100;
            OjoI.Opacity = 100;
            PupilaD.Opacity = 100;
            PupilaI.Opacity = 100;
        }

        private void ponerEscudo()
        {
            Storyboard sb = (Storyboard)this.Cabeza.Resources["CabezaAzulKey"];
            sb.Begin();
            Storyboard sb1 = (Storyboard)this.Brazo_D.Resources["ManoDAzulKey"];
            sb1.Begin();
            Storyboard sb12 = (Storyboard)this.Brazo_D2.Resources["ManoD2AzulKey"];
            sb12.Begin();
            Storyboard sb2 = (Storyboard)this.Brazo_I.Resources["ManoIAzulKey"];
            sb2.Begin();
            Storyboard sb3 = (Storyboard)this.Cuerpo.Resources["CuerpoKey"];
            sb3.Begin();
            Storyboard sb4 = (Storyboard)this.Concha.Resources["ConchaKey"];
            sb4.Begin();
            Storyboard sb5 = (Storyboard)this.Oreja_D.Resources["OrejaDKey"];
            sb5.Begin();
            Storyboard sb6 = (Storyboard)this.Oreja_I.Resources["OrejaIKey"];
            sb6.Begin();
            Storyboard sb7 = (Storyboard)this.Cola.Resources["ColaKey"];
            sb7.Begin();
            Storyboard sb8 = (Storyboard)this.Pie_I.Resources["PieIKey"];
            sb8.Begin();
            Storyboard sb9 = (Storyboard)this.Pie_D.Resources["PieDKey"];
            sb9.Begin();
            Storyboard sbA = (Storyboard)this.Nariz.Resources["NarizKey"];
            sbA.Begin();
            Escudo_Os.Opacity = 100;
        }

        private void quitarEscudo()
        {
            Storyboard sb = (Storyboard)this.Cabeza.Resources["noCabezaAzulKey"];
            sb.Begin();
            Storyboard sb1 = (Storyboard)this.Brazo_D.Resources["noManoDAzulKey"];
            sb1.Begin();
            Storyboard sb12 = (Storyboard)this.Brazo_D2.Resources["noManoD2AzulKey"];
            sb12.Begin();
            Storyboard sb2 = (Storyboard)this.Brazo_I.Resources["noManoIAzulKey"];
            sb2.Begin();
            Storyboard sb3 = (Storyboard)this.Cuerpo.Resources["noCuerpoEscudoKey"];
            sb3.Begin();
            Storyboard sb4 = (Storyboard)this.Concha.Resources["noConchaKey"];
            sb4.Begin();
            Storyboard sb5 = (Storyboard)this.Oreja_D.Resources["noOrejaDKey"];
            sb5.Begin();
            Storyboard sb6 = (Storyboard)this.Oreja_I.Resources["noOrejaIKey"];
            sb6.Begin();
            Storyboard sb7 = (Storyboard)this.Cola.Resources["noColaKey"];
            sb7.Begin();
            Storyboard sb8 = (Storyboard)this.Pie_I.Resources["noPieIKey"];
            sb8.Begin();
            Storyboard sb9 = (Storyboard)this.Pie_D.Resources["noPieDKey"];
            sb9.Begin();
            Storyboard sbA = (Storyboard)this.Nariz.Resources["noNarizKey"];
            sbA.Begin();
            Escudo_Os.Opacity = 0;
        }


        private void movimiento()
        {
            animar(Cabeza_Os, "Y", 1000, 0, 0, 20, "Si");
            animar(Cuerpo_Os, "Y", 1000, 0, 0, 20, "Si");
            animar(Cola_Os, "Y", 1000, 0, 0, 20, "Si");
            animar(BrazoD_Os, "Y", 1000, 0, 0, 20, "Si");
            animar(BrazoI_Os, "Y", 1000, 0, 0, 20, "Si");
        }

        private void poner(String boca)
        {
            if (boca == "Feliz")
            {
                animar(Boca_Feliz, "Opacity", 100, 0, 0, 100, "No");
                animar(Boca_Idle, "Opacity", 100, 0, 0, 0, "No");
                animar(Fuma_Os, "Opacity", 100, 0, 0, 0, "No");

            }
            else if (boca == "Triste")
            {
                animar(Boca_Feliz, "Opacity", 10, 0, 0, 0, "No");
                animar(Boca_Idle, "Opacity", 10, 0, 0, 100, "No");
                animar(Fuma_Os, "Opacity", 10, 0, 0, 0, "No");
            }
            else
            {
                animar(Boca_Feliz, "Opacity", 100, 0, 0, 0, "No");
                animar(Boca_Idle, "Opacity", 100, 0, 0, 0, "No");
                animar(Fuma_Os, "Opacity", 100, 0, 0, 100, "No");
            }
        }

        //Lanza animaciones que estén en el código XAML
        private void lanzarAnimacion(Canvas element, String nombre)
        {
            Storyboard sb = (Storyboard)element.Resources[nombre];
            animaciones.Add(sb);
            sb.Begin();

        }


        private void eliminaridle()
        {
            foreach (Storyboard sb in animaciones)
            {
                sb.Stop();
            }
            animaciones.Clear();
            Boca_Feliz.Opacity = 100;
        }
        //Lanza animaciones grabadas en Blend
        private void lanzarAnimacion(String nombre)
        {
            Storyboard sb = (Storyboard)this.Resources[nombre];
            animaciones.Add(sb);
            sb.Begin();

        }

        private void sonido(String uri)
        {
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri(uri));
            mpSonidos.Play();
        }

        private void debil()
        {

            sonido("ms-appx:///AssetsOshawottJSV/Cristal_Roto.mp3");
            poner("Feliz");
            animar(Os, "X", 100, 10 / 100, 0, 2000, "A");
            animar(Golpe_O, "Opacity", 600, 20 / 100, 0, 100, "A");

        }

        /*
         * Crea animaciones de 4 tipos: 
         * X o Y Mover horizontal y Vertical
         * Angle Rotar
         * ScaleX Como que lo rota en 3D
         * Angle X Nose pero está ahí
         * Opacity 
         */
        private void animar(Canvas p, String tipo, int duracion, int inicio, int from, int to, String repetir)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromMilliseconds(duracion));
            sb.BeginTime = TimeSpan.FromSeconds(inicio);
            Transform transform = tipoAnimacion(tipo, p);
            da.From = from;
            da.To = to;


            if (transform == null)
            {
                Storyboard.SetTarget(da, p);
            }
            else
            {
                Storyboard.SetTarget(da, transform);
            }

            Storyboard.SetTargetProperty(da, tipo);
            if (repetir == "Si")
            {
                sb.RepeatBehavior = RepeatBehavior.Forever;
                sb.AutoReverse = true;
            }
            else if (repetir == "A")
            {
                sb.AutoReverse = true;
            }
            animaciones.Add(sb);
            sb.Children.Add(da);
            sb.Begin();

        }


        private Transform tipoAnimacion(String tipo, Canvas p)
        {
            Transform transform = null;


            if (tipo == "X" || tipo == "Y")
            {
                if (p.RenderTransform == null || !(p.RenderTransform is TranslateTransform))
                {
                    p.RenderTransform = new TranslateTransform();
                }

                transform = (TranslateTransform)p.RenderTransform;
            }
            else if (tipo == "Angle")
            {
                {
                    if (p.RenderTransform == null || !(p.RenderTransform is RotateTransform))
                    {
                        p.RenderTransform = new RotateTransform();
                    }

                    transform = (RotateTransform)p.RenderTransform;
                }
            }
            else if (tipo == "ScaleX" || tipo == "ScaleY")
            {
                if (p.RenderTransform == null || !(p.RenderTransform is ScaleTransform))
                {
                    p.RenderTransform = new ScaleTransform();
                }

                transform = (ScaleTransform)p.RenderTransform;
            }
            else if (tipo == "AngleX" || tipo == "AngleY")
            {
                if (p.RenderTransform == null || !(p.RenderTransform is SkewTransform))
                {
                    p.RenderTransform = new SkewTransform();
                }

                transform = (SkewTransform)p.RenderTransform;
            }




            return transform;
        }



        private void usarPocimaVida(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imRPotion.Visibility = Visibility.Collapsed;
        }

        private void increaseHealth(object sender, object e)
        {
            if (pbVida.Value < 100)
            {
                pbVida.Value++;
            }
            else
            {
                dtTime.Stop();
            }

        }

        private void UsarPocimaEnergia(object sender, PointerRoutedEventArgs e)
        {
            dtTime2 = new DispatcherTimer();
            dtTime2.Interval = TimeSpan.FromMilliseconds(100);
            dtTime2.Tick += increaseEnergy;
            dtTime2.Start();
            this.imYPotion.Visibility = Visibility.Collapsed;
        }

        private void increaseEnergy(object sender, object e)
        {
            if (pbEnergia.Value < 100)
            {
                pbEnergia.Value++;
            }
            else
            {
                dtTime2.Stop();
            }

        }


        private void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    debil();
                    quitarEscudo();
                    break;

                case Windows.System.VirtualKey.Number2:
                    AtaqueF();
                    break;

                case Windows.System.VirtualKey.Number3:
                    Escudo();
                    break;

                case Windows.System.VirtualKey.Number4:
                    vida();
                    nocansado();
                    noherido();
                    break;

                case Windows.System.VirtualKey.Number5:
                    idle();
                    break;

                case Windows.System.VirtualKey.Number6:
                    cansado();
                    break;

                case Windows.System.VirtualKey.Number7:
                    herido();
                    break;

                case Windows.System.VirtualKey.Number8:
                    eliminado();
                    break;

                case Windows.System.VirtualKey.Number9:
                    noeliminado();
                    break;
            }
        }

        public void verFondo(bool ver)
        {
            if (!ver) this.Fondo.Visibility = Visibility.Collapsed;
            else this.Fondo.Visibility = Visibility.Visible;
        }

        public void verFilaVida(bool ver)
        {
            if (!ver) this.gridGeneral.RowDefinitions[0].Height = new GridLength(0);
            else this.gridGeneral.RowDefinitions[0].Height = new GridLength(50, GridUnitType.Pixel);
        }

        public void verFilaEnergia(bool ver)
        {
            if (!ver) this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
            else this.gridGeneral.RowDefinitions[1].Height = new GridLength(50, GridUnitType.Pixel);
        }
        
        public void verPocionVida(bool ver)
        {
            if (!ver) this.imRPotion.Visibility = Visibility.Collapsed; 
            else this.imRPotion.Visibility = Visibility.Visible; 
        }

        public void verPocionEnergia(bool ver)
        {
            if (!ver) this.imYPotion.Visibility = Visibility.Collapsed;
            else this.imYPotion.Visibility = Visibility.Visible;
        }

        public void verNombre(bool ver)
        {
            if (!ver) this.gridGeneral.RowDefinitions[3].Height = new GridLength(0);
            else this.gridGeneral.RowDefinitions[3].Height = new GridLength(50, GridUnitType.Pixel);
        }

        public void verEscudo(bool ver)
        {
            if (!ver) quitarEscudo();
            else ponerEscudo();
        }

        public void activarAniIdle(bool activar)
        {
            if (!activar) eliminaridle();
            else idle();
        }

        public void animacionAtaqueFlojo()
        {
            debil();
        }

        public void animacionAtaqueFuerte()
        {
            AtaqueF();
        }

        public void animacionDefensa()
        {
           Escudo();
        }

        public void animacionDescasar()
        {
            vida();
        }

        public void animacionCansado()
        {
            cansado();
        }

        public void animacionNoCansado()
        {
            nocansado();
        }

        public void animacionHerido()
        {
            herido();
        }

        public void animacionNoHerido()
        {
            noherido();
        }

        public void animacionDerrota()
        {
            eliminado();
        }
    }
}
