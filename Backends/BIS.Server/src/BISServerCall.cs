using BIS.Shared.Network;





namespace BIS.Server
{
    public class BISServerCall : BISDispatcher
    {
        protected override async ValueTask DispatchAsync ( )
        {
            switch ( this.NetworkEvent )
            {
                case BISNetworkEvent.None:
                    await Task.Delay ( 0 );
                    break;
            }
        }
    }
}
