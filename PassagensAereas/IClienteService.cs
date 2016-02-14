using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace PassagensAereas
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat= WebMessageFormat.Xml, UriTemplate="addCliente/{nome};{cpf}")]
        bool Salvar(string nome, string cpf);

        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat= WebMessageFormat.Xml, UriTemplate = "getClienteByNome/{nome}")]
        Cliente Buscar(string nome);

        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat= WebMessageFormat.Json, UriTemplate="getClientes/")]
        List<Cliente> getClientes();
    }
}
