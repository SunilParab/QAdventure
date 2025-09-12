using UnityEngine;

public class RopeFollow : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float pullForce;
    [SerializeField]
    float repelForce;
    [SerializeField]
    float idealMaxDistance;
    [SerializeField]
    float idealMinDistance;

    public int disables;

    //Components
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disables == 0) {
            float dist = Vector2.Distance(target.transform.position, transform.position);
            if (dist > idealMaxDistance)
            {
                rb.AddForce((target.transform.position - transform.position).normalized * pullForce * dist / idealMaxDistance, ForceMode2D.Force);
            } else if (dist < idealMinDistance) {
                rb.AddForce((transform.position - target.transform.position).normalized * repelForce * (rb.linearVelocity.magnitude+1) * (idealMinDistance - dist), ForceMode2D.Force);
            }
        }
    }
}
