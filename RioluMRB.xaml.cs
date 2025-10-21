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
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Threading.Tasks;
using ClassLibrary1_Prueba;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    using ClassLibrary1_Prueba;
    public sealed partial class RioluMRB : UserControl, iPokemon
    {
        DispatcherTimer dtTime;
        private Storyboard currentStoryboard; // Variable para rastrear la animación activa
        private readonly HashSet<Storyboard> animacionesActivas = new HashSet<Storyboard>();
        // Campos privados para valores internos (si es necesario)
        private double altura;
        private double peso;
        private string descripcion;

        

        public RioluMRB()
        {
            this.InitializeComponent();
            this.vidaProgressBar.Value = 100; // Valor inicial para la barra de vida
            this.energiaProgressBar.Value=100 ; // Valor inicial para la barra de energía

            // Configurar eventos Completed para cada Storyboard
            Storyboard heridoStoryboard = (Storyboard)this.Resources["HeridoAnimation"];
            Storyboard cansadoStoryboard = (Storyboard)this.Resources["CansadoAnimation"];
            Storyboard escudoStoryboard = (Storyboard)this.Resources["EscudoAnimation"];
            Storyboard derrotadoStoryboard = (Storyboard)this.Resources["DerrotadoAnimation"];
            Storyboard ataqueDebilStoryboard = (Storyboard)this.Resources["AtaqueDebilAnimation"];
            Storyboard ataqueFuerteStoryboard = (Storyboard)this.Resources["AtaqueFuerteAnimation"];
            Storyboard defensaStoryboard = (Storyboard)this.Resources["Defensa"];
            Storyboard descansoStoryboard = (Storyboard)this.Resources["DescansoAnimation"];
            Storyboard estandarStoryboard = (Storyboard)this.Resources["RespiracionRapida"];

            heridoStoryboard.Completed += AnimacionCompletada;
            cansadoStoryboard.Completed += AnimacionCompletada;
            escudoStoryboard.Completed += AnimacionCompletada;
            derrotadoStoryboard.Completed += AnimacionCompletada;
            ataqueDebilStoryboard.Completed += AnimacionCompletada;
            ataqueFuerteStoryboard.Completed += AnimacionCompletada;
            defensaStoryboard.Completed += AnimacionCompletada;
            descansoStoryboard.Completed += AnimacionCompletada;
            estandarStoryboard.Completed += AnimacionCompletada;
        }
        // Implementación de las propiedades de iPokemon
        public double Vida
        {
            get { return this.vidaProgressBar.Value; } // Vincula al control ProgressBar interno
            set { this.vidaProgressBar.Value = value; }
        }

        public double Energia
        {
            get { return this.energiaProgressBar.Value; }
            set { this.energiaProgressBar.Value = value; }
        }

        public string Nombre
        {
            get { return this.NombrePokemon.Text; } // Vincula al control TextBlock interno
            set { this.NombrePokemon.Text = value; }
        }

        public string Categoría
        {
            get { return this.tbCategoria.Text; }
            set { this.tbCategoria.Text = value; }
        }

        public string Tipo
        {
            get { return this.tbTipo.Text; }
            set { this.tbTipo.Text = value; }
        }

        public double Altura
        {
            get { return this.altura; }
            set { this.altura = value; } // Puede usarse para cálculos, no visualizado directamente
        }

        public double Peso
        {
            get { return this.peso; }
            set { this.peso = value; } // Puede ser similar a "Altura"
        }

        public string Evolucion
        {
            get { return this.tbEvolucion.Text; }
            set { this.tbEvolucion.Text = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        private void AnimacionCompletada(object sender, object e)
        {
            // Eliminar animación finalizada
            if (sender is Storyboard storyboard && animacionesActivas.Contains(storyboard))
            {
                animacionesActivas.Remove(storyboard);
            }
            RestaurarEstadoOriginal();
        }

        private void RestaurarEstadoOriginal()
        {
            // Restaurar transformaciones
            CompositeTransform pokemonTransform = (CompositeTransform)Pokemon.RenderTransform;
            pokemonTransform.ScaleX = 1;
            pokemonTransform.ScaleY = 1;
            pokemonTransform.TranslateX = 0;
            pokemonTransform.TranslateY = 0;
            tirita.Visibility = Visibility.Collapsed;
            rasguño1.Visibility = Visibility.Collapsed;
            rasguño2.Visibility = Visibility.Collapsed;
            rasguño3.Visibility = Visibility.Collapsed;
            rasguño4.Visibility = Visibility.Collapsed;
            OrejaCansado.Visibility = Visibility.Collapsed;
            LenguaCansada.Visibility = Visibility.Collapsed;
            sudor.Visibility = Visibility.Collapsed;
            sudor_Copiar.Visibility = Visibility.Collapsed;
            sudor_Copiar1.Visibility = Visibility.Collapsed;
            sudor_Copiar2.Visibility = Visibility.Collapsed;
            sudor_Copiar3.Visibility = Visibility.Collapsed;
            sudor_Copiar4.Visibility = Visibility.Collapsed;
            sudor_Copiar5.Visibility = Visibility.Collapsed;
            sudor_Copiar6.Visibility = Visibility.Collapsed;
            sudor_Copiar7.Visibility = Visibility.Collapsed;
            OrejaDerecha.Visibility = Visibility.Visible;
            Boca1.Visibility = Visibility.Visible;
            escudo.Visibility = Visibility.Collapsed;
            Boca_Descanso.Visibility = Visibility.Collapsed;
            OjoDerechoDescanso.Visibility = Visibility.Collapsed;
            OjoIzquierdoDescanso.Visibility = Visibility.Collapsed;
            Boca_Copiar.Visibility = Visibility.Visible;
            OjoDerecho.Visibility = Visibility.Visible;
            OjoIzquierdo.Visibility = Visibility.Visible;
            // Restaurar opacidad
            Pokemon.Opacity = 1;

            // Restaurar visibilidad
            Pokemon.Visibility = Visibility.Visible;
        }




        




        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
        }

        private void increaseHealth(object sender, object e)
        {
            this.vidaProgressBar.Value += 1.5;
            if (vidaProgressBar.Value >= 100)
            {
                this.dtTime.Stop();
                this.pocion_vida.Visibility = Visibility.Collapsed; // Ocultar la poción solo después de llenar la barra.
            }
        }

        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEnergy;
            dtTime.Start();
        }
        private void increaseEnergy(object sender, object e)
        {
            this.energiaProgressBar.Value += 1.5;
            if (energiaProgressBar.Value >= 100)
            {
                this.dtTime.Stop();
                this.pocion_energia.Visibility = Visibility.Collapsed; // Ocultar la poción solo después de llenar la barra.
            }
        }

        public void verFondo(bool ver)
        {
            this.fondoImage.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            this.vidaProgressBar.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            this.energiaProgressBar.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            this.pocion_vida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            this.pocion_energia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            this.nombre.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            this.escudo.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }


   

        public void animacionHerido()
        {
            Storyboard heridoStoryboard = (Storyboard)this.Resources["HeridoAnimation"];
            Storyboard estandarStoryboard = (Storyboard)this.Resources["RespiracionRapida"];
            estandarStoryboard.Stop();
            animacionesActivas.Add(heridoStoryboard);
                MediaPlayer mpSonido2 = new MediaPlayer();
                mpSonido2.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/corazon.mp3"));
                mpSonido2.Play();
                heridoStoryboard.Begin();
            
        }


        public async void animacionAtaqueFuerte()
        {
            Storyboard ataqueFuerteStoryboard = (Storyboard)this.Resources["AtaqueFuerteAnimation"];
            
                animacionesActivas.Add(ataqueFuerteStoryboard);
                MediaPlayer mpSonido4 = new MediaPlayer();
                mpSonido4.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/explosion.mp3"));
                ataqueFuerteStoryboard.Begin();
                await Task.Delay(2000);
                mpSonido4.Play();
            
        }


        public async void animacionAtaqueFlojo()
        {
            Storyboard ataqueDebilStoryboard = (Storyboard)this.Resources["AtaqueDebilAnimation"];
            
                animacionesActivas.Add(ataqueDebilStoryboard);
                MediaPlayer mpSonido3 = new MediaPlayer();
                mpSonido3.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/ataquedebil.mp3"));
                mpSonido3.Play();
                await Task.Delay(500);
                ataqueDebilStoryboard.Begin();
            
        }


        public async void animacionDefensa()
        {
            Storyboard defensaStoryboard = (Storyboard)this.Resources["Defensa"];
            
                animacionesActivas.Add(defensaStoryboard);
                MediaPlayer mpSonido = new MediaPlayer();
                mpSonido.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/escudo.mp3"));
                mpSonido.Play();

                await Task.Delay(1000); // Retraso de 1.5 segundos antes de iniciar la animación
                defensaStoryboard.Begin();
            
        }


        public async void animacionDescasar()
        {
            Storyboard descansoStoryboard = (Storyboard)this.Resources["DescansoAnimation"];
            
            animacionesActivas.Add(descansoStoryboard);
            MediaPlayer mpSonido = new MediaPlayer();
            mpSonido.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/descanso.mp3"));
            mpSonido.Play();
            await Task.Delay(100);
            descansoStoryboard.Begin();
            
        }


        public void animacionCansado()
        {
            Storyboard cansadoStoryboard = (Storyboard)this.Resources["CansadoAnimation"];
            Storyboard estandarStoryboard = (Storyboard)this.Resources["RespiracionRapida"];
            estandarStoryboard.Stop();
            animacionesActivas.Add(cansadoStoryboard);
            cansadoStoryboard.Begin();
            
        }


        public void animacionEscudo()
        {
            Storyboard escudoStoryboard = (Storyboard)this.Resources["EscudoAnimation"];
            Storyboard estandarStoryboard = (Storyboard)this.Resources["RespiracionRapida"];
            estandarStoryboard.Stop();
            animacionesActivas.Add(escudoStoryboard);
             escudoStoryboard.Begin();
            
        }

        public void animacionNoEscudo()
        {
            Storyboard escudoStoryboard = (Storyboard)this.Resources["EscudoAnimation"];

            
            escudoStoryboard.Stop();
            RestaurarEstadoOriginal();

        }




        public async void animacionDerrota()
        {
            Storyboard derrotadoStoryboard = (Storyboard)this.Resources["DerrotadoAnimation"];
            
                animacionesActivas.Add(derrotadoStoryboard);
                MediaPlayer mpSonido1 = new MediaPlayer();
                mpSonido1.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/derrotado.mp3"));
                mpSonido1.Play();
                await Task.Delay(500);
                derrotadoStoryboard.Begin();
            
        }

        public void animacionNoHerido()
        {
            Storyboard heridoStoryboard = (Storyboard)this.Resources["HeridoAnimation"];
            MediaPlayer mpSonido2 = new MediaPlayer();
            mpSonido2.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsRioluMRB/corazon.mp3"));
            heridoStoryboard.Stop();
            mpSonido2.Pause();
            RestaurarEstadoOriginal();
        }

        public void animacionNoCansado()
        {
            Storyboard cansadoStoryboard = (Storyboard)this.Resources["CansadoAnimation"];
            cansadoStoryboard.Stop(); // Detener la animación antes de restaurar el estado
            RestaurarEstadoOriginal(); // Aquí restauras los elementos visuales al estado original
        }


        public void ActivarAniIdle(bool activar)
        {
            Storyboard estandarStoryboard = (Storyboard)this.Resources["RespiracionRapida"];

            if (activar)
            {
                // Inicia la animación estándar del Pokémon
                estandarStoryboard.Begin();
            }
            else
            {
                // Detiene la animación estándar del Pokémon
                estandarStoryboard.Stop();
            }
        }

        public void activarAniIdle(bool activar)
        {
            throw new NotImplementedException();
        }
    }
}
