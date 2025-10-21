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
using Windows.System;

using Windows.Media.Playback;
using Windows.Media.Core;
using ClassLibrary1_Prueba;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.ConstrainedExecution;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a


namespace IPOkemonApp
{
    public sealed partial class OshawottHAM : UserControl, iPokemon
    {
        DispatcherTimer dtTime;
        DispatcherTimer dtTime_e;
        Storyboard sb_iddle;
        Storyboard sb_transicion;
        Storyboard sb_aux;
        MediaPlayer mp;



        private bool herido = false;
        private bool cansado = false;
        private bool escudado = false;
        private bool descansando = false;
        private bool derrotado = false;


        private string nombre = "Oshawott";
        private string categoría = "Nutria";
        private string tipo = "Agua";
        private double altura = 0.5;
        private double peso = 5.9;
        private string evolucion = "Dewott";
        private string descripcion = "Se trata de un Pokémon enérgico y alegre. Ataca con la vieira de su ombligo. En cuanto para un ataque, pasa al contraataque sin dilación.\n" +
            "También la utiliza para cortar bayas que estén duras.";


        public bool Herido
        {
            get { return herido; }
            set { herido = value; }
        }

        public bool Cansado
        {
            get { return cansado; }
            set { cansado = value; }
        }

        public bool Escudado
        {
            get { return escudado; }
            set { escudado = value; }
        }

        public bool Descansando
        {
            get { return descansando; }
            set { descansando = value; }
        }

        public bool Derrotado
        {
            get { return derrotado; }
            set { derrotado = value; }
        }



        // INTERFAZ IPOKEMON IMPLEMENTADA

        public double Vida {
            get { return this.pbHealth.Value; }
            set { this.pbHealth.Value = value; }
        }

        public double Energia
        {
            get { return this.pbEnergy.Value; }
            set { this.pbEnergy.Value = value; }
        }

        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Categoría { get { return this.categoría; } set { this.categoría = value; } }
        public string Tipo { get { return this.tipo; } set { this.tipo = value; } }
        public double Altura { get { return this.altura; } set { this.altura = value; } }
        public double Peso { get { return this.peso; } set { this.peso = value; } }
        public string Evolucion { get { return this.evolucion; } set { this.evolucion = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }


        public void verFondo(bool ver)
        {
            if (!ver) { this.imFondo.Source = null; }
            else { this.imFondo.Source = new BitmapImage(new Uri("ms-appx:///AssetsOshawottHAM/playa_foto.jpg")); }
        }

        public void verFilaVida(bool ver)
        {
            if (!ver) { this.pbHealth.Visibility=Visibility.Collapsed; this.imCorazon.Visibility = Visibility.Collapsed; }
            else { this.pbHealth.Visibility = Visibility.Visible; this.imCorazon.Visibility = Visibility.Visible; }
        }

        public void verFilaEnergia(bool ver)
        {
            if (!ver) { this.pbEnergy.Visibility = Visibility.Collapsed; this.imEnergia.Visibility = Visibility.Collapsed; }
            else { this.pbEnergy.Visibility = Visibility.Visible; this.imEnergia.Visibility = Visibility.Visible; }
        }

        public void verPocionVida(bool ver)
        {
            if (!ver) { this.imRPotion.Source = null; }
            else { this.imRPotion.Source = new BitmapImage(new Uri("ms-appx:///AssetsOshawottHAM/red-potion.png")); }
        }

        public void verPocionEnergia(bool ver)
        {
            if (!ver) { this.imYPotion.Source = null; }
            else { this.imYPotion.Source = new BitmapImage(new Uri("ms-appx:///AssetsOshawottHAM/yellow-potion.png")); }
        }

        public void verNombre(bool ver)
        {
            if (!ver) { this.tbNombre.Visibility = Visibility.Collapsed; }
            else { this.tbNombre.Visibility = Visibility.Visible; }
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                escudo.Opacity = 0.3;

                escudo.RenderTransform = escudo.RenderTransform as CompositeTransform ?? new CompositeTransform();
                var t = (CompositeTransform)escudo.RenderTransform;

                t.ScaleX = 6.613;
                t.ScaleY = 13.121;
                t.TranslateX = 15.882;
                t.TranslateY = 200;
            }
            else
            {
                escudo.Opacity = 0;

                escudo.RenderTransform = escudo.RenderTransform as CompositeTransform ?? new CompositeTransform();
                var t = (CompositeTransform)escudo.RenderTransform;

                t.ScaleX = 1;
                t.ScaleY = 1;
                t.TranslateX = 0;
                t.TranslateY = 0;
            }
        }


