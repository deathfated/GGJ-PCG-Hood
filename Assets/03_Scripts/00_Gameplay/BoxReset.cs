using UnityEngine;

public class BoxReset : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void ResetBox()
    {
        transform.position = startPos;
    }
}
