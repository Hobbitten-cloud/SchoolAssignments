namespace LearnHTTPS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", (HttpContext context) =>
            {
                HttpResponse response = context.Response;

                response.ContentType = "text/html";

                string textResponse = "";

                textResponse += "<h1> Welcome to my webserver </h1>";

                return textResponse;
            });

            app.MapGet("/plaintext", (HttpContext context) =>
            {
                return "<h2> Welcome to my webserver </h2>";
            });

            app.MapGet("/response", (HttpContext context) =>
            {
                HttpResponse response = context.Response;
                response.Headers["My-Custom-Header"] = "Mit eget response header";

                return "Hello world - I JUST SENT A RESPONSE HEADER";
            });

            app.MapGet("/codestatus", (HttpContext context) =>
            {
                HttpRequest request = context.Request;
                string path = request.Path;

                HttpResponse response = context.Response;
                response.StatusCode = 707;

                return "Request path " + path;
            });

            app.MapGet("/hello", () => "Hello World!");
            app.MapGet("/sejereje", () => "Dennis er sej");
            app.MapGet("/underviser/allan", () => "Allan elsker kaffe");

            app.Run();
        }
    }
}
