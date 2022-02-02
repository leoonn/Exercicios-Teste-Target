using System;
namespace Teste_Target_Sistemas.Entities
{
    class Distribuidora
    {
        public string Estado { get; private set; }
        public double Value { get; private set; }
        
        

        public Distribuidora( string estado, double value)
        {
            Value = value;
            Estado = estado;
        }

        public void CalcularPorcentagem(double total)
        {
            double porcentagem = (100 / total) * Value;
            Console.WriteLine($"A distribuidora de {Estado} tem uma fatia de {porcentagem.ToString("F2")}% no faturamento");
        }
    }
}
