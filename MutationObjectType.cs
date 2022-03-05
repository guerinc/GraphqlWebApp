using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MutationObjectType
    {
        public async Task<string> AddProduct(
            [Service] ITopicEventSender eventSender,
            Book model)
        {
            // add your own logic to saving data into some data store.
            //model.CreatedDate = DateTime.Now;
            await eventSender.SendAsync(nameof(SubscriptionObjectType.SubscribeProduct), model);
            return model.Name;
        }
    }
}
