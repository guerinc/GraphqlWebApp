using GraphQL;
using GraphQL.Client.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class BookConsumer
    {
        private readonly IGraphQLClient _client;
        public BookConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Book>> GetAllOwners(string dt)
        {
            var query = new GraphQLRequest
            {// books {
                Query = @"
                query QueryObjectType ($nameU: String) {
                    commands (name:$nameU) {
                    name,
                    price,
                    createdDate
                    }
                }",
                OperationName = "QueryObjectType",
                Variables = new { nameU = dt }
            };
            try
            {
                var response = await _client.SendQueryAsync<ResponseCommandsCollectionType>(query);
                return response.Data.Commands.ToList();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}

public class ResponseBookType
{
    public Book Book { get; set; }
}

public class ResponseBookCollectionType
{
    public Book[] Books { get; set; }
}

public class ResponseCommandsCollectionType
{
    public Book[] Commands { get; set; }
}