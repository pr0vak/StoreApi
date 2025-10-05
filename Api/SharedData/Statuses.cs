namespace Api.SharedData;

public static class Statuses
{
    public const string Pending = "pending";
    public const string ReadyToShip = "ready_to_ship";
    public const string Completed = "completed";

    public static IReadOnlyList<string> AllStatuses
    {
        get => [Pending, ReadyToShip, Completed];
    }
}
