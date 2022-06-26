using System.Diagnostics;

namespace Hangfire.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            //*****
            //Minute(0-59) Hour(0-23) DayOfMonth(1-31) Month(1-12) DayOfWeek(0-6)
            //cronmaker.com

            Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), Cron.Minutely);
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Report has been sent");
        }
    }
}
