using UnityEngine;

public class SokobanManager : MonoBehaviour
{
    public TargetTrigger[] allTargets;
    public void Start ()
    {
        foreach(TargetTrigger trigger in allTargets)
        {
            trigger.initial(this);
        }
    }

    public void CheckWinCondition()
    {
        foreach (TargetTrigger target in allTargets)
        {
            if (!target.IsComplete)
            {
                return; // masih ada target kosong
            }
        }

        WinGame();
    }

    private void WinGame()
    {
        Debug.Log("SEMUA BOX SUDAH MASUK!");
    }
}