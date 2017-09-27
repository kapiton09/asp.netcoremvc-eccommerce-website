namespace asp_assignment.Models.BagStore
{
    public enum OrderState
    {
        CheckingOut,
        Placed,
        Filling,
        ReadyToShip,
        Shipped,
        Delivered,
        Cancelled
    }

    public static class OrderStateExtensions
    {
        public static string GetDisplayName(this OrderState state)
        {
            switch (state)
            {
                case OrderState.Placed:
                    return "Ready to Pack";
                case OrderState.Filling:
                    return "Being Packed";
                case OrderState.ReadyToShip:
                    return "Ready to Ship";
                case OrderState.Shipped:
                    return "Shipped";
                case OrderState.Delivered:
                    return "Delivered";
                case OrderState.Cancelled:
                    return "Cancelled";
                default:
                    return state.ToString();
            }
        }
    }
}