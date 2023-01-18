using System;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        public bool FimDeJogo { get; set; }
        public char[] Posicoes { get; set; }
        private char JogadorVez { get; set; }
        public short Contador { get; set; }

        public JogoDaVelha()
        {
            FimDeJogo = false;
            Posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            JogadorVez = 'X';
            Contador = 0;
        }

        public void Iniciar()
        {
            while (!FimDeJogo)
            {  
                TabelaJogo();
                LerEscolha();
                TabelaJogo();
                VerificarFimDeJogo();
                MudarVez();
            }

            var menu = new Menu();
            Console.ReadKey();
            menu.MenuJogo();
        }

        private void MudarVez()
        {
            JogadorVez = JogadorVez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if (Contador < 5)
                return;
            if (VeridicarHorizontal() || VeridicarVertical() || VeridicarDiagonal())
            {
                FimDeJogo = true;
                Console.WriteLine($"Fim de Jogo! Marcador {JogadorVez} venceu !!!");
            }

            if(Contador is 9 && !FimDeJogo)
            {
                FimDeJogo = true;
                Console.WriteLine($"Fim de Jogo! Empate");
            }
        }

        private bool VeridicarHorizontal()
        {
            bool vitoriaLinha1 = Posicoes[0] == Posicoes[1] && Posicoes[0] == Posicoes[2];
            bool vitoriaLinha2 = Posicoes[3] == Posicoes[4] && Posicoes[3] == Posicoes[5];
            bool vitoriaLinha3 = Posicoes[6] == Posicoes[7] && Posicoes[6] == Posicoes[8];

            return (vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3);
        }
        
        private bool VeridicarVertical()
        {
            bool vitoriaColuna1 = Posicoes[0] == Posicoes[3] && Posicoes[0] == Posicoes[6];
            bool vitoriaColuna2 = Posicoes[1] == Posicoes[4] && Posicoes[1] == Posicoes[7];
            bool vitoriaColuna3 = Posicoes[2] == Posicoes[5] && Posicoes[2] == Posicoes[8];

            return (vitoriaColuna1 || vitoriaColuna2 || vitoriaColuna3);
                
        }
        
        private bool VeridicarDiagonal()
        {
            bool vitoriaDiagonal1 = Posicoes[0] == Posicoes[4] && Posicoes[0] == Posicoes[8];
            bool vitoriaDiagonal2 = Posicoes[2] == Posicoes[4] && Posicoes[2] == Posicoes[6];

            return (vitoriaDiagonal1 || vitoriaDiagonal2);
        }
        
        private void LerEscolha()
        {
            Console.Write("Digite a posição desejada: ");
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            
            while (!conversao || !ValidarEscolha(posicaoEscolhida))
            {
                Console.WriteLine("Escolha um valor válido");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            Posicoes[indice] = JogadorVez;
            Contador++;
        }

        private bool ValidarEscolha(int posicaoEscolhida)
        {
            try
            {
                int indice = posicaoEscolhida - 1;
                return Posicoes[indice] != 'O' && Posicoes[indice] != 'X';
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Valor digitado excede o limite de posições disponíveis no jogo" );
                return false;
            }
        }

        private void TabelaJogo()
        {
            Console.Clear();
            Console.WriteLine(Tabela());
        }

        private string Tabela()
        {
            return $"{Posicoes[0]} | {Posicoes[1]} | {Posicoes[2]} \n" +
                   "_________\n" +
                   $"{Posicoes[3]} | {Posicoes[4]} | {Posicoes[5]} \n" +
                   "_________\n" +
                   $"{Posicoes[6]} | {Posicoes[7]} | {Posicoes[8]} \n";
        }
    }
}
