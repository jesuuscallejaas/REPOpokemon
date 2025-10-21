using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ClassLibrary1_Prueba;
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


namespace IPOkemonApp
{
    public sealed partial class WartortleAAA : UserControl, iPokemon
    {
        private double vida = 100;
        private double energia = 100;
        private bool estaCansado = false;
        private bool estaDerrotado = false;
        private bool estaHerido = false;

        public double Vida
        {
            get { return this.ProgressBarVida.Value; }
            set { this.ProgressBarVida.Value = value; }
        }

        public double Energia
        {
            get { return this.ProgressBarEner.Value; }
            set { this.ProgressBarEner.Value = value; }
        }

        public string Nombre { get { return "Wartortle"; } set { } }
        public string Categoría { get { return "Tortuga"; } set { } }
        public string Tipo { get { return "Agua"; } set { } }
        public double Altura { get { return 1; } set { } }
        public double Peso { get { return 22.5; } set { } }
        public string Evolucion { get { return "Preevolucion: Squirtle, evolucion Blastoise"; } set { } }
        public string Descripcion { get { return "Wartortle es la forma evolucionada de Squirtle, y representa una transición hacia una criatura más fuerte, resistente y estratégica. Aunque mantiene su tipo Agua, su diseño y personalidad reflejan una madurez respecto a su pre-evolución. Es un Pokémon que combina agilidad con resistencia, siendo comúnmente representado como un defensor leal y tenaz.\r\n\r\nFísicamente, conserva el caparazón característico, pero con una apariencia más robusta y detalles afilados. Su rasgo más distintivo es su cola peluda y blanca, parecida a una nube o a un remolino de espuma marina. Esta cola no solo tiene un valor estético; según la Pokédex, Wartortle la utiliza para equilibrarse mientras nada a gran velocidad. Además, se dice que los ejemplares más longevos tienen la cola más oscura y densa, convirtiéndose en símbolo de sabiduría y experiencia."; } set { } }



        public WartortleAAA()
        {
            this.InitializeComponent();


        }

        private void ReducirVida(object sender, TappedRoutedEventArgs e)
        {
            double valorActualSalud = ProgressBarVida.Value;



                valorActualSalud = valorActualSalud - 10;
                ProgressBarVida.Value = valorActualSalud;


        }

        private void AumentarVida(object sender, TappedRoutedEventArgs e)
        {
            double valorActual = ProgressBarVida.Value;
            valorActual += 10;
            if (valorActual > 100)
            {
                valorActual = 100;
            }
            ProgressBarVida.Value = valorActual;
           
        }


        private void ReducirEnergia(object sender, TappedRoutedEventArgs e)
        {
            double valorActualEnergia = ProgressBarEner.Value;



                valorActualEnergia -= 10;
                ProgressBarEner.Value = valorActualEnergia;
            
   
            
                Storyboard sb_cansado = (Storyboard)this.Resources["Cansado"];
                sb_cansado.Begin();
            

        }

        private void AumentarEnergia(object sender, TappedRoutedEventArgs e)
        {
            double valorActual = ProgressBarEner.Value;
            valorActual += 10;
            if (valorActual > 100)
            {
                valorActual = 100;
            }


        }

        public void verFondo(bool ver)
        {
            fondoPokemon.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            ProgressBarVida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            ProgressBarEner.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            vidaPot.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }
        public void verIconoVida(bool ver)
        {
            salud.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }


        public void verPocionEnergia(bool ver)
        {
            pocenergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }
        public void verIconoEnergia(bool ver)
        {
            energiaIcono.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }


        public void verNombre(bool ver)
        {
            Wartortle.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)

