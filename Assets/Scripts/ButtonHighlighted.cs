using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlighted : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    public Image help;

    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData != null)
        {
            Button btn;
            btn = eventData.pointerEnter.GetComponentInParent<Button>();
            btn.Select();

        }
    }

    // When selected with buttons or gamepad.
    public void OnSelect(BaseEventData eventData)
    {
        if (eventData != null)
        {
            switch (eventData.selectedObject.name)
            {
                case "VsButton":
                    help.color = Color.black;
                    break;
                case "CoopButton":
                    help.color = Color.cyan;
                    break;
                case "EndlessButton":
                    help.color = Color.magenta;
                    break;
                default:
                    break;
            }
        }
    }

}