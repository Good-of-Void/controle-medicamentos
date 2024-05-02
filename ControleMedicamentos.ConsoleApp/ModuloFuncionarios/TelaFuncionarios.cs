using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios
{
    internal class TelaFuncionarios : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Funcionários...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "CPF"
            );

            List<EntidadeBase> funcionarioscadastrados = repositorio.SelecionarTodos();

            foreach (Funcionarios funcionario in funcionarioscadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CPF do funcionário: ");
            string CPF = Console.ReadLine();

            Funcionarios novoFuncionario = new Funcionarios(nome, telefone, CPF);

            return novoFuncionario;
        }
 
    }
}
