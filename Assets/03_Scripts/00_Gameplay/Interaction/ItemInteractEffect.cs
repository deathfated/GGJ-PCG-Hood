using UnityEngine;
public class ItemInteractEffect : ScriptableObject, IItemInteractionEffect 
{
    public void OnItemInteract(Character character)
    {

    }
}

[CreateAssetMenu(fileName = "DamagePlayer", menuName = "Item/Damage Player")]
public class DamagePlayer : ScriptableObject, IItemInteractionEffect
{
    public float damageValue;
    public void OnItemInteract(Character character)
    {
        character.TakeDamage(damageValue);
    }
}

[CreateAssetMenu(fileName = "DamagePlayer", menuName = "Item/Heal Player")]
public class HealPlayer : ScriptableObject, IItemInteractionEffect
{
    public float healValue;
    public void OnItemInteract(Character character)
    {
        character.Heal(healValue);
    }
}

[CreateAssetMenu(fileName = "DamagePlayer", menuName = "Item/Get Item")]
public class GetItem : ScriptableObject, IItemInteractionEffect
{
    //public float healValue;
    public void OnItemInteract(Character character)
    {
        //Damage Player
    }
}
