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
                    
                    // int nodeHeight = (int)this.transform.parent.transform.GetComponent<GameController>().GetComponent<RectTransform>().rect.height;
                    // int nodeWidth = (int)this.transform.parent.transform.GetComponent<GameController>().GetComponent<RectTransform>().rect.width;
                    
                    // float iResX = this.transform.parent.GetComponent<GameController>().GetComponent<RectTransform>().rect.width / nodeWidth;
                    // float iResY = this.transform.parent.GetComponent<GameController>().GetComponent<RectTransform>().rect.height / nodeHeight;

                    // Vector3 mousePos = Input.mousePosition;
                    // Vector3 worldPosition = new Vector3( Mathf.Floor((float)((mousePos.x / Screen.width * iResX))), 
                    //                                      Mathf.Floor((float)((1 - (mousePos.y / Screen.height))) * iResY), 0);

                    
                    // int mouseX = (int)(worldPosition.x);
                    // int mouseY = (int)(worldPosition.y);

                    
                    // this.transform.parent.parent.GetComponent<GameController>().grid[mouseX, mouseY].gameObject.transform.GetChild(0).gameObject.GetComponent<Piece>().rotatePiece();
                    OnDoubleClicked();
                    
                }

            }
        }
    }
