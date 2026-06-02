using System;

using System.Threading;
using System.Threading.Tasks;

using MagicOnion;
using MagicOnion.Client;

using BIS.Shared.Network;





namespace BIS.Client.Core
{
    internal class BISNetwork
    {
        private SynchronizationContext _mainThread;
        
        
        
        
        
        public string HostName { get; private set; }
        
        
        
        public int PortNumber { get; private set; }
        
        
        
        
        
        
        
        public BISNetwork ( string hostName , int portNumber )
        {
            _mainThread = SynchronizationContext.Current;
            
            HostName = hostName;
            PortNumber = portNumber;
            
            try
            {
                var channel = GrpcChannelx.ForAddress ( "http://" + HostName + ":" + PortNumber );
            }
            catch ( Exception exception )
            {
                Console.WriteLine ( exception );
                throw;
            }
        }
    }
}