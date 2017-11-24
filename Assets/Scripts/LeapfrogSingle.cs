
using UnityEngine;

public class LeapfrogSingle: MonoBehaviour
{

    public Rigidbody centralBody;
    private float speed = 1f; 

    private float[] a;
    private float[] v;
    private float[] r;
    private float mass;
    private float dt; 

    // Use this for initialization
    void Start() {
        // precalc acceleration
        InitialConditions ic = InitialConditions.Instance();
        v = new float[] { ic.v, 0, 0 };
        transform.position = new Vector3(0, ic.r, 0);
        r = new float[] { 0, ic.r, 0 };
        a = new float[3]; 
        CalcAcceleration();
        mass = centralBody.mass;

        speed = ic.speed;
        dt = ic.dt;


    }

    private void CalcAcceleration() {
        // assuming central mass at origin

        float rSquared = r[0] * r[0] + r[1] * r[1] + r[2] * r[2];
        float r3 = rSquared * Mathf.Sqrt(rSquared);
        a[0] = -r[0] * mass / (r3);
        a[1] = -r[1] * mass / (r3);
        a[2] = -r[2] * mass / (r3);

    }

    // Update is called once per frame
    void FixedUpdate() {

        // Instead of AddForce - update the velocity directly
        for (int i = 0; i < speed; i++) {
            v[0] += a[0] * 0.5f * dt;
            v[1] += a[1] * 0.5f * dt;
            v[2] += a[2] * 0.5f * dt;

            r[0] += v[0] * dt;
            r[1] += v[1] * dt;
            r[2] += v[2] * dt;
            CalcAcceleration();
            v[0] += a[0] * 0.5f * dt;
            v[1] += a[1] * 0.5f * dt;
            v[2] += a[2] * 0.5f * dt;
        }
        transform.position = new Vector3( r[0],  r[1], r[2]);

     }
}
