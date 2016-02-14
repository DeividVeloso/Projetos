using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassagensAereas
{
    public class ClienteService : IClienteService
    {
        public bool Salvar(string nome, string cpf)
        {
            ClienteDAO dao = new ClienteDAO();
            try
            {
                Cliente cliente = new Cliente();
                cliente.CPF = cpf;
                cliente.Nome = nome;
                dao.Salvar(cliente);
                return true;
            }
            catch (Exception ex)
            {
                //Salva Log
                throw;
            }
            return false;
        }

        public Cliente Buscar(string nome)
        {
            ClienteDAO dao = new ClienteDAO();
            return dao.Buscar(nome);
        }


        public List<Cliente> getClientes()
        {
            return ClienteDAO.dados;
        }

    }
}
