using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public abstract class  CadastroPadrao<T> : TelaBase where T : EntidadeBase 
    {
        private string telaNome;
        ControladorBase<T> controladorBase;

        public CadastroPadrao(ControladorBase<T> controlador, string nomeTela) : base(nomeTela)
        {
            telaNome = nomeTela;
            controladorBase = controlador;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo registro...");

            T registro = ObterRegistro();

            string resultadoValidacao = controladorBase.InserirNovo(registro);

            if (resultadoValidacao == "REGISTRO_VALIDO")
                ApresentarMensagem("Registro inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela("Visualizando registros...");

            T[] registros = controladorBase.SelecionarTodosRegistros();

            if (registros.Length == 0)
            {
                ApresentarMensagem("Nenhum registro cadastrado!", TipoMensagem.Atencao);
                return false;
            }

            ApresentarTabela(registros);

            return true;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um registro...");

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write("\nDigite o número do registro que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorBase.ExisteRegistroComEsteId(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem("Nenhum registro foi encontrado com este número: " + id, TipoMensagem.Erro);
                EditarRegistro();
                return;
            }

            T registro = ObterRegistro();

            string resultadoValidacao = controladorBase.Editar(id, registro);

            if (resultadoValidacao == "REGISTRO_VALIDO")
                ApresentarMensagem("Registro editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um registro...");

            //T registro = ObterRegistro();

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write("\nDigite o número do registro que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorBase.ExisteRegistroComEsteId(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem("Nenhum registro foi encontrado com este número: " + id, TipoMensagem.Erro);
                ExcluirRegistro();
                return;
            }

            bool conseguiuExcluir = controladorBase.ExcluirRegistro(id);

            if (conseguiuExcluir)
                ApresentarMensagem("Registro excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o registro", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public abstract void ApresentarTabela(T[] registros);
        

        public abstract T ObterRegistro();

    }
}
