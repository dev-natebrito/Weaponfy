namespace Weaponfy.Models.DBsettings;

public class WeaponfyDatabaseSettings : IWeaponfyDatabaseSettings
{
    public string WeaponsCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
