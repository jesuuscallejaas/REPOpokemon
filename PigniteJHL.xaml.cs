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
using ClassLibrary1_Prueba;
using Windows.UI.Core;
using Windows.Media.Playback;
using Windows.Media.Core;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class PigniteJHL : UserControl, iPokemon
    {
        DispatcherTimer dtTime;
        DispatcherTimer dtTimeEnergia;
        public PigniteJHL()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
        }
        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.5;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Visibility = Visibility.Collapsed;

            }
        }

        private void usePotionEnergia(object sender, PointerRoutedEventArgs e)
        {
            dtTimeEnergia = new DispatcherTimer();
            dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(100); // Intervalo de tiempo
            dtTimeEnergia.Tick += increaseEnergia; // Método que se ejecuta en cada tick
            dtTimeEnergia.Start(); // Inicia el temporizador
        }

        private void increaseEnergia(object sender, object e)
        {
            this.pbEnergia.Value += 0.5; // Aumenta la energía en 0.5 puntos
            if (pbEnergia.Value >= 100) // Si la energía llega al máximo
            {
                this.dtTimeEnergia.Stop(); // Detiene el temporizador
                this.pocionEnergia.Visibility = Visibility.Collapsed; // Oculta la poción amarilla
            }
        }

        double iPokemon.Vida { get => pbHealth.Value; set => pbHealth.Value = value; }
        double iPokemon.Energia { get => pbEnergia.Value; set => pbEnergia.Value = value; }
        string iPokemon.Nombre { get => nombrePokemon.Text; set => nombrePokemon.Text = value; }
        string iPokemon.Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } 
        string iPokemon.Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double iPokemon.Altura { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double iPokemon.Peso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string iPokemon.Evolucion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string iPokemon.Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Vida { get => pbHealth.Value; internal set => pbHealth.Value = value; }
        public double Energia { get => pbEnergia.Value; internal set => pbEnergia.Value = value; }

        void iPokemon.verFondo(bool ver)
        {
            background.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.verFilaVida(bool ver)
        {
            pbHealth.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.verFilaEnergia(bool ver)
        {
            pbEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.verPocionVida(bool ver)
        {
            imRPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.verPocionEnergia(bool ver)
        {
            pocionEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.verNombre(bool ver)
        {
            nombrePokemon.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.verEscudo(bool ver)
        {
            escudo.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        void iPokemon.activarAniIdle(bool activar)
        {
            if (activar)
            {
                // Comienza la animación de Idle
                AnimacionIdle.Begin();
            }
            else
            {
                // Detiene la animación de Idle
                AnimacionIdle.Stop();
            }
        }

        void iPokemon.animacionAtaqueFlojo()
        {
            AtaqueDebil.Begin();
        }

        void iPokemon.animacionAtaqueFuerte()
        {
            AtaqueFuerte.Begin();
        }

        void iPokemon.animacionDefensa()
        {
            MostrarEscudo.Begin();
        }

        void iPokemon.animacionDescasar()
        {
            AnimacionDescanso.Begin();
        }

        void iPokemon.animacionCansado()
        {
            throw new NotImplementedException();
        }

        void iPokemon.animacionNoCansado()
        {
            throw new NotImplementedException();
        }

        void iPokemon.animacionHerido()
        {
            throw new NotImplementedException();
        }

        void iPokemon.animacionNoHerido()
        {
            throw new NotImplementedException();
        }

        void iPokemon.animacionDerrota()
        {
            throw new NotImplementedException();
        }

        MediaPlayer mpAtaqueFuerte = new MediaPlayer();
        internal async void animacionAtaqueFuerte()
        {
            // Reproducir el sonido justo después de la rotación
            mpAtaqueFuerte.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPigniteJHL/ataqueFuerte.mp3"));
            mpAtaqueFuerte.Play();

            await Task.Delay(1000);

            AtaqueFuerte.Begin();

            AtaqueFuerte.Completed += async (s, args) =>
            {
                // Esperar 1.5 segundos antes de regresar a la posición inicial
                await Task.Delay(1500);

                // Ejecutar el segundo Storyboard en el hilo de la UI
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    RegresarAtaqueFuerte.Begin();
                });

                // Detener el sonido cuando termina la animación de regreso
                RegresarAtaqueFuerte.Completed += (sender, e) =>
                {
                    mpAtaqueFuerte.Pause();
                    mpAtaqueFuerte.PlaybackSession.Position = TimeSpan.Zero;
                };
            };
        }

        MediaPlayer mpAtaqueDebil = new MediaPlayer();

        internal void animacionAtaqueFlojo()
        {
            AtaqueDebil.Begin();

            // Cuando termine la animación de rotación, ejecutar el movimiento hacia abajo y la llamarada
            AtaqueDebil.Completed += async (s, args) =>
            {
                // Reproducir el sonido de ataque débil
                mpAtaqueDebil.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPigniteJHL/ataqueDebil.mp3"));
                mpAtaqueDebil.Play();

                // Ejecutar el movimiento hacia abajo después de la rotación
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    MovimientoHaciaAbajo.Begin();
                });

                // Cuando termine el movimiento hacia abajo, ejecutar el regreso
                MovimientoHaciaAbajo.Completed += async (s2, args2) =>
                {
                    // Esperar 1 segundo antes de regresar a la posición inicial
                    await Task.Delay(1000);

                    // Ejecutar la animación de regreso
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        RegresoAtaqueDebil.Begin();
                    });

                    // Detener el sonido cuando termina la animación de regreso
                    RegresoAtaqueDebil.Completed += (sender, e) =>
                    {
                        mpAtaqueDebil.Pause();
                        mpAtaqueDebil.PlaybackSession.Position = TimeSpan.Zero;
                    };
                };
            };
        }

        MediaPlayer mpEscudo = new MediaPlayer();

        internal async void animacionDefensa()
        {
            mpEscudo.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPigniteJHL/escudo.mp3"));
            mpEscudo.Play();

            await Task.Delay(1000);
            MostrarEscudo.Begin();

            MostrarEscudo.Completed += async (s, args) =>
            {
                await Task.Delay(2500);

                // Ejecutar el segundo Storyboard en el hilo de la UI
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    OcultarEscudo.Begin();
                });
            };
        }

        internal void verTirita(bool v)
        {
            tirita.Visibility = v ? Visibility.Visible : Visibility.Collapsed;

            boca.Visibility = v ? Visibility.Collapsed : Visibility.Visible;
            bocaTriste.Visibility = v ? Visibility.Visible : Visibility.Collapsed;

            double desplazamiento = v ? 5 : 0; 
            double desplazarDienteDch = v ? 11 : 0;

            // Mover el diente izquierdo
            var transformDienteIzq = dienteizq.RenderTransform as CompositeTransform;
            if (transformDienteIzq != null)
            {
                transformDienteIzq.TranslateY = desplazamiento;
            }

            // Mover el diente derecho
            var transformDienteDch = dientedch.RenderTransform as CompositeTransform;
            if (transformDienteDch != null)
            {
                transformDienteDch.TranslateY = desplazarDienteDch;
            }
        }

        MediaPlayer mpDescanso = new MediaPlayer();

        internal async void animacionDescansar()
        {
            mpDescanso.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPigniteJHL/descanso.mp3"));
            mpDescanso.Play();

            await Task.Delay(100);

            
            AnimacionDescanso.Begin();
            await Task.Delay(1500);
            AnimacionDescanso.Completed += async(sender, e) =>
            {
                mpDescanso.Pause();
                DesaparicionParticulas.Begin();
            };
        }

        internal void verCansado(bool v)
        {
            cansado.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
            double desplazar = v ? 10 : 0;
            var transform = canvasCola.RenderTransform as CompositeTransform;
            if (transform != null)
            {
                transform.TranslateY = desplazar;
            }
        }

        internal void animacionHerido()
        {
            verTirita(true);
        }

        internal void animacionNoHerido()
        {
            verTirita(false);
        }

        internal void animacionCansado()
        {
            verCansado(true);
        }

        internal void animacionNoCansado()
        {
            verCansado(false);
        }

        internal void verEscudo(bool v)
        {
            escudo.Opacity = v ? 0.7 : 0.0;
            escudo.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void verFondo(bool v)
        {
            background.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void verFilaVida(bool v)
        {
            pbHealth.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
            corazon.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
            imRPotion.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void verFilaEnergia(bool v)
        {
            pbEnergia.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
            energia.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
            pocionEnergia.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void verPocionVida(bool v)
        {
            imRPotion.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void verPocionEnergia(bool v)
        {
            pocionEnergia.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void verNombre(bool v)
        {
            nombrePokemon.Visibility = v ? Visibility.Visible : Visibility.Collapsed;
        }

        internal void activarAniIdle(bool activar)
        {
            if (activar)
            {
                // Comienza la animación de Idle y se repite indefinidamente
                AnimacionIdle.Begin();
            }
            else
            {
                // Detener la animación cuando el checkbox se desmarca
                AnimacionIdle.Stop();
            }
        }
    }
}
