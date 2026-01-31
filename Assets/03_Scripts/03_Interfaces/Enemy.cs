using System;
using UnityEngine;

namespace Psalmhaven
{
    public class Enemy : Character, IMask
    {

        //public float MaxDamage;
        [SerializeField] private string maskName;
        [SerializeField] private string[] combatActions;

        public string MaskName => maskName;
        public string[] CombatActions => combatActions;

        public static event Action OnEnemyDied;


        public override void Die()
        {
            Debug.Log("Enemy ded");
            OnEnemyDied?.Invoke();

            Destroy(gameObject);
        }
    }
}
