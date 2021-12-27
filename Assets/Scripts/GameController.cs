using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject losePanel, movePanel, menuPanel,
                                        spawnCube;
    [SerializeField] private Text scoreTextInGame, scoreTextInLosePanel, chestsText;
    private int health, chestsInGame = 0, score = 0;
    private bool isLose = false;

    private void Start()
    {
        PlayerPrefs.SetInt("ChestInGame", 0);
        PlayerPrefs.SetInt("SpeedEnemies", 6);
        PlayerPrefs.SetInt("Score", 0);
        health = 100;
        StartCoroutine(ScoreNumerable());
    }

    private void FixedUpdate()
    {
        if (health <= 0 && !isLose) {
            EventLoseGame();
        }
    }
    
    private IEnumerator ScoreNumerable()
    {
        yield return new WaitForSeconds(0.75f);
        score++;
        scoreTextInGame.GetComponent<Text>().text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
        StartCoroutine(ScoreNumerable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Limiter" || other.tag == "Cannonball") {
            health -= 100;
        }
        if (other.tag == "Bonus") {
            chestsInGame += 1;
            chestsText.text = chestsInGame.ToString();
            Destroy(other.gameObject);
        }
    }

    private void EventLoseGame()
    {
        isLose = true;
        scoreTextInLosePanel.text = "Your score:\n" + score.ToString();
        PlayerPrefs.SetInt("SpeedEnemies", 0);

        losePanel.SetActive(true);
        movePanel.SetActive(false);
        spawnCube.SetActive(false);

        SaveProgress();
    }

    private void SaveProgress()
    {
        int generalChests = PlayerPrefs.GetInt("NumberOfChest");
        PlayerPrefs.SetInt("NumberOfChest", generalChests + chestsInGame);
        chestsInGame = 0;

        if (PlayerPrefs.GetInt("BestScore") < score)
            PlayerPrefs.SetInt("BestScore", score);
        score = 0;
    }

    public void MoveToMainMenu() {
        SaveProgress();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RestartGame() {
        SaveProgress();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void MenuButton() {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToGame() {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}