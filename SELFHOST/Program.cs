using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SELFHOST
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8111/hello");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }

    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string HelloUnknown();

        [OperationContract]
        string About();
    }

    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }

        public string HelloUnknown()
        {
            return string.Format("Hello Unknown");
        }

        public string About()
        {
            return "About";
        }
    }

}
