namespace Weaponfy.Models.DBsettings;

public interface IWeaponfyDatabaseSettings
{
    string WeaponsCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}