using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour {

    public Rigidbody centralBody;
    public EnergyGraph energyGraph;


    private Rigidbody rbody; 

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        InitialConditions ic = InitialConditions.Instance();

        rbody.velocity = new Vector3(0, -ic.v, 0);
        transform.position = new Vector3(ic.r, 0, 0);

        Debug.LogFormat("Timestep={0}", Time.fixedDeltaTime);
	}

    private float Energy() {
        float r = Vector3.Magnitude(centralBody.transform.position - transform.position);
        Vector3 v = rbody.velocity;
        return 0.5f * Vector3.SqrMagnitude(v) - centralBody.mass / r;
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

        if (energyGraph != null)
            energyGraph.energy = Energy();
    }
}
