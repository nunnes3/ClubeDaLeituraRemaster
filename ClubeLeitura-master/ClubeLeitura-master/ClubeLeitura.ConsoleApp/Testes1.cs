﻿using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class Testes1
    {
        static void Main2(string[] args)
        {
            Amigo amigo = NovoAmigo();

            Caixa caixa = NovaCaixa();

            Revista revista = NovaRevista(caixa);

            ControladorEmprestimo ctrlEmprestimo = new ControladorEmprestimo();

            string resultado;

            resultado = ctrlEmprestimo.RegistrarEmprestimo(amigo, revista, DateTime.Now);

            bool conseguiuDevolver = ctrlEmprestimo.RegistrarDevolucao(1, DateTime.Now);

            resultado = ctrlEmprestimo.RegistrarEmprestimo(amigo, revista, DateTime.Now);
        }

        #region CRUDS
        private static Revista NovaRevista(Caixa caixa)
        {
            Revista revista = new Revista("Superman", "Trilogia", 10, caixa);
            ControladorBase<Revista> ctrlRevistas = new ControladorBase<Revista>();
            ctrlRevistas.InserirNovo(revista);
            return revista;
        }

        private static Caixa NovaCaixa()
        {
            Caixa caixa = new Caixa("Azul", "xua-654");
            ControladorBase<Caixa> ctrlCaixas = new ControladorBase<Caixa>();
            ctrlCaixas.InserirNovo(caixa);
            return caixa;
        }

        private static Amigo NovoAmigo()
        {
            Amigo amigo = new Amigo("Léo", "Gabriel", "321", "Otacílio");
            ControladorBase<Amigo> ctrlAmigos = new ControladorBase<Amigo>();
            ctrlAmigos.InserirNovo(amigo);
            return amigo;
        }

        #endregion
    }
}
