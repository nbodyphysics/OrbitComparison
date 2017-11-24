using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour {

    public Rigidbody centralBody;
    public Vector3 initialVelocity; 


    private Rigidbody rbody; 

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        rbody.velocity = initialVelocity;

        Debug.LogFormat("Timestep={0}", Time.fixedDeltaTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 r =  centralBody.transform.position - transform.position;
        Vector3 forceDirection = Vector3.Normalize(r);
        float rMag = Vector3.Magnitude(r);
        // F = M1 a = G M1 M2/R^2
        // Take G=1
        float forceMagnitude = rbody.mass * centralBody.mass / (rMag * rMag);
        rbody.AddForce(forceMagnitude * forceDirection);
	}
}
