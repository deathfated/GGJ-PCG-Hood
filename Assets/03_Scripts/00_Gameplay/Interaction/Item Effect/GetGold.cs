using UnityEngine;


[CreateAssetMenu(fileName = "Get Gold", menuName = "Item/Get Gold")]
public class GetGold : ItemInteractEffect
{
    public int goldValue;

    public override void ItemInteract(Character character)
    {
        GameManager.instance.GetCurrency(goldValue);
    }
}