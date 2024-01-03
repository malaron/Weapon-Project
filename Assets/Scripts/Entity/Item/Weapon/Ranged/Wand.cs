using UnityEngine;

public class Wand : RangedWeapon
{
    public int NumCharges;
    private readonly string[] StatsToDisplay = { "MinLevel", "Range", /*"Ammo",*/ "NumCharges", "AttackSpeed", "Weight" };

    public void SetInfo()
    {
        SetInfo(this);
    }

    /// <summary>
    /// Reads and displays the Wand's stats in the Information Panel
    /// </summary>
    /// <param name="parent">The information panel to put the information inside</param>
    /// <param name="spacing">The amount of vertical space between lines of information</param>
    protected override void SetInfoText(Transform parent, float spacing)
    {
         Helpers.CreateInfoList(StatsToDisplay, this, parent, InfoPanelTextPrefab, 240, spacing);
   }

}