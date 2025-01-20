using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 thrust;
    public Quaternion heading;

    // Start is called before the first frame update
    void Start()
    {
        thrust.x = 400.0f;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().MoveRotation(heading);
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;

        if (collider.CompareTag("Asteroid"))
        {
            AsteroidScript roid = collider.gameObject.GetComponent<AsteroidScript>();

            roid.Die();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("collide with " + collider.tag);
        }
    }
}
