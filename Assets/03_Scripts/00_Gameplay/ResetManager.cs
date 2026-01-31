using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public BoxReset[] allBoxes;

    public void ResetLevel()
    {
        foreach (BoxReset box in allBoxes)
        {
            box.ResetBox();
        }
    }
}
