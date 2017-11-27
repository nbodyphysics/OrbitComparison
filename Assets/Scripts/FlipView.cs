using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipView : MonoBehaviour {

    public Camera main;
    public Camera secondary;

    private Rect mainRect;
    private Rect secondaryRect;
    private float mainDepth;
    private float secondaryDepth; 

    private bool showMain = true; 

	// Use this for initialization
	void Start () {
        mainRect = main.rect;
        mainDepth = main.depth;
        secondaryRect = secondary.rect;
        secondaryDepth = secondary.depth;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.C)) {
            if (showMain) {
                main.rect = secondaryRect;
                main.depth = secondaryDepth;
                secondary.rect = mainRect;
                secondary.depth = mainDepth;
            } else {
                main.rect = mainRect;
                main.depth = mainDepth;
                secondary.rect = secondaryRect;
                secondary.depth = secondaryDepth;
            }
            showMain = !showMain;
        }
	}
}
