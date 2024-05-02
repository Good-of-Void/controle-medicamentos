

using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class Paciente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CartaoSus { get; set; }

        public Paciente(string nome, string telefone, string cartaoSus)
        {
            Nome = nome;
            Telefone = telefone;
            CartaoSus = cartaoSus;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros.Add("O Nome do Paciente precisa conter ao menos 3 caracteres");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O Telefone precisa ser preenchido");

            if (string.IsNullOrEmpty(CartaoSus))
                erros.Add("O Cartão do SUS precisa ser preenchido");

            return erros;
        }
    }
}
