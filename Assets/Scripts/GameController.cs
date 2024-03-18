using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public GameObject NodePrefab;
    public GameObject selectedNode;
    public HashSet<Vector2> matches = new HashSet<Vector2>();
    public List<string> eachLine = new List<string>();
    public GameObject[,] grid;
    public Text ScoreText;
    public Text LastWordText;
    public TextAsset wordFile;

    private Vector2 nodeSize;
    private RectTransform _rectTransform;
    private string wordsAsString;
    private string lastWordFound;
    private int playerScore;

    float iResX = 0;
    float iResY = 0;
    int rows = 9;
    int cols = 18;
    int nodeHeight = 0;
    int nodeWidth = 0;
    int kWords;

    // Start is called before the first frame update
    void Start()
    {
        wordsAsString = wordFile.text;
        eachLine.AddRange(wordsAsString.ToUpper().ToString().Trim().Split("\n"[0]) );
        _rectTransform = GetComponent<RectTransform>();
        playerScore = 0;

        CreateNodes();
    }

    void CreateNodes() {
        grid=new GameObject[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject node = Instantiate(NodePrefab);
                node.transform.SetParent(this.transform);

                nodeHeight = (int)node.transform.GetComponent<RectTransform>().rect.height;
                nodeWidth = (int)node.transform.GetComponent<RectTransform>().rect.width;

                Vector2 pos = new Vector2(i * nodeWidth, j * -nodeHeight);
                node.GetComponent<RectTransform>().anchoredPosition = pos;
                node.transform.localScale = Vector3.one;
                node.GetComponent<NodeData>().setGridValues(i, j);
                grid[i , j] = node;

                if(iResX == 0 && iResY == 0) {
                    iResX = this.transform.GetComponent<RectTransform>().rect.width / nodeWidth;
                    iResY = this.transform.GetComponent<RectTransform>().rect.height / nodeHeight;

                }
            }
        }
    }

    public void Select() {
            selectedNode.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
    }

    public void Unselect() {
            selectedNode.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;

    }

    public void Swap(GameObject gameObject1, GameObject gameObject2)
    {
        Debug.Log(validPosition(gameObject1, gameObject2).ToString());
        Debug.Log(nodeWidth - 5);

        if (validPosition(gameObject1, gameObject2) <= (nodeWidth + 5) && validPosition(gameObject1, gameObject2) > 0)
        {

            Vector3 tempPosition = gameObject1.transform.position;

            // Swap Obj1 Position
            gameObject1.transform.position = gameObject2.transform.position;
            // Swap Obj Position
            gameObject2.transform.position = tempPosition;

            int gobj1X = (int)gameObject1.GetComponent<NodeData>().getGridPos()[0];
            int gobj1Y = (int)gameObject1.GetComponent<NodeData>().getGridPos()[1];


            int gobj2X = (int)gameObject2.GetComponent<NodeData>().getGridPos()[0];
            int gobj2Y = (int)gameObject2.GetComponent<NodeData>().getGridPos()[1];


            grid[gobj2X, gobj2Y] = gameObject1;
            grid[gobj1X, gobj1Y] = gameObject2;

            gameObject1.GetComponent<NodeData>().setGridValues(gobj2X, gobj2Y);
            gameObject2.GetComponent<NodeData>().setGridValues(gobj1X, gobj1Y);

        }
    }

    public float validPosition(GameObject letter1, GameObject letter2) {
        Debug.Log(Vector2.Distance(letter1.transform.position, letter2.transform.position).ToString());
        return Vector2.Distance(letter1.transform.position, letter2.transform.position);
    }

    public bool validWord(string formedWord)
    {
        foreach (string dictWord in eachLine)
        {
            if (dictWord.Trim().Equals(formedWord))
            {
                return true;
            }
        }
        return false;
    }

    public void check_vertical() {

        for (int row=0; row < rows; row++) {
            for(int col=0; col < (cols - 2); col++) {
                string wordToCheck = grid[row, col].GetComponent<NodeData>().getLetterValue() + grid[row, col+1].GetComponent<NodeData>().getLetterValue() + grid[row, col+2].GetComponent<NodeData>().getLetterValue();

                if (validWord(wordToCheck)) {
                    Debug.Log("VERT: " + wordToCheck);
                    matches.Add(grid[row, col].GetComponent<NodeData>().getGridPos());
                    matches.Add(grid[row, col+1].GetComponent<NodeData>().getGridPos());
                    matches.Add(grid[row, col+2].GetComponent<NodeData>().getGridPos());
                    lastWordFound = wordToCheck;
                    updateLastWordText();

                }
            }
        }
    }

    public void check_horizontal() {
        for(int row=0; row < (rows - 2); row++) {
            for(int col=0; col < cols; col++) {
                string wordToCheck = grid[row, col].GetComponent<NodeData>().getLetterValue() + grid[row+1, col].GetComponent<NodeData>().getLetterValue() + grid[row+2, col].GetComponent<NodeData>().getLetterValue();

                if (validWord(wordToCheck)) {
                    Debug.Log("HORIZ: " + wordToCheck);
                    matches.Add(grid[row, col].GetComponent<NodeData>().getGridPos());
                    matches.Add(grid[row + 1, col].GetComponent<NodeData>().getGridPos());
                    matches.Add(grid[row + 2, col].GetComponent<NodeData>().getGridPos());
                    lastWordFound = wordToCheck;
                    updateLastWordText();
                    }
                }
            }
        }

    public void addNodes() {
        foreach (Vector2 m in matches)
        {
            GameObject node = Instantiate(NodePrefab);
            node.transform.SetParent(this.transform);

            nodeHeight = (int)node.transform.GetComponent<RectTransform>().rect.height;
            nodeWidth = (int)node.transform.GetComponent<RectTransform>().rect.width;

            Vector2 pos = new Vector2((int)m[0] * nodeWidth, -(int)m[1] * nodeHeight);
            node.GetComponent<RectTransform>().anchoredPosition = pos;
            node.transform.localScale = Vector3.one;
            grid[ (int)m[0] , (int)m[1] ] = node;
            node.GetComponent<NodeData>().setGridValues((int)m[0], (int)m[1]);
        }
    }

    public int getCurrentScore() {
        return playerScore;
    }

    public void deleteMatches() {
        foreach (Vector2 m in matches)
            {
                Destroy(grid[ (int)m[0] , (int)m[1] ].gameObject);
                playerScore++;
            }
        addNodes();
    }

    void updateScoreText() {
        ScoreText.text = getCurrentScore().ToString();
    }

    void updateLastWordText()
    {
        LastWordText.text = "Last Word Found: " + lastWordFound.ToString();
    }

    // Update is called once per frame
    void Update()
         {
            if (Input.GetMouseButtonDown(0))
                {
                    // Get mouse position
                    Vector3 mousePos = Input.mousePosition;
                    Vector3 worldPosition = new Vector3( Mathf.Floor((float)((mousePos.x / Screen.width * iResX))),
                                                         Mathf.Floor((float)((1 - (mousePos.y / Screen.height))) * iResY), 0);
                    int mouseX = (int)(worldPosition.x);
                    int mouseY = (int)(worldPosition.y);

                    // Check if selected
                    if(selectedNode != null) {

                        Swap(selectedNode, grid[mouseX, mouseY].gameObject);

                        Unselect();
                        check_horizontal();
                        check_vertical();

                        if(matches.Count != 0) {
                            deleteMatches();

                        }

                        updateScoreText();

                        selectedNode = null;
                        matches = new HashSet<Vector2>();

                    }

                    else if(selectedNode ==  grid[mouseX, mouseY].gameObject) {
                        Unselect();
                        selectedNode = null;
                    }

                    else if(selectedNode == null) {
                        selectedNode = grid[mouseX, mouseY].gameObject;
                        Select();
                    }

                    else {
                        // If nothing is selected, select something
                        selectedNode = null;
                    }

                }
        }
}
