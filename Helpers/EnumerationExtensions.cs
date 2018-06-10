namespace MyApi.Helpers
{
    public static class EnumerationExtensions
    {
        public static string OrderStatusExtension(int statusID)
        {
            switch(statusID)
            {
                case 1:
                    return "New";
                case 2:
                    return "Booked";
                case 3:
                    return "Allocated";
                case 4:
                    return "Planned";
                case 5:
                    return "Despatched";
                case 6:
                    return "Completed";
                default:
                    return "Unknown";
            }
        }
    }
}