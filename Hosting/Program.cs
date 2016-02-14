using PassagensAereas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Por que usar typeof?
            ServiceHost servico = new ServiceHost(typeof(ClienteService));
            Uri endereco = new Uri("http://localhost:8080/cliente");

            servico.AddServiceEndpoint(typeof(IClienteService), new BasicHttpBinding(), endereco);

            try
            {
                servico.Open();
                printServiceInformation(servico);
                Console.ReadLine();
                servico.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                servico.Abort();
                Console.ReadLine();
            }
        }

        public static void printServiceInformation(ServiceHost host)
        {
            Console.WriteLine("{0} service online", host.Description.ServiceType);
            foreach (ServiceEndpoint  se in host.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
}
