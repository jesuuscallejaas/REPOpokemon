using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class DunsparcePCA : UserControl,iPokemon
    {
        DispatcherTimer dtTime;

        public DunsparcePCA()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        { 
            if (args.VirtualKey == Windows.System.VirtualKey.Number1)
            {
                muerte_start();
            }
            if (args.VirtualKey == Windows.System.VirtualKey.Number2)
            {
                ResetPokemon();
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.im_pocionVida.Visibility = Visibility.Collapsed;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pb_vida.Value += 0.5;
            if (pb_vida.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }
        private void idle_start()
        {
            sb_aleteo.Begin();
            sb_cola.Begin();
            sb_parpadeo.Begin();
        }

        private void idle_stop()
        {
            sb_aleteo.Stop();
            sb_cola.Stop();
            sb_parpadeo.Stop();
        }

        private void escudo_start()
        {
            meEscudo.Play();
            sb_escudo.Begin();
        }
        private void ataqueDebil_start()
        {
            meVeneno.Play();
            sb_ataqueDebil.Begin();

        }
        private void SbAtaqueDebil_Completed(object sender, object e)
        {
            // Restablecer las propiedades de los elementos a su estado original

            // Restablecer la cola
            if (cola.RenderTransform is CompositeTransform)
            {
                ((CompositeTransform)cola.RenderTransform).Rotation = 0;
            }
            else
            {
                cola.RenderTransform = new CompositeTransform();
            }

            // Restablecer la flecha
            imFlecha.RenderTransform = new CompositeTransform
            {
                Rotation = -130,
                ScaleX = -1
            };
            imFlecha.Opacity = 0;

            // Restablecer el veneno
            if (imVeneno.RenderTransform is CompositeTransform)
            {
                ((CompositeTransform)imVeneno.RenderTransform).TranslateY = 0;
            }
            else
            {
                imVeneno.RenderTransform = new CompositeTransform();
            }
            imVeneno.Opacity = 0;
        }

        private void ataqueFuerte_start()
        {
            mePiedras.Play();
            sb_ataqueFuerte.Begin(); // Inicia la animación fuerte

        }

        private void SbAtaqueFuerte_Completed(object sender, object e)
        {
            // Restablece la posición del Pokémon y la piedra
            if (vb_pokemon.RenderTransform is CompositeTransform pokemonTransform)
            {
                pokemonTransform.TranslateX = 0;
            }
            else
            {
                vb_pokemon.RenderTransform = new CompositeTransform();
            }

            if (imPiedra.RenderTransform is CompositeTransform piedraTransform)
            {
                piedraTransform.TranslateX = 0;
            }
            else
            {
                imPiedra.RenderTransform = new CompositeTransform();
            }
            imPiedra.Opacity = 0; // Asegura que la piedra esté oculta
        }

        private void SbMuerte_Completed(object sender, object e)
        {
            // Aquí puedes añadir lógica adicional para cuando termine la animación de muerte
            // Por ejemplo, mostrar un mensaje, reiniciar el juego, etc.
        }

        private async void muerte_start()
        {
            idle_stop();
            await Task.Delay(500);// Detiene animaciones idle
            sb_muerte.Begin(); // Inicia la animación de muerte
            await Task.Delay(2000); // Espera a que termine la animación
                                    // Aquí puedes añadir lógica adicional
        }

        private void curacion_start()
        {

            imCuracion.RenderTransform = new CompositeTransform();
            imCuracion.Opacity = 0;
            meCuracion.Play();
            sb_curacion.Begin();

        }

        private void SbCuracion_Completed(object sender, object e)
        {
            // Restablece la imagen de curación
            imCuracion.Opacity = 0;
            if (imCuracion.RenderTransform is CompositeTransform transform)
            {
                transform.TranslateY = 0;
            }

            // Restablece colores del Pokémon
            var gradient = Cuerpo.Fill as LinearGradientBrush;
            if (gradient != null && gradient.GradientStops.Count > 1)
            {
                gradient.GradientStops[0].Color = Windows.UI.Color.FromArgb(255, 255, 229, 0); // #FFFFE500
                gradient.GradientStops[1].Color = Windows.UI.Color.FromArgb(255, 0, 132, 255);  // #FF0084FF
            }
        }


        private void pocaVida_start()
        {


            // Iniciar animación de poca vida
            mePocaVida.Play();
            sb_pocaVida.Begin();
            

            // Opcional: Cambiar expresión ojos (si tienes elementos para esto)
            p_lineaOjoIzq.Stroke = new SolidColorBrush(Colors.Red);
            p_lineaOjoDcho.Stroke = new SolidColorBrush(Colors.Red);
        }

        private void pocaVida_stop()
        {
            // Detener animación
            mePocaVida.Pause();
            sb_pocaVida.Stop();

            // Restaurar valores normales
            Cuerpo.Opacity = 1;
            var gradient = Cuerpo.Fill as LinearGradientBrush;
            if (gradient != null && gradient.GradientStops.Count > 1)
            {
                gradient.GradientStops[0].Color = Windows.UI.Color.FromArgb(255, 255, 229, 0); // #FFFFE500
                gradient.GradientStops[1].Color = Windows.UI.Color.FromArgb(255, 0, 132, 255); // #FF0084FF
            }

            // Restaurar ojos
            p_lineaOjoIzq.Stroke = new SolidColorBrush(Colors.Black);
            p_lineaOjoDcho.Stroke = new SolidColorBrush(Colors.Black);

            // Volver a animaciones normales

        }

        private void pocaEnergia_start()
        {


            // Iniciar animación de poca energía
            sb_pocaEnergia.Begin();

            // Opcional: Cambiar expresión de los ojos (líneas más delgadas)
            p_lineaOjoIzq.StrokeThickness = 0.5;
            p_lineaOjoDcho.StrokeThickness = 0.5;
        }

        private void pocaEnergia_stop()
        {
            // Detener animación
            sb_pocaEnergia.Stop();

            // Restaurar colores originales
            var gradient = Cuerpo.Fill as LinearGradientBrush;
            if (gradient != null && gradient.GradientStops.Count > 1)
            {
                gradient.GradientStops[0].Color = Windows.UI.Color.FromArgb(255, 255, 229, 0); // #FFFFE500
                gradient.GradientStops[1].Color = Windows.UI.Color.FromArgb(255, 0, 132, 255);  // #FF0084FF
            }

            // Restaurar ojos
            p_lineaOjoIzq.Opacity = 1;
            p_lineaOjoDcho.Opacity = 1;
            p_lineaOjoIzq.StrokeThickness = 1;
            p_lineaOjoDcho.StrokeThickness = 1;


        }


        private void ResetPokemon()
        {
            // 1. Detener todas las animaciones posibles
            sb_aleteo.Stop();
            sb_cola.Stop();
            sb_parpadeo.Stop();
            sb_escudo.Stop();
            sb_ataqueDebil.Stop();
            sb_ataqueFuerte.Stop();
            sb_muerte.Stop();
            sb_curacion.Stop();
            sb_pocaVida.Stop();
            sb_pocaEnergia.Stop();

            // 2. Restablecer transformaciones del Pokémon
            if (vb_pokemon.RenderTransform is CompositeTransform pokemonTransform)
            {
                pokemonTransform.TranslateX = 0;
                pokemonTransform.TranslateY = 0;
            }
            else
            {
                vb_pokemon.RenderTransform = new CompositeTransform();
            }

            // 3. Restablecer rotación del canvas principal
            if (Pokemon.RenderTransform is RotateTransform rotateTransform)
            {
                rotateTransform.Angle = 0;
            }
            else
            {
                Pokemon.RenderTransform = new RotateTransform { Angle = 0 };
            }

            // 4. Restablecer alas
            Ala_izq.RenderTransform = new CompositeTransform { Rotation = 0 };
            Ala_dcha.RenderTransform = new CompositeTransform { Rotation = -2 }; // Valor inicial que tenías

            // 5. Restablecer cola
            cola.RenderTransform = new CompositeTransform { Rotation = 0 };

            // 6. Restablecer colores del cuerpo
            var gradient = Cuerpo.Fill as LinearGradientBrush;
            if (gradient != null && gradient.GradientStops.Count > 1)
            {
                gradient.GradientStops[0].Color = Windows.UI.Color.FromArgb(255, 255, 229, 0); // #FFFFE500
                gradient.GradientStops[1].Color = Windows.UI.Color.FromArgb(255, 0, 132, 255);  // #FF0084FF
            }

            // 7. Restablecer ojos
            p_lineaOjoIzq.Stroke = new SolidColorBrush(Colors.Black);
            p_lineaOjoDcho.Stroke = new SolidColorBrush(Colors.Black);
            p_lineaOjoIzq.StrokeThickness = 1;
            p_lineaOjoDcho.StrokeThickness = 1;
            p_lineaOjoIzq.Opacity = 1;
            p_lineaOjoDcho.Opacity = 1;

            // 8. Ocultar cruces de ojos (si las hay)
            if (cruzOjoIzq != null) cruzOjoIzq.Opacity = 0;
            if (cruzOjoDcho != null) cruzOjoDcho.Opacity = 0;

            // 9. Restablecer elementos de ataque/efectos
            imFlecha.Opacity = 0;
            imFlecha.RenderTransform = new CompositeTransform { Rotation = -130, ScaleX = -1 };

            imVeneno.Opacity = 0;
            if (imVeneno.RenderTransform is CompositeTransform venenoTransform)
            {
                venenoTransform.TranslateY = 0;
            }

            imPiedra.Opacity = 0;
            if (imPiedra.RenderTransform is CompositeTransform piedraTransform)
            {
                piedraTransform.TranslateX = 0;
            }

            imEscudo.Opacity = 0;
            imCuracion.Opacity = 0;
            if (imCuracion.RenderTransform is CompositeTransform curacionTransform)
            {
                curacionTransform.TranslateY = 0;
            }

        }

        
        public double Vida
        {
            get => pb_vida.Value;
            set
            {
                pb_vida.Value = value;
                // Activar animación de poca vida si es menor al 30%
                if (value < 30)
                {
                    pocaVida_start();
                }
                else
                {
                    pocaVida_stop();
                }
            }
        }

        public double Energia
        {
            get => pb_energia.Value;
            set
            {
                pb_energia.Value = value;
                // Activar animación de poca energía si es menor al 30%
                if (value < 30)
                {
                    pocaEnergia_start();
                }
                else
                {
                    pocaEnergia_stop();
                }
            }
        }

        public string Nombre
        {
            get => tb_nombrePokemon.Text;
            set => tb_nombrePokemon.Text = value;
        }

        public string Categoría { get; set; } = "Pokémon Tierra-Serpiente";
        public string Tipo { get; set; } = "Normal";
        public double Altura { get; set; } = 1.5;
        public double Peso { get; set; } = 14.0;
        public string Evolucion { get; set; } = "Ninguna";
        public string Descripcion { get; set; } = "Dunspare es conocido por su habilidad para volar a pesar de sus pequeñas alas.";

        public void verFondo(bool ver)
        {
            imFondo.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            im_corazon.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            pb_vida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            im_energia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            pb_energia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            im_pocionVida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            im_pocionEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            tb_nombrePokemon.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            if (ver)
                escudo_start();
            else
                imEscudo.Opacity = 0;
        }

        public void activarAniIdle(bool activar)
        {
            if (activar)
                idle_start();
            else
                idle_stop();
        }

        public void animacionAtaqueFlojo()
        {
            ataqueDebil_start();
        }

        public void animacionAtaqueFuerte()
        {
            ataqueFuerte_start();
        }

        public void animacionDefensa()
        {
            escudo_start();
        }

        public void animacionDescasar()
        {
            curacion_start();
        }

        public void animacionCansado()
        {
            pocaEnergia_start();
        }

        public void animacionNoCansado()
        {
            pocaEnergia_stop();
        }

        public void animacionHerido()
        {
            pocaVida_start();
        }

        public void animacionNoHerido()
        {
            pocaVida_stop();
        }

        public void animacionDerrota()
        {
            muerte_start();
        }

    }
}
