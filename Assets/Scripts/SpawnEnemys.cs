using System.Collections;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject[] enemysCommonRock;
    [SerializeField] private GameObject[] agresiveEnemies;
    private GameObject[][] allEnemies;
    private int score, limiterForAgrEnem;

    private void Start()
    {
        allEnemies = new GameObject[2][];
        allEnemies[0] = enemysCommonRock;
        allEnemies[1] = agresiveEnemies;

        limiterForAgrEnem = 0;

        StartCoroutine(SpawnEnemy(GetObjectFromArray(GetUpperBorder())));
    }

    private IEnumerator SpawnEnemy(GameObject obj)
    {
        score = PlayerPrefs.GetInt("Score");
        yield return new WaitForSeconds(GetComplexityLevel());
        Instantiate(obj, spawnPosition.position + new Vector3(Random.Range(-5f, 5f), 0f, 0f), obj.transform.rotation);
        StartCoroutine(SpawnEnemy(GetObjectFromArray(GetUpperBorder())));
    }

    private GameObject GetObjectFromArray(int upperBorder)
    {
        int rand = Random.Range(0, upperBorder),
            lever = rand > 80  && limiterForAgrEnem < 1 ? 1 : 0;

        if(lever == 1)
            limiterForAgrEnem = 4;
        else
            limiterForAgrEnem--;

        return allEnemies[lever][Random.Range(0, allEnemies[lever].Length)];
    }

    private int GetUpperBorder()
    {
        if (score > 50)
            return 100;
        return 80;
    }

    private float GetComplexityLevel()
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
