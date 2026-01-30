using System;
using UnityEngine;

namespace Psalmhaven
{
    public class Player : Character
    {
        public string[] combatActions;
        public static event Action OnPlayerDied;

        public override void Die()
        {
            Debug.Log("Anjir mati");
            OnPlayerDied?.Invoke();

        }
    }
}