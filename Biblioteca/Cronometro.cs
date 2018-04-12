using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Cronometro : UserControl
    {
        public Cronometro()
        {
            InitializeComponent();
        }

        private void Cronometro_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Cree 3 variables, que son las que se usan en ActualizarLabel
        /// </summary>
        private int min=0;
        private int seg = 0;
        private int mili = 0;

        /// <summary>
        /// Lo que se hace aquí es realizar la suma correcta, es decir, que el 
        /// cronómetro funcione de manera correcta, de tal manera que si una de las 
        /// variables llega a un límite, ésta actualiza la label respectivamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            mili++;
            if (mili == 100)
            {
                mili = 0;
                seg++;
                if (seg == 60)
                {
                    seg = 0;
                    min++;
                }
            }
            ActualizarLabel();
        }

        /// <summary>
        /// Lo que se hace dentro de este método es partir el label 
        /// en varias secciones, tales como, minutos, segundos y milisegundos
        /// para que al momento de que inicie o se de clic en el botón play inicie
        /// el contador(cronómetro)
        /// </summary>
        public void ActualizarLabel()
        {
            string cadena ="";
            if (min.ToString().Length == 1)
            {
                cadena += "0" + min.ToString();
            }else
            {
                cadena += min.ToString();
            }
            cadena += ":";
            if (seg.ToString().Length == 1)
            {
                cadena += "0" + seg.ToString();
            }
            else
            {
                cadena += seg.ToString();
            }
            cadena += ":";
            if (mili.ToString().Length == 1)
            {
                cadena += "0" + mili.ToString();
            }
            else
            {
                cadena += mili.ToString();
            }
            lblMirar.Text = cadena;
        }

        /// <summary>
        /// Este método manda llaman otro método llamado Play.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        /// <summary>
        /// Lo que hace este método es inicializar el timer agregado en el componente
        /// </summary>
        public void Play()
        {
            timer.Enabled = true;
        }

        /// <summary>
        /// Se llama el método "Pausa"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPausa_Click(object sender, EventArgs e)
        {
            Pausa();
        }

        /// <summary>
        /// Se detiene el timer dentro de este método
        /// </summary>
        public void Pausa()
        {
            timer.Enabled = false;
        }

        /// <summary>
        /// El timer comienza de ceros de nuevo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();    
        }

        /// <summary>
        /// La label se restablece a su valor inicial
        /// </summary>
        public void Reset()
        {
            timer.Enabled = false;
            seg = 0;
            min = 0;
            mili = 0;
            ActualizarLabel();
        }

        private void lblMirar_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Aquí definimos el tipo de letra, así como el tamaño de la misma de la label.
        /// </summary>
        public Font FontLabel
        {
            get
            {
                return lblMirar.Font;
            }

            set
            {
                lblMirar.Font = value;
            }
        }
    }
}
