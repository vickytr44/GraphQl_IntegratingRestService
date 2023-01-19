using GraphQlService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<BooksRepository>();

builder.Services
    .AddHttpClient("rest", c => c.BaseAddress = new Uri("https://localhost:7034"));


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<BookExtensions>()
   .AddDocumentFromFile("./Schema.graphql")
   .AddJsonSupport()
   .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();

app.Run();