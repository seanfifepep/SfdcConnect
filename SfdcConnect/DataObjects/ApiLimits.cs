using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdcConnect
{
    //public class LimitInfo
    //{
    //    public int UsedAPICalls;
    //    public int MaxAPICalls;
    //}

    public class ApiLimits
    {
        public Limit ConcurrentAsyncGetReportInstances { get; set; }
        public Limit ConcurrentSyncReportRuns { get; set; }
        public Limit DailyApiRequests { get; set; }
        public Limit DailyAsyncApexExecutions { get; set; }
        public Limit DailyBulkApiRequests { get; set; }
        public Limit DailyGenericStreamingApiEvents { get; set; }
        public Limit DailyGenericStreamingV2ApiEvents { get; set; }
        public Limit DailyStreamingApiEvents { get; set; }
        public Limit DailyWorkflowEmails { get; set; }
        public Limit DataStorageMB { get; set; }
        public Limit FileStorageMB { get; set; }
        public Limit HourlyAsyncReportRuns { get; set; }
        public Limit HourlyDashboardRefreshes { get; set; }
        public Limit HourlyDashboardResults { get; set; }
        public Limit HourlyDashboardStatuses { get; set; }
        public Limit HourlySyncReportRuns { get; set; }
        public Limit HourlyTimeBasedWorkflow { get; set; }
        public Limit MassEmail { get; set; }
        public Limit SingleEmail { get; set; }
        public Limit StreamingApiConcurrentClients { get; set; }
        public Limit StreamingV2ApiConcurrentClients { get; set; }
    }

    public class Limit
    {
        public int Max { get; set; }
        public int Remaining { get; set; }
        public int Used { get { return Max - Remaining; } }

        public override string ToString()
        {
            return string.Format("{0}/{1} used, {2} remain", Used, Max, Remaining);
        }
    }

}
