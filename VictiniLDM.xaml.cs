using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace IPOkemonApp
{
    public sealed partial class VictiniLDM : UserControl, ClassLibrary1_Prueba.iPokemon
    {
        private MediaPlayer mpSonidos;
        private Storyboard sbMoverAlas;
        private bool enAnimacion = false; // Bandera para controlar animaciones
        private bool esDerrotado = false; // Bandera para controlar si la animación es "derrotado"
        DispatcherTimer dtTime;
        DispatcherTimer delayTimer;

        public VictiniLDM()
        {
            this.InitializeComponent();
            mpSonidos = new MediaPlayer();

            // Ocultar elementos al inicio
            escudo1.Visibility = Visibility.Collapsed;
            fuego.Visibility = Visibility.Collapsed;
            curacion1.Visibility = Visibility.Collapsed;
            bola_de_fuego.Visibility = Visibility.Collapsed;
            llamas.Visibility = Visibility.Collapsed;
            verFondo(false);
            verFilaVida(false);
            verFilaEnergia(false);
            verPocionVida(false);
            verPocionEnergia(false);
            verNombre(false);

            this.IsTabStop = true;
            this.KeyDown += ControlTeclas;

            
                
            
        }

        private void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            if (enAnimacion) return; // Evita interrupciones si hay una animación en curso

            Storyboard sbaux = null;

            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    sbaux = (Storyboard)this.Resources["ataque"];
                    IniciarRetrasoSonido("explosion_1.mp3", TimeSpan.FromSeconds(1));
                    break;
                case Windows.System.VirtualKey.Number2:
                    sbaux = (Storyboard)this.Resources["ataque_debil"];
                    IniciarRetrasoSonido("fuegos.mp3", TimeSpan.FromSeconds(0));
                    break;
                case Windows.System.VirtualKey.Number3:
                    sbaux = (Storyboard)this.Resources["curacion"];
                    IniciarRetrasoSonido("recovery.mp3", TimeSpan.FromSeconds(0));
                    break;
                case Windows.System.VirtualKey.Number4:
                    sbaux = (Storyboard)this.Resources["escudo"];
                    break;
                case Windows.System.VirtualKey.Number5:
                    sbaux = (Storyboard)this.Resources["escudo_puesto"];
                    break;
                case Windows.System.VirtualKey.Number6:
                    sbaux = (Storyboard)this.Resources["cansado"];
                    break;
                case Windows.System.VirtualKey.Number7:
                    sbaux = (Storyboard)this.Resources["herido"];
                    break;
                case Windows.System.VirtualKey.Number8:
                    sbaux = (Storyboard)this.Resources["derrotado"];
                    esDerrotado = true; // Marca que la animación "derrotado" está en progreso
                    break;
                case Windows.System.VirtualKey.Number9:
                    sbaux = (Storyboard)this.Resources["escudo_puesto"];
                    break;
            }

            if (sbaux != null)
            {
                enAnimacion = true; // Indica que hay una animación en progreso

                if (sbMoverAlas != null)
                {
                    sbMoverAlas.Stop(); // Detiene "mover_alas" antes de iniciar otra
                }

                sbaux.Completed -= AnimacionFinalizada;
                sbaux.Completed += AnimacionFinalizada;
                sbaux.Begin();
            }
        }

        private void IniciarRetrasoSonido(string archivo, TimeSpan retraso)
        {
            delayTimer = new DispatcherTimer();
            delayTimer.Interval = retraso;
            delayTimer.Tick += (s, e) =>
            {
                ReproducirSonido(archivo);
                delayTimer.Stop();
            };
            delayTimer.Start();
        }

        private void ReproducirSonido(string archivo)
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///AssetsVictiniLDM/{archivo}"));
            mpSonidos.Play();
        }

        private void AnimacionFinalizada(object sender, object e)
        {
            enAnimacion = false; // Libera la bandera para permitir nuevas animaciones

            // Volver a "mover_alas" solo si ninguna otra animación está en ejecución y no es "derrotado"
            if (sbMoverAlas != null && !esDerrotado)
            {
                sbMoverAlas.Begin();
            }

            // Resetear la bandera de "derrotado"
            esDerrotado = false;
        }

        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imRPotion.Visibility = Visibility.Collapsed;
        }

        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.5;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }

        public void verFondo(bool ver)
        {
            if (this.gridPrincipal != null)
            {
                if (ver)
                {
                    this.gridPrincipal.Background = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("ms-appx:///AssetsVictiniLDM/fondo.png")),
                        Stretch = Stretch.UniformToFill
                    };
                }
                else
                {
                    this.gridPrincipal.Background = null;
                }
            }
        }

        public void verFilaVida(bool ver)
        {
            if (gridPrincipal != null && gridPrincipal.RowDefinitions.Count > 0)
            {
                // Cambiar la altura de la fila 0 (donde está pbHealth)
                gridPrincipal.RowDefinitions[0].Height = ver
                    ? new GridLength(50) // o el valor original si era distinto
                    : new GridLength(0);
            }

            // También puedes ocultar visualmente el ProgressBar y la imagen, si lo deseas:
            pbHealth.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            if (gridPrincipal != null && gridPrincipal.RowDefinitions.Count > 1)
            {
                // Cambiar la altura de la fila 1 (donde está pbEnergy)
                gridPrincipal.RowDefinitions[1].Height = ver
                    ? new GridLength(50) // o el valor original si era distinto
                    : new GridLength(0);
            }

            // Ocultar o mostrar visualmente la barra de energía y la poción amarilla
            pbEnergy.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            
        }

        public void verPocionVida(bool ver)
        {
            if (imRPotion != null)
            {
                imRPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (imYPotion != null)
            {
                imYPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public void verNombre(bool ver)
        {
            if (nombrePokemon != null)
            {
                nombrePokemon.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public void verEscudo(bool ver)
        {
            if (escudo1 != null)
            {
                escudo1.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public void activarAniIdle(bool activar)
        {
            if (activar==true)
            {
                var sb = (Storyboard)this.Resources["mover_alas"];
                sb.Begin();
            }

            else {
                if (this.Resources.ContainsKey("mover_alas"))
                {
                    var sbCansado = (Storyboard)this.Resources["mover_alas"];
                    sbCansado.Stop();
                }
                var sb = (Storyboard)this.Resources["estado_inicial"];
                sb.Begin();
            }
        }

        public void animacionAtaqueFlojo()
        {
            var sb = (Storyboard)this.Resources["ataque_debil"];
            sb.Begin();
            IniciarRetrasoSonido("fuegos.mp3", TimeSpan.FromSeconds(0));
            // Crear un DispatcherTimer para el retraso de 3 segundos
            var delayTimer = new DispatcherTimer();
            delayTimer.Interval = TimeSpan.FromSeconds(4);
            delayTimer.Tick += (s, e) =>
            {
                var sb2 = (Storyboard)this.Resources["estado_inicial"];
                sb2.Begin();
                delayTimer.Stop(); // Detener el timer después de ejecutar la animación
            };
            delayTimer.Start();
        }

        public void animacionAtaqueFuerte()
        {
            var sb = (Storyboard)this.Resources["ataque"];
            sb.Begin();
            IniciarRetrasoSonido("explosion_1.mp3", TimeSpan.FromSeconds(1));
            // Crear un DispatcherTimer para el retraso de 3 segundos
            var delayTimer = new DispatcherTimer();
            delayTimer.Interval = TimeSpan.FromSeconds(3);
            delayTimer.Tick += (s, e) =>
            {
                var sb2 = (Storyboard)this.Resources["estado_inicial"];
                sb2.Begin();
                delayTimer.Stop(); // Detener el timer después de ejecutar la animación
            };
            delayTimer.Start();
        }

        public void animacionDefensa()
        {
            var sb = (Storyboard)this.Resources["escudo"];
            sb.Begin();
            IniciarRetrasoSonido("fire-whoosh.mp3", TimeSpan.FromSeconds(0));
            var delayTimer = new DispatcherTimer();
            delayTimer.Interval = TimeSpan.FromSeconds(3);
            delayTimer.Tick += (s, e) =>
            {
                var sb2 = (Storyboard)this.Resources["estado_inicial"];
                sb2.Begin();
                delayTimer.Stop(); // Detener el timer después de ejecutar la animación
            };
            delayTimer.Start();
        }

        public void animacionDescasar()
        {
            var sb = (Storyboard)this.Resources["curacion"];
            sb.Begin();
            IniciarRetrasoSonido("recovery.mp3", TimeSpan.FromSeconds(0));
            var delayTimer = new DispatcherTimer();
            delayTimer.Interval = TimeSpan.FromSeconds(4);
            delayTimer.Tick += (s, e) =>
            {
                var sb2 = (Storyboard)this.Resources["estado_inicial"];
                sb2.Begin();
                delayTimer.Stop(); // Detener el timer después de ejecutar la animación
            };
            delayTimer.Start();
        }

        public void animacionCansado()
        {
            var sb = (Storyboard)this.Resources["cansado"];
            sb.Begin();
        }

        public void animacionNoCansado()
        {
            if (this.Resources.ContainsKey("cansado"))
            {
                var sbCansado = (Storyboard)this.Resources["cansado"];
                sbCansado.Stop();
            }
            var sb = (Storyboard)this.Resources["estado_inicial"];
            sb.Begin();
        }

        public void animacionHerido()
        {
            var sb = (Storyboard)this.Resources["herido"];
            sb.Begin();
        }

        public void animacionNoHerido()
        {
            if (this.Resources.ContainsKey("herido"))
            {
                var sbCansado = (Storyboard)this.Resources["herido"];
                sbCansado.Stop();
            }
            var sb = (Storyboard)this.Resources["estado_inicial"];
            sb.Begin();
        }

        public void animacionDerrota()
        {
            var sb = (Storyboard)this.Resources["derrotado"];
            sb.Begin();
        }

        public double Vida
        {
            get => this.pbHealth.Value;
            set => this.pbHealth.Value = value;
        }
        public double Energia
        {
            get => this.pbEnergy.Value;
            set => this.pbEnergy.Value = value;
        }
        public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Altura { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Peso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Evolucion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
