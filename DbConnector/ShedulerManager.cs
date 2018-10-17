using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace DbConnector
{
    class Job : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }

    class ShedulerManager
    {
        public static async void Start()
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            var job = JobBuilder.Create<Job>().Build();

            var trigger = TriggerBuilder.Create()
//                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

    }
}
