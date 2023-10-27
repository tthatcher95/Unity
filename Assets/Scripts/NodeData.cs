using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeData : MonoBehaviour
{
    public Vector2 gridPos;
    public Vector2 dimensions;
    string letterValue;
    // Start is called before the first frame update
    public void setGridValues(int x, int y) {
        this.gridPos = new Vector2(x, y);
    }

    public void setLetterValue(string letter) {
        this.letterValue = letter;
    }

    public void setDimensions(int width, int height)  {
        this.dimensions = new Vector2(this.gridPos[0]*width, this.gridPos[1]*height);
    }

    public Vector2 getDimensions() {
        return this.dimensions;
    }

    public Vector2 getGridPos() {
        return this.gridPos;
    }

    public string getLetterValue() {
        return this.letterValue;
    }


}
