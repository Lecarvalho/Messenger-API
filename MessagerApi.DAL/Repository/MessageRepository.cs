using System.Collections.Generic;
using MessagerApi.Business.Models;

namespace MessagerApi.DAL.Repository
{
    public class MessageRepository : RepositoryBase<MessageModel>
    {
        public MessageRepository(DataContext context) : base(context)
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