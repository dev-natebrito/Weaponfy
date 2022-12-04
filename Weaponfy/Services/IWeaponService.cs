using Weaponfy.Models;

namespace Weaponfy.Services;

public interface IWeaponService
{
    List<Weapon> Get();
    Weapon Get(string id);
    Weapon Create(Weapon weapon);
    void Update(string id, Weapon video);
    void Remove(string id);

}