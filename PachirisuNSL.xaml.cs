using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class PachirisuNSL : UserControl, iPokemon
    {
        DispatcherTimer dtTime;
        public PachirisuNSL()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            StartIdleAnimation();
            //Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        public double Vida
        {
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }

        public double Energia
        {
            get { return this.pbEnergia.Value; }
            set { this.pbEnergia.Value = value; }
        }


        public string Nombre {
            get { return this.tbNombre.Text; }
            set { this.tbNombre.Text = value; }
        }
        public string Categoría {
            get { return this.tbCategoria.Text; }
            set { this.tbCategoria.Text = value; }
        }
        public string Tipo {
            get { return this.tbCategoria.Text; }
            set { this.tbCategoria.Text = value; }
        }
        public double Altura
        {
            get { return double.Parse(this.tbAltura.Text); }
            set { this.tbAltura.Text = value.ToString(); }
        }
        public double Peso
        {
            get { return double.Parse(this.tbPeso.Text); }
            set { this.tbPeso.Text = value.ToString(); }
        }
        public string Evolucion {
            get { return this.tbEvolucion.Text; }
            set { this.tbEvolucion.Text = value; }
        }
        public string Descripcion {
            get { return this.tbDescripcion.Text; }
            set { this.tbDescripcion.Text = value; }
        }

        
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus(FocusState.Programmatic);
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
            this.imYPotion.Visibility = Visibility.Collapsed;
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergia.Value += 0.5;
            if (pbEnergia.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }

        // Animaciones
        private void StartIdleAnimation()
        {
            Storyboard sb = (Storyboard)this.Resources["Idle"];
            sb.Begin();
        }

        public void verFondo(bool verfondo)
        {
            if (verfondo)
            {
                this.grPrincipal.Background.Opacity=100;
            }
            else
            {
                this.grPrincipal.Background.Opacity = 0;
            }
        }

        public void verFilaVida(bool ver)
        {
            this.pbVida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            this.imRPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            this.imCorazon.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }


        public void verFilaEnergia(bool ver)
        {
            this.pbEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            this.imYPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
            this.imEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            this.imRPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            this.imYPotion.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            this.tbNombre.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                Storyboard sb = (Storyboard)this.Resources["Escudo"];
                sb.Begin();
            }
            else
            {
                Storyboard sb = (Storyboard)this.Resources["Escudont"];
                sb.Begin();
            }
        }

        public void activarAniIdle(bool activar)
        {
            Storyboard sb = (Storyboard)this.Resources["Idle"];
            if (activar)
            {
                sb.RepeatBehavior = RepeatBehavior.Forever;
                sb.Begin();
            }
            else
            {
                sb.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard sb = (Storyboard)this.Resources["AtaqueDebil"];
            sb.Begin();
        }

        public void animacionAtaqueFuerte()
        {
            Storyboard sb = (Storyboard)this.Resources["AtaqueFuerte"];
            sb.Begin();
        }

        public void animacionDefensa()
        {
            Storyboard sb = (Storyboard)this.Resources["Escudo"];
            sb.Begin();
        }

        public void animacionDescasar()
        {
            Storyboard sb = (Storyboard)this.Resources["Mimir"];
            sb.Begin();
        }

        public void animacionCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["Cansado"];
            sb.Begin();
        }

        public void animacionNoCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["Cansado"];
            sb.Stop();
        }

        public void animacionHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["Herido"];
            sb.Begin();
        }

        public void animacionNoHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["Heridont"];
            sb.Begin();
        }

        public void animacionDerrota()
        {
            Storyboard sb = (Storyboard)this.Resources["Derrotado"];
            sb.Begin();
        }

        public void animacionReset()
        {
            Storyboard sb = (Storyboard)this.Resources["Derrotado"];
            sb.Stop();
            sb = (Storyboard)this.Resources["Mimir"];
            sb.Stop();
            sb = (Storyboard)this.Resources["Escudo"];
            sb.Stop();
        }

        //Animaciones con botones

        /*private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Number1)
            {
                Storyboard sb = (Storyboard)this.Resources["AtaqueDebil"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number2)
            {
                Storyboard sb = (Storyboard)this.Resources["AtaqueFuerte"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number3)
            {
                Storyboard sb = (Storyboard)this.Resources["Escudo"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number4)
            {
                Storyboard sb = (Storyboard)this.Resources["Escudont"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number5)
            {
                Storyboard sb = (Storyboard)this.Resources["Mimir"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number6)
            {
                Storyboard sb = (Storyboard)this.Resources["Mimirnt"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number7)
            {
                Storyboard sb = (Storyboard)this.Resources["Herido"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number8)
            {
                Storyboard sb = (Storyboard)this.Resources["Heridont"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Number9)
            {
                Storyboard sb = (Storyboard)this.Resources["Cansado"];
                sb.Begin();
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Q)
            {
                Storyboard sb = (Storyboard)this.Resources["Derrotado"];
                sb.Begin();
            }
        }*/
    }
}