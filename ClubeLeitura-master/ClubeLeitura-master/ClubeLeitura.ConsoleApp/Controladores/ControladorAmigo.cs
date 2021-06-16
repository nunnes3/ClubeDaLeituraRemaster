using System;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Controladores
{
    public class ControladorAmigo : ControladorBase<Amigo>
    {       
        

        

        internal Amigo[] SelecionarTodosAmigos()
        {
             Amigo[] amigosAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigosAux, amigosAux.Length);

            return amigosAux;
        }

        internal Amigo SelecionarAmigoPorId(int idAmigo)
        {
            return (Amigo)SelecionarRegistroPorId(idAmigo);
        }
    }
}