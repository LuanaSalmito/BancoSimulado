using System;
using System.Net;

namespace SuperBanco
{
    class Program
    {
        static void Main(string[] args)
        {

            var conta = new ContaBancaria("Luana", 8000);
            Console.WriteLine($"A conta {conta.Numero} foi criada por {conta.Dono} com {conta.Saldo}.");

            conta.Saque(120, DateTime.Now, "Led");
            Console.WriteLine(conta.Saldo);

            conta.Saque(130, DateTime.Now, "Mouse");
            Console.WriteLine(conta.Saldo);

            conta.Saque(1900, DateTime.Now, "Phone");
            Console.WriteLine(conta.Saldo);


            Console.WriteLine(conta.HistoricoConta());






            ////testando o saldo inicial, que tem que ser '''positivo'''

            //try
            //{
            //    var contaInvalida = new ContaBancaria("Inválida", -55);
            //}

            //catch (ArgumentOutOfRangeException e) {
            //    Console.WriteLine("Tentativa inválida, não se pode criar conta com saldo negativo.");
            //    Console.WriteLine(e.ToString());
            // }



            conta.Depositar(500, DateTime.Now, "Teclado");
            Console.WriteLine(conta.Saldo);
        }

    }

} 