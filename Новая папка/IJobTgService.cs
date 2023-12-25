using Quartz;
using Telegram.Bot.Types;

namespace congrr.Новая_папка
{
    public class IJobTgService : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                List<string> name= new List<string>();
                foreach (var item in GetINfoBdRepository.entitys)
                {
                   if(DateTime.Today.Date == item.Date.Date)
                   {
                        name.Add(item.FullName);
                   }
                }
                tgWork tg = new tgWork();
                tg.SendCongr(name);

            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
