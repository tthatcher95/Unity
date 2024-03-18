using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Piece : MonoBehaviour
{
    public enum Suits {blank, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z};
    // public enum Suits {none, green, yellow, red}
    public Suits Suit = Suits.blank;
    public Rigidbody2D rb;

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //If your mouse hovers over the GameObject with the script attached, output this message
        this.GetComponent<Image>().color = Color.magenta;

    }

    void OnMouseExit()
    {
            // Reset the color of the GameObject back to normal
            this.GetComponent<Image>().color = Color.white;

    }

    // Start is called before the first frame update
    void Start()

    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ChangeSuitRandom();
    }

    public void freezePiece() {
        rb.bodyType = RigidbodyType2D.Static;
    }

    void ChangeSuitRandom() {
        //Get a random number
        int rand = UnityEngine.Random.Range(1, 27);

        // var suits = Enum.GetValues(typeof(Suits));
        var suits = Enum.GetValues(typeof(Suits));
        Suits randSuit = (Suits)suits.GetValue(rand);

        // Apply that suit
        ChangeSuit(randSuit);

    }
    void ChangeSuit(Suits suit) {
        Sprite A = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_A_Tile");
        Sprite B = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_B_Tile");
        Sprite C = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_C_Tile");
        Sprite D = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_D_Tile");
        Sprite E = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_E_Tile");
        Sprite F = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_F_Tile");
        Sprite G = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_G_Tile");
        Sprite H = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_H_Tile");
        Sprite I = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_I_Tile");
        Sprite J = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_J_Tile");
        Sprite K = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_K_Tile");
        Sprite L = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_L_Tile");
        Sprite M = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_M_Tile");
        Sprite N = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_N_Tile");
        Sprite O = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_O_Tile");
        Sprite P = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_P_Tile");
        Sprite Q = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_Q_Tile");
        Sprite R = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_R_Tile");
        Sprite S = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_S_Tile");
        Sprite T = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_T_Tile");
        Sprite U = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_U_Tile");
        Sprite V = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_V_Tile");
        Sprite W = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_W_Tile");
        Sprite X = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_X_Tile");
        Sprite Y = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_Y_Tile");
        Sprite Z = Resources.Load<Sprite>("Images/Letter_Tiles_PNG/Water_Upper_Z_Tile");

        Image image = this.GetComponent<Image>();

        switch (suit)
        {
            case Suits.blank:
                break;
            case Suits.A:
                image.sprite = A;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("A");
                break;
            case Suits.B:
                image.sprite = B;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("B");
                break;
            case Suits.C:
                image.sprite = C;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("C");
                break;
            case Suits.D:
                image.sprite = D;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("D");
                break;
            case Suits.E:
                image.sprite = E;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("E");
                break;
            case Suits.F:
                image.sprite = F;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("F");
                break;
            case Suits.G:
                image.sprite = G;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("H");
                break;
            case Suits.H:
                image.sprite = H;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("H");
                break;
            case Suits.I:
                image.sprite = I;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("I");
                break;
            case Suits.J:
                image.sprite = J;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("J");
                break;
            case Suits.K:
                image.sprite = K;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("K");
                break;
            case Suits.L:
                image.sprite = L;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("L");
                break;
            case Suits.M:
                image.sprite = M;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("M");
                break;
            case Suits.N:
                image.sprite = N;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("N");
                break;
            case Suits.O:
                image.sprite = O;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("O");
                break;
            case Suits.P:
                image.sprite = P;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("P");
                break;
            case Suits.Q:
                image.sprite = Q;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("Q");
                break;
            case Suits.R:
                image.sprite = R;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("R");
                break;
            case Suits.S:
                image.sprite = S;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("S");
                break;
            case Suits.T:
                image.sprite = T;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("T");
                break;
            case Suits.U:
                image.sprite = U;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("U");
                break;
            case Suits.V:
                image.sprite = V;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("V");
                break;
            case Suits.W:
                image.sprite = W;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("W");
                break;
            case Suits.X:
                image.sprite = X;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("X");
                break;
            case Suits.Y:
                image.sprite = Y;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("Y");
                break;
            case Suits.Z:
                image.sprite = Z;
                this.transform.parent.gameObject.GetComponent<NodeData>().setLetterValue("Z");
                break;
            default:
                break;

        }
    }
    // Update is called once per frame
    //void Update()
    //{

    //}
}
