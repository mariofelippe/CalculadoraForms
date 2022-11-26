using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraForms
{
    public class Calculadora
    {
        public decimal PrimeiroNumero { get; set; }
        public decimal SegundoNumero { get; set; }
        public decimal Resultado { get; set; }
        public string Operacao { get; set; } = String.Empty;

        private void Somar()
        {
            Resultado = PrimeiroNumero + SegundoNumero;           
                      
        }

        private void Subtrair()
        {
            Resultado = PrimeiroNumero - SegundoNumero;
        }
        private void Multiplicar()
        {
            Resultado = PrimeiroNumero * SegundoNumero;
        }
        private void Dividir()
        {
            if(SegundoNumero == 0)
            {
                return;
            }
            Resultado = PrimeiroNumero / SegundoNumero;
        }
        public void Calcular()
        {
            switch (Operacao)
            {
                case "+":
                    Somar();
                    break;
                case "-":
                    Subtrair();
                    break;
                case "x":
                    Multiplicar();
                    break;
                case "÷":
                    Dividir();
                    break;
            }
        }

        public void Limpar()
        {
            Resultado = 0;
            PrimeiroNumero = 0;
            Operacao = String.Empty;
        }

        public Decimal Porcentagem()
        {
            Resultado = PrimeiroNumero * SegundoNumero / 100;
            return Resultado;
        }
    }
}
