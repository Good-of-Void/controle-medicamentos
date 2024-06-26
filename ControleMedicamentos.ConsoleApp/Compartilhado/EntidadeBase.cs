﻿namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    internal abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract List<string> Validar();

        public abstract void AtualizarRegistro(EntidadeBase novoegistro);
    }
}
