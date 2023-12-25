using congrr.Data;
using Quartz;
using Quartz.Impl;
using static Quartz.Logging.OperationName;

namespace congrr.Новая_папка
{
    public class TimeTgService
    {
        public async Task TimeCount()
        {
            IScheduler schedulerFactory = await StdSchedulerFactory.GetDefaultScheduler();

            await schedulerFactory.Start();

            IJobDetail job = JobBuilder.Create<IJobTgService>()
           .WithIdentity("myJob", "group1")
           .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .WithDailyTimeIntervalSchedule(s =>
                    s.WithIntervalInHours(24)
                    .OnEveryDay())
                 .Build();
            await schedulerFactory.ScheduleJob(job, trigger);


        }
    }
}
