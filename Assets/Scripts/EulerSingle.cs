
using UnityEngine;

public class EulerSingle : MonoBehaviour
{

    public Rigidbody centralBody;

    private float speed = 1f;

    private float[] v;
    private float[] r;
    private float[] a;
    private float mass;
    private float dt;

    // Use this for initialization
    void Start() {
        InitialConditions ic = InitialConditions.Instance();
        v = new float[] { 0, -ic.v, 0 };
        r = new float[] { -ic.r, 0, 0 };
        a = new float[3];

        mass = centralBody.mass;
        dt = ic.dt;
        speed = ic.GetSpeed();
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
            CalcAcceleration();
 
            r[0] += v[0] * dt;
            r[1] += v[1] * dt;
            r[2] += v[2] * dt;

            v[0] += a[0] * dt;
            v[1] += a[1] * dt;
            v[2] += a[2] * dt;
        }
        transform.position = new Vector3(r[0], r[1], r[2]);
    }
}
