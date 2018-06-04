namespace ISC.ActiveDirectoryManager.Models
{
    public class AlertHelper
    {
        public class Alert
        {
            public const string TempDataKey = "TempDataAlerts";

            public string AlertStyle { get; set; }
            public string Message { get; set; }
            public bool Dismissable { get; set; }
            public bool Permanent { get; set; }
        }

        public static class AlertStyles
        {
            public const string Success = "success";
            public const string Information = "info";
            public const string Warning = "warning";
            public const string Danger = "danger";
        }
    }
}