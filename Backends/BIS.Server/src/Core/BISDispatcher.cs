using MagicOnion.Server.Hubs;

using BIS.Shared.Network;





namespace BIS.Server
{
    public abstract class BISDispatcher : StreamingHubBase<IBISServerCall , IBISClientCall> , IBISServerCall
    {
        private BISNetworkData _receivedData;



        private BISNetworkData _responseData;





        protected BISNetworkEvent NetworkEvent { get; private set; }






        protected BISNetworkData GetReceivedData ( )
        {
            return new BISNetworkData ( this._receivedData );
        }



        protected void SetResponseData ( BISNetworkData responseData )
        {
            this._responseData = responseData;
        }



        protected void RemoveResponseData ( )
        {
            this._responseData = null;
        }



        public async ValueTask<BISNetworkData> CallEventAsync ( BISNetworkEvent networkEvent , BISNetworkData receivedData = null )
        {
            this.NetworkEvent = networkEvent;

            await this.DispatchAsync ( );

            return this._responseData;
        }



        protected abstract ValueTask DispatchAsync ( );
    }
}
