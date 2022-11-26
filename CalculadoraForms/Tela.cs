using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Tela : Form
    {
        private Calculadora _calculadora;
        private bool resultado;
        public Tela()
        {
            InitializeComponent();
            _calculadora = new Calculadora();
            
        }

        private void Tela_Load(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            VerificacaoInicial();
            lblDisplay.Text = lblDisplay.Text + "9";
        }
        private void button0_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text != "0")
                lblDisplay.Text = lblDisplay.Text + "0";
        }

        private void virula_Click(object sender, EventArgs e)
        {
            
            if(!lblDisplay.Text.Contains(","))            
                lblDisplay.Text = lblDisplay.Text + ",";
        }

        private void ce_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            lblDisplay.Text = "0";
            lblHist.Text = String.Empty;
            _calculadora.Limpar();
        }

        private void VerificacaoInicial()
        {
            if (resultado)
            {
                _calculadora.Limpar();
                Limpar();
                resultado = false;
            }
            if (lblDisplay.Text.Length == 1 && lblDisplay.Text == "0" && !resultado )
            {
                lblDisplay.Text = String.Empty;
            }
           
            
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
         
            if(_calculadora.Operacao == "")
            {
                resultado = false;
                return;
            }

            if (lblDisplay.Text.All(char.IsDigit) || lblDisplay.Text.Contains('-'))
            {                
                if (resultado)
                {
                    _calculadora.PrimeiroNumero = decimal.Parse(lblDisplay.Text);
                }
                else
                {
                    _calculadora.SegundoNumero = decimal.Parse(lblDisplay.Text);
                }
            }

            if (lblDisplay.Text == "0" && _calculadora.Operacao == "/")
            {
                lblDisplay.Text = "Divisão por zero";
                
            }
            else
            {
                                      
                _calculadora.Calcular();
                lblHist.Text = $"{_calculadora.PrimeiroNumero} {_calculadora.Operacao} {_calculadora.SegundoNumero} =";
                lblDisplay.Text = _calculadora.Resultado.ToString();
                  
            }

            resultado = true ;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0" && lblDisplay.Text.Length > 1 )
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
                if(lblDisplay.Text == "-")
                {
                    lblDisplay.Text = "0";
                }
            }
            else
            {
                lblDisplay.Text = "0";
            }            
                
        }
        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (lblHist.Text == "0 - ")
                lblDisplay.Text = $"-{lblDisplay.Text}";
            _calculadora.PrimeiroNumero = decimal.Parse(lblDisplay.Text);
            _calculadora.Operacao = "+";
            lblHist.Text = $"{lblDisplay.Text} + ";
            lblDisplay.Text = "0";
            resultado = false;

        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
           
            _calculadora.PrimeiroNumero = decimal.Parse(lblDisplay.Text);
            _calculadora.Operacao = "-";
            lblHist.Text = $"{lblDisplay.Text} - ";
            lblDisplay.Text = "0";
            resultado = false;
        }

        private void btnMutiplicar_Click(object sender, EventArgs e)
        {
            _calculadora.PrimeiroNumero = decimal.Parse(lblDisplay.Text);
            _calculadora.Operacao = "x";
            lblHist.Text = $"{lblDisplay.Text} x ";
            lblDisplay.Text = "0";
            resultado = false;
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            _calculadora.PrimeiroNumero = decimal.Parse(lblDisplay.Text);
            _calculadora.Operacao = "÷";
            lblHist.Text = $"{lblDisplay.Text} ÷ ";
            lblDisplay.Text = "0";
            resultado = false;
        }

        private void btnNegativar_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Contains('-'))
            {
                lblDisplay.Text = lblDisplay.Text.Replace("-","");
            }
            else
            {
                if(lblDisplay.Text != "0")
                    lblDisplay.Text = $"-{lblDisplay.Text}";
            }
                
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            _calculadora.SegundoNumero = decimal.Parse(lblDisplay.Text);
            lblHist.Text = $"{_calculadora.PrimeiroNumero} {_calculadora.Operacao} {_calculadora.SegundoNumero} ";
            lblDisplay.Text = _calculadora.Porcentagem().ToString();
        }
    }
}
