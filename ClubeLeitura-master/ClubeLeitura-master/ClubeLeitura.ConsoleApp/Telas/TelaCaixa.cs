using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : CadastroPadrao<Caixa>,ICadastravel
    {
        private readonly ControladorBase<Caixa> controladorCaixa;
        public TelaCaixa(ControladorBase<Caixa> controlador) : base(controlador, "Cadastro Caixa")

        {
            controladorCaixa = controlador;
        }

        public override void ApresentarTabela(Caixa[] registros)
        {
            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Etiqueta", "Cor");

            foreach (Caixa caixa in registros)
            {
                Console.WriteLine(configuracaColunasTabela, caixa.id, caixa.etiqueta, caixa.cor);
            }
        }

        public override Caixa ObterRegistro()
        {
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            return new Caixa(cor, etiqueta);
        }
    }
}