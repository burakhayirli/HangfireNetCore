using System.Diagnostics;

namespace Hangfire.Web.BackgroundJobs
{
    public class ContinuationJobs
    {
        public static void WriteWatermarkStatusJob(string id, string filename)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{filename} : Watermark has been added to picture"));
        }
    }
}
