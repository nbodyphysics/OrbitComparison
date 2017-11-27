using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGraph : MonoBehaviour {

    public float energy;

    public float energyScale = 1f;
    public float energyOffset = 0f;

    public float timeScale = 1f;

    private Vector3 initialPosition; 

    void Start() {
        initialPosition = transform.position;
    }
	
	// Set position based on scaled energy and time
	void Update () {
        transform.position = initialPosition +
            new Vector3(Time.time * timeScale, energy * energyScale + energyOffset, 0); 
	}
}
