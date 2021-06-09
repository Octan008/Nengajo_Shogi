using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Koma
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void move_away(){
        StateManager.game_end();
        base.move_away();
    }
    public override void Selected(){
        base.Selected();
        if(posY > -1){
            if(StateManager.GetState_teban() == senko && StateManager.GetState_check() == 0){
                Debug.Log(StateManager.GetState_check());
                for(int i=-1; i<2; i++){
                    for(int j=-1; j<2; j++){
                        if(!(i==0 && j==0)){
                            if(-1 < posX + i && posX+i < 3 && -1 < posY + j && posY+j < 4){                            
                                    Mark_distination(posX+i, posY+j);            
                            }                    
                        }
                    }
                }
                StateManager.SelectDistination(idf);
            } 
        }
        else{
            Debug.Log("out");
        }      
    }
}
