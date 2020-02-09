using System;
using MessagerApi.DAL.Configuration;
using Microsoft.Extensions.Options;

namespace MessagerApi.DAL
{
    public class DataContext
    {
        public DataContext(IOptions<FirestoreConfig> firestoreConfig)
        {
            Connect(firestoreConfig.Value);
        }

        private void Connect(FirestoreConfig firestoreConfig)
        {
            //connect here
        }
    }
}
