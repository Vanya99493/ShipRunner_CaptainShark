using UnityEngine;

public class MoveCannonball : MonoBehaviour
{
    private GameObject targetBox;
    //private Vector3 targetBoxPosition;
    private int speed = 45;

    private void Start()
    {
        targetBox = GameObject.Find("PlaceToFall(Clone)");
    }

    private void FixedUpdate()
    {
        /*targetBoxPosition = new Vector3(
            targetBoxPosition.x + Random.Range(-1f, 1f),
            targetBoxPosition.y + Random.Range(-1f, 1f),
            targetBoxPosition.z + Random.Range(-1f, 1f)
            );*/

        transform.position += (targetBox.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlaceToFall") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
