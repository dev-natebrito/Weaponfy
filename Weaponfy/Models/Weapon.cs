using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Weaponfy.Models;

public class Weapon
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")] public string Name { get; set; } = null!;

    [BsonElement("RollRange")] public string RollRange { get; set; } = null!;

    [BsonElement("WeaponType")] public string WeaponType { get; set; } = null!;

    [BsonElement("AttackType")] public string AttackType { get; set; } = null!;

    [BsonElement("Range")] public string Range { get; set; } = null!;

    [BsonElement("Damage")] public int Damage { get; set; }

    [BsonElement("Dice")] public int? Dice{ get; set; }

    [BsonElement("SpiritDamage")] public int SpiritDamage { get; set; }

    [BsonElement("AdditionalDamage")] public int AdditionalDamage { get; set; }

    [BsonElement("DamageType")] public string DamageType { get; set; } = null!;

    [BsonElement("Properties")] public string Properties { get; set; } = null!;

    [BsonElement("Description")] public string Description { get; set; } = null!;

    [BsonElement("Color")] public string Color { get; set; } = null!;


    [BsonElement("Notes")] public string Notes { get; set; } = null!;

    public Weapon()
    {
        Dice ??= 1;
    }
}