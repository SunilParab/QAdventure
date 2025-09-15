using System.Collections.Generic;
using UnityEngine;

public class UController : MonoBehaviour
{

    GameObject storedObject;

    [Header("Values")]
    [SerializeField]
    float radius;
    [SerializeField]
    float launchForce;

    public int boldedCount;

    [Header("References")]
    [SerializeField]
    PlayerController player;

    //Components
    Rigidbody2D rb;
    RopeFollow rf;

    List<GameObject> spawnedObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rf = GetComponent<RopeFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.reference.PlayerPaused())
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Collider2D newObj = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Copyable"));
                if (newObj != null)
                {
                    storedObject = newObj.gameObject;
                }
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                if (player.IsRegularGrounded())
                {
                    spawnedObjects.Add(Instantiate(storedObject, transform.position, transform.rotation));
                }
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                if (boldedCount == 0)
                {
                    transform.localScale *= 2;
                }
                boldedCount++;
                Invoke(nameof(Unbold), 2);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                for (int i = spawnedObjects.Count - 1; i >= 0; i--)
                {
                    Destroy(spawnedObjects[i]);
                }
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce((player.transform.position - transform.position).normalized * launchForce, ForceMode2D.Impulse);
                rf.disables++;
                Invoke(nameof(UnDisable), 0.5f);
            }
        }

    }

    void Unbold()
    {
        boldedCount--;
        if (boldedCount == 0) {
            transform.localScale /= 2;
        }
    }

    void UnDisable()
    {
        rf.disables--;
    }

}
