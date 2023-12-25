namespace congrr.UpdateIvent
{
    public class UpdateDb : EventArgs
    {
        public static event EventHandler<EventArgs> Updated;
        public static void OnUpdated()
        {
            Updated?.Invoke(null, EventArgs.Empty);
        }
    }
}
