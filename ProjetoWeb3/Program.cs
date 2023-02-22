using ProjetoWeb3_Infra.Data.Repository;
using ProjetoWeb3_Service.Interface;
using ProjetoWeb3_Service.Service;



namespace ProjetoWeb3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICityEventService, CityEventService>();
            builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();

            builder.Services.AddScoped<IEventReservationService, EventReservationService>();
            builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
