using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject NodePrefab;
    public GameObject selectedNode;

    public GameObject TheObject;
    public GameObject FoundObject;
    
    private RectTransform _rectTransform;
    public string RaycastReturn;


    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        CreateNodes();
    }

    void CreateNodes() {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject node = Instantiate(NodePrefab);
                node.transform.SetParent(this.transform);
                Vector2 pos = new Vector2(i * 200, j * -200);
                node.GetComponent<RectTransform>().anchoredPosition = pos;
                node.transform.localScale = Vector3.one;

            } 
        }
    }

    public void Select() // 4
        {
            selectedNode.GetComponent<Image>().color = Color.green;
        }
    public void Unselect() // 5 
        {
            selectedNode.GetComponent<Image>().color = Color.white;
        }

    private void OnMouseDown() //6
        {
            if(selectedNode != null)
            {
                Unselect();
            }
            Select();
        }
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
        
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("did hit");
            RaycastReturn = hitData.collider.gameObject.name;
            Debug.Log("did hit");
            FoundObject = GameObject.Find(RaycastReturn);
            Debug.Log("did hit");
            Destroy(FoundObject);
            Debug.Log("did hit");
            Debug.Log(hitData.collider.gameObject.name);
            // selectedNode = hitData.transform.gameObject;
            // OnMouseDown();
        }
        
        if (hitData && Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICKED A THING");
            
        }
    }
}
