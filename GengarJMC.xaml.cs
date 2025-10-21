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
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class GengarJMC : UserControl, iPokemon
    {

        DispatcherTimer dtTimeVida;
        DispatcherTimer dtTimeEnergia;
        MediaPlayer mpSonidos;


        public double Vida 
        { 
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }
        private bool verEnergia = true;
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[1].Height = new GridLength(50,GridUnitType.Pixel);
            }
        }

        private bool verVida = true;
        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida) this.gridGeneral.RowDefinitions[0].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[0].Height = new GridLength(50, GridUnitType.Pixel);
            }
        }

        private bool verPocimaVida = true;

        public bool VerPocimaVida
        {
            get { return verPocimaVida; }
            set
            {
                this.verPocimaVida = value;
                if (!verPocimaVida) this.imPocimaVida.Visibility = Visibility.Collapsed;
                else this.imPocimaVida.Visibility = Visibility.Visible;
            }
        }

        private bool verPocimaEnergia = true;
        public bool VerPocimaEnergia
        {
            get { return verPocimaEnergia; }
            set
            {
                this.verPocimaEnergia = value;
                if (!verPocimaEnergia) this.imPocimaEnergia.Visibility = Visibility.Collapsed;
                else this.imPocimaEnergia.Visibility = Visibility.Visible;
            }
        }

        private bool verNombrePokemon = true;
        public bool VerNombrePokemon
        {
            get { return verNombrePokemon; }
            set
            {
                this.verNombrePokemon = value;
                if (!verNombrePokemon) this.tbNombrePokemon.Visibility = Visibility.Collapsed;
                else this.tbNombrePokemon.Visibility = Visibility.Visible;
            }
        }

        public double Energia { get { return this.pbEnergia.Value; } set { this.pbEnergia.Value = value; } }
        public string Nombre { get { return this.tbNombrePokemon.Text; } set { this.tbNombrePokemon.Text = value; } }
        public string Categoría
        {
            get { return "Sombra"; }
            set { /* ... */ }
        }

        public string Tipo
        {
            get { return "Fantasma/Veneno"; }
            set { /* ... */ }
        }

        public double Altura
        {
            get { return 1.5; } // Altura en metros
            set { /* ... */ }
        }

        public double Peso
        {
            get { return 40.5; } // Peso en kilogramos
            set { /* ... */ }
        }

        public string Evolucion
        {
            get { return "Gastly → Haunter → Gengar"; }
            set { /* ... */ }
        }

        public string Descripcion
        {
            get
            {
                return "Gengar, el Pokémon Sombra. Se dice que se esconde en las sombras de las personas y roba su calor. Le gusta burlarse de la gente con su risa espeluznante.";
            }
            set { /* ... */ }
        }

        public GengarJMC()
        {
            this.mpSonidos=new MediaPlayer();
            this.InitializeComponent();
        }

        private void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            MediaPlayer mpSonidos = new MediaPlayer();

            switch (e.Key)
            {

                //Idle
                case VirtualKey.Number0:
                    sbIdle.Begin();
                    break;


                //Ataque debil
                case VirtualKey.Number1:
                    sbAtaqueDebil.Begin();
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/AtaqueDebil.mp3"));
                    mpSonidos.Play();
                    break;

                //Ataque fuerte
                case VirtualKey.Number2:
                    //Cambia fill elipses a rojo
                    CambiarFillEllipses(Color.FromArgb(255, 255, 0, 0));
                    sbParticulas.RepeatBehavior = new RepeatBehavior(2);
                    sbParticulas.Begin();
                    sbAtaqueFuerte.Begin();
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/AtaqueFuerte.mp3"));
                    mpSonidos.Play();
                    break;

                //Escudo
                case VirtualKey.Number3:
                    sbEscudo.Begin();
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/Escudo.mp3"));
                    mpSonidos.Play();
                    break;

                //Descanso
                case VirtualKey.Number4:
                    CambiarFillEllipses(Color.FromArgb(255, 32, 226, 121));
                    sbParticulas.RepeatBehavior = new RepeatBehavior(3);
                    sbParticulas.Begin();
                    sbDescanso.Begin();
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/Curacion.mp3"));
                    mpSonidos.Play();
                    break;

                //Herido
                case VirtualKey.Number5:
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/Herido.mp3"));
                    mpSonidos.Play();
                    sbHerido.Begin();
                    break;

                //Cansado
                case VirtualKey.Number6:
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/Cansado.mp3"));
                    mpSonidos.Play();
                    if (eDienteRoto.Visibility == Visibility.Visible)
                    {
                        sbCansado.Begin();
                    }
                    else
                    {
                        sbCansado.Begin();
                        eDienteRoto.Visibility = Visibility.Collapsed;
                    }
                    break;

                //Derrotado
                case VirtualKey.Number7:
                    mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/Derrotado.mp3"));
                    mpSonidos.Play();
                    sbDerrotado.Begin();
                    break;
            }
        }

        public void CambiarFillEllipses(Color nuevoColor)
        {
            SolidColorBrush brush = new SolidColorBrush(nuevoColor);
            eParticula1.Fill = brush;
            eParticula1.Stroke = brush;
            eParticula2.Fill = brush;
            eParticula2.Stroke = brush;
            eParticula3.Fill = brush;
            eParticula3.Stroke = brush;
            eParticula4.Fill = brush;
            eParticula4.Stroke = brush;
            eParticula5.Fill = brush;
            eParticula5.Stroke = brush;
            eParticula6.Fill = brush;
            eParticula6.Stroke = brush;
            eParticula7.Fill = brush;
            eParticula7.Stroke = brush;
            eParticula8.Fill = brush;
            eParticula8.Stroke = brush;
        }
        private void usarPocimaVida(object sender, PointerRoutedEventArgs e)
        {
            dtTimeVida = new DispatcherTimer();
            dtTimeVida.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeVida.Tick += incrementarVida;
            dtTimeVida.Start();
            this.imPocimaVida.Visibility = Visibility.Collapsed;
        }

        private void incrementarVida(object sender, object e)
        {
            if (pbVida.Value < 100)
                pbVida.Value++;
            else dtTimeVida.Stop();

        }

        private void usarPocimaEnergia(object sender, PointerRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Uso energia");
            dtTimeEnergia = new DispatcherTimer();
            dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeEnergia.Tick += incrementarEnergia;
            dtTimeEnergia.Start();
            this.imPocimaEnergia.Visibility = Visibility.Collapsed;
        }


        private void incrementarEnergia(object sender, object e)
        {
            if (pbEnergia.Value < 100)
                pbEnergia.Value++;
            else dtTimeEnergia.Stop();

        }

        private void sbAtaqueDebil_Completed(object sender, object e)
        {
            // Resetear la visibilidad de imManoSombra
            imManoSombra.Visibility = Visibility.Collapsed;

            // Reiniciar las transformaciones de imManoSombra
            if (imManoSombra.RenderTransform is CompositeTransform transform)
            {
                transform.TranslateX = 0;
                transform.TranslateY = 0;
                transform.ScaleX = 1;
                transform.ScaleY = 1;
                transform.Rotation = 0;
            }
            else
            {
                // Si no tiene transformaciones, asegurarse de asignarle una
                imManoSombra.RenderTransform = new CompositeTransform();
            }

            // Resetear oreja izquierda (pOrejaIzq)
            if (pOrejaIzq.RenderTransform is CompositeTransform transformIzq)
            {
                transformIzq.Rotation = 0;
                transformIzq.TranslateX = 0;
                transformIzq.TranslateY = 0;
                transformIzq.ScaleX = 1;
                transformIzq.ScaleY = 1;
            }

            // Resetear oreja derecha (pOrdejaDer)
            if (pOrdejaDer.RenderTransform is CompositeTransform transformDer)
            {
                transformDer.Rotation = 0;
                transformDer.TranslateX = 0;
                transformDer.TranslateY = 0;
                transformDer.ScaleX = 1;
                transformDer.ScaleY = 1;
            }

            // Restablecer pOjoIzq
            if (pOjoIzq.RenderTransform is CompositeTransform pOjoIzqTransform)
            {
                pOjoIzqTransform.ScaleX = 1.0;
                pOjoIzqTransform.ScaleY = 1.0;
                pOjoIzqTransform.TranslateX = 0.0;
                pOjoIzqTransform.TranslateY = 0.0;
                pOjoIzqTransform.Rotation = 0.0;
            }
            pOjoIzq.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xEE, 0x01, 0x0B)); // Color original

            // Restablecer ePupilaIzq
            if (ePupilaIzq.RenderTransform is CompositeTransform ePupilaIzqTransform)
            {
                ePupilaIzqTransform.ScaleX = 1.0;
                ePupilaIzqTransform.ScaleY = 1.0;
                ePupilaIzqTransform.TranslateX = 0.0;
                ePupilaIzqTransform.TranslateY = 0.0;
            }
            ePupilaIzq.Fill = new SolidColorBrush(Colors.White); // Color original

            // Restablecer pOjoDer
            if (pOjoDer.RenderTransform is CompositeTransform pOjoDerTransform)
            {
                pOjoDerTransform.ScaleX = -1.0;
                pOjoDerTransform.ScaleY = 1.0;
                pOjoDerTransform.TranslateX = 0.0;
                pOjoDerTransform.TranslateY = 0.0;
                pOjoDerTransform.Rotation = 0.0;
            }
            pOjoDer.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xEE, 0x01, 0x0B)); // Color original

            // Restablecer ePupilaDer
            if (ePupilaDer.RenderTransform is CompositeTransform ePupilaDerTransform)
            {
                ePupilaDerTransform.ScaleX = 1.0;
                ePupilaDerTransform.ScaleY = 1.0;
                ePupilaDerTransform.TranslateX = 0.0;
                ePupilaDerTransform.TranslateY = 0.0;
            }
            ePupilaDer.Fill = new SolidColorBrush(Colors.White); // Color original

            // Restablecer pOrejaIzq
            if (pOrejaIzq.RenderTransform is CompositeTransform pOrejaIzqTransform)
            {
                pOrejaIzqTransform.ScaleX = 1.066;
                pOrejaIzqTransform.ScaleY = 1.0;
                pOrejaIzqTransform.TranslateX = 0.0;
                pOrejaIzqTransform.TranslateY = 0.0;
                pOrejaIzqTransform.Rotation = 0.0;
            }
        }


        private void sbAtaqueFuerte_Completed(object sender, object e)
        {
            // Resetear las transformaciones de imNube1
            if (imNube1.RenderTransform is CompositeTransform transNube1)
            {
                transNube1.TranslateX = 0;
                transNube1.TranslateY = 0;
            }

            // Resetear las transformaciones de imNube2
            if (imNube2.RenderTransform is CompositeTransform transNube2)
            {
                transNube2.TranslateX = 0;
                transNube2.TranslateY = 0;
            }

            // Resetear las propiedades de cvBolaSombra
            cvBolaSombra.Visibility = Visibility.Collapsed;
            cvBolaSombra.Opacity = 0;

            // Resetear la transformación de cvBolaSombra
            if (cvBolaSombra.RenderTransform is CompositeTransform transBola)
            {
                transBola.TranslateX = 0;
                transBola.TranslateY = 0;
            }

            // Se resetea la animación de cansado en caso de que estuviera activa (Ya que si no, no se resetea el efecto de color)
            if (sbCansado.GetCurrentState() == ClockState.Active)
            {
                sbCansado.Stop();
                sbCansado.Begin();

            }
        }

        private void sbDescanso_Completed(object sender, object e)
        {
            // Se resetea la animación de cansado en caso de que estuviera activa (Ya que si no, no se resetea el efecto de color)
            if (sbCansado.GetCurrentState() == ClockState.Active)
            {
                sbCansado.Stop();
                sbCansado.Begin();
            }
        }

        public void verFondo(bool ver)
        {
            // Si ver es true, asigna el ImageBrush ya definido en XAML; de lo contrario, quita el fondo.
            gridGeneral.Background = ver ? (Brush)ibFondo : null;
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
            VerPocimaVida = ver;
        }

        public void verPocionEnergia(bool ver)
        {
            VerPocimaEnergia = ver;
        }

        public void verNombre(bool ver)
        {
            VerNombrePokemon = ver;
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                // Aseguramos que el elemento se muestre
                eEscudo.Visibility = Visibility.Visible;

                // Si el RenderTransform ya es un CompositeTransform, lo reutilizamos; de lo contrario, lo creamos.
                CompositeTransform ct = eEscudo.RenderTransform as CompositeTransform;
                if (ct == null)
                {
                    ct = new CompositeTransform();
                    eEscudo.RenderTransform = ct;
                }

                // Establecemos los valores finales de la animación
                ct.ScaleX = 9.647;
                ct.ScaleY = 6.236;
                ct.TranslateX = 3;
                ct.TranslateY = -2.5;
            }
            else
            {
                // Oculta el elemento
                eEscudo.Visibility = Visibility.Collapsed;
            }
        }

        public void activarAniIdle(bool activar)
        {
            if (activar)
                sbIdle.Begin();
            else
                sbIdle.Stop();
        }

        public void animacionAtaqueFlojo()
        {
            sbAtaqueDebil.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/AtaqueDebil.mp3"));
            mpSonidos.Play();
        }

        public void animacionAtaqueFuerte()
        {
            CambiarFillEllipses(Color.FromArgb(255, 255, 0, 0));
            sbParticulas.RepeatBehavior = new RepeatBehavior(2);
            sbParticulas.Begin();
            sbAtaqueFuerte.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/AtaqueFuerte.mp3"));
            mpSonidos.Play();
        }

        public void animacionDefensa()
        {
            sbEscudo.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/Escudo.mp3"));
            mpSonidos.Play();
        }

        public void animacionDescansar()
        {
            CambiarFillEllipses(Color.FromArgb(255, 32, 226, 121));
            sbParticulas.RepeatBehavior = new RepeatBehavior(3);
            sbParticulas.Begin();
            sbDescanso.Begin();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/Curacion.mp3"));
            mpSonidos.Play();
        }

        public void animacionCansado()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/Cansado.mp3"));
            mpSonidos.Play();
            if (eDienteRoto.Visibility == Visibility.Visible)
            {
                sbCansado.Begin();
            }
            else
            {
                sbCansado.Begin();
                eDienteRoto.Visibility = Visibility.Collapsed;
            }
        }

        public void animacionNoCansado()
        {
            sbCansado.Stop();
            // Si sigue reproduciendose herido, reinicia esa animación
            if (sbHerido.GetCurrentState() == ClockState.Active)
            {
                sbHerido.Stop();
                sbHerido.Begin();
            }
        }

        public void animacionHerido()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/Herido.mp3"));
            mpSonidos.Play();
            sbHerido.Begin();
        }

        public void animacionNoHerido()
        {
            sbHerido.Stop();
            if (sbCansado.GetCurrentState() == ClockState.Active)
            {
                sbCansado.Stop();
                sbCansado.Begin();
            }
        }

        public void animacionDerrota()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGengarJMC/Sounds/Derrotado.mp3"));
            mpSonidos.Play();
            sbDerrotado.Begin();
        }

        public void animacionDescasar()
        {
            throw new NotImplementedException();
        }
    }
}
