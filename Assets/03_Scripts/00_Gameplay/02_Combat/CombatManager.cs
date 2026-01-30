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
        private Button[] buttons;

        private void Start()
        {
            buttons = optionsPanel.GetComponentsInChildren<Button>();
        }

        public void StartActionAttack()
        {
            int resultRoll = TestRoll();
            Debug.Log("rando " + resultRoll);

            //check if its string or int
            int playerDmg;
            if (int.TryParse(player.combatActions[resultRoll], out playerDmg)) { }
            else
            {
                Debug.Log("POPO " + player.combatActions[resultRoll]);
                return;
            }

            int enemyDmg;
            if (int.TryParse(enemy.CombatActions[resultRoll], out enemyDmg)) { }
            else
            {
                Debug.Log("POPO " + enemy.CombatActions[resultRoll]);
                return;
            }

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

        public int TestRoll()
        {
            return Random.Range(0, 5);
        }

        private void OnEnable()
        {
            Player.OnPlayerDied += ShowGameOver;
        }

        private void OnDisable()
        {
            Player.OnPlayerDied -= ShowGameOver;
        }

        private void ShowGameOver()
        {
            gameoverPanel.SetActive(true);
            optionsPanel.SetActive(false);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}