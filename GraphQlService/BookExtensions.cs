﻿using System.Text.Json;

namespace GraphQlService;

[ExtendObjectType(typeof(Book))]
public class BookExtensions
{
    [GraphQLType("Author!")]
    public async Task<JsonElement> GetAuthorAsync(
        [Parent] Book book,
        [Service] IHttpClientFactory clientFactory,
        CancellationToken cancellationToken)
    {
        using var client = clientFactory.CreateClient("rest");
        var content = await client.GetByteArrayAsync($"authors/{book.AuthorId}", cancellationToken);
        return JsonDocument.Parse(content).RootElement;
    }
}
