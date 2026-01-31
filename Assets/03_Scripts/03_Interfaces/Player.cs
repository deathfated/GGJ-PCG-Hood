using System;
using UnityEngine;

namespace Psalmhaven
{
    public class Player : Character
    {
        public int currentMask;
        public string[] combatEffectData;
        public string[] combatActions;
        public string[] combatActions2;
        public int[] runActions;

        public static event Action OnPlayerDied;

        public override void Die()
        {
            Debug.Log("Anjir mati");
            OnPlayerDied?.Invoke();

        }
    }
}