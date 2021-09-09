using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRotation : MonoBehaviour
{
    [SerializeField]
    private float speed = 2000f;

    private Rigidbody rb = null;

    private bool InAir = false;

    //Coroutine lastRoutine = null;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        Release();
    }

    public void Release()
    {
        rb.AddForce(transform.forward * speed);
        InAir = true;
        //lastRoutine = StartCoroutine(RotateWithVelocity());
        StartCoroutine(nameof(RotateWithVelocity));
    }

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();

        while(InAir)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity, transform.forward);
            yield return null;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            //StopCoroutine(lastRoutine);
            StopCoroutine(nameof(RotateWithVelocity));
        }
    }
}
