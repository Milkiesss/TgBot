using congrr.Data;
using congrr.UpdateIvent;

namespace congrr.Новая_папка
{
    public class GetINfoBdRepository
    {

        public static List<model> entitys = new List<model>();

        private readonly IConfiguration configuration1;

        public GetINfoBdRepository(IConfiguration configuration)
        {
            configuration1 = configuration;
            UpdateDb.Updated += (sender, args) => GetInfo();
        }

        public async Task StartTrigers()
        {
            TimeTgService timeTgService = new TimeTgService();
            timeTgService.TimeCount();
        }
        public async Task GetInfo()
        {
            entitys.Clear();

            using (var context = new DBContext(configuration1))
            {
                entitys.AddRange(context.birth.ToList());
            }
            StartTrigers();
        }
    }
}
