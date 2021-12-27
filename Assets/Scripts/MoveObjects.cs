using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    private float speed;

    private void FixedUpdate()
    {
        speed = PlayerPrefs.GetInt("SpeedEnemies");
        gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
