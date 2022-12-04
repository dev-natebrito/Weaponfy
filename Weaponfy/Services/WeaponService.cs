using MongoDB.Driver;
using Weaponfy.Models;
using Weaponfy.Models.DBsettings;

namespace Weaponfy.Services;

public class WeaponService : IWeaponService
{
    private readonly IMongoCollection<Weapon> _weaponCollection;

    public WeaponService(IWeaponfyDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _weaponCollection = database.GetCollection<Weapon>(settings.WeaponsCollectionName);
    }

    public List<Weapon> Get()
    {
        return _weaponCollection.Find(weapon => true).ToList();
    }

    public Weapon Get(string id)
    {
        return _weaponCollection.Find(weapon => weapon.Id == id).FirstOrDefault();
    }

    public Weapon Create(Weapon weapon)
    {
        _weaponCollection.InsertOne(weapon);
        return weapon;
    }

    public void Update(string id, Weapon weapon)
    {
        _weaponCollection.ReplaceOne(weapon => weapon.Id == id, weapon);
    }

    public void Remove(string id)
    {
        _weaponCollection.DeleteOne(weapon => weapon.Id == id);
    }
}