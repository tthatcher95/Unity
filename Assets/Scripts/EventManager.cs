using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EventManager : MonoBehaviour, IPointerClickHandler
{

    public delegate void ClickAction();
    public static event ClickAction OnDoubleClicked;

    public void OnPointerClick(PointerEventData eventData)
        {
            if(OnDoubleClicked != null) {
                if (eventData.clickCount == 2) {
                    Debug.Log ("double click");
                    Debug.Log(eventData.position);
                    
                    OnDoubleClicked();
                    
                }

            }
        }
    }
