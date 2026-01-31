using System.Security.Cryptography;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Psalmhaven
{
    public class MainMenuManager : MonoBehaviour
    {
        PlayerController player;
        PlayerInput playerInput;
        private void Awake()
        {
            playerInput = UIManager.instance.GetComponent<PlayerInput>();
            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            player.enabled = false;
            playerInput.enabled = false;

            UIManager.instance.StartMainMenu(CloseMainMenu);
        }

        private void CloseMainMenu(int number)
        {
            player.enabled = true;
            playerInput.enabled = true;
            UIManager.instance.CloseMainMenu();
        }
    }
}