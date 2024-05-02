using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores
{
    internal class TelaFornecedores : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Fornecedores...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10}",
                "Id", "Nome", "Telefone", "CNPJ"
            );

            EntidadeBase[] fornecedorescadastrados = repositorio.SelecionarTodos();

            foreach (Fornecedores fornecedor in fornecedorescadastrados)
            {
                if (fornecedor == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do fornecedor: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CNPJ do fornecedor: ");
            string CNPJ = Console.ReadLine();

            Fornecedores novoFornecedor = new Fornecedores(nome, telefone, CNPJ);

            return novoFornecedor;
        }
    }
}
