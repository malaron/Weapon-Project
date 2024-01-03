using Unity.VisualScripting;
using UnityEngine;

public class Ammo : Item
{
    private readonly DamageType DamageType = DamageType.PIERCE;
    public float Damage;
    public float SpeedModifier;

    protected override void SetInfoText(Transform parent, float spacing)
    {
        throw new System.NotImplementedException();
    }
}