        {
            SonidoEscudo.Play();
            EscudoGigante.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void activarAniIdle(bool activar)
        {
            double valorActualEnergia = ProgressBarEner.Value;
            double valorActualVida = ProgressBarVida.Value;

            if (activar)
            {


                // Restaurar estado visual
                Sudor.Visibility = Visibility.Collapsed;
                IrisIzq.Opacity = 1;
                IrisDer.Opacity = 1;
                BocaTranslate.Y = 0;
                BocaScale.ScaleY = 1;
                TransformacionWartortle.Y = 0;

                    Diente1.Visibility = Visibility.Visible;
                    HeridaVisual.Visibility = Visibility.Collapsed;
                    HeridaVisual2.Visibility = Visibility.Collapsed;
                    IrisIzq.Fill = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 166, 64, 11)); // #A6400B
                    SonidoHerido.Stop();
                

               
             
                
            }
        }


        public void animacionAtaqueFlojo()
        {
            double valorActualEnergia = ProgressBarEner.Value;


       
            
                Storyboard sb_debil = (Storyboard)this.Resources["AtaqueDebil"];
                sb_debil.Begin();


                SonidoDebil.Play();

            


        }

        public async void animacionAtaqueFuerte()
        {
            


           Storyboard sb_fuerte = (Storyboard)this.Resources["AtaqueFuerte"];
           sb_fuerte.Begin();


           SonidoFuerte.Play();


            


        }



        public void animacionCansado()
        {
            Storyboard sb_cansado = (Storyboard)this.Resources["Cansado"];
            sb_cansado.Begin();
        }

        public void animacionNoCansado()
        {
            Sudor.Visibility = Visibility.Collapsed;
            IrisIzq.Opacity = 1;
            IrisDer.Opacity = 1;
            TransformacionWartortle.Y = 0;

        }

        public void animacionHerido()
        {
            Storyboard sb_herido = (Storyboard)this.Resources["Herido"];
            sb_herido.Begin();
            SonidoHerido.Play();
        }

        public void animacionNoHerido()
        {
            // Mostrar diente de nuevo
            Diente1.Visibility = Visibility.Visible;

            // Ocultar imagen de herida
            HeridaVisual.Visibility = Visibility.Collapsed;
            // Ocultar imagen de herida
            HeridaVisual2.Visibility = Visibility.Collapsed;

            // Restaurar color original del iris izquierdo
            // Restaurar color del ojo
            IrisIzq.Fill = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 166, 64, 11)); // #A6400B

            SonidoHerido.Stop();
        }

        public void animacionDerrota()
        {
            OjoIzq.Visibility = Visibility.Collapsed;
            OjoDer.Visibility = Visibility.Collapsed;

            OjoXIzq.Visibility = Visibility.Visible;
            OjoXDer.Visibility = Visibility.Visible;

            Debug.WriteLine("KO activado");

            SonidoKO.Play();
            Debug.WriteLine("Probando sonido manual");


            Storyboard sb_ko = (Storyboard)this.Resources["KO"];
            sb_ko.Begin();

            SonidoHerido.Stop();
        }

        public void animacionDescasar()
        {
            double valorActualSalud = ProgressBarVida.Value;
            double valorActualEnerg = ProgressBarEner.Value;



                SnorePlayer.MediaPlayer.Volume = 0.3;
                SnorePlayer.MediaPlayer.Play();

                // Llamamos a la animación 'Descansar' desde los recursos XAML
                Storyboard sb_dorm = (Storyboard)this.Resources["Descansar"];
                sb_dorm.Begin();



        }

        public async void animacionDefensa()
        {
            // Mostrar escudo y campo antes de iniciar la animación
            EscudoGigante.Visibility = Visibility.Visible;
            CampoDeFuerza.Visibility = Visibility.Visible;

            // Iniciar animación
            Storyboard sb_defensa = (Storyboard)this.Resources["Defensa"];
            sb_defensa.Begin();

            // Esperar 3 segundos
            await Task.Delay(3000);

            // Detener animación (opcional si no es AutoReverse o Loop)
            sb_defensa.Stop();

            // Ocultar escudo y campo después del tiempo
            EscudoGigante.Visibility = Visibility.Collapsed;
            CampoDeFuerza.Visibility = Visibility.Collapsed;
        }

    }
}