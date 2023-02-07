using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonClickPerfect : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent calledWhenClicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            calledWhenClicked.Invoke();
        }
    }
   
}
