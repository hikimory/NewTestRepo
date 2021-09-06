using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float _currentWheelRotation = 0f;

    [SerializeField]
    private float _previousAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Solution1();
    }

    void Solution1()
    {
        
        Vector3 direction = new Vector3(target.position.x, target.position.y, transform.position.z) - transform.position;
        Debug.DrawRay(transform.position, direction, Color.green);
        // direction.z = transform.position.z;
        // Debug.DrawRay(transform.position, direction, Color.red);
        transform.up = direction;
    }

    void Solution2()
    {
        Vector3 direction = target.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.green);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = Vector3.forward * angle;
    }
}
