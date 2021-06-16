using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Controladores
{
    public class ControladorBase<T> where T : EntidadeBase
    {
        const int CAPACIDADE_REGISTROS = 100;
        protected T[] registros;

        private int ultimoId;

        public ControladorBase()
        {
            registros = new T[CAPACIDADE_REGISTROS];
        }

        public string InserirNovo(T generico)
        {
            string resultadoValidacao = generico.Validar();

            if (resultadoValidacao == "REGISTRO_VALIDO")
            {
                int posicao = ObterPosicaoVaga();
                generico.id = NovoId();
                registros[posicao] = generico;
            }

            return resultadoValidacao;
        }

        public string Editar(int id, T generico)
        {
            string resultado = generico.Validar();

            if (resultado == "REGISTRO_VALIDO")
            {
                int posicao = ObterPosicaoOcupada(id);
                generico.id = id;
                registros[posicao] = generico;
            }

            return resultado;
        }

        public bool ExisteRegistroComEsteId(int id)
        {
            return SelecionarRegistroPorId(id) != null;
        }

        public bool ExcluirRegistro(int id)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                

                if (id != null && id == i)
                {
                    int registroAnterior = i - 1; 
                    registros[registroAnterior] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }
            return conseguiuExcluir;
        }

        public T[] SelecionarTodosRegistros()
        {
            T[] registrosAux = new T[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (T registro in registros)
            {
                if (registro != null)
                    registrosAux[i++] = registro;
            }

            return registrosAux;
        }

        public T SelecionarRegistroPorId(int id)
        {
            T registro = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].id == id)
                {
                    registro = registros[i];

                    break;
                }
            }

            return registro;
        }

        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }

            return numeroRegistrosCadastrados;
        }

        protected int ObterPosicaoVaga()
        {
            int posicao = -1;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        protected int ObterPosicaoOcupada(int id)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].id == id)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        protected int NovoId()
        {
            return ++ultimoId;
        }
    }
}