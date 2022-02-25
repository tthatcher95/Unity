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
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeSuitRandom();   
    }
    void ChangeSuitRandom() {
        //Get a random number
        int rand = UnityEngine.Random.Range(1, 27);

        // Get a random suit
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
                break;
            case Suits.B:
                image.sprite = B;
                break;
            case Suits.C:
                image.sprite = C;
                break;
            case Suits.D:
                image.sprite = D;
                break;
            case Suits.E:
                image.sprite = E;
                break;
            case Suits.F:
                image.sprite = F;
                break;
            case Suits.G:
                image.sprite = G;
                break;
            case Suits.H:
                image.sprite = H;
                break;
            case Suits.I:
                image.sprite = I;
                break;
            case Suits.J:
                image.sprite = J;
                break;
            case Suits.K:
                image.sprite = K;
                break;
            case Suits.L:
                image.sprite = L;
                break;
            case Suits.M:
                image.sprite = M;
                break;
            case Suits.N:
                image.sprite = N;
                break;
            case Suits.O:
                image.sprite = O;
                break;
            case Suits.P:
                image.sprite = P;
                break;
            case Suits.Q:
                image.sprite = Q;
                break;
            case Suits.R:
                image.sprite = R;
                break;
            case Suits.S:
                image.sprite = S;
                break;
            case Suits.T:
                image.sprite = T;
                break;
            case Suits.U:
                image.sprite = U;
                break;
            case Suits.V:
                image.sprite = V;
                break;
            case Suits.W:
                image.sprite = W;
                break;
            case Suits.X:
                image.sprite = X;
                break;
            case Suits.Y:
                image.sprite = Y;
                break;
            case Suits.Z:
                image.sprite = Z;
                break;
            default:
                break;

        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
