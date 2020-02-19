using System;
using MessengerApi.DAL.Configuration;
using Microsoft.Extensions.Options;

namespace MessengerApi.DAL
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
