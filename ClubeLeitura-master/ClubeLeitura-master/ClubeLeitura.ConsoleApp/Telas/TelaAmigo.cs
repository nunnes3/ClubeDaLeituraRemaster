using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaAmigo : CadastroPadrao<Amigo> , ICadastravel
    {
        private readonly ControladorBase<Amigo> controladorAmigo;
        public TelaAmigo(ControladorBase<Amigo> controlador) : base(controlador,"Cadastro Amigo")
        {
            controlador = controlador;
        }

        public override void ApresentarTabela(Amigo[] amigos)
        {
            string configuracaoColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Nome", "Local");

            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine(configuracaoColunasTabela, amigo.id, amigo.nome, amigo.deOndeEh);
            }
        }

        public override Amigo ObterRegistro()
        {
            Console.Write("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amiguinho: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite da onde é o amiguinho: ");
            string deOndeEh = Console.ReadLine();

            return new Amigo(nome, nomeResponsavel, telefone, deOndeEh);
        }
    }
}
