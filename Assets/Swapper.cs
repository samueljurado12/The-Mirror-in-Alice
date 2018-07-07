using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour {

    private static bool upperScreenCanCatch;

    private PickableObject scoreUp, scoreDown;

    [SerializeField]
    private bool upscreenObject;

    private void Start() {
        scoreUp = GetComponentsInChildren<PickableObject>()[0];
        scoreDown = GetComponentsInChildren<PickableObject>()[1];
        upperScreenCanCatch = Random.value > 0.5;
        drawObjectsUpperScreen();
        drawObjectsLowerScreen();
        
    }

    private void Update() {
            drawObjectsUpperScreen();
            drawObjectsLowerScreen();
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
        Debug.Log("Now this is " + (upscreenObject == upperScreenCanCatch ? "up":"down"));
        upperScreenCanCatch = !upperScreenCanCatch; 
    }

}
