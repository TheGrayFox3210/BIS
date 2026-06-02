using System.Threading.Tasks;

using MagicOnion;





namespace BIS.Shared.Network
{
    public interface IBISServerCall : IStreamingHub<IBISServerCall , IBISClientCall>
    {
        ValueTask<BISNetworkData> CallEventAsync ( BISNetworkEvent networkEvent , BISNetworkData networkData = null );
    }





    public interface IBISClientCall
    {
        void OnCallEvent ( BISNetworkEvent networkEvent , BISNetworkData receivedData = null );
    }





    public class BISClientCall : IBISClientCall
    {
        public delegate void BISReceivedEventHandler ( BISNetworkEvent networkEvent , BISNetworkData receivedData = null );





        public event BISReceivedEventHandler Received;





        public void OnCallEvent ( BISNetworkEvent networkEvent , BISNetworkData receivedData = null )
        {
            this.Received?.Invoke ( networkEvent , receivedData );
        }
    }
}
