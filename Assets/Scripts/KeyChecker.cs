using UnityEngine;

public class KeyChecker : MonoBehaviour
{

    void Start() {

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, transform.lossyScale, transform.rotation.z, LayerMask.GetMask("UPassable"));

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].CompareTag("Openable"))
            {
                Destroy(hits[i].gameObject);
            }
        }
    }
}
