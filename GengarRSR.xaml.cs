using ClassLibrary1_Prueba;
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


namespace IPOkemonApp
{
    public sealed partial class GengarRSR : UserControl, iPokemon
    {

        public double Vida
        {
            get { return this.ProgressBarVida.Value;}
            set { this.ProgressBarVida.Value = value;}
        }

        public double Energia
        {
            get { return this.ProgressBarEner.Value; }
            set { this.ProgressBarEner.Value = value; }
        }

        public string Nombre { get { return "Gengar"; } set { } }
        public string Categoría { get { return "Sombra"; } set { } }
        public string Tipo { get { return "Fantasma y Veneno"; } set { } }
        public double Altura { get { return 1.5; } set { } }
        public double Peso { get { return 40.5; } set { } }
        public string Evolucion { get { return "No tiene evolución como tal, Gengar es la segunda evolución de Gastly y la evolución de Haunter, aunque puede megaevolucionar a Mega-Gengar"; } set { } }
        public string Descripcion{ get {return "A pesar de su apariencia aterradora, Gengar es un Pokémon bromista que solo busca reírse asustando a humanos y Pokémon. Si un entrenador llega a tener uno, Gengar será fiel a él para siempre, e intentará que sea feliz. Siempre está riéndose y para él todo es un juego."; } set { } }

        public GengarRSR()
        {
            this.InitializeComponent();
            this.InitializeComponent();
            this.IsTabStop = true;
            this.Focus(FocusState.Programmatic);
        }


        private void enfadarOjoI(object sender, TappedRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["ojoIzqNegroKey"];
            sb.Begin();
        }

        private void enfadarOjoDerecho(object sender, TappedRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["ojoDerNegroKey"];
            sb.Begin();
        }


