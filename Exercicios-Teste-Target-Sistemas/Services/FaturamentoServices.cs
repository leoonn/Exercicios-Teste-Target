using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste_Target_Sistemas.Entities;

namespace Teste_Target_Sistemas.Services
{
    class FaturamentoServices
    {
        public double MenorValorEmUmDia(List<Faturamento> faturamento)
        {
            
            return faturamento.Where(f => f.valor != 0).Min(f => f.valor);
        }
        public double MaiorValorEmUmDia(List<Faturamento> faturamento)
        {
            
            return faturamento.Where(f => f.valor != 0).Max(f => f.valor);
        }
        public int DiasSuperiorAMedia(List<Faturamento> faturamento)
        {
            int count = 0;
            double Sum = faturamento.Where(f => f.valor != 0).Sum(f => f.valor);
            double media = Sum / faturamento.Count(f => f.valor != 0);
            foreach (Faturamento faturamentos in faturamento)
            {
                if (faturamentos.valor > media)
                {
                    count++;
                }
            }
            Console.WriteLine($"A media de faturamento no mes foi de: {media}");
            return count;
        }
    }
}
