using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBanco
{
    public class transações
    {
        public decimal Quantia { get; }

        public DateTime Data { get; }

        public string Notas { get; }


        public transações(decimal Quantia, DateTime Data, string Notas)
        {
            this.Quantia = Quantia;
            this.Data = Data;
            this.Notas = Notas;
        }



    }
}
