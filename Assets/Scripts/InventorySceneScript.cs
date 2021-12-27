using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventorySceneScript : MonoBehaviour
{
    private int numberOfChest, multiplier, numberOfNeededKeys = 3;
    [SerializeField] private Text numberOfChestText, multiplierText, earnedMoneyText;
    [SerializeField] private Image[] lastPeekKey, currPeekKey, lightsElements;
    [SerializeField] private GameObject chestElement, OpenChestPanel, WiningPanel, backToMenu;
    [SerializeField] private Sprite[] allKey;
    private List<int> requiredSet = new List<int>(), yourSet = new List<int>();

    private void Start()
    {
        numberOfChest = PlayerPrefs.GetInt("NumberOfChest");
    }

    private void FixedUpdate()
    {
        if (numberOfChest > 0)
        {
            chestElement.SetActive(true);
            numberOfChestText.text = numberOfChest.ToString() + "x";
        }
        else
        {
            chestElement.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenChest()
    {
        if (numberOfChest > 0)
        {
            backToMenu.SetActive(false);

            numberOfChest--;
            PlayerPrefs.SetInt("NumberOfChest", numberOfChest);

            multiplier = 5;

            multiplierText.text = "x" + multiplier.ToString();

            OpenChestPanel.SetActive(true);

            while (requiredSet.Count < numberOfNeededKeys) {
                int rand = Random.Range(0, allKey.Length);

                if (!requiredSet.Contains(rand)) {
                    requiredSet.Add(rand);
                }
            }
        }
    }

    public void PressToOpenButton()
    {
        if (yourSet.Count == numberOfNeededKeys) {
            bool isWin = true;

            for (int i = 0; i < currPeekKey.Length; i++) {
                lastPeekKey[i].GetComponent<Image>().sprite = allKey[yourSet[i]];
                currPeekKey[i].GetComponent<Image>().sprite = null;

                if (yourSet[i] == requiredSet[i]) {
                    lightsElements[i].GetComponent<Image>().color = Color.green;
                }
                else if (requiredSet.Contains(yourSet[i])) {
                    lightsElements[i].GetComponent<Image>().color = Color.yellow;
                    isWin = false;
                }
                else {
                    lightsElements[i].GetComponent<Image>().color = Color.red;
                    isWin = false;
                }
            }

            if (isWin) {
                FinishOpenedChest();
            }
            else {
                multiplier -= multiplier > 1 ? 1 : 0;
                multiplierText.text = "x" + multiplier.ToString();
            }

            yourSet.Clear();
        }
    }

    public void PressToClearButton()
    {
        for (int i = 0; i < currPeekKey.Length; i++) {
            currPeekKey[i].GetComponent<Image>().sprite = null;
        }
        yourSet.Clear();
    }

    private void FinishOpenedChest()
    {
        WiningPanel.SetActive(true);

        int earnedMoney = Random.Range(50, 150) * multiplier;
        earnedMoneyText.text = "You earned: " + earnedMoney.ToString() + " coins!";

        PlayerPrefs.SetInt("YourMoney", PlayerPrefs.GetInt("YourMoney") + earnedMoney);
    }

    public void PressToFinishButton()
    {
        requiredSet.Clear();
        yourSet.Clear();
        for (int i = 0; i < numberOfNeededKeys; i++) {
            lastPeekKey[i].GetComponent<Image>().sprite = null;
            lightsElements[i].GetComponent<Image>().color = Color.white;
        }

        backToMenu.SetActive(true);
        WiningPanel.SetActive(false);
        OpenChestPanel.SetActive(false);
    }

    private void PressToKeyButton(int index)
    {
        if (yourSet.Count == 0 || (!yourSet.Contains(index) && yourSet.Count < numberOfNeededKeys)) {
            yourSet.Add(index);
            currPeekKey[yourSet.Count - 1].GetComponent<Image>().sprite = allKey[index];
        }
    }

    public void PressToKey1Button()
    {
        PressToKeyButton(0);
    }
    public void PressToKey2Button()
    {
        PressToKeyButton(1);
    }
    public void PressToKey3Button()
    {
        PressToKeyButton(2);
    }
    public void PressToKey4Button()
    {
        PressToKeyButton(3);
    }
    public void PressToKey5Button()
    {
        PressToKeyButton(4);
    }
    public void PressToKey6Button()
    {
        PressToKeyButton(5);
    }
}