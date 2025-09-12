using UnityEngine;

public class UController : MonoBehaviour
{

    GameObject storedObject;

    [Header("Values")]
    [SerializeField]
    float radius;
    [SerializeField]
    float launchForce;

    [Header("References")]
    [SerializeField]
    GameObject Player;

    //Components
    Rigidbody2D rb;
    RopeFollow rf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rf = GetComponent<RopeFollow>();
    }

    // Update is called once per frame
    void Update()
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
            Instantiate(storedObject, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce((Player.transform.position - transform.position).normalized * launchForce, ForceMode2D.Impulse);
            rf.disables++;
            Invoke(nameof(UnDisable),0.5f);
        }

    }

    void UnDisable()
    {
        rf.disables--;
    }

}
