using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Text money, bestScore, numberOfChest;

    private void Start()
    {
        bestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore").ToString();
        money.text = "Money: " + PlayerPrefs.GetInt("YourMoney").ToString();
        numberOfChest.text = "Chests: " + PlayerPrefs.GetInt("NumberOfChest").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void MoveToInventoryScene()
    {
        SceneManager.LoadScene(1);
    }
}
