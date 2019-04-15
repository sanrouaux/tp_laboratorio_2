using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        private bool _esDecimal = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string strNum1;
            string strNum2;
            string strOperador;
            double result;

            strNum1 = this.txtNumero1.Text;
            strNum2 = this.txtNumero2.Text;
            strOperador = this.cmbOperador.Text;

            result = Form1.Operar(strNum1, strNum2, strOperador);
            this._esDecimal = true;

            this.lblResultado.Text = result.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this._esDecimal = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this._esDecimal == true)
            {
                if (Numero.DecimalBinario(this.lblResultado.Text) != "Valor inválido")
                {
                    this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
                    this._esDecimal = false;
                }
                else
                {
                    MessageBox.Show(Numero.DecimalBinario(this.lblResultado.Text));
                }                
            }
            else
            {
                MessageBox.Show("EL valor ya es binario");
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this._esDecimal == false)
            {
                if (Numero.BinarioDecimal(this.lblResultado.Text) != "Valor inválido")
                {
                    this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
                    this._esDecimal = true;
                }
                else
                {
                    MessageBox.Show(Numero.BinarioDecimal(this.lblResultado.Text));
                }                
            }
            else
            {
                MessageBox.Show("EL valor ya es decimal");
            }
        }


        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double result;

            Numero objNum1 = new Numero(numero1);
            Numero objNum2 = new Numero(numero2);
            result = Calculadora.Operar(objNum1, objNum2, operador);

            return result;
        }
    }
}
