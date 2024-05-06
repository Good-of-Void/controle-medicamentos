using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class RequisiçaoEntrada : EntidadeBase
    {
        public RequisiçaoEntrada(int quantidade, DateTime data, Medicamento medicamento, Fornecedor fornecedor, Funcionario funcionario)
        {
            Quantidade = quantidade;
            Data = data;
            Medicamento = medicamento;
            Fornecedor = fornecedor;
            Funcionario = funcionario;
        }

        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public Medicamento Medicamento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Convert.ToString(Quantidade).Trim()))
                erros.Add("O campo \"Quantidade\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Medicamento).Trim()))
                erros.Add("O campo \"Medicamento\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Fornecedor).Trim()))
                erros.Add("O campo \"Fornecedor\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Funcionario).Trim()))
                erros.Add("O campo \"Funcionario\" é obrigatório");

            return erros;
        }

        public bool RetirarMedicamento()
        {
            if (Medicamento.Quantidade < Quantidade)
                return false;

            Medicamento.Quantidade -= Quantidade;
            return true;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            RequisiçaoEntrada novo = (RequisiçaoEntrada)novoegistro;

            this.Data = novo.Data; 
            this.Quantidade = novo.Quantidade; 
            this.Medicamento = novo.Medicamento; 
            this.Fornecedor = novo.Fornecedor; 
            this.Funcionario = novo.Funcionario; 
        }
    }
}
