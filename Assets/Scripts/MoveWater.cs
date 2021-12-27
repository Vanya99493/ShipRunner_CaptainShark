using UnityEngine;

public class MoveWater : MonoBehaviour
{
    private float speed, titleSize;
    private Transform currentObject;

    private void Start()
    {
        currentObject = GetComponent<Transform>();
        titleSize = transform.localScale.z;
    }

    private void Update()
    {
        speed = PlayerPrefs.GetInt("SpeedEnemies");

        currentObject.position = new Vector3(
            currentObject.position.x,
            currentObject.position.y,
            Mathf.Repeat(Time.time * speed, titleSize) - 48
        );
    }
}
