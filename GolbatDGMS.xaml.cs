using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class GolbatDGMS : UserControl, iPokemon
    {
        DispatcherTimer dtTime;

        private double _vida;
        private double _energia;
        private string _nombre;
        private string _categoria;
        private string _tipo;
        private double _altura;
        private double _peso;
        private string _evolucion;
        private string _descripcion;

        public double Vida
        {
            get => _vida;
            set => _vida = value;
        }

        public double Energia
        {
            get => _energia;
            set => _energia = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string Categoría
        {
            get => _categoria;
            set => _categoria = value;
        }

        public string Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }

        public double Altura
        {
            get => _altura;
            set => _altura = value;
        }

        public double Peso
        {
            get => _peso;
            set => _peso = value;
        }

        public string Evolucion
        {
            get => _evolucion;
            set => _evolucion = value;
        }

        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }

        public GolbatDGMS()
        {
            this.InitializeComponent();
            Vida = 60;
            Energia = 40;
            Nombre = "Golbat";
            Categoría = "Murciélago";
            Tipo = "Veneno volador";
            Altura = 1.60;
            Peso = 55;
            Evolucion = "Crobat";
            Descripcion = "Es al caer la noche cuando sale a revolotear y a buscar sangre fresca. Golbat derriba a sus víctimas mordiéndoles con los cuatro colmillos que tiene y chupándoles la sangre.";
            NombrePokemon.Text = Nombre;
            PbHealth.Value = Vida;
            PbEnergy.Value = Energia;
            sliderVida.Value = Vida;
            sliderEnergia.Value = Energia;
            txtDescripcion.Text = Descripcion;
            Storyboard sb = (Storyboard)this.Resources["Aleteo"];
            sb.Begin();
            
        }

        private void SliderVida_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Vida = e.NewValue; 
            PbHealth.Value = Vida; 
        }

        private void SliderEnergia_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Energia = e.NewValue; 
            PbEnergy.Value = Energia; 
        }

        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imagenPocionVida.Visibility = Visibility.Collapsed;
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/potion.mp3"));
            mpSonidos.Play();
        }
        private void increaseHealth(object sender, object e)
        {
            Vida += 2;
            PbHealth.Value = Vida;
            sliderVida.Value = Vida;
            if (PbHealth.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }

        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEnergy;
            dtTime.Start();
            this.imagenPocionEnergia.Visibility = Visibility.Collapsed;
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/potion.mp3"));
            mpSonidos.Play();
        }

        private void increaseEnergy(object sender, object e)
        {
            Energia += 2;
            PbEnergy.Value = Energia;
            sliderEnergia.Value = Energia;
            if (PbEnergy.Value >= 100)
            {
                this.dtTime.Stop();
            }
        }
        private void enfadarOjosIzq(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.PupilaIzq.Resources["CambiarOjos"];
            sb.Begin();
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/eye_change.mp3"));
            mpSonidos.Play();
        }
        private void enfadarOjosDer(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.PupilaDer.Resources["CambiarOjos"];
            sb.Begin();
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/eye_change.mp3"));
            mpSonidos.Play();
        }
        private void hacerCosquillasPataD(object sender, PointerRoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            sb.Children.Add(da);
            sb.BeginTime = TimeSpan.FromSeconds(0);
            ptBoca.RenderTransform = (Transform)new ScaleTransform();
            Storyboard.SetTarget(da, ptBoca.RenderTransform);
            Storyboard.SetTargetProperty(da, "ScaleY");
            da.From = 1;
            da.To = 1.1;
            sb.AutoReverse = true;
            sb.RepeatBehavior = new RepeatBehavior(3);
            sb.Begin();
        }
        

        
        
        /*private void AccionAleteo(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Aleteo"];
            sb.Begin();
        }*/

        
        
        
        private void AccionHerido_Cansado(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Herido_Cansado"];
            sb.Begin();
        }
        private void AccionHerido_Cansado_a_normal(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Herido_Cansado_a_normal"];
            sb.Begin();
        }
        private void AccionHerido_cansado_a_cansado(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Herido_cansado_a_cansado"];
            sb.Begin();
        }
        private void AccionCansado_a_herido_cansado(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Cansado_a_herido_y_cansado"];
            sb.Begin();
        }
        private void AccionHerido_cansado_a_herido(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Herido_cansado_a_Herido"];
            sb.Begin();
        }
        private void AccionHerido_a_herido_cansado(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["Herido_a_herido_cansado"];
            sb.Begin();
        }

        

        public void verFondo(bool ver)
        {
            if (fondo.Background is ImageBrush imageBrush)
            {
                if (ver == false)
                {
                    imageBrush.Opacity = 100;
                }
                else
                {
                    imageBrush.Opacity = 0;
                }
            }
         
            
            
        }

        public void verFilaVida(bool ver)
        {
            if (ver == false)
            {
                PbHealth.Opacity = 100;
            }
            else
            {
                PbHealth.Opacity = 0;
            }
          
            
            
            
        }

        public void verFilaEnergia(bool ver)
        {
            if (ver == false)
            {
                PbEnergy.Opacity = 100;
            }
            else
            {
                PbEnergy.Opacity = 0;
            }
          
            
        }

        public void verPocionVida(bool ver)
        {
            if (ver == false)
            {
                imagenPocionVida.Opacity = 100;
            }
            else
            {
                imagenPocionVida.Opacity = 0;
            }
          
            

        }

        public void verPocionEnergia(bool ver)
        {
            if (ver == false)
            {
                imagenPocionEnergia.Opacity = 100;
            }
            else
            {
                imagenPocionEnergia.Opacity = 0;
            }
          
            

        }

        public void verNombre(bool ver)
        {
            if (ver == false)
            {
                NombrePokemon.Opacity = 100;
            }
            else
            {
                NombrePokemon.Opacity = 0;
            }
           
            
        }

        public void verEscudo(bool ver)
        {
            if (ver == false)
            {
                escudo.Opacity = 100;
            }
            else
            {
                escudo.Opacity = 0;
            }
           
            
        }

        public void activarAniIdle(bool activar)
        {
            Storyboard sb = (Storyboard)this.Resources["Aleteo"];
            sb.Begin();
           
        }

        public void animacionAtaqueFlojo()
        {
            Storyboard sb = (Storyboard)this.Resources["ataqueNormal"];
            sb.Begin();
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/ataqueNormal.mp3"));
            mpSonidos.Play();
            
        }

        public void animacionAtaqueFuerte()
        {
            Storyboard sb = (Storyboard)this.Resources["AtaqueFuerte"];
            sb.Begin();
            MediaPlayer mpSonidos = new MediaPlayer();
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/eye_change.mp3"));
            mpSonidos.Play();
            MediaPlayer mpSonidos1 = new MediaPlayer();
            mpSonidos1.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsGolbatDGMs/Ataque_fuerte.mp3"));
            mpSonidos1.Play();

           
        }

        public void animacionDefensa()
        {
            Storyboard sb = (Storyboard)this.Resources["UsarEscudo"];
            sb.Begin();
            
        }

        public void animacionDescasar()
        {
            Storyboard sb = (Storyboard)this.Resources["Descansar"];
            sb.Begin();
           
        }

        public void animacionCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["Cansado"];
            sb.Begin();
            
        }

        public void animacionNoCansado()
        {
            Storyboard sb = (Storyboard)this.Resources["Recuperarse"];
            sb.Begin();
            
        }

        public void animacionHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["Herido"];
            sb.Begin();
            
        }

        public void animacionNoHerido()
        {
            Storyboard sb = (Storyboard)this.Resources["Herido_a_normal"];
            sb.Begin();
           
        }

        public void animacionDerrota()
        {
            Storyboard sb = (Storyboard)this.Resources["Derrotado"];
            sb.Begin();
           
            

        }

        

        private void boton_ataqueFlojo_Click(object sender, RoutedEventArgs e)
        {
            animacionAtaqueFlojo();
        }

        private void boton_defensa_Click(object sender, RoutedEventArgs e)
        {
            animacionDefensa();
        }

        private void boton_descansar_Click(object sender, RoutedEventArgs e)
        {
            animacionDescasar();
        }

        private void boton_ataqueFuerte_Click(object sender, RoutedEventArgs e)
        {
            animacionAtaqueFuerte();
        }


        private void CheckBox_idle_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            activarAniIdle(value);
        }

        private void CheckBox_cansado_Checked(object sender, RoutedEventArgs e)
        {
            animacionCansado();
        }

        private void Checkbox_cansado_Unchecked(object sender, RoutedEventArgs e)
        {
            animacionNoCansado();
        }

        private void Checkbox_herido_Checked(object sender, RoutedEventArgs e)
        {
            animacionHerido();
        }

        private void Checkbox_herido_Unchecked(object sender, RoutedEventArgs e)
        {
            animacionNoHerido();
        }

        private void Checkbox_escudo_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verEscudo(value);
        }

        private void Checkbox_escudo_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verEscudo(value);
        }

        private void Checkbox_fondo_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verFondo(value);
        }

        private void Checkbox_fondo_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verFondo(value);
        }

        private void Checkbox_vida_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verFilaVida(value);
        }

        private void Checkbox_vida_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verFilaVida(value);
        }

        private void Checkbox_energia_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verFilaEnergia(value);
        }

        private void Checkbox_energia_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verFilaEnergia(value);
        }

        private void Checkbox_PocionVida_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verPocionVida(value);
        }

        private void Checkbox_PocionVida_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verPocionVida(value);
        }

        private void Checkbox_PocionEnergia_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verPocionEnergia(value);
        }

        private void Checkbox_PocionEnergia_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verPocionEnergia(value);
        }

        private void Checkbox_Nombre_Checked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == false;
            verNombre(value);
        }

        private void Checkbox_Nombre_Unchecked(object sender, RoutedEventArgs e)
        {
            bool value = Checkbox_idle.IsChecked == true;
            verNombre(value);
        }
    }
}
