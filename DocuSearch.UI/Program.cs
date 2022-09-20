using Microsoft.AspNetCore.Mvc.Versioning;
using Nest;
using DocuSearch.DataAccess;
using DocuSearch.DataAccess.InMemory;
using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Service.Interfaces;
using DocuSearch.Services;
using DocuSearch.UI.Controllers;

namespace DocuSearch.UI;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var services = builder.Services;
		var configuration = builder.Configuration;
		// Add services to the container.
		
		services.AddScoped<IDocumentInformationDataAccess, InMemoryDocumentInformationDataAccess>();
		services.AddScoped<IElasticSearchDataAccess, ElasticSearchDataAccess>();
		services.AddScoped<IFileStorageDataAccess, LocalFileStorageDataAccess>();
		services.AddTransient<IDocumentService, DocumentService>();
		services.AddTransient<IJobService, JobService>();
		services.AddTransient<IElasticSearchService, ElasticSearchService>();
		services.AddTransient<IFileStorageService, FileStorageService>();
		
		services.AddSingleton<IElasticClient>( sp =>
		{
			var settings = new ConnectionSettings(new Uri(configuration["ElasticSearch:Url"]))
				.EnableDebugMode()
				.PrettyJson()
				.RequestTimeout(TimeSpan.FromMinutes(2));
			return new ElasticClient(settings);
		});
		
		services.AddAutoMapper(typeof(DocumentController), typeof(DocumentService));
		services.AddApiVersioning(options =>
		{
			options.ReportApiVersions = true;
			options.ApiVersionReader = new UrlSegmentApiVersionReader();
		});
		services.AddControllersWithViews();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRouting();


		app.MapControllerRoute(
			name: "default",
			pattern: "{controller}/{action=Index}/{id?}");

		app.MapFallbackToFile("index.html");

		app.Run();
	}
}