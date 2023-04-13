using System.Net.Mime;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Html.Parser;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/{**slug}",
        async context =>
        {
            var client = context.RequestServices.GetRequiredService<HttpClient>();
            var uri = new Uri($"https://www.vox.com/{context.Request.Path}");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                // Modify the content by replacing all six-letter words with the trademark symbol
                var parser = new HtmlParser();
                var document = parser.ParseDocument(content);
                var elements = document.QuerySelectorAll("p")
                    .Concat(document.QuerySelectorAll("li > a"))
                    .Concat(document.QuerySelectorAll("h1"))
                    .Concat(document.QuerySelectorAll("h2 > a"))
                    .Concat(document.QuerySelectorAll("h3 > a"));

                Parallel.ForEach(elements,
                    (node, _) =>
                    {
                        node.TextContent = Regex.Replace(node.TextContent, @"\b\w{6}\b", "$0™");
                    });

                content = document.ToHtml();
                document.Dispose();

                // replace all internal navigation links with proxy address
                content = content.Replace("https://www.vox.com", context.Request.Scheme + "://" + context.Request.Host);

                context.Response.ContentType = response.Content.Headers.ContentType?.MediaType ?? MediaTypeNames.Text.Html;
                await context.Response.WriteAsync(content);
            }
            else
            {
                context.Response.StatusCode = (int)response.StatusCode;
                await context.Response.WriteAsync(response.ReasonPhrase);
            }
        });
});

app.Run();