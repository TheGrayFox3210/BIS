using System.Collections.Generic;

using Newtonsoft.Json;
using MessagePack;
using System;





namespace BIS.Shared.Network
{
    [MessagePackObject( true )]
    public class BISNetworkData
    {
        public Dictionary<BISDataName , string> Container { get; set; } = new Dictionary<BISDataName , string> ( );





        public BISNetworkData ( )
        {

        }



        public BISNetworkData ( BISNetworkData source )
        {
            this.Container = new Dictionary<BISDataName, string> ( source.Container );
        }


                
        public T GetData<T> ( BISDataName dataName ) 
        {
            if ( this.Container.ContainsKey ( dataName ) == false )
                return default;
            return JsonConvert.DeserializeObject<T> ( this.Container[ dataName ] );
        }



        public void SetData ( BISDataName dataName , object data )
        {
            this.Container.Remove ( dataName );
            this.Container.Add ( dataName , JsonConvert.SerializeObject ( data ) );
        }



        public void RemoveData ( BISDataName dataName )
        {
            this.Container.Remove ( dataName );
        }
    }
}
