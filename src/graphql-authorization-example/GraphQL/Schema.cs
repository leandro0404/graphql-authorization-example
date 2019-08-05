using GraphQL;
using GraphQL.Authorization;
using GraphQL.Types;
using graphql_authorization_example.Authorize;
using graphql_authorization_example.Models;
using System.Collections.Generic;

namespace graphql_authorization_example.GraphQL
{
    #region Schema
    public class BaseSchema : Schema
    {
        public BaseSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<BaseQuery>();
            Mutation = resolver.Resolve<BaseMutation>();

        }
    }
    #endregion

    #region Query / Mutation
    public class BaseQuery : ObjectGraphType
    {
        public BaseQuery()
        {
            Field<ListGraphType<ProductType>>(
              nameof(Product),
              arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "filter" }),
              resolve: context =>
              {
                  var filter = context.GetArgument<Product>("filter");
                  return new List<Product> {
                      new Product { Id= 1, Name ="produto 1" , Price = 1},
                      new Product { Id= 2, Name ="produto 2" , Price = 2}
                  };
              }
          );
        }
    }
    public class BaseMutation : ObjectGraphType<Product>
    {
        public BaseMutation()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Price);
        }
    }
    #endregion

    #region Types
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Price).AuthorizeWith(AuthorizePolicy.Email);
        }
    }
    public class ProductInputType : InputObjectGraphType<Product>
    {
        public ProductInputType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Price);
        }
    }
    #endregion

}
