using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisiçaoEntrada
{
    internal class TelaRequisiçaoEntrada : TelaBase
    {

        public TelaPaciente telaPaciente = null;
        public TelaMedicamento telaMedicamento = null;
        public TelaFornecedor telaFornecedor = null;
        public TelaFuncionario telaFuncionario = null;

        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequisicaoSaida entidade = (RequisicaoSaida)ObterRegistro();

            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros.ToArray());
                return;
            }

            bool conseguiuRetirar = entidade.RetirarMedicamento();

            if (!conseguiuRetirar)
            {
                ExibirMensagem("A quantidade de retirada informada não está disponível.", ConsoleColor.DarkYellow);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisição de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "Id", "Data da requisição ", "Medicamento" , "Quantidade Retirada" , "Funcionario"
            );

            List<EntidadeBase> RequisicoesEntrada = repositorio.SelecionarTodos();

            foreach (RequisiçaoEntrada entrada in RequisicoesEntrada)
            {
                if (entrada == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    entrada.Id, entrada.Data, entrada.Medicamento.Nome, entrada.Quantidade, entrada.Funcionario.Nome
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        
        protected override EntidadeBase ObterRegistro()
        {

            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o id do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            Console.Write("Digite a quantidade a ser retirada: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            telaFornecedor.VisualizarRegistros(false);

            Console.Write("Digite o id do fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o id funcionario: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            Console.Write("Digite a data da requisição: ");
            DateTime dataRequisicao = Convert.ToDateTime(Console.ReadLine());

            
            RequisiçaoEntrada requisiçaoEntrada = new RequisiçaoEntrada(
                quantidade, dataRequisicao,
                medicamentoSelecionado, fornecedorSelecionado,
                funcionarioSelecionado);

            return requisiçaoEntrada;
        }
    }
}
