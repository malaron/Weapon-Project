using TMPro;
using UnityEngine;

public abstract class Spell : Entity
{
    protected string SpellName;
    protected int SpellLevel;

    private void SetSpellInfo(Spell spell)
    {
        GameObject title = Instantiate(InfoPanelTitlePrefab, InfoPanel.transform);

        TMP_Text titleText = title.GetComponent<TMP_Text>();
        titleText.text = spell.SpellName;
        titleText.fontStyle = FontStyles.Bold | FontStyles.Underline;

        // This bubbles back up to the spell: fireball, magic missile, etc, this way we can
        // customize the data displayed based on the spell. By doing it as an abstract method
        // it will force the developer to add that method to the new spell class when it inherits the subclass
        // ensuring the display information is added.
        spell.SetInfoText(InfoPanel.transform, -50f);
    }
}