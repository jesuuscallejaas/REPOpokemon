using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp

{
    public sealed partial class AzumarillEFAR : UserControl, iPokemon
    {

        DispatcherTimer dtTime;

        //private int vida;

        public double Vida { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Energia { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Altura { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Peso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Evolucion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AzumarillEFAR()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            PokeNimations.Begin(); // Inicia la animación automáticamente
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
        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEnergi;
            dtTime.Start();
            this.imYPotion.Visibility = Visibility.Collapsed;

        }
        private void increaseEnergi(object sender, object e)
        {
            this.pbEnergy.Value += 0.5;
            if (pbEnergy.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }

        public void verFondo(bool ver)
        {
            //No tengo fondo mi pokemon vuela en el vacio del abismo 
        }

        public void verFilaVida(bool ver)
        {
            if (!ver) { this.pbHealth.Visibility = Visibility.Collapsed; this.imCorazon.Visibility = Visibility.Collapsed; }
            else { this.pbHealth.Visibility = Visibility.Visible; this.imCorazon.Visibility = Visibility.Visible; }
        }

        public void verFilaEnergia(bool ver)
        {
            if (!ver) { this.pbEnergy.Visibility = Visibility.Collapsed; this.imEnergia.Visibility = Visibility.Collapsed; }
            else { this.pbEnergy.Visibility = Visibility.Visible; this.imEnergia.Visibility = Visibility.Visible; }
        }

        public void verPocionVida(bool ver)
        {
            if (ver) imRPotion.Visibility = Visibility.Visible;
            else imRPotion.Visibility = Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver) imYPotion.Visibility = Visibility.Visible;
            else imYPotion.Visibility = Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            if (ver) tbNombre.Visibility = Visibility.Visible;
            else tbNombre.Visibility = Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {

            Storyboard animacionDefensa = (Storyboard)this.Resources["AccionDefensiva"];
            if (ver == true)
            {
                animacionDefensa.Begin();
            }
            else
            {
                animacionDefensa.Stop();
            }
        }

        public void activarAniIdle(bool activar)
        {
            Storyboard activarAniIdle = (Storyboard)this.Resources["PokeNimations"];
            if (activar == true)
            {
                activarAniIdle.Begin();
            }
            else
            {
                activarAniIdle.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard animacionAtaqueFlojo = (Storyboard)this.Resources["Ataque1Animation"];
            animacionAtaqueFlojo.Begin();
        }

        public void animacionAtaqueFuerte()
        {
            Storyboard animacionAtaqueFuerte = (Storyboard)this.Resources["SuperAtaqueStart"];
            animacionAtaqueFuerte.Begin();
        }

        public void animacionDefensa()
        {
            Storyboard animacionDefensa = (Storyboard)this.Resources["AccionDefensiva"];
            animacionDefensa.Begin();
        }

        public void animacionDescasar()
        {
            Storyboard animacionDescasar = (Storyboard)this.Resources["Descansar"];
            animacionDescasar.Begin();
        }

        public void animacionCansado()
        {
            Storyboard animacionCansado = (Storyboard)this.Resources["Cansado"];
            animacionCansado.Begin();
        }

        public void animacionNoCansado()
        {
            Storyboard animacionNoCansado = (Storyboard)this.Resources["Cansado"];
            animacionNoCansado.Stop();
        }

        public void animacionHerido()
        {
            Storyboard animacionHerido = (Storyboard)this.Resources["PokeHurtAnimation"];
            animacionHerido.Begin();
        }

        public void animacionNoHerido()
        {
            Storyboard animacionNoHerido = (Storyboard)this.Resources["PokeHurtAnimation"];
            animacionNoHerido.Stop();
        }

        public void animacionDerrota()
        {
            Storyboard animacionDerrota = (Storyboard)this.Resources["PokeDeathAnimation"];
            animacionDerrota.Begin();
        }
    }
}
