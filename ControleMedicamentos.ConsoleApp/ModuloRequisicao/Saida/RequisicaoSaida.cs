﻿using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Saida
{
    internal class RequisicaoSaida : EntidadeBase
    {

        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRetirada { get; set; }

        public RequisicaoSaida(Medicamento medicamentoSelecionado, Paciente pacienteSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Paciente = pacienteSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeRetirada = quantidade;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Medicamento == null)
                erros.Add("O medicamento precisa ser preenchido");

            if (Paciente == null)
                erros.Add("O paciente precisa ser informado");

            if (QuantidadeRetirada < 1)
                erros.Add("Por favor informe uma quantidade válida");

            return erros;
        }

        public bool RetirarMedicamento()
        {
            if (Medicamento.Quantidade < QuantidadeRetirada)
                return false;

            Medicamento.Quantidade -= QuantidadeRetirada;
            return true;
        }

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            RequisicaoSaida novo = (RequisicaoSaida)novoregistro;

            this.Medicamento = novo.Medicamento;
            this.Paciente = novo.Paciente;
            this.DataRequisicao = novo.DataRequisicao;
            this.QuantidadeRetirada = novo.QuantidadeRetirada;

        }
    }
}
