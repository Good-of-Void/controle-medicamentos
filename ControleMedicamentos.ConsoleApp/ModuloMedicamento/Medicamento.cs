﻿using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : EntidadeBase
    {
        public Medicamento(string nome, string descricao, string lote, DateTime dataValidade)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            DataValidade = dataValidade;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        private DateTime DataValidade { get; set; }
        public int Quantidade { get; set; } = 5;

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Descricao.Trim()))
                erros.Add("O campo \"descrição\" é obrigatório");

            if (string.IsNullOrEmpty(Lote.Trim()))
                erros.Add("O campo \"lote\" é obrigatório");

            DateTime hoje = DateTime.Now.Date;

            if (DataValidade < hoje)
                erros.Add("O campo \"data de validade\" não pode ser menor que a data atual");

            return erros;
        }

        public bool RetirarMedicamento(int quantidade,Medicamento medicamento)
        {
            if(medicamento.Quantidade >= quantidade)
            {
                medicamento.Quantidade -= quantidade;
                return true;
            }
            return false;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Medicamento novasInformacoes = (Medicamento)novoegistro;

            this.Nome = novasInformacoes.Nome;
            this.Descricao = novasInformacoes.Descricao;
            this.Lote = novasInformacoes.Lote;
            this.DataValidade = novasInformacoes.DataValidade;
            this.Fornecedor = novasInformacoes.Fornecedor;
            this.Quantidade = novasInformacoes.Quantidade;
        }
    }
}
