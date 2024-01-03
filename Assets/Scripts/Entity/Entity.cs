using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [HideInInspector] protected GameObject InfoPanel;
    [HideInInspector] protected GameObject InfoPanelTitlePrefab;
    [HideInInspector] protected GameObject InfoPanelTextPrefab;

    /// <summary>
    /// Called when class is first instantiated.
    /// Virtual so child classes can have their own Awake without overriding this one
    /// Without Virtual here, and override on the child, the below settings end up null
    /// for that child (See MeleeWeapon.cs as an example).
    /// </summary>
    void Awake()
    {
        InfoPanel = GameObject.Find("Canvas/InfoPanel");
        InfoPanelTitlePrefab = Resources.Load("Info Text Title") as GameObject;
        InfoPanelTextPrefab = Resources.Load("Info Text") as GameObject;        
    }

    // Polymorphism, Each class at the highest level has its own version of SetInfoText, this allows the Item class to be
    // Class agnostic and have no knowledge about the types of weapons or their stats
    protected abstract void SetInfoText(Transform transform, float spacing);

}