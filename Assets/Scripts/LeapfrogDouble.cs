
using UnityEngine;

public class LeapfrogDouble : MonoBehaviour
{

    public Rigidbody centralBody;
    private float speed = 1f; 

    private double[] a;
    private double[] v;
    private double[] r;
    private double mass;
    private double dt; 

    // Use this for initialization
    void Start() {
        // precalc acceleration
        InitialConditions ic = InitialConditions.Instance();
        v = new double[] { ic.v, 0, 0 };
        transform.position = new Vector3(0, ic.r, 0);
        r = new double[] { 0, ic.r, 0 };
        a = new double[3]; 
        CalcAcceleration();
        mass = centralBody.mass;

        speed = ic.GetSpeed();
        dt = ic.dt;

        Debug.LogFormat("dt={0}", dt);

    }

    private void CalcAcceleration() {
        // assuming central mass at origin

        double rSquared = r[0] * r[0] + r[1] * r[1] + r[2] * r[2];
        double r3 = rSquared * System.Math.Sqrt(rSquared);
        a[0] = -r[0] * mass / (r3);
        a[1] = -r[1] * mass / (r3);
        a[2] = -r[2] * mass / (r3);

    }

    // Update is called once per frame
    void FixedUpdate() {

        // Instead of AddForce - update the velocity directly
        for (int i = 0; i < speed; i++) {
            v[0] += a[0] * 0.5 * dt;
            v[1] += a[1] * 0.5 * dt;
            v[2] += a[2] * 0.5 * dt;

            r[0] += v[0] * dt;
            r[1] += v[1] * dt;
            r[2] += v[2] * dt;
            CalcAcceleration();
            v[0] += a[0] * 0.5 * dt;
            v[1] += a[1] * 0.5 * dt;
            v[2] += a[2] * 0.5 * dt;
        }
        transform.position = new Vector3((float) r[0], (float) r[1], (float) r[2]);

     }
}
