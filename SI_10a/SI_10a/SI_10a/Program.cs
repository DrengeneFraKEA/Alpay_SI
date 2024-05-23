using GraphiQl;
using GraphQL;
using GraphQL.Types;
using SI_10a;
using SI_10a.Queries;
using SI_10a.QueryTypes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Query>();
builder.Services.AddSingleton<Mutation>();
//builder.Services.AddSingleton<BookQuery>();
builder.Services.AddSingleton<BookType>();
//builder.Services.AddSingleton<BookMutation>();
//builder.Services.AddSingleton<AuthorQuery>();
builder.Services.AddSingleton<AuthorType>();
builder.Services.AddSingleton<MessageType>();


builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
var sp = builder.Services.BuildServiceProvider();
builder.Services.AddSingleton<ISchema>(new SI10aSchema(new FuncDependencyResolver(type => sp.GetService(type))));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.UseGraphiQl();

app.Run();
