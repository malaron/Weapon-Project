using UnityEngine;

public class RangedWeapon : Weapon
{
    public float Range;
        public GameObject Ammo;

    private readonly string[] StatsToDisplay = { "Ammo", "range", "MinLevel", "AttackSpeed", "Weight" };

    /// <summary>
    /// Reads and displays the Ranged Weapon's stats in the Information Panel
    /// </summary>
    /// <param name="parent">The information panel to put the information inside</param>
    /// <param name="spacing">The amount of vertical space between lines of information</param>
    protected override void SetInfoText(Transform parent, float spacing)
    {
        Helpers.CreateInfoList(StatsToDisplay, this, parent, InfoPanelTextPrefab, 240, spacing);
    }

}
