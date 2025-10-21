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
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using ClassLibrary1_Prueba;

namespace IPOkemonApp
{
    public sealed partial class PorygonCNC : UserControl, iPokemon
    {
        private DispatcherTimer dtTime;
        private double targetHealth;
        private string categoria;
        private string tipo;
        private double altura;
        private double peso;
        private string evolucion;
        private string descripcion;

        public double Vida
        {
            get { return this.health_progressbar.Value; }
            set { this.health_progressbar.Value = value; }
        }
        public double Energia {
            get { return this.energy_progressbar.Value; }
            set { this.energy_progressbar.Value = value; }
        }
        public string Nombre { 
            get { return this.pokeName.Text; }
            set { this.pokeName.Text = value; }
        }
        public string Categoría
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        public string Evolucion
        {
            get { return evolucion; }
            set { evolucion = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public PorygonCNC()
        {
            this.InitializeComponent();
        }

        private void PlayAnimation(Storyboard animation, MediaElement sound)
        {
            estatico.Stop();
            animation.Completed += (s, e) =>
            {
                Animation_Completed(s, e);
                {
                    estatico.Begin();
                }
            };
            animation.Begin();

            if (sound != null)
            {
                sound.Play();
            }
        }
        public bool RepetirAnimacionIdle { get; set; } = true;
        private void Animation_Completed(object sender, object e)
        {
            var animation = sender as Storyboard;
            if (animation != null)
            {
                animation.Completed -= Animation_Completed;
            }
        }

        private void RedPotion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UsePotionRed();
        }

        private void YellowPotion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            usePotionYellow();
        }

        private void UsePotionRed()
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseHealth;
            targetHealth = health_progressbar.Value + (health_progressbar.Maximum * 0.15);
            if (targetHealth > health_progressbar.Maximum)
            {
                targetHealth = health_progressbar.Maximum;
            }
            dtTime.Start();
        }

        private void usePotionYellow()
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseEnergy;
            targetHealth = energy_progressbar.Value + (energy_progressbar.Maximum * 0.15);
            if (targetHealth > energy_progressbar.Maximum)
            {
                targetHealth = energy_progressbar.Maximum;
            }
            dtTime.Start();
        }

        private void IncreaseHealth(object sender, object e)
        {
            health_progressbar.Value += 0.5;
            if (health_progressbar.Value >= targetHealth)
            {
                dtTime.Stop();
            }
        }

        private void IncreaseEnergy(object sender, object e)
        {
            energy_progressbar.Value += 0.5;
            if (energy_progressbar.Value >= targetHealth)
            {
                dtTime.Stop();
            }
        }

        public void verFondo(bool ver)
        {
            this.gridGeneral.Background.Opacity = ver ? 1 : 0;
        }

        public void verFilaVida(bool ver)
        {
            this.gridGeneral.RowDefinitions[0].Height = ver ? new GridLength(50) : new GridLength(0);
        }

        public void verFilaEnergia(bool ver)
        {
            this.gridGeneral.RowDefinitions[1].Height = ver ? new GridLength(50) : new GridLength(0);
        }

        public void verPocionVida(bool ver)
        {
            this.pocimaVida.Width = ver ? 50 : 0;
        }

        public void verPocionEnergia(bool ver)
        {
            this.pocimaEnergia.Width = ver ? 50 : 0;
        }

        public void verNombre(bool ver)
        {
            this.gridGeneral.RowDefinitions[3].Height = ver ? new GridLength(50) : new GridLength(0);
        }

        public void verEscudo(bool ver)
        {
            if (ver)
            {
                conEscudo.Begin();
            }
            else
            {
                quitarConEscudo.Begin();
            }
        }

        public void activarAniIdle(bool activar)
        {
            if (activar)
            {
                estatico.Begin();
            }
            else
            {
                estatico.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            PlayAnimation(AtaqueDebil, soundAtaqueDebil);
        }

        public void animacionAtaqueFuerte()
        {
            PlayAnimation(AtaqueFuerte, soundAtaqueFuerte);
        }

        public void animacionDefensa()
        {
            PlayAnimation(escudo, soundAtaqueEscudo);
        }

        public void animacionDescasar()
        {
            PlayAnimation(descanso, soundDescanso);
        }

        public void animacionCansado()
        {
            PlayAnimation(Cansado, null);
        }

        public void animacionNoCansado()
        {
            PlayAnimation(quitarCansado, null);
        }

        public void animacionHerido()
        {
            PlayAnimation(Herido, null);
        }

        public void animacionNoHerido()
        {
            PlayAnimation(quitarHerido, null);
        }

        public void animacionDerrota()
        {
            PlayAnimation(Derrotado, soundDerrotado);
        }
    }
}