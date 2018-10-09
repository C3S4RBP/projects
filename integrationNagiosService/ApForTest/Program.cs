using IntegrationNagiosLibrary.Nagios;
using IntegrationNagiosLibrary.Event;

namespace ApForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            nagiosCore NagiosCore = new nagiosCore();
            Events evtx = new Events();
            evtx.WriteToEventLog("Inicia pruebas");
            NagiosCore.integrationProcess();
        }
    }
}