        private async void enfadarGengar(object sender, TappedRoutedEventArgs e)
        {
            // ===== TEMBLOR =====
            DoubleAnimation temblor = new DoubleAnimation
            {
                From = -3,
                To = 3,
                Duration = new Duration(TimeSpan.FromMilliseconds(100)),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(6)
            };

            Storyboard sbTemblor = new Storyboard();
            sbTemblor.Children.Add(temblor);

            // Asegurar que haya un TranslateTransform aplicado
            if (!(cvGengar.RenderTransform is TranslateTransform))
                cvGengar.RenderTransform = new TranslateTransform();

            Storyboard.SetTarget(temblor, cvGengar);
            Storyboard.SetTargetProperty(temblor, "(UIElement.RenderTransform).(TranslateTransform.X)");

            sbTemblor.Begin();

            // ===== CAMBIO DE COLOR DE OJOS =====
            Storyboard sbIzq = (Storyboard)this.Resources["ojoIzqNegroKey"];
            Storyboard sbDer = (Storyboard)this.Resources["ojoDerNegroKey"];
            sbIzq.Begin();
            sbDer.Begin();


            // ===== BOCA ENFADADA =====
            Storyboard sbBoca = (Storyboard)this.Resources["bocaEnfadadaKey"];
            Storyboard sbDientesOcultar = (Storyboard)this.Resources["dientesOcultarKey"];
            sbBoca.Begin();
            sbDientesOcultar.Begin();

            await Task.Delay(1000);

            // ===== VOLVER A NORMAL =====
            Storyboard sbBocaNormal = (Storyboard)this.Resources["bocaNormalKey"];
            Storyboard sbDientesMostrar = (Storyboard)this.Resources["dientesMostrarKey"];
            sbBocaNormal.Begin();
            await Task.Delay(200); // esperamos un poco para que la boca vuelva primero
            sbDientesMostrar.Begin();
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
            pocionVida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            pocionEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            gengar.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            escudo.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void activarAniIdle(bool activar)
        {
            var sbIdle = (Storyboard)this.Resources["IdleGengar"];
            sbIdle.Begin();
        }

        public void animacionAtaqueFlojo()
        {
            ResetDefensa();
            Storyboard sbAtaqueDebil = (Storyboard)this.Resources["ataqueDebilKey"];
            sndGolpe.Play(); // sonido de impacto
            sbAtaqueDebil.Begin();
        }

        public async void animacionAtaqueFuerte()
        {
            ResetDefensa();

            lengua.Visibility = Visibility.Visible; 

            AtaqueFuerteGengar.Begin();
            ((Storyboard)this.Resources["dientesOcultarKey"]).Begin();
            ((Storyboard)this.Resources["ImpactoVisualKey"]).Begin();

            ImpactoVisualElement.Visibility = Visibility.Visible;
            ImpactoVisualElement2.Visibility = Visibility.Visible;
            ImpactoVisualElement3.Visibility = Visibility.Visible;
            ImpactoVisualElement4.Visibility = Visibility.Visible;

            ImpactoVisualElement5.Visibility = Visibility.Visible;
            ImpactoVisualElement6.Visibility = Visibility.Visible;
            ImpactoVisualElement7.Visibility = Visibility.Visible;
            ImpactoVisualElement8.Visibility = Visibility.Visible;

            sndLengua.Play();

            await Task.Delay(500); // esperar a que acabe animación

            ((Storyboard)this.Resources["dientesMostrarKey"]).Begin();

            // ===== VOLVER A NORMAL =====
            ((Storyboard)this.Resources["bocaNormalKey"]).Begin();
            ((Storyboard)this.Resources["dientesMostrarKey"]).Begin();

            ImpactoVisualElement.Visibility = Visibility.Collapsed;
            ImpactoVisualElement2.Visibility = Visibility.Collapsed;
            ImpactoVisualElement3.Visibility = Visibility.Collapsed;
            ImpactoVisualElement4.Visibility = Visibility.Collapsed;

            ImpactoVisualElement5.Visibility = Visibility.Collapsed;
            ImpactoVisualElement6.Visibility = Visibility.Collapsed;
            ImpactoVisualElement7.Visibility = Visibility.Collapsed;
            ImpactoVisualElement8.Visibility = Visibility.Collapsed;

            await Task.Delay(200);
        }

        public void animacionDefensa()
        {
            escudo.Visibility = Visibility.Visible;
            DestelloDefensa.Visibility = Visibility.Visible;
            AuraEscudo.Visibility = Visibility.Visible;
            sndDefensa.Play();

            var animacionEscudo = (Storyboard)this.Resources["DefensaGengar"];
            animacionEscudo.Begin();
        }

        private void ResetDefensa()
        {
            escudo.Visibility = Visibility.Collapsed;
            DestelloDefensa.Visibility = Visibility.Collapsed;
            AuraEscudo.Visibility = Visibility.Collapsed;

            Particula1.Opacity = 0;
            Particula2.Opacity = 0;
            Particula3.Opacity = 0;

            cvGengar.Opacity = 1;
        }

        public async void animacionDescasar()
        {
            ResetDefensa();  // Restablecer defensa, si es necesario

            // Reproducir sonido de descanso
            sndDescanso.Play();

            // Iniciar la animación de descanso
            var sbDescanso = (Storyboard)this.Resources["DescansarGengar"];
            sbDescanso.Begin();

            // Activar las animaciones de ojos dormidos y boca cerrada
            var sbOjosDormidos = (Storyboard)this.Resources["ojoDormidoKey"];
            var sbBocaCerrada = (Storyboard)this.Resources["bocaCerradaKey"];
            sbOjosDormidos.Begin();
            sbBocaCerrada.Begin();

            // Mostrar "zzz" y las estrellas
            imgZzz.Visibility = Visibility.Visible;
            estrella1.Visibility = Visibility.Visible;
            estrella2.Visibility = Visibility.Visible;
            estrella3.Visibility = Visibility.Visible;
            estrella4.Visibility = Visibility.Visible;
            estrella5.Visibility = Visibility.Visible;
            estrella6.Visibility = Visibility.Visible;

            // Esperar unos segundos (para dar tiempo a la animación de descanso)
            await Task.Delay(4000);  // Aquí se espera el tiempo de la animación de descanso

            // Restaurar a su estado original
            ((Storyboard)this.Resources["RestaurarOjosNormales"]).Begin();
            ((Storyboard)this.Resources["bocaNormalKey"]).Begin();
            ((Storyboard)this.Resources["dientesMostrarKey"]).Begin();

            // Ocultar "zzz" y las estrellas
            imgZzz.Visibility = Visibility.Collapsed;
            estrella1.Visibility = Visibility.Collapsed;
            estrella2.Visibility = Visibility.Collapsed;
            estrella3.Visibility = Visibility.Collapsed;
            estrella4.Visibility = Visibility.Collapsed;
            estrella5.Visibility = Visibility.Collapsed;
            estrella6.Visibility = Visibility.Collapsed;
        }


        public void animacionCansado()
        {
            ResetDefensa();

            var sbCansado = (Storyboard)this.Resources["CansadoGengar"];
            sbCansado.Begin();

            var sbDientes = (Storyboard)this.Resources["dientesOcultarKey"];
            sbDientes.Begin();
        }

        public void animacionNoCansado()
        {

            var sbCansado = (Storyboard)this.Resources["CansadoGengar"];
            sbCansado.Stop();

            var sbBocaNormal = (Storyboard)this.Resources["bocaNormalKey"];
            sbBocaNormal.Begin();

            var sbDientes = (Storyboard)this.Resources["dientesMostrarKey"];
            sbDientes.Begin();

            Gota1.Visibility = Visibility.Collapsed;
            Gota2.Visibility = Visibility.Collapsed;
        }

        public void animacionHerido()
        {
            ResetDefensa();
            var sbHerido = (Storyboard)this.Resources["HeridoGengar"];
            sbHerido.Begin();
            // Reproducir sonido de llanto
            sndLloro.Play();
        }

        public void animacionNoHerido()
        {
            var sbHerido = (Storyboard)this.Resources["HeridoGengar"];
            sbHerido.Stop();
            sndLloro.Stop();
            corazonHerido.Visibility = Visibility.Collapsed;
            lagrimaIzq.Visibility = Visibility.Collapsed;
            lagrimaDer.Visibility = Visibility.Collapsed;
        }

        public void animacionDerrota()
        {
            // Iniciar animación derrotado
            ResetDefensa();
            var sbDerrotado = (Storyboard)this.Resources["DerrotadoGengar"];
            sbDerrotado.Begin();
        }
    }
}
