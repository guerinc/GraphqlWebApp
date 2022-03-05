using HotChocolate;
using HotChocolate.Types;
using WebApplication1.Models;

namespace WebApplication1
{
    public class SubscriptionObjectType
    {
        [Topic]
        [Subscribe]
        public Book SubscribeProduct([EventMessage] Book book)
        {
            return book;
        }
    }
}
