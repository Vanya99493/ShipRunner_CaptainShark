using System.Collections;
using UnityEngine;

public class AgressiveGunScript : MonoBehaviour
{
    [SerializeField] private GameObject cannonball, placeToFall, tower;
    private GameObject ship;
    private Vector3 gunPosition;
    private float range = 40;
    private int ammunation = 2;
    private bool isReload = true;

    private void Start()
    {
        ship = GameObject.Find("Ship");
        gunPosition = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        float length = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(tower.transform.position.x - ship.transform.position.x, 2) + 
                                            Mathf.Pow(tower.transform.position.z - ship.transform.position.z, 2)));

        if (length <= range && ammunation > 0 && isReload) {
            isReload = false;
            ammunation--;
            StartCoroutine(Shot());
        }
    }

    IEnumerator Shot()
    {
        float complSpeed = 2f; // ************
        Vector3 placeToFallPosition = new Vector3(ship.transform.position.x, 
                                                  ship.transform.position.y + 0.1f, 
                                                  ship.transform.position.z - (complSpeed * 6f + complSpeed / 2)
                                                  );

        gameObject.transform.Rotate(gameObject.transform.rotation.x, GetAngle(placeToFallPosition), gameObject.transform.rotation.z);

        Instantiate(placeToFall, placeToFallPosition, placeToFall.transform.rotation);

        yield return new WaitForSeconds(complSpeed);

        Instantiate(cannonball, new Vector3(gunPosition.x, gunPosition.y, tower.transform.position.z), cannonball.transform.rotation);

        yield return new WaitForSeconds(1f);
        isReload = true;
    }

    private int GetAngle(Vector3 placeToFallPosition)
    {
        float angle = Vector3.SignedAngle(placeToFallPosition - transform.position, transform.forward, Vector3.up) * -1 + 90;

        return (int)angle;
    }
}
