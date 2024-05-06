using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : EntidadeBase
    {
        //Contrutor
        public Medicamento(string nome, string descricao,int quantidade, string lote, DateTime dataValidade, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            Quantidade = Quantidade;    
            Lote = lote;
            DataValidade = dataValidade;
            Fornecedor = fornecedor;
        }

        //variaveis e gets e sets
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        private DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public Fornecedor Fornecedor { get; set; }

        //valida a entrada de dados
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Descricao.Trim()))
                erros.Add("O campo \"descrição\" é obrigatório");

            if (string.IsNullOrEmpty(Lote.Trim()))
                erros.Add("O campo \"lote\" é obrigatório");
            
            if (string.IsNullOrEmpty(Convert.ToString(Fornecedor).Trim()))
                erros.Add("O campo \"Fornecedor\" é obrigatório");
            
            if (string.IsNullOrEmpty(Convert.ToString(Quantidade).Trim()))
                erros.Add("O campo \"quantidade\" é obrigatório");

            if (Quantidade <= 0)
                erros.Add("A quantidade tem que ser maior que 0");

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
