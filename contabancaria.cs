using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SuperBanco
{
    public class ContaBancaria
    {
        public string Numero { get; }
        public string Dono { get; set; }
        public decimal Saldo {
            get
            {
                decimal saldo = 0;
                foreach (var item in todasTransações)
                {
                    saldo = saldo + item.Quantia;
                    //pode usar saldo+= item.Quantia; é a mesma coisa.
                    
                }
                return saldo;
            }

        }

        private static int NumeroDaConta = 1203456789;

        private List<transações> todasTransações = new List<transações>();
        
        public ContaBancaria(string nome, decimal saldoInicial) {

            this.Dono = nome;

            Depositar(saldoInicial, DateTime.Now, "Saldo inicial.");

            this.Numero = NumeroDaConta.ToString();NumeroDaConta++;
        }


        public void Depositar(decimal quantia, DateTime data, string nota)
        {
            if (quantia <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantia), "O depósito da quantia deve ser positivo.");
            }
            var deposito = new transações(quantia, data, nota);
            todasTransações.Add(deposito);
        }

        public void Saque(decimal quantia, DateTime data, string nota)
        {
            if (quantia <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantia), "A quantia do saque deve ser positiva.");
            }
            if (Saldo - quantia < 0)
            {
                throw new InvalidOperationException("Não há saldo sufuciente para saque.");
            }
            var saque = new transações(-quantia, data, nota);
            todasTransações.Add(saque);
        }


        public string HistoricoConta()
        {
            //CABEÇALHO
            //StringBuilder é uma forma de armazenar uma grande quantidade de strings e modifica-las sem criar um novo objeto para isso.
            //Seu uso pode evitar o uso desnecessário de memória, já que o metodo String vôcê sempre cria um novo objeto que requer alocação de memória.

            var relatorio = new StringBuilder();


            //LINHAS

            relatorio.AppendLine("Data\t\tQuantia\t\tNotas");
            foreach (var item in todasTransações)
            {
                relatorio.AppendLine($"{item.Data.ToShortDateString()}\t{item.Quantia}\t\t{item.Notas}");

            }
            return relatorio.ToString();


        }
    }
}
