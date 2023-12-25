
using congrr.Data;
using congrr.Новая_папка;
using System.Drawing;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace congrr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DBContext>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            Task.Run(() =>
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                GetINfoBdRepository tg = new GetINfoBdRepository(configuration);
                tg.GetInfo();
            });
            Task.Run(() =>
            {
                tgWork tg = new tgWork();
                tg.start();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            
        }
            
    }
}