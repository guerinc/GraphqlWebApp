using HotChocolate.Types;
using WebApplication1.Models;
using System.Linq;
using HotChocolate;
using System.Collections.Generic;
using HotChocolate.Data.Filters;
using HotChocolate.Resolvers;
using Newtonsoft.Json.Linq;
using System;

namespace WebApplication1
{
    public class QueryObjectType
    {
        public IQueryable<Book> GetCommands(IResolverContext context, string name)
        {
            return context.Service<IBookService>().GetAll().Where(x => x.Name.Equals(name));
        }

        public IQueryable<Book> GetBooks(IResolverContext ctx) => ctx.Service<IBookService>().GetAll();
    }

    //public class BookType : ObjectType<Book>
    //{
    //    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    //    {
    //        descriptor.Field(d => d.Name).Type<DataType>();
    //    }
    //}

    //public class DataType : ObjectType
    //{
    //    protected override void Configure(IObjectTypeDescriptor descriptor)
    //    {
    //        descriptor.Field("name").Type<StringType>().Resolve((ctx, ct) => (string)ctx.Parent<JObject>()["name"]);
    //        descriptor.Field("price").Type<DecimalType>().Resolve((ctx, ct) => (decimal)ctx.Parent<JObject>()["price"]);
    //        descriptor.Field("createddate").Type<DateType>().Resolve((ctx, ct) => (DateTime)ctx.Parent<JObject>()["createdate"]);
    //    }
    //}

    public interface IBookService { IQueryable<Book> GetAll(); }

    public class InMemoryBookService : IBookService
    {
        private readonly Book[] _staticBooks = {
            new Book {Price = 11, CreatedDate = System.DateTime.Now,Name = "test"},
            new Book {Price = 22, CreatedDate = System.DateTime.Now,Name = "korku"},
            new Book {Price = 33, CreatedDate = System.DateTime.Now,Name = "deneme"},
            new Book {Price = 44, CreatedDate = System.DateTime.Now,Name = "commands"}
        };

        public IQueryable<Book> GetAll() => _staticBooks.AsQueryable();
    }
}
