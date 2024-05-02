namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    internal abstract class RepositorioBase
    {
        protected List<EntidadeBase> registros = new List<EntidadeBase>();

        protected int contadorId = 1;

        public void Cadastrar(EntidadeBase novoRegistro)
        {
            novoRegistro.Id = contadorId++;

            RegistrarItem(novoRegistro);
        }

        public bool Editar(int id, EntidadeBase novaEntidade)
        {
            novaEntidade.Id = id;

            foreach (var registro in registros)
            {
                if (registro.Id == id)
                {
                    registros.Add(novaEntidade);
                    registros.Remove(registro);
                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            foreach (var registro in registros)
            {
                if (registro.Id == id)
                {
                    registros.Remove(registro);
                    return true;
                }
            }

            return false;
        }

        public EntidadeBase[] SelecionarTodos()
        {
            return registros.ToArray();
        }

        public EntidadeBase SelecionarPorId(int id)
        {
            foreach(var registro in registros)
            {
                EntidadeBase e = registro;

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return e;
            }

            return null;
        }

        public bool Existe(int id)
        {
            foreach (var registro in registros)
            {
                EntidadeBase e = registro;

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }

        protected void RegistrarItem(EntidadeBase novoRegistro)
        {
            registros.Add(novoRegistro);
        }
    }

}
