using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public bool IsComplete = false;
    private SokobanManager manager;
    public void initial (SokobanManager Manager)
    {
        this.manager=Manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            IsComplete = true;
            Debug.Log("BOX SUDAH SAMPAI KE TARGET!");
            manager.CheckWinCondition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            IsComplete = false;
            Debug.Log("BOX KELUAR DARI TARGET!");
        }
    }

    
}