namespace Api.SharedData;

public static class Roles
{
    public const string Admin = "admin";
    public const string Consumer = "consumer";

    public static IReadOnlyList<string> GetRoles()
    {
        return [Admin, Consumer];
    }
}
