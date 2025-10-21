using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
    public sealed partial class PsyduckERP : UserControl, iPokemon
    {
        private MediaPlayer mpSonidos;
        public PsyduckERP()
        {
            this.InitializeComponent();
            mpSonidos = new MediaPlayer();
        }


        public double Vida { get => BarraVida.Value; set => BarraVida.Value=value; }
        public double Energia { get => BarraEnergia.Value; set => BarraEnergia.Value = value; }
        public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Categoría { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Altura { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Peso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Evolucion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private void PlaySound(string fileName)
        {
            mpSonidos.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///AssetsPsyduckERP/{fileName}"));
            mpSonidos.Play();
        }

        public void activarAniIdle(bool activar)
        {
            if(activar == true)
            {
                estatica.Begin();
            }
            else
            {
                estatica.Stop();
            }
            
        }

        public void animacionAtaqueFlojo()
        {
           PlaySound("debil1.wav");
           AtaqueDebil.Begin();

        }

        public void animacionAtaqueFuerte()
        {
            PlaySound("cascada1.wav");
            AtaqueFuerte.Begin();
            
        }
        

        public void animacionCansado()
        {
            cansancio.Begin();
        }

        public void animacionDefensa()
        {
            PlaySound("barrera.wav");
            EstadoDefensa.Begin();

        }

        public void animacionDerrota()
        {
            
                muerto.Begin();
            

        }

        public void animacionDescasar()
        {
            recuperación.Begin();

        }

        public void animacionHerido()
        {
            herido.Begin();
        }

        public void animacionNoCansado()
        {
            cansancio.Stop();
        }

        public void animacionNoHerido()
        {
            herido.Stop();
        }

        public void verEscudo(bool ver)
        {
            if (ver == true)
            {
                Escudo.Visibility = Visibility.Visible;
            }
            else
            {
                Escudo.Visibility = Visibility.Collapsed;
            }   
        }

        public void verFilaEnergia(bool ver)
        {
            if (ver == true)
            {
                BarraEnergia.Visibility = Visibility.Visible;
            }
            else
            {
                BarraEnergia.Visibility = Visibility.Collapsed;
            }   
        }

        public void verFilaVida(bool ver)
        {
            if (ver == true)
            {
                BarraVida.Visibility = Visibility.Visible;
            }
            else
            {
                BarraVida.Visibility = Visibility.Collapsed;
            }
        }

        public void verFondo(bool ver)
        {
            if (ver == true)
            {
                imFondo.Visibility = Visibility.Visible;
            }
            else
            {
                imFondo.Visibility = Visibility.Collapsed;
            }   
        }

        public void verNombre(bool ver)
        {
            if (ver == true)
            {
                NombrePoke.Visibility = Visibility.Visible;
            }
            else
            {
                NombrePoke.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionEnergia(bool ver)
        {
            if (ver == true)
            {
                ImgEnergia.Visibility = Visibility.Visible;
            }
            else
            {
                ImgEnergia.Visibility = Visibility.Collapsed;
            }
        }

        public void verPocionVida(bool ver)
        {
            if (ver == true)
            {
                ImgCura.Visibility = Visibility.Visible;
            }
            else
            {
                ImgCura.Visibility = Visibility.Collapsed;
            }
        }

        
    }
}
