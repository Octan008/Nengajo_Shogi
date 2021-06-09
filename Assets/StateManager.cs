using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class StateManager : MonoBehaviour
{
    // public enum Teban {
    //     player1,
    //     player2
    // }
    public static bool teban = true;
    public static int check = 0;
    public static bool play = false;
    public static int SelectedKoma = -1;
    // public static int[,] map =  {{1,1,1}, {0,1,0}, {0,2,0}, {2,2,2}};
    public static int[,] map =  {{1,0,0,2}, {1,1,2,2}, {1,0,0,2}};
    public static int[,] id_map =  {{0,-1,-1,4}, {2,6,7,3}, {5,-1,-1,1}};
    public static int[,] map_prime =  {{1,0,0,2}, {1,1,2,2}, {1,0,0,2}};
    public static int[,] id_map_prime =  {{0,-1,-1,4}, {2,6,7,3}, {5,-1,-1,1}};
    static GameObject board;
    public static int senko_out = 0;
    public static int koko_out= 0;
    public static bool tile_select_sceed = false;
    public static GameObject Board;

    public static void SetBoard(GameObject b){
        board = b;
    }
    // private static teban currentState;
    // Start is called before the first frame update
    void Start()
    {
        Board = GameObject.Find("Prime_Game_Board");
        
    }
    public static void ResetAll(){
        
        Reset();
        teban = true;
        map =  map_prime;
        id_map =  id_map_prime;
        tile_select_sceed = false;
        koko_out= 0;
        senko_out = 0;
        SelectedKoma = -1;
        SceneManager.LoadScene("SampleScene");
    }
    public static void game_end(){
        Debug.Log("勝敗確定");
        Board.GetComponent<UIControl>().EndGame();
        play = false;
    }
    public static void SelectDistination(int id){
        if(tile_select_sceed){
            SelectedKoma = id;
            check = 1;
            Board.GetComponent<UIControl>().reset_button_set(true);
        }
        else{
            Reset();
        }

    }

    // Update is called once per frame
    // void Update()
    // {
    //     TouchInfo info = AppUtil.GetTouch();
    //     if(check == 1 && info == TouchInfo.Began){
            
    //     }
        
    // }
    public static int GetState_check() {
        return check;
    }
    public static bool GetState_teban(){
        return teban;
    }
    public static void Neutral(){
        check = 0;
    }
    public static void NextState(){        
        check = 1;
        Debug.Log(teban.ToString() + ", " + check.ToString());        
    }
    public static void NextTeban(){
        teban = !teban;
        if(teban) Board.GetComponent<UIControl>().Senko();
        else Board.GetComponent<UIControl>().Koko();
        Reset();
    }
    public static void Reset(){
        check = 0;
        for(int i=1; i<13; i++){
            board.transform.GetChild(i).GetComponent<Tile>().Reset();
        }
        tile_select_sceed = false;
        Board.GetComponent<UIControl>().reset_button_set(false);
    }
}
