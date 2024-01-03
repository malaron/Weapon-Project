using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Item : Entity, IPointerClickHandler
{
    public string Name;
    public float Weight;
    public RarityType Rarity;



    /// <summary>
    /// Called whenever any item in game is clicked if that item inherits the Item class
    /// </summary>
    /// <param name="eventData">Click Event</param>
    public void OnPointerClick(PointerEventData eventData)
    { 
        GameObject clicked = eventData.pointerPress;

        // Every Item in the game should have a base class of Item
        // For example: 
        // RangedWeapon -> Weapon -> Item
        // Potion -> Food -> Consumable -> Item
        // Scroll -> Consumable -> Item
        // Of course for this tutorial example we only have weapons
        Item item = clicked.GetComponent<Item>(); 

        SetInfo(item);
    }

    /// <summary>
    /// Called every frame. Adds a rotation to all game items for a little animation
    /// </summary>
    protected void Update()
    {
        transform.Rotate(0, -30 * Time.deltaTime, 0, Space.World);
    }

    /// <summary>
    /// Clears the previous info that was displayed and then calls SetItemInfo to generate new info
    /// </summary>
    /// <param name="obj">The Item whose information is to be displayed</param>
    protected void SetInfo(Item obj)
    {
        while (InfoPanel.transform.childCount > 0) {
            DestroyImmediate(InfoPanel.transform.GetChild(0).gameObject);
        }

        SetItemInfo(obj);
    }

    /// <summary>
    ///  Sets the initial information on the item (title) and calls the item's SetInfoText to set the rest.
    /// </summary>
    /// <param name="item">The item to display the information of</param>
    private void SetItemInfo(Item item)
    {
        Color color = item.Rarity switch
        {
            RarityType.COMMON => new Color(0.8773585f, 0.8773585f, 0.8773585f),
            RarityType.UNCOMMON => new Color(0, 0.9150943f, 0.005920846f),
            RarityType.RARE => new Color(0, 0.02568205f, 0.9056604f),
            RarityType.EPIC => new Color(0.6415094f, 0, 0.5710384f),
            RarityType.LEGENDARY => new Color(0.9716981f, 0.8029708f, 0.2704254f),
            _ => new Color(1, 0, 0)
        };

        GameObject title = Instantiate(InfoPanelTitlePrefab, InfoPanel.transform);

        TMP_Text titleText = title.GetComponent<TMP_Text>();
        titleText.text = item.Name;
        titleText.fontStyle = FontStyles.Bold | FontStyles.Underline;
        titleText.color = color;

        // This bubbles back up to the weapon: Melee, Ranged, Wand (subset of Ranged), etc, this way we can
        // customize the data displayed based on the item. By doing it as an abstract method
        // it will force the developer to add that method to the new weapon class when it inherits the subclass
        // ensuring the display information is added.
        item.SetInfoText(InfoPanel.transform, -50f);
    }
}
