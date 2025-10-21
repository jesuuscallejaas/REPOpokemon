using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class Porygon2DAR : UserControl, iPokemon
    {

        DispatcherTimer dtTimerSalud;
        DispatcherTimer dtTimerEnergia;

        Storyboard storyboardActual;

        MediaPlayer mpSonidos = new MediaPlayer();


        public double Vida
        {
            get { return (double)this.pbSalud.Value; }
            set { this.pbSalud.Value = (int)value; }
        }

        public double Energia
        {
            get { return (double)this.pbEnergia.Value; }
            set { this.pbEnergia.Value = (int)value; }
        }

        public string Nombre
        {
            get { return this.tbNombre.Text; }
            set { this.tbNombre.Text = value; }
        }

        public string categ = "Virtual";
        public string Categoria
        {
            get { return this.categ; }
            set { this.categ = value; }
        }

        public string tip = "Normal";
        public string Tipo
        {
            get { return this.tip; }
            set { this.tip = value; }
        }

        public double altu = 0.6;
        public double Altura
        {
            get { return this.altu; }
            set { this.altu = value; }
        }

        public double pes = 32.5;
        public double Peso
        {
            get { return this.pes; }
            set { this.pes = value; }
        }

        public string evol = "Porygon-Z";
        public string Evolucion
        {
            get { return this.evol; }
            set { this.evol = value; }
        }

        public string descrip = "Porygon2 fue creado por el hombre gracias a los avances de la ciencia. " +
            "Esta obra humana ha sido provista de inteligencia artificial que le permite aprender gestos y " +
            "sensaciones nuevas por su cuenta, desarrollando habilidades que antes no poseía, " +
            "convirtiéndose en una criatura única entre los Pokémon artificiales.";
        public string Descripcion
        {
            get { return this.descrip; }
            set {
                if (value.Length >= 200 && value.Length <= 500)
                    this.descrip = value;
                else
                    throw new ArgumentException("La descripción debe tener entre 200 y 500 caracteres. ");
            }
        }

        public string Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Porygon2DAR()
        {
            this.InitializeComponent();
            this.IsTabStop = true;

            sbNormal = (Storyboard)Resources["sbNormalKey"];
            sbNormalACansado = (Storyboard)Resources["sbNormalACansadoKey"];
            sbNormalAHerido = (Storyboard)Resources["sbNormalAHeridoKey"];
            sbCansado = (Storyboard)Resources["sbCansadoKey"];
            sbCansadoANormal = (Storyboard)Resources["sbCansadoANormalKey"];
            sbHerido = (Storyboard)Resources["sbHeridoKey"];
            sbHeridoANormal = (Storyboard)Resources["sbHeridoANormalKey"];
            sbAtaqueOnda = (Storyboard)Resources["sbAtaqueOndaKey"];
            sbAccionDefensiva = (Storyboard)Resources["sbAccionDefensivaKey"];
            sbQuitarEscudo = (Storyboard)Resources["sbQuitarEscudoKey"];
            sbAtaqueLanzamiento = (Storyboard)Resources["sbAtaqueLanzamientoKey"];
            sbAccionDescanso = (Storyboard)Resources["sbAccionDescansoKey"];
            sbDerrotado = (Storyboard)Resources["sbDerrotadoKey"];

            sbCansadoACansadoYHerido = (Storyboard)Resources["sbCansadoACansadoYHeridoKey"];
            sbHeridoACansadoYHerido = (Storyboard)Resources["sbHeridoACansadoYHeridoKey"];
            sbCansadoYHerido = (Storyboard)Resources["sbCansadoYHeridoKey"];
            sbCansadoYHeridoACansado = (Storyboard)Resources["sbCansadoYHeridoACansadoKey"];
            sbCansadoYHeridoAHerido = (Storyboard)Resources["sbCansadoYHeridoAHeridoKey"];
        }

      
        private void imgPocionRoja_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimerSalud = new DispatcherTimer();
            dtTimerSalud.Interval = TimeSpan.FromMilliseconds(100);
            dtTimerSalud.Tick += aumentarSalud;
            dtTimerSalud.Start();
            this.imgPocionRoja.Visibility = Visibility.Collapsed;
        }

        private void aumentarSalud(object sender, object e)
        {
            this.pbSalud.Value += 0.5;
            if (pbSalud.Value >= 100)
            {
                this.dtTimerSalud.Stop();
            }
        }

        private void imgPocionAmarilla_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimerEnergia = new DispatcherTimer();
            dtTimerEnergia.Interval = TimeSpan.FromMilliseconds(100);
            dtTimerEnergia.Tick += aumentarEnergia;
            dtTimerEnergia.Start();
            this.imgPocionAmarilla.Visibility = Visibility.Collapsed;
        }

        private void aumentarEnergia(object sender, object e)
        {
            this.pbEnergia.Value += 0.5;
            if (pbEnergia.Value >= 100)
            {
                this.dtTimerEnergia.Stop();
            }
        }





        public void verFondo(bool ver)
        {
            if (ver == true)
            {
                imgFondo.Visibility = Visibility.Visible;
            }
            else
            {
                imgFondo.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaVida(bool ver)
        {
            if (ver == true)
            {
                pbSalud.Visibility = Visibility.Visible;
                imgCorazon.Visibility = Visibility.Visible;
            }
            else
            {
                pbSalud.Visibility= Visibility.Collapsed;
                imgCorazon.Visibility = Visibility.Collapsed;
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if (ver == true)
            {
                pbEnergia.Visibility = Visibility.Visible;
                imgEnergia.Visibility = Visibility.Visible;
            }
            else
            {
                pbEnergia.Visibility= Visibility.Collapsed;
                imgEnergia.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionVida(bool ver)
        {
            if (ver == true)
            {
                imgPocionRoja.Visibility = Visibility.Visible;
            }
            else
            {
                imgPocionRoja.Visibility= Visibility.Collapsed;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver == true)
            {
                imgPocionAmarilla.Visibility = Visibility.Visible;
            }
            else
            {
                imgPocionAmarilla.Visibility= Visibility.Collapsed;
            }
        }

        public void verNombre(bool ver)
        {
            if (ver == true)
            {
                tbNombre.Visibility = Visibility.Visible;
            }
            else
            {
                tbNombre.Visibility= Visibility.Collapsed;
            }
        }

        public void verEscudo(bool ver)
        {
            if (ver == true)
            {
                imgEscudoProteccion.Opacity = 1;
            }
            else
            {
                sbQuitarEscudo.Begin();
            }
        }

        public void activarAniIdle(bool activar)
        {
            if (activar == true)
            {
                pararAnimacionActual();
                sbNormal.Begin();
                storyboardActual = sbNormal;
            }
            else
            {
                sbNormal.Stop();
                storyboardActual = null;
            }
        }

        public void animacionAtaqueFlojo()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPorygon2DAR/sonido_ondas.mp3"));
            mpSonidos.Play();
            sbAtaqueOnda.Begin();
        }

        public void animacionAtaqueFuerte()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPorygon2DAR/sonido_boomerang.mp3"));
            mpSonidos.Play();
            sbAtaqueLanzamiento.Begin();
        }

        public void animacionDefensa()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPorygon2DAR/sonido_accion_defensiva.mp3"));
            mpSonidos.Play();
            sbAccionDefensiva.Begin();
        }

        public void animacionDescansar()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPorygon2DAR/sonido_descanso.mp3"));
            mpSonidos.Play();
            sbAccionDescanso.Begin();
        }

        public void animacionCansado()
        {
            pararAnimacionActual();
            sbNormalACansado.Completed -= SbNormalACansado_Completed;
            sbNormalACansado.Completed += SbNormalACansado_Completed;
            sbNormalACansado.Begin();
        }

        private void SbNormalACansado_Completed(object sender, object e)
        {
            sbCansado.Begin();
            storyboardActual = sbCansado;
        }

        public void animacionNoCansado()
        {
            pararAnimacionActual();
            sbCansadoANormal.Begin();
        }

        public void animacionHerido()
        {
            pararAnimacionActual();
            sbNormalAHerido.Completed -= SbNormalAHerido_Completed;
            sbNormalAHerido.Completed += SbNormalAHerido_Completed;
            sbNormalAHerido.Begin();
        }

        private void SbNormalAHerido_Completed(object sender, object e)
        {
            sbHerido.Begin();
            storyboardActual = sbHerido;
        }

        public void animacionNoHerido()
        {
            pararAnimacionActual();
            sbHeridoANormal.Begin();
        }

        public void animacionDerrota()
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsPorygon2DAR/sonido_derrota.mp3"));
            mpSonidos.Play();
            sbDerrotado.Begin();
        }

        
        private void pararAnimacionActual()
        {
            if (storyboardActual != null)
            {
                storyboardActual.Stop();
                storyboardActual = null;
            }
        }


        // ////////////////////// //
        // ANIMACIONES COMBINADAS //
        // ////////////////////// //

        public void animacionCansadoACansadoYHerido()
        {
            pararAnimacionActual();
            sbCansadoACansadoYHerido.Completed -= SbCansadoACansadoYHerido_Completed;
            sbCansadoACansadoYHerido.Completed += SbCansadoACansadoYHerido_Completed;
            sbCansadoACansadoYHerido.Begin();
        }

        private void SbCansadoACansadoYHerido_Completed(object sender, object e)
        {
            sbCansadoYHerido.Begin();
            storyboardActual = sbCansadoYHerido;
        }

        public void animacionHeridoACansadoYHerido()
        {
            pararAnimacionActual();
            sbHeridoACansadoYHerido.Completed -= SbHeridoACansadoYHerido_Completed;
            sbHeridoACansadoYHerido.Completed += SbHeridoACansadoYHerido_Completed;
            sbHeridoACansadoYHerido.Begin();
        }

        private void SbHeridoACansadoYHerido_Completed(object sender, object e)
        {
            sbCansadoYHerido.Begin();
            storyboardActual = sbCansadoYHerido;
        }

        public void animacionCansadoYHeridoACansado()
        {
            pararAnimacionActual();
            sbCansadoYHeridoACansado.Completed -= SbCansadoYHeridoACansado_Completed;
            sbCansadoYHeridoACansado.Completed += SbCansadoYHeridoACansado_Completed;
            sbCansadoYHeridoACansado.Begin();
        }

        private void SbCansadoYHeridoACansado_Completed(object sender, object e)
        {
            sbCansado.Begin();
            storyboardActual = sbCansado;
        }

        public void animacionCansadoYHeridoAHerido()
        {
            pararAnimacionActual();
            sbCansadoYHeridoAHerido.Completed -= SbCansadoYHeridoAHerido_Completed;
            sbCansadoYHeridoAHerido.Completed += SbCansadoYHeridoAHerido_Completed;
            sbCansadoYHeridoAHerido.Begin();
        }

        private void SbCansadoYHeridoAHerido_Completed(object sender, object e)
        {
            sbHerido.Begin();
            storyboardActual = sbHerido;
        }

        public void animacionDescasar()
        {
            throw new NotImplementedException();
        }
    }

}
