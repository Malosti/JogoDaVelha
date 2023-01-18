using System;

namespace JogoDaVelha
{
    class Menu
    {
        public void MenuJogo()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao Jogo da Velha");
            Console.WriteLine();
            Console.WriteLine("1 - Jogar");
            Console.WriteLine();
            Console.WriteLine("2 - Sair");
            Console.WriteLine();
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: var jogo = new JogoDaVelha(); jogo.Iniciar(); break;

                case 2: Environment.Exit(0); break;

                default: Console.WriteLine("Escolha uma opção válida..."); Console.ReadKey(); MenuJogo(); break;
            }
        }
    }
}
