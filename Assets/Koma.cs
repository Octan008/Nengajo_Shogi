using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koma : MonoBehaviour
{
    public int posX;
    public int posY;
    float size  =0.221f;
    public bool senko;
    int senko_id;
    public int idf = -1;
    // Start is called before the first frame update
    public void move(int x, int y){
        if(senko) senko_id = 1;
        else senko_id = 2;  
        if(posY > -1){
            StateManager.map[posX, posY] = 0;
            StateManager.id_map[posX, posY] = -1;
        }

        StateManager.map[x, y] = senko_id;
        StateManager.id_map[x,y] = idf;
                
        this.transform.localPosition = new Vector3( -size*1.5f + y*size, 0.0f, -size*1f + x*size);
        posX = x; posY = y;
    }

    public virtual void move_away(){
        int num = 0;
        if(senko) num = StateManager.senko_out;
        else num = StateManager.koko_out;

        int i;
        if(senko) i = 1;
        else i = -1;
        this.transform.localPosition = new Vector3( i * (size*1.5f + 1.5f*size) , 0.0f, -size*1f + num*size);
        this.transform.Rotate(new Vector3(0, 180, 0));

        if(senko) StateManager.senko_out++ ;
        else StateManager.koko_out++;

        posX = num; posY = -1;
        senko = !senko;
    }
    public void revive(){
        for(int i=0; i<3; i++){
            for(int j=0; j<4; j++){
                if(StateManager.map[i,j] == 0){
                    int tile = j + i * 4;
                    this.transform.parent.parent.GetChild(1+tile).GetComponent<Tile>().change_color2(new Color(0.8f,0.8f,0f,0.5f));
                    StateManager.tile_select_sceed  =  StateManager.tile_select_sceed || true;
                }
                
            }
        }
    }

    void SetIdf(int id){
        idf = id;
    }
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Selected(){
        if(posY > -1){
            if(StateManager.GetState_teban() != senko && StateManager.GetState_check() == 1){
                int tile = posY + posX * 4;
                if(this.transform.parent.parent.GetChild(1+tile).GetComponent<Tile>().GetState() == 1){                
                    this.transform.parent.parent.GetChild(1+tile).GetComponent<Tile>().SetTarget();
                }
            }   
            else if(StateManager.GetState_teban() == senko && StateManager.GetState_check() == 0){
                int tile = posY + posX * 4;
                this.transform.parent.parent.GetChild(1+tile).GetComponent<Tile>().change_color();
            }
        }
        else{
            if(StateManager.GetState_teban() == senko && StateManager.GetState_check() == 0){
                revive();
                StateManager.SelectDistination(idf);
            }
            
        }            
    }
    public void Mark_distination(int x, int y){
        if(senko) senko_id = 1;
        else senko_id = 2;   
        if(StateManager.map[x, y] == 0){
            int tile = y + x * 4;
            this.transform.parent.parent.GetChild(1+tile).GetComponent<Tile>().change_color2(new Color(0.8f,0.8f,0f,0.5f));
            StateManager.tile_select_sceed  =  StateManager.tile_select_sceed || true;
        }
        else if(StateManager.map[x, y] != senko_id){
            int tile = y + x * 4;
            this.transform.parent.parent.GetChild(1+tile).GetComponent<Tile>().change_color2(new Color(0.8f,0.0f,0f,0.5f));
            StateManager.tile_select_sceed  =  StateManager.tile_select_sceed || true;
        }
        // if(!senko){ x = 2-x; y = 3-y;}
        
    }
}