        public void activarAniIdle(bool activar)
        {
            if (activar) { sb_iddle.Begin(); }
            else { sb_iddle.Stop(); }

        }

        public void animacionAtaqueFlojo()
        {
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/lanzar_boomerang.mp3"));
            mp.Position = TimeSpan.FromSeconds(1.5);
            mp.Play();

            activarAniIdle(false);
            if (!Herido)
            {
                sb_aux = (Storyboard)Resources["ataque_flojo_key"];
                sb_aux.Completed += (s, args) => activarAniIdle(true);
            }
            else
            {
                sb_aux = (Storyboard)Resources["ataque_flojo_herido_key"];
                sb_aux.Completed += (s, args) => activarAniIdle(true);
            }

            sb_aux.Begin();

        }

        public void animacionAtaqueFuerte()
        {
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/rayolaser.mp4"));
            mp.Play();

            activarAniIdle(false); 


            if (!Herido)
            {
                sb_aux = (Storyboard)Resources["ataque_fuerte_key"];
                sb_aux.Completed += (s, args) => activarAniIdle(true);
            }
            else
            {
                sb_aux = (Storyboard)Resources["ataque_fuerte_herido_key"];
                sb_aux.Completed += (s, args) => activarAniIdle(true);
            }


            sb_aux.Begin();
        }

        public void animacionDefensa()
        {
            activarAniIdle(false);
            if (!Herido)
            {
                if (!Escudado)
                {
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/barrera.mp3"));
                    mp.Position = TimeSpan.FromSeconds(2);
                    mp.Play();
                    sb_transicion = (Storyboard)Resources["poner_escudo_key"];
                    sb_iddle = (Storyboard)Resources["escudo_iddle_key"];
                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Escudado = true;
                    sb_transicion.Begin();
                }
                else
                {
                    sb_transicion = (Storyboard)Resources["escudo_to_normal_key"];
                    if (!Cansado)
                    {
                        sb_iddle = (Storyboard)Resources["iddle_key"];
                    }
                    else
                    {
                        sb_iddle = (Storyboard)Resources["cansado_key"];
                    }

                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Escudado = false;
                    sb_transicion.Begin();
                }
            }
            else
            {
                if (!Escudado)
                {
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/barrera.mp3"));
                    mp.Position = TimeSpan.FromSeconds(2);
                    mp.Play();

                    sb_transicion = (Storyboard)Resources["herido_poner_escudo_key"];
                    sb_iddle = (Storyboard)Resources["escudo_herido_key"];
                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Escudado = true;
                    sb_transicion.Begin();
                }
                else
                {
                    sb_transicion = (Storyboard)Resources["escudo_to_herido_key"];
                    if (!Cansado)
                    {
                        sb_iddle = (Storyboard)Resources["herido_key"];
                    }
                    else
                    {
                        sb_iddle = (Storyboard)Resources["herido_cansado_key"];
                    }

                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Escudado = false;
                    sb_transicion.Begin();
                }
            }
        }

