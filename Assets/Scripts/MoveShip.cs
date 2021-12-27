using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject ship;

    public void ToLeft()
    {
        ship.transform.position = new Vector3(ship.transform.position.x + speed * Time.deltaTime, ship.transform.position.y, ship.transform.position.z);
    }

    public void ToRight()
    {
        ship.transform.position = new Vector3(ship.transform.position.x - speed * Time.deltaTime, ship.transform.position.y, ship.transform.position.z);
    }
}
