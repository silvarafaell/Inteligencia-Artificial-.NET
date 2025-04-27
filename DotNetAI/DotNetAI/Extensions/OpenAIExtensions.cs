using OpenAI;

namespace DotNetAI.Extensions
{
    public static class OpenAIExtensions
    {
        public static WebApplicationBuilder AddOpenAI(this WebApplicationBuilder builder)
        {
            // var apiKey = builder.Configuration["OpenAI:Key"];
            var apiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY"); //pega o valor da variavel de ambiente do windows

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("OpenAI API key is not set.");
            }

            var openAIClient = new OpenAIClient(apiKey);

            builder.Services.AddSingleton(openAIClient);
            return builder;
        }

    }
}
