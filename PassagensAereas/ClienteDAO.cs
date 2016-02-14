using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassagensAereas
{
    public class ClienteDAO
    {
        public static List<Cliente> dados = new List<Cliente>();

        public void Salvar(Cliente cliente)
        {
            ClienteDAO.dados.Add(cliente);
        }

        public Cliente Buscar(string nome)
        {
            foreach (Cliente cliente in dados)
            {
                if (cliente.Nome.Equals(nome))
                {
                    return cliente;
                }
            }
            return null;
        }

    }
}
