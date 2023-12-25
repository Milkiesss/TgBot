using Quartz;
using System.Security.Policy;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace congrr
{
    public class tgWork 
    {
        public static ITelegramBotClient client = new TelegramBotClient("6533860140:AAE2euuJUqN_Sw05EfUODQqrd0Qj5tdhhbc");
        public static long idChat;
        public async Task start()
        {
            client.StartReceiving(Update, Error);
        }

        private async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message.Text != null)
            {
                if (message.Text.ToLower().Contains("/start"))
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Работа бота началась");
                    idChat = message.Chat.Id;
                    return;
                }
            }
        }
        public async Task SendCongr(List<string> names)
        {
            var imagePath = "https://cdn-icons-png.flaticon.com/512/5013/5013829.png";

            foreach (var item in names)
            {
                    // Сбрасываем позицию потока в начало перед каждой отправкой изображения
                var file = new InputOnlineFile(imagePath);
                await client.SendPhotoAsync(idChat, file);
                

                await client.SendTextMessageAsync(idChat, $"с Днем Рождения! {item}");
            }
        }

    
        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

    }
}
