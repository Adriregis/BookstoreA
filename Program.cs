using BookstoreA.Data;
using BookstoreA.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<GenreService>();
        builder.Services.AddScoped<BookService>();
        builder.Services.AddScoped<SeedingService>();


        builder.Services.AddDbContext<BookstoreContext>(options =>
		{
			options.UseMySql(
				builder
					.Configuration
					.GetConnectionString("BookstoreContext"),
				ServerVersion
					.AutoDetect(
						builder
							.Configuration
							.GetConnectionString("BookstoreContext")
					)
			);
		});


        var app = builder.Build();

        var ptBR = new CultureInfo("pt-BR");

        var localizationOption = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(ptBR),
            SupportedCultures = new List<CultureInfo> { ptBR },
            SupportedUICultures = new List<CultureInfo> { ptBR }
        };

        app.UseRequestLocalization(localizationOption);


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}
        else
        {
            app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
        }

        app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}