using Psalmhaven;
using UnityEngine;

public class TransitionBoss : MonoBehaviour
{
    public Animator animator;
    public PlayerController playerController;
    public Transform enemyTransform;
    public Quaternion offsetRotation = new Quaternion(0, 90, 0, 0);

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    public void TriggerCutsceneBossFirst()
    {
        playerController.transform.localPosition = Vector3.zero;
        playerController.transform.localRotation = offsetRotation;
        enemyTransform.localPosition = Vector3.zero;
        playerController.enabled = false;
        animator.SetBool("FirstBoss", true);
    }
}
