using UnityEngine;


[CreateAssetMenu(fileName = "DamagePlayer", menuName = "Item/Damage Player")]
public class DamagePlayer : ItemInteractEffect
{
    public float damageValue;

    public override void ItemInteract(Character character)
    {
        float calculate = character.CurrentHealth - damageValue;

        if(calculate <= 0)
        {
            return;
        }

        character.TakeDamage(damageValue);
        Debug.Log("Player Take Damage");
    }
}
