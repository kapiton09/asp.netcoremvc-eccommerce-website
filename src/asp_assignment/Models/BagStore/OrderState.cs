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
                default:
                    return state.ToString();
            }
        }
    }
}