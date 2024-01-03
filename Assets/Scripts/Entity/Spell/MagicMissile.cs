using UnityEngine;

public class MagicMissile : Spell
{
    private readonly string[] StatsToDisplay = { "SpellName", "SpellLevel" };


    void Awake()
    {
        SpellName = "Magic Missile";
        SpellLevel = 1;
    }

    void SetSpellLevel(int level)
    {
        SpellLevel = level;
    }

    /// <summary>
    /// Reads and displays the Melee Weapon's stats in the Information Panel
    /// </summary>
    /// <param name="parent">The information panel to put the information inside</param>
    /// <param name="spacing">The amount of vertical space between lines of information</param>
    protected override void SetInfoText(Transform parent, float spacing)
    {
        Helpers.CreateInfoList(StatsToDisplay, this, parent, InfoPanelTextPrefab, 240, spacing);
    }
    
}