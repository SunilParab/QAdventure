using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("U")) {
            UController Uref = collision.collider.GetComponent<UController>();
            if (Uref.boldedCount > 0)
            {
                Uref.destroyed.Add(this.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
