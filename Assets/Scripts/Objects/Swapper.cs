using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour {

    public static bool upperScreenCanCatch;

    private PickableObject scoreUp, scoreDown;

    public bool upscreenObject;

    private void Start() {
        scoreUp = GetComponentsInChildren<PickableObject>()[0];
        scoreDown = GetComponentsInChildren<PickableObject>()[1];
        upperScreenCanCatch = Random.value > 0.5;
        drawObjectsUpperScreen();
        drawObjectsLowerScreen();
        
    }

    private void Update() {
        if (upscreenObject) {
            drawObjectsUpperScreen();
        } else {
            drawObjectsLowerScreen();
        }
    }

    private void drawObjectsLowerScreen() {
        scoreUp.gameObject.SetActive(!upperScreenCanCatch);
        scoreDown.gameObject.SetActive(upperScreenCanCatch);
    }

    private void drawObjectsUpperScreen() {
        scoreUp.gameObject.SetActive(upperScreenCanCatch);
        scoreDown.gameObject.SetActive(!upperScreenCanCatch);
    }

    public void swap() {
        upperScreenCanCatch = !upperScreenCanCatch; 
    }

    public static bool getUpperScreenCanCatch() {
        return upperScreenCanCatch;
    }

}
