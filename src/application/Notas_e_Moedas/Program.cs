using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Notas_e_Moedas
{
    class Program
    {
        /* Nome: Lucas Araujo dos Santos
         * RA: 081210009
         */
        
        #region Enunciado
        /* Notas e Moedas
         * 
         * Leia um valor de ponto flutuante com duas casas decimais.
         * Este valor representa um valor monetário.
         * A seguir, calcule o menor número de notas e moedas possíveis no qual o valor pode ser decomposto.
         * 
         * As notas consideradas são de 100, 50, 20, 10, 5, 2.
         * 
         * As moedas possíveis são de 1, 0.50, 0.25, 0.10, 0.05 e 0.01.
         * 
         * A seguir mostre a relação de notas necessárias.
         * 
         * Entrada
         * 
         * O arquivo de entrada contém um valor de ponto flutuante N (0 ≤ N ≤ 1000000.00).
         * 
         * Saída
         * 
         * Imprima a quantidade mínima de notas e moedas necessárias para trocar o valor inicial, conforme exemplo fornecido.
         * 
         * Obs: Utilize ponto (.) para separar a parte decimal.
         * 
         * Exemplo de Entrada:
         * 
         * 576.73
         * 
         * Exemplo de Saída:
         * 
         * NOTAS:
         * 
         * 5 nota(s) de R$ 100.00
         * 1 nota(s) de R$ 50.00
         * 1 nota(s) de R$ 20.00
         * 0 nota(s) de R$ 10.00
         * 1 nota(s) de R$ 5.00
         * 0 nota(s) de R$ 2.00
         * 
         * MOEDAS:
         * 1 moeda(s) de R$ 1.00
         * 1 moeda(s) de R$ 0.50
         * 0 moeda(s) de R$ 0.25
         * 2 moeda(s) de R$ 0.10
         * 0 moeda(s) de R$ 0.05
         * 3 moeda(s) de R$ 0.01
         * 
         * Link: https://www.beecrowd.com.br/judge/pt/problems/view/1021
         */
        #endregion

        #region Programa Principal
        static void Main(string[] args)
        {
            NotasMoedas notas = new NotasMoedas();
            decimal valor;
            char continua = 'S';

            do
            {
                Console.Clear();
                VerificaValor("Digite um valor: ", out valor);

                VerificarNotas(valor, out notas);

                ExibeNotas(notas);

                Console.WriteLine("\nDeseja continuar? (S/N)");
                continua = Console.ReadLine().ToString().ToUpper()[0];
            }
            while (continua == 'S');

            Console.WriteLine("\nPressione uma tecla para encerrar o programa...");
            Console.ReadKey();
        }
        #endregion

        #region Exibe Notas
        /// <summary>
        /// Este método exibe as notas necessárias para chegar no valor digitado pelo usuário.
        /// </summary>
        /// <param name="notas">Struct contendo a quantidade de cada nota e moeda necessária.</param>
        static void ExibeNotas(NotasMoedas notas)
        {
            Console.WriteLine($"\nNOTAS:\n\n{notas.cem} nota(s) de R$ 100.00\n" +
                $"{notas.cinquenta} nota(s) de R$ 50.00\n" +
                $"{notas.vinte} nota(s) de R$ 20.00\n" +
                $"{notas.dez} nota(s) de R$ 10.00\n" +
                $"{notas.cinco} nota(s) de R$ 5.00\n" +
                $"{notas.dois} nota(s) de R$ 2.00\n" +
                $"\nMOEDAS:\n\n{notas.umreal} moeda(s) de R$ 1.00\n" +
                $"{notas.cinquentacents} moeda(s) de R$ 0.50\n" +
                $"{notas.vintecincocents} moeda(s) de R$ 0.25\n" +
                $"{notas.dezcents} moeda(s) de R$ 0.10\n" +
                $"{notas.cincocents} moeda(s) de R$ 0.05\n" +
                $"{notas.umcentavo} moeda(s) de R$ 0.01");
        }
        #endregion

        #region Verifica Valor
        /// <summary>
        /// Este método verifica se o valor digitado pelo usuário é maior que zero e menor que 1000000.00
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida ao usuário.</param>
        /// <param name="valor">Variável em que será armazenado o valor digitado pelo usuário.</param>
        static void VerificaValor(string mensagem, out decimal valor)
        {
            valor = 0;

            do
            {
                try
                {
                    Console.WriteLine(mensagem);
                    valor = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    //valor = decimal.Parse(Console.ReadLine().Replace('.', ','));

                    if (valor <= 0 || Convert.ToDouble(valor) >= 1000000.00)
                        Console.WriteLine("\nO valor deve ser maior que zero e menor que 1000000.00!!\n");
                }
                catch
                {
                    Console.WriteLine("\nDigite apenas números!!\n");
                }
            }
            while (valor <= 0 || Convert.ToDouble(valor) >= 1000000.00);
        }
        #endregion

        #region Verificar Notas
        /// <summary>
        /// Este método verifica quantas notas e moedas serão necessárias para chegar no valor digitado pelo usuário.
        /// </summary>
        /// <param name="valor">Valor digitado pelo usuário.</param>
        /// <param name="notas">Struct em que será armazenado a quantidade de cada nota e moeda necessária para chegar no valor digitado pelo usuário.</param>
        static void VerificarNotas(decimal valor, out NotasMoedas notas)
        {
            // Calculando as notas
            notas.cem = ((int)valor) / 100;
            valor = valor % 100;

            notas.cinquenta = ((int)valor) / 50;
            valor = valor % 50;

            notas.vinte = ((int)valor) / 20;
            valor = valor % 20;

            notas.dez = ((int)valor) / 10;
            valor = valor % 10;

            notas.cinco = ((int)valor) / 5;
            valor = valor % 5;

            notas.dois = ((int)valor) / 2;
            valor = valor % 2;

            // Calculando as moedas
            valor = valor * 100;
            
            notas.umreal = ((int)valor) / 100;
            valor = valor % 100;

            notas.cinquentacents = ((int)valor) / 50;
            valor = valor % 50;

            notas.vintecincocents = ((int)valor) / 25;
            valor = valor % 25;

            notas.dezcents = ((int)valor) / 10;
            valor = valor % 10;

            notas.cincocents = ((int)valor) / 5;
            valor = valor % 5;

            notas.umcentavo = ((int)valor) / 1;
            valor = valor % 1;
        }
        #endregion

        #region Struct NotasMoedas
        struct NotasMoedas
        {
            public int cem;
            public int cinquenta;
            public int vinte;
            public int dez;
            public int cinco;
            public int dois;

            public int umreal;
            public int cinquentacents;
            public int vintecincocents;
            public int dezcents;
            public int cincocents;
            public int umcentavo;
        }
        #endregion
    }
}