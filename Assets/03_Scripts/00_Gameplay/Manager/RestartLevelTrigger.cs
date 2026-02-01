using Psalmhaven;
using UnityEngine;

public class RestartLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneTransitionManager.instance.Restart();
    }
}
