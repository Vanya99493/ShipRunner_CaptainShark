using UnityEngine;

public class MoveLeftSRightRock : MonoBehaviour
{
    private float speed, titleSize;
    private Transform currentObject;
    public int neededMove;

    private void Start()
    {
        currentObject = GetComponent<Transform>();
        titleSize = transform.localScale.z * 4.5f;
    }

    private void Update()
    {
        speed = PlayerPrefs.GetInt("SpeedEnemies");

        currentObject.position = new Vector3(
            currentObject.position.x,
            currentObject.position.y,
            Mathf.Repeat(Time.time * speed, titleSize) + neededMove
        );
    }
}
