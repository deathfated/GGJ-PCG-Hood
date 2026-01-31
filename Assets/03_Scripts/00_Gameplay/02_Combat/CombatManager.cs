using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Psalmhaven
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] Player player;
        [SerializeField] Enemy enemy;

        [SerializeField] GameObject optionsPanel;
        [SerializeField] GameObject gameoverPanel;
        //private DiceRoller diceRoller;
        [SerializeField] GameObject hUD;
        private int resultRoll = 1;

        [SerializeField] float delayRoll;
        private Button[] buttons;

        [HideInInspector] public static CombatManager Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                // If an instance already exists and it's not this one, destroy this new object
                Destroy(this.gameObject);
            }
            else
            {
                // Otherwise, set this as the only instance
                Instance = this;
                // Optional: keep the object alive across scene loads
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void Start()
        {
            buttons = optionsPanel.GetComponentsInChildren<Button>();
            //diceRoller = UIManager.Instance.GetComponentInChildren<DiceRoller>();
        }

        public void StartCombat()
        {

        }

        public void StartActionAttack()
        {
            //int resultRoll = diceRoller.RollDice();
            //delayRoll = diceRoller.DiceAnimDelay;
            //diceRoller.AnimateRollDice(resultRoll);
            UIManager.instance.RollDice(number =>
            {
                resultRoll = number;
                ActionAttack(resultRoll);
            });
            //StartCoroutine("ActionAttack", resultRoll);
            //Debug.Log("rando " + resultRoll);
        }

        private void ActionAttack(int resultRoll)
        {
            //yield return new WaitForSeconds(resultRoll);

            //check if its string or int
            int playerDmg;
            if (player.currentMask == 1) //switch actions based on mask (stupid method)
            {
                if (int.TryParse(player.combatActions[resultRoll], out playerDmg)) { }
                else return;
            }
            else
            {
                if (int.TryParse(player.combatActions2[resultRoll], out playerDmg)) { }
                else return ;
            }

            int enemyDmg;
            if (int.TryParse(enemy.CombatActions[resultRoll], out enemyDmg)) { }
            else return ;

            int resultDamage = playerDmg + enemyDmg;
            Debug.Log($"{playerDmg} + {enemyDmg} = {resultDamage}");

            float dmg;
            if (resultRoll > 2) //enemy gets damage
            {
                //if (resultDamage < 0) resultDamage = 0; //checking if enemy too tanky
                dmg = resultDamage;
                enemy.TakeDamage(dmg);

            }
            else //player gets damage
            {
                dmg = resultDamage;
                player.TakeDamage(dmg);
            }

            Debug.Log("end = " + dmg);
        }

        private void OnEnable()
        {
            Player.OnPlayerDied += ShowGameOver;

            //UIManager.instance.OnDiceRolled += ActionAttack;

        }

        private void OnDisable()
        {
            Player.OnPlayerDied -= ShowGameOver;

            //UIManager.instance.OnDiceRolled -= ActionAttack;

        }

        private void ShowGameOver()
        {
            gameoverPanel.SetActive(true);
            optionsPanel.SetActive(false);
            hUD.SetActive(false);
            Time.timeScale = 0f; // optional pause
        }

        public void RestartGame()
        {

            //destroy dontdestroyonload objects
            //foreach (var obj in GameObject.FindGameObjectsWithTag("Persistent"))
            //{
            //    Destroy(obj);
            //}

            //reload scene
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}