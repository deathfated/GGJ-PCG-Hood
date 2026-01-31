using UnityEngine;

namespace Psalmhaven
{ 
    public interface IMask
    {
        string MaskName { get; }
        string[] CombatActions { get; }
    }

}