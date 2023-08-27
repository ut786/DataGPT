﻿using DataGPT.Net.Abstractions.Infrastructure;
using DataGPT.Net.Constants;
using DataGPT.Net.Infrastructure;
using DataGPT.Net.OpenAI;
using Microsoft.Extensions.DependencyInjection;

namespace DataGPT.Net;
public static class Setup
{
	public static IDataGptSetup AddDataGpt(this IServiceCollection services, AiClientConfig config)
	{
		services.AddHttpClient<HttpClient>(Strings.AI_CLIENT_NAME, client =>
		{
			client.BaseAddress = new Uri("https://api.openai.com/v1/");
			client.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.SecreteKey}");
		});
		services.AddScoped<IOpenAIClient, OpenAIClient>( );

		return new DataGptSetup { Services = services };
	}
}
