namespace MVPDemo.Services
{
    public class ActionExecutorOptions
    {
        public ActionExecutorOptions()
        {
            NotifyLoadingAfterMilliseconds = 500;
        }
        public int NotifyLoadingAfterMilliseconds { get; set; }
    }
}