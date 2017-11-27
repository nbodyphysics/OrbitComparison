using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialConditions : MonoBehaviour {

    public float r;
    public float v;
    public float dt;
    private float speed;

    public Text timestep;

    private static InitialConditions instance;

    public static InitialConditions Instance() {
        if (!instance) {
            instance = FindObjectOfType(typeof(InitialConditions)) as InitialConditions;
            if (!instance)
                Debug.LogError("There needs to be one active InitialConditions script on a GameObject in your scene.");
        }

        return instance;
    }

    private void Awake() {
        timestep.text = string.Format("Timestep = {0}", dt);
        speed = Time.fixedDeltaTime / dt;
    }

    public float GetSpeed() {
        return speed;
    }


}
