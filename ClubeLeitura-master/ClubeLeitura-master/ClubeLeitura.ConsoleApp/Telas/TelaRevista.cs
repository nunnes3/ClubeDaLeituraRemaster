using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaRevista : CadastroPadrao<Revista>,ICadastravel
    {
        private readonly TelaCaixa telaCaixa;
        private readonly ControladorBase<Caixa> controladorCaixa;        

        private readonly ControladorBase<Revista> controladorRevista;

        public TelaRevista(ControladorBase<Revista> ctrlRevista, ControladorBase<Caixa> ctrlCaixa, TelaCaixa tlCaixa)
            : base(ctrlRevista)
        {
            controladorRevista = ctrlRevista;
            telaCaixa = tlCaixa;
            controladorCaixa = ctrlCaixa;
        }

        public override void ApresentarTabela(Revista[] registros)
        {
            string configuracaColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Nome", "Coleção", "Caixa");

            foreach (Revista revista in registros)
            {
                Console.WriteLine(configuracaColunasTabela, revista.id, revista.nome,
                    revista.colecao, revista.caixa.cor);
            }
        }

        public override Revista ObterRegistro()
        {
            bool verificaCaixas = telaCaixa.VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (verificaCaixas == false)
            {
                TelaPrincipal tela = new TelaPrincipal();
                tela.ObterTelaBase();
            }



            Console.Write("\nDigite o número da caixa: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorCaixa.ExisteRegistroComEsteId(idCaixa);

            Caixa caixa = controladorCaixa.SelecionarRegistroPorId(idCaixa);

            Console.Write("Digite a nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write("Digite o número de edição da revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            return new Revista(nome, colecao, numeroEdicao, caixa);
        }
    }
}
