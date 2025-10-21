// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using ClassLibrary1_Prueba;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace IPOkemonApp
{
    public sealed partial class DratiniGFS : UserControl, iPokemon
    {
        DispatcherTimer dtTime;
        public DratiniGFS()
        {
            this.InitializeComponent();
            this.Loaded += DratiniGFS_Loaded;
            this.Focus(FocusState.Programmatic);
            this.IsTabStop = true;
            this.KeyDown += controlTeclas;
        }

        public double Vida
        {
            get { return pbVida.Value; }
            set { pbVida.Value = value; }
        }

        public double Energia
        {
            get { return pbEnergia.Value; }
            set { pbEnergia.Value = value; }
        }

        public string Nombre { get; set; } = "Dratini";
        public string Categoría { get; set; } = "Dragón";
        public string Tipo { get; set; } = "Dragón";
        public double Altura { get; set; } = 1.8; // en metros
        public double Peso { get; set; } = 3.3;   // en kilogramos
        public string Evolucion { get; set; } = "Dragonair -> Dragonite";
        public string Descripcion { get; set; } = "Un Pokémon serpentino que vive en las profundidades del mar. A medida que crece, muda su piel muchas veces.";

        public void verFondo(bool verfondo)
        {
            if (!verfondo) { this.imFondo.Source = null; }
            else { this.imFondo.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///AssetsDratiniGFS/fondoPokemon.jpg")); }
        }


        private void DratiniGFS_Loaded(object sender, RoutedEventArgs e)
        {
            movBase.Begin();
            rotaciónOrejas.Begin();
        }

        private void animacionBase()
        {
            movBase.Begin();
            rotaciónOrejas.Begin();
        }

        private void animacionBaseStop()
        {
            movBase.Stop();
            rotaciónOrejas.Stop();
        }

        private void StartEstadoCansado()
        {
            // Iniciar la animación de estado cansado
            estadoCansado.Begin();

            // Hacer más lento el movimiento base
            movBase.SpeedRatio = 0.5; // Ajusta la velocidad a la mitad, haciendo la animación más lenta

            // Hacer más lenta la animación de las orejas
            rotaciónOrejas.SpeedRatio = 0.5; // Ajusta la velocidad a la mitad, haciendo la animación más lenta
        }

        private void StopEstadoCansado()
        {
            // Iniciar la animación de estado cansado
            estadoCansado.Stop();

            // Hacer más lento el movimiento base
            movBase.SpeedRatio = 1; // Ajusta la velocidad a la mitad, haciendo la animación más lenta

            // Hacer más lenta la animación de las orejas
            rotaciónOrejas.SpeedRatio = 1; // Ajusta la velocidad a la mitad, haciendo la animación más lenta
        }

        private void StartEstadoHerido()
        {
            movBase.Stop(); // Detener la animación de movimiento base
            // Iniciar la animación de estado cansado
            estadoHerido.Begin();

        }

        private void StopEstadoHerido()
        {
            movBase.Begin(); // Detener la animación de movimiento base
            // Iniciar la animación de estado cansado
            estadoHerido.Stop();

        }

        private void StartEstadoDerrotado()
        {
            movBase.Stop(); // Detener la animación de movimiento base
            // Iniciar la animación de estado cansado
            estadoDerrotado.Begin();

        }

        private void StopEstadoDerrotado()
        {
            movBase.Begin(); // Detener la animación de movimiento base
            // Iniciar la animación de estado cansado
            estadoDerrotado.Stop();

        }

        private void ataqueDébil()
        {
            // Iniciar la animación de ataque débil
            animaciónAtaqueDébil.Begin();
        }

        private void ataqueFuerte()
        {
            // Iniciar la animación de ataque fuerte
            animaciónAtaqueFuerte.Begin();
        }


        private void ponerEscudo()
        {
            // Iniciar la animación de escudo
            imBurbuja.Visibility = Visibility.Visible;
            animaciónEscudo.Begin();
        }

        private void descansar()
        {
            // Iniciar la animación de descanso
            animaciónDescanso.Begin();

        }

        private void controlTeclas(object sender, KeyRoutedEventArgs e)
        {
            // Verificar que la tecla presionada sea una tecla numérica (1-9)
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    StartEstadoDerrotado();  // Iniciar estado derrotado
                    break;
                case Windows.System.VirtualKey.Number2:
                    StopEstadoDerrotado();  // Detener estado derrotado
                    break;
                case Windows.System.VirtualKey.Number3:
                    StartEstadoCansado();  // Iniciar estado cansado
                    break;
                case Windows.System.VirtualKey.Number4:
                    StopEstadoCansado();  // Detener estado cansado
                    break;
                case Windows.System.VirtualKey.Number5:
                    StopEstadoHerido();  // Detener estado herido
                    break;
                case Windows.System.VirtualKey.Number6:
                    StartEstadoHerido();  // Iniciar estado herido
                    break;
                case Windows.System.VirtualKey.Number7:
                    ataqueDébil();  // Iniciar ataque débil
                    break;
                case Windows.System.VirtualKey.Number8:
                    ataqueFuerte();  // Iniciar ataque fuerte
                    break;
                case Windows.System.VirtualKey.Number9:
                    ponerEscudo();  // Iniciar escudo
                    break;
                case Windows.System.VirtualKey.Number0:
                    descansar();  // Iniciar descanso
                    break;
                case Windows.System.VirtualKey.A:
                    usarPocimaEnergia(sender, null);  // Usar pócima de energía
                    break;
                case Windows.System.VirtualKey.S:
                    usarPocimaVida(sender, null);  // Usar pócima de vida
                    break;
                default:
                    break;
            }
        }

        private void GridBase_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void usarPocimaVida(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.impocionVida.Visibility = Visibility.Collapsed;
        }

        private void increaseHealth(object sender, object e)
        {
            this.pbVida.Value += 0.5;
            if (pbVida.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }

        private void usarPocimaEnergia(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEnergy;
            dtTime.Start();
            this.impocionEnergía.Visibility = Visibility.Collapsed;
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergia.Value += 0.5;
            if (pbEnergia.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }

        private void pbVida_Tapped(object sender, TappedRoutedEventArgs e)
        {
            usarPocimaVida(sender, null);
        }

        private void pbEnergía_Tapped(object sender, TappedRoutedEventArgs e)
        {
            usarPocimaEnergia(sender, null);
        }
        private void pbVida_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }


        public void verFilaVida(bool ver)
        {
            if (!ver) this.GridBase.RowDefinitions[0].Height = new GridLength(0);
            else this.GridBase.RowDefinitions[0].Height = new GridLength(5, GridUnitType.Star);

        }


        public void verFilaEnergia(bool ver)
        {
            if (!ver) this.GridBase.RowDefinitions[1].Height = new GridLength(0);
            else this.GridBase.RowDefinitions[1].Height = new GridLength(5, GridUnitType.Star);
        }

        public void verPocionVida(bool ver)
        {
            if (ver) { this.impocionVida.Visibility = Visibility.Visible; }
            else { this.impocionVida.Visibility = Visibility.Collapsed; }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver) { this.impocionEnergía.Visibility = Visibility.Visible; }
            else { this.impocionEnergía.Visibility = Visibility.Collapsed; }
        }

        public void verNombre(bool ver)
        {
            if (ver) { this.txtNombre.Visibility = Visibility.Visible; }
            else { this.txtNombre.Visibility = Visibility.Collapsed; }
        }

        public void verEscudo(bool ver)
        {
            if (ver) { this.imBurbuja.Visibility = Visibility.Visible; }
            else { this.imBurbuja.Visibility = Visibility.Collapsed; }
        }

        public void activarAniIdle(bool activar)
        {
            if (activar) { animacionBase(); }
            else { animacionBaseStop(); }

        }

        public void animacionAtaqueFlojo()
        {
            ataqueDébil();
        }

        public void animacionAtaqueFuerte()
        {
            ataqueFuerte();
        }

        public void animacionDefensa()
        {
            ponerEscudo();
        }

        public void animacionDescasar()
        {
            descansar();
        }

        public void animacionCansado()
        {
            StartEstadoCansado();
        }

        public void animacionNoCansado()
        {
            StopEstadoCansado();
        }

        public void animacionHerido()
        {
            StartEstadoHerido();
        }

        public void animacionNoHerido()
        {
            StopEstadoHerido();
        }

        public void animacionDerrota()
        {
            StartEstadoDerrotado();
        }
    }
}