        public void animacionDescasar()
        {
            activarAniIdle(false); // Detener animación de idle
            if (!Herido)
            {
                if (!Descansando)
                {
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/mimimi.mp3"));
                    mp.Play();
                    sb_transicion = (Storyboard)Resources["activar_descanso_key"];
                    sb_iddle = (Storyboard)Resources["descansando_key"];
                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Descansando = true;
                    sb_transicion.Begin();
                }
                else
                {
                    sb_transicion = (Storyboard)Resources["desactivar_descanso_key"];
                    if (!Cansado)
                    {
                        sb_iddle = (Storyboard)Resources["iddle_key"];
                    }
                    else
                    {
                        sb_iddle = (Storyboard)Resources["cansado_key"];
                    }

                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Descansando = false;
                    sb_transicion.Begin();
                }
            }
            else
            {
                if (!Descansando)
                {
                    mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/mimimi.mp3"));
                    mp.Play();
                    sb_transicion = (Storyboard)Resources["activar_descanso_herido_key"];
                    sb_iddle = (Storyboard)Resources["descansando_herido_key"];
                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Descansando = true;
                    sb_transicion.Begin();
                }
                else
                {
                    sb_transicion = (Storyboard)Resources["desactivar_descanso_herido_key"];
                    if (!Cansado)
                    {
                        sb_iddle = (Storyboard)Resources["herido_key"];
                    }
                    else
                    {
                        sb_iddle = (Storyboard)Resources["herido_cansado_key"];
                    }

                    sb_transicion.Completed += (s, args) => activarAniIdle(true);
                    Descansando = false;
                    sb_transicion.Begin();
                }
            }
        }

        public void animacionCansado()
        {
            activarAniIdle(false);
            if (!Herido)
            {
                sb_iddle = (Storyboard)Resources["cansado_key"];
                Cansado = true;
                activarAniIdle(true);
            }
            else
            {
                sb_iddle = (Storyboard)Resources["herido_cansado_key"];
                Cansado = true;
                activarAniIdle(true);
            }
        }

        public void animacionNoCansado()
        {
            activarAniIdle(false);
            if (!Herido)
            {
                sb_iddle = (Storyboard)Resources["iddle_key"];
                Cansado = false;
                activarAniIdle(true);
            }
            else
            {
                sb_iddle = (Storyboard)Resources["herido_key"];
                Cansado = false;
                activarAniIdle(true);
            }
        }

        public void animacionHerido()
        {
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/baja_vida.mp3"));
            mp.Play();
            activarAniIdle(false);
            if (!Cansado)
            {
                sb_transicion = (Storyboard)Resources["normal_to_herido_key"];
                sb_iddle = (Storyboard)Resources["herido_key"];
                sb_transicion.Completed += (s, args) => activarAniIdle(true);
                Herido = true;
                sb_transicion.Begin();
            }
            else
            {
                sb_transicion = (Storyboard)Resources["normal_to_herido_key"];
                sb_iddle = (Storyboard)Resources["herido_cansado_key"];
                sb_transicion.Completed += (s, args) => activarAniIdle(true);
                Herido = true;
                sb_transicion.Begin();
            }
        }

        public void animacionNoHerido()
        {
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/curar.mp3"));
            mp.Play();
            activarAniIdle(false);
            if (!Cansado)
            {
                sb_transicion = (Storyboard)Resources["herido_to_normal_key"];
                sb_iddle = (Storyboard)Resources["iddle_key"];
                sb_transicion.Completed += (s, args) => activarAniIdle(true);
                Herido = false;
                sb_transicion.Begin();
            }
            else
            {
                sb_transicion = (Storyboard)Resources["herido_to_normal_key"];
                sb_iddle = (Storyboard)Resources["cansado_key"];
                sb_transicion.Completed += (s, args) => activarAniIdle(true);
                Herido = false;
                sb_transicion.Begin();
            }
        }

        public void animacionDerrota()
        {
            mp.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///AssetsOshawottHAM/explosion.mp3"));
            mp.Position = TimeSpan.FromSeconds(2);
            mp.Play();
            activarAniIdle(false);
            Derrotado = true;
            sb_aux = (Storyboard)Resources["derrotado_key"];

            sb_aux.Begin();
        }

        // FIN DE IPOKEMON




        // MI CONSTRUCTOR
        public OshawottHAM()
        {
            this.InitializeComponent();

            sb_iddle = (Storyboard)Resources["iddle_key"];
            mp = new MediaPlayer();

        }



        private void imRPotion_PointerReleased(object sender, PointerRoutedEventArgs e)
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

        private void imYPotion_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTime_e = new DispatcherTimer();
            dtTime_e.Interval = TimeSpan.FromMilliseconds(100);
            dtTime_e.Tick += increaseEnergy;
            dtTime_e.Start();
            this.imYPotion.Visibility = Visibility.Collapsed;
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergy.Value += 0.5;
            if (pbEnergy.Value >= 100)
            {
                this.dtTime_e.Stop();
            }
        }
    }
}
