using System.Collections;
using UnityEngine;

public class SpwanBonuses : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject[] allBonuses;
    private int score;
    private float temp, temp2 = -1f;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");

        StartCoroutine(SpawnBonus(GetObjectFromArray()));
    }

    private IEnumerator SpawnBonus(GameObject obj)
    {
        score = PlayerPrefs.GetInt("Score");
        temp = GetSecondComplexityLevel() / 2f;

        if (temp != temp2)
            temp2 = temp;
        else
            temp = 0;

        yield return new WaitForSeconds(GetComplexityLevel() + temp);
        Instantiate(obj, spawnPosition.position + new Vector3(Random.Range(-5f, 5f), 0f, 0f), obj.transform.rotation);
        StartCoroutine(SpawnBonus(GetObjectFromArray()));
    }

    private GameObject GetObjectFromArray()
    {
        int rand = Random.Range(0, allBonuses.Length);
        return allBonuses[rand];
    }

    private float GetComplexityLevel()
    {
        if (score > 1000)
            return 10f;
        if (score > 700)
            return 11f;
        if (score > 400)
            return 12f;
        if (score > 200)
            return 13f;
        return 15f;
    }

    private float GetSecondComplexityLevel()
    {
        if (score > 1000)
            return 2f;
        if (score > 700)
            return 2.2f;
        if (score > 400)
            return 2.4f;
        if (score > 200)
            return 2.6f;
        if (score > 100)
            return 2.8f;
        return 3f;
    }
}