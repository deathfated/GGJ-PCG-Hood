using UnityEngine;

public class ResetArea : MonoBehaviour
{
    public ResetManager resetManager;

   private void OnTriggerEnter(Collider other)
{
        
        resetManager.ResetLevel();
        Debug.Log("BERHASI DIRESET!");
    
}
}
