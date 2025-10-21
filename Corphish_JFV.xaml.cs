
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
using Windows.UI.Xaml.Navigation;


// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemonApp
{
    public sealed partial class Corphish_JFV : UserControl, iPokemon
    {
        public Corphish_JFV()
        {
            this.InitializeComponent();

        }

        public double Vida
        {
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }
        public double Energia
        {
            get { return this.pbEnergy.Value; }
            set { this.pbEnergy.Value = value; }
        }
        public string Nombre
        {
            get { return this.tbNombre.Text; }
            set { this.tbNombre.Text = value; }

        }
        public string Categoría
        {
            get { return this.Categoria.Text; }
            set { this.Categoria.Text = value; }
        }
        public string Tipo
        {
            get { return this.tbTipo.Text; }
            set { this.tbTipo.Text = value; }
        }
        public double Altura
        {
            get { return this.pbAltura.Value; }
            set { this.pbAltura.Value = value; }
        }
        public double Peso
        {
            get { return this.pbPeso.Value; }
            set { this.pbPeso.Value = value; }
        }
        public string Evolucion 
        {
            get { return this.tbEvolucion.Text; }
            set { this.tbEvolucion.Text = value; }
        }
        public string Descripcion 
        {
            get { return this.tbDescripcion.Text; }
            set { this.tbDescripcion.Text = value; }
        }

        public void activarAniIdle(bool activar)
        {
            Storyboard Basico = (Storyboard)FindName("Basico");

            if (activar)
            {
                Basico?.Begin();
            }
            else
            {
                Basico?.Stop();
            }

        }

        public void animacionAtaqueFlojo()
        {
            Storyboard ataqueFlojo = (Storyboard)FindName("AtaqueDebil");
            ataqueFlojo?.Begin();

        }
        

        public void animacionAtaqueFuerte()
        {
            Storyboard ataqueFuerte = (Storyboard)FindName("AtaqueFuerte");
            ataqueFuerte?.Begin();
        }

        public void animacionCansado()
        {
            Storyboard cansado = (Storyboard)FindName("Normal_Cansado");
            cansado?.Begin();
        }

        public void animacionDefensa()
        {
            Storyboard Defensa = (Storyboard)FindName("Basico");
            verPocionVida(false);
            pbVida.Value += 50; 
            Defensa?.Begin();
        }

        public void animacionDerrota()
        {
            Storyboard Derrota = (Storyboard)FindName("Muerto");
            Derrota?.Begin();
        }

        public void animacionDescasar()
        {
            Storyboard Descansar = (Storyboard)FindName("Cansado_Normal");
            verPocionEnergia(false);
            pbEnergy.Value += 50;
            Descansar?.Begin();
        }

        public void animacionHerido()
        {
            Storyboard Herido = (Storyboard)FindName("Normal_Herido");
            Herido?.Begin();
        }

        public void animacionNoCansado()
        {
            Storyboard noCansado = (Storyboard)FindName("Cansado_Normal");
            noCansado?.Begin();
        }

        public void animacionNoHerido()
        {
            Storyboard noHerido = (Storyboard)FindName("Herido_Normal");
            noHerido?.Begin();
        }

        public void verEscudo(bool ver)
        {
            Storyboard Escudo = (Storyboard)FindName("Escudo");
            if (ver)
            {
                Escudo?.Begin();
            }
            else
            {
                Escudo?.Stop();
            }
        }

        public void verFilaEnergia(bool ver)
        {
            if (!ver) { this.pbEnergy.Visibility = Visibility.Collapsed; }
            else { this.pbEnergy.Visibility = Visibility.Visible; }
        }

        public void verFilaVida(bool ver)
        {
            if (!ver) { this.pbVida.Visibility = Visibility.Collapsed; }
            else { this.pbVida.Visibility = Visibility.Visible; }
        }

        public void verFondo(bool ver)
        {
            if (!ver) { this.ImFondo.Visibility = Visibility.Collapsed; }
            else { this.ImFondo.Visibility = Visibility.Visible; }
        
        }

        public void verNombre(bool ver)
        {
            if (!ver) { this.tbNombre.Visibility = Visibility.Collapsed; }
            else { this.tbNombre.Visibility = Visibility.Visible; } 
        }

        public void verPocionEnergia(bool ver)
        {
            if (!ver) { this.imYPotion.Visibility = Visibility.Collapsed; }
            else { this.imYPotion.Visibility = Visibility.Visible; }
        }

        public void verPocionVida(bool ver)
        {
            if (!ver) { this.imRPotion.Visibility = Visibility.Collapsed; }
            else { this.imRPotion.Visibility = Visibility.Visible; }
        }

        private void tbEvolucion_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
