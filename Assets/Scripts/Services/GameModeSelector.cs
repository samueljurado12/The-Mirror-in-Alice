using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameModeSelector : MonoBehaviour {

    public Button vsModeButton, coopModeButton, endlessModeButton;

	// Use this for initialization
	void Start () {
        Button btn1 = vsModeButton.GetComponent<Button>();
        Button btn2 = coopModeButton.GetComponent<Button>();
        Button btn3 = endlessModeButton.GetComponent<Button>();

        //OnClick listeners
        btn1.onClick.AddListener(vsModeClicked);
        btn2.onClick.AddListener(coopModeClicked);
        btn3.onClick.AddListener(endlessModeClicked);
	}

    void vsModeClicked()
    {
        //Output this to console when the Button is clicked
        coopModeButton.interactable = false;
        endlessModeButton.interactable = false;

        if (confirmSelection()) {
            //TODO: Go to vs Scene
        }
        else {
            coopModeButton.interactable = true;
            endlessModeButton.interactable = true;
        }

    }

    void coopModeClicked()
    {
        //Output this to console when the Button is clicked
        vsModeButton.interactable = false;
        endlessModeButton.interactable = false;
        if (confirmSelection())
        {
            //TODO: Go to coop Scene
        }
        else
        {
            vsModeButton.interactable = true;
            endlessModeButton.interactable = true;
        }

    }

    void endlessModeClicked()
    {
        //Output this to console when the Button is clicked
        coopModeButton.interactable = false;
        vsModeButton.interactable = false;
        if (confirmSelection())
        {
            //TODO: Go to enles Scene
        }
        else
        {
            coopModeButton.interactable = true;
            vsModeButton.interactable = true;
        }

    }

    private bool confirmSelection() {
        return true; //TODO: Ask user for confirmation
    }


}
