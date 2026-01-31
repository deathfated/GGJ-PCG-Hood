using System;
using UnityEngine;

public class ActionItemInteraction : BaseInteraction
{
    [Header("Canvas Group")]
    [SerializeField] private CanvasGroup uiPanel;

    private Coroutine activeCoroutine;
    [SerializeField] private ItemInteractEffect[] interactEffect;
    private bool hasInteract;

    //Dummy 
    protected Character playerCharacter;
    private void Start()
    {
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
        uiPanel.alpha = 0f;
    }

    public override void TriggerEnter(Collider other)
    {
        if (hasInteract)
            return;

        ClearCoroutine();
        ShowPanel(true);
    }

    private void ClearCoroutine()
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine);
        }
    }

    public void OnRollDice(int diceNumber)
    {
        if (interactEffect[diceNumber] == null)
        {
            CloseInteraction();
        }
        else
        {
            interactEffect[diceNumber].OnItemInteract(playerCharacter);
        }
    }

    public void CloseInteraction()
    {
        hasInteract = true;
    }

    public override void TriggerExit(Collider other)
    {
        if (hasInteract)
            return;

        base.TriggerExit(other);
        ShowPanel(false);
    }

    public void ShowPanel(bool isShow)
    {
        ClearCoroutine();
        if (isShow)
        {
            activeCoroutine = StartCoroutine(Fade(uiPanel, 0, 1, onComplete : ShowRollDice));
        }
        else
        {
            activeCoroutine = StartCoroutine(Fade(uiPanel, 1, 0, onComplete: HideRollDice));
        }
    }

    private void ShowRollDice()
    {
        Debug.Log("ShowUI Dice");
    }

    private void HideRollDice()
    {
        Debug.Log("HideUI Dice");
    }
}
