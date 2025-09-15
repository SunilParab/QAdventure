using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("U")) {
            if (collision.collider.GetComponent<UController>().boldedCount > 0) {
                Destroy(gameObject);
            }
        }
    }
}
