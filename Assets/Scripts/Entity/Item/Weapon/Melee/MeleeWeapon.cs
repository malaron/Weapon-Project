using UnityEngine;

public class MeleeWeapon : Weapon
{
    public float Damage;
    public DamageType DamageType;

    private readonly string[] StatsToDisplay = { "MinLevel", "Damage", "DamageType", "AttackSpeed", "Weight" };

    /// <summary>
    /// Reads and displays the Melee Weapon's stats in the Information Panel
    /// </summary>
    /// <param name="parent">The information panel to put the information inside</param>
    /// <param name="spacing">The amount of vertical space between lines of information</param>
    // TODO: This should be moved all the way up into the Item class, however we won't for this tutorial    
    // TODO: because we're using it as an example of polymorphism, contrived as it is. xD
    // TODO: In real world I'd have SetInfoText in the Item class and we would have better classes using polymorphism.
    // TODO:  such as a polymorphic method to calculate damage after an attack, removing a projectile or spell charge if it's a ranged weapon.
    protected override void SetInfoText(Transform parent, float spacing)
    {
        Helpers.CreateInfoList(StatsToDisplay, this, parent, InfoPanelTextPrefab, 240, spacing);
    }
}
