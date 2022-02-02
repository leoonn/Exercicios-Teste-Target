using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Teste_Target_Sistemas.Entities;
using System.Text.Json;
using Teste_Target_Sistemas.Services;

namespace Teste_Target_Sistemas
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite o numero do exercicio que quer executar de 1 ao 5, Digite 0 para Sair");
            int opcao = int.Parse(Console.ReadLine());
            while (opcao != 0)
            {

                switch (opcao)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opcao nao encontrada, digite novamente");
                        break;
                }
                Console.WriteLine("Digite o numero do exercicio que quer executar de 1 ao 5, Digite 0 para Sair");
                opcao = int.Parse(Console.ReadLine());
            }
            Exercise3();
        }

        static void Exercise1()
        {
            int INDICE = 13, SOMA = 0, K = 0;
            while (K < INDICE)
            {
                K += 1;
                SOMA += K;
            }
            Console.WriteLine(SOMA);
        }
        static void Exercise2()
        {
            List<int> listFibo = new List<int>();
            int Value = 0, fibo = 1;
            Console.WriteLine($"Digite um numero para a sequencia de fibonacci");
            int n = int.Parse(Console.ReadLine());
            while (fibo <= n)
            {
                Console.WriteLine($"{Value} + {fibo} = ");
                Value += fibo;
                Console.WriteLine(Value);
                Console.Write($"{Value} + {fibo}");
                fibo += Value;
                Console.WriteLine($" = {fibo} ");

                listFibo.Add(fibo);
                listFibo.Add(Value);
            }
            if (listFibo.Contains(n))
            {
                Console.WriteLine("O numero inserido faz parte da sequencia ");
            }
            else
            {
                Console.WriteLine("O numero inserido não faz parte da sequencia ");
            }
        }
        static void Exercise3()
        {
            //Será necessario alterar o path com o do seu computador
            string pathJson = @"C:\Users\USERS\OneDrive\Documentos\GitHub\Exercicios-Teste-Target-Sistemas\Exercicios-Teste-Target-Sistemas\Json-Exercicio-3\dados.json";

            if (File.Exists(pathJson))
            {
                double menorValor, maiorvalor;
                int diasSuperiorAMedia;
                List<Faturamento> faturamento = JsonSerializer.Deserialize<List<Faturamento>>(File.ReadAllText(pathJson));
                if (faturamento != null)
                {
                    FaturamentoServices ServiceFat = new FaturamentoServices();
                    menorValor = ServiceFat.MenorValorEmUmDia(faturamento);
                    maiorvalor = ServiceFat.MaiorValorEmUmDia(faturamento);
                    diasSuperiorAMedia = ServiceFat.DiasSuperiorAMedia(faturamento);

                    Console.WriteLine($"O menor valor é: {menorValor.ToString("F2")}");
                    Console.WriteLine($"O maior valor é: {maiorvalor.ToString("F2")}");
                    Console.WriteLine($"Houve {diasSuperiorAMedia} dias em que o valor diario de faturamento foi maior que a média");
                }
            }
        }
        static void Exercise4()
        {
            /* SUMARY
             SP – R$67.836,43
             RJ – R$36.678,66
             MG – R$29.229,88
             ES – R$27.165,48
             Outros – R$19.849,53
            */
            Distribuidora Sp = new Distribuidora("SP", 67836.43);
            Distribuidora Rj = new Distribuidora("RJ", 36678.66);
            Distribuidora Mg = new Distribuidora("MG", 29229.88);
            Distribuidora Es = new Distribuidora("ES", 27165.48);
            Distribuidora Outros = new Distribuidora("Outros", 19849.53);
            List<Distribuidora> distribuidoras = new List<Distribuidora>();
            distribuidoras.Add(Sp);
            distribuidoras.Add(Rj);
            distribuidoras.Add(Mg);
            distribuidoras.Add(Es);
            distribuidoras.Add(Outros);

            double total = distribuidoras.Sum(d => d.Value);
            foreach (Distribuidora distribuidora in distribuidoras)
            {
                distribuidora.CalcularPorcentagem(total);
            }
        }
        static void Exercise5()
        {
            Console.WriteLine("Digite uma palavra para ser invertida");
            string entrada = Console.ReadLine();
            char[] letras = new char[entrada.Length];
            string invert = "";
            for (int CountLetras = 0; CountLetras < entrada.Length; CountLetras++)
            {
                letras[CountLetras] = entrada[CountLetras];
            }
            for (int i = entrada.Length; i >= 1; i--)
            {
                invert = invert + letras[i - 1];
                if (invert.Length == entrada.Length)
                {
                    Console.WriteLine($"A palavra invertida é: {invert}");
                }
            }
        }
    }
}
