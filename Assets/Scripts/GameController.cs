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
    // public List<List<GameObject>> grid = new List<List<GameObject>>();
    public HashSet<Vector2> matches = new HashSet<Vector2>();
    public GameObject[,] grid;
    public Text ScoreText;

    public TextAsset wordFile;
    private Vector2 nodeSize;
    private RectTransform _rectTransform;
    private string wordsAsString;
    private string lastWordFound;
    private List<string> eachLine;
    private int playerScore;

    float iResX = 0;
    float iResY = 0;
    int rows = 7; 
    int cols = 7;
    int nodeHeight = 0;
    int nodeWidth = 0;
    int kWords;

    // Start is called before the first frame update
    void Start()
    {
        wordsAsString = wordFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(wordsAsString.ToUpper().Split("\n"[0]) );

        for(int i = 0; i < eachLine.Count; i++) {
            if(eachLine[i].Length > rows || eachLine[i].Length > cols) {
                eachLine.RemoveAt(i);
            }
        }
        
        kWords = eachLine.Count;

        _rectTransform = GetComponent<RectTransform>();
        playerScore = 0;


        // ScoreText = GetComponent<ScoreText>();        
        // updateScoreText();
        CreateNodes();
    }

    void CreateNodes() {
        grid=new GameObject[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            // grid.Add( new List<GameObject>());

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
                grid[i, j] = node;
                
                if(iResX == 0 && iResY == 0) {
                    iResX = this.transform.GetComponent<RectTransform>().rect.width / nodeWidth;
                    iResY = this.transform.GetComponent<RectTransform>().rect.height / nodeHeight;

                }
                // if(j == cols - 1) {
                //     node.transform.GetChild(0).gameObject.GetComponent<Piece>().freezePiece();
                // }

            }

            // grid[i].Reverse();
        }
    }

    public void Select() {
            selectedNode.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
            // selectedNode.transform.GetChild(0).gameObject.GetComponent<Piece>().selectPiece();
            // Debug.Log(selectedNode.GetComponent<NodeData>().getLetterValue());
            // Debug.Log(selectedNode.GetComponent<NodeData>().getGridPos());

    }
    
    public void Unselect() {
            selectedNode.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
            // selectedNode.transform.GetChild(0).gameObject.GetComponent<Piece>().deselectPiece();

    }

    public void Swap(GameObject gameObject1, GameObject gameObject2) {
        
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

    public bool validPosition(GameObject letter1, GameObject letter2) {
        return Vector2.Distance(letter1.transform.position, letter2.transform.position) <= 1 && Vector2.Distance(letter1.transform.position, letter2.transform.position) != 0;
    }

    public void check_vertical() {
        for(int row=0; row < rows; row++) {
            for(int col=0; col < (cols - 3); col++) {
                var wordToCheck = grid[row, col].GetComponent<NodeData>().getLetterValue() + grid[row, col+1].GetComponent<NodeData>().getLetterValue() + grid[row, col+2].GetComponent<NodeData>().getLetterValue(); 
                if( eachLine.Contains(wordToCheck)) {
                        matches.Add(grid[row, col].GetComponent<NodeData>().getGridPos());
                        matches.Add(grid[row, col+1].GetComponent<NodeData>().getGridPos());
                        matches.Add(grid[row, col+2].GetComponent<NodeData>().getGridPos());
                        lastWordFound = wordToCheck;
                }
            }
        }
    }

    public void check_horizontal() {
        for(int row=0; row < (rows - 3); row++) {
            for(int col=0; col < cols; col++) {
                var wordToCheck = grid[row, col].GetComponent<NodeData>().getLetterValue() + grid[row+1, col].GetComponent<NodeData>().getLetterValue() + grid[row+2, col].GetComponent<NodeData>().getLetterValue(); 
                if( eachLine.Contains(wordToCheck)) {
                        matches.Add(grid[row, col].GetComponent<NodeData>().getGridPos());
                        matches.Add(grid[row + 1, col].GetComponent<NodeData>().getGridPos());
                        matches.Add(grid[row + 2, col].GetComponent<NodeData>().getGridPos());
                        lastWordFound = wordToCheck;
                    }
                }
            }
        }

    public void addNodes() {
        foreach (Vector2 m in matches)
        {   
            // Debug.Log("ADD-COORDS: " + m);

            GameObject node = Instantiate(NodePrefab);
            node.transform.SetParent(this.transform);
            
            nodeHeight = (int)node.transform.GetComponent<RectTransform>().rect.height;
            nodeWidth = (int)node.transform.GetComponent<RectTransform>().rect.width;
            
            Vector2 pos = new Vector2((int)m[0] * nodeWidth, -(int)m[1] * nodeHeight);
            node.GetComponent<RectTransform>().anchoredPosition = pos;
            node.transform.localScale = Vector3.one;
            // node.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.blue;
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
                // grid[ (int)m[0] , (int)m[1] ].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.magenta;
                // Debug.Log("FOUND-COORDS: " + m);
                Destroy(grid[ (int)m[0] , (int)m[1] ].gameObject);
                playerScore++;

            }
        
        addNodes();
        // matches = new HashSet<Vector2>();
    }

    void updateScoreText() {
        ScoreText.text = "Last Word Found: " + lastWordFound;
    }

    // Update is called once per frame
    void Update()
         {
            if (Input.GetMouseButtonDown(0))
                {   
                    // Get mouse position
                    Vector3 mousePos = Input.mousePosition;

                    // Debug.Log("POSITION-X " + (mousePos.x / Screen.width * iResX));
                    // Debug.Log("POSITION-Y " + ((1 - (mousePos.y / Screen.height))) * iResY);


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

