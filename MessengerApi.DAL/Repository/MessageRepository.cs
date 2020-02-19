using System.Collections.Generic;
using MessengerApi.Business.Models;

namespace MessengerApi.DAL.Repository
{
    public class Messengerepository : RepositoryBase<MessageModel>
    {
        public Messengerepository(DataContext context) : base(context)
        {
        }

        public override IEnumerable<MessageModel> Get(int limit)
        {
            return new List<MessageModel>
            {
                new MessageModel
                {
                    Content = "Test"
                }
            };
        }

        public override MessageModel GetById(int id)
        {
            return new MessageModel
            {
                Content = "Test"
            };
        }

        public override void Insert(MessageModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}