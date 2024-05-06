using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : TelaBase
    {
        public TelaFornecedor telaFornecedor = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Medicamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {2, -20}",
                "Id", "Nome", "Quantidade", "Fornecedor"
            );

            List<EntidadeBase> medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {2, -20}",
                    medicamento.Id, medicamento.Nome, medicamento.Quantidade,medicamento.Fornecedor
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();
            
            Console.Write("Digite a quantidade: ");
            int quantidade = (int)Convert.ToUInt32(Console.ReadLine());

            telaFornecedor.VisualizarRegistros(false);

            Console.Write("Digite o id do fornecedor: ");
            int idFornecedor = (int)Convert.ToUInt32(Console.ReadLine());

            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            Console.Write("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao,quantidade, lote, dataValidade,fornecedorSelecionado);

            return medicamento;
        }
    }
}
