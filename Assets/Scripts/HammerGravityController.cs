using UnityEngine;
using Autohand;

public class HammerGravityController : MonoBehaviour 
{
    private Rigidbody rb;
    public Grabbable grabbable;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<Grabbable>();
        rb.useGravity = false;
    }

    public void OnGrab()
    {
        rb.useGravity = true;
    }

    public void OnRelease()
    {
        rb.useGravity = false;
    }
}