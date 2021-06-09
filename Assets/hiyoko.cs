using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiyoko : Koma
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public new void Selected(){
        base.Selected();
        if(posY > -1){
        if(StateManager.GetState_teban() == senko && StateManager.GetState_check() == 0){
            int i=0; int j=1;
            if(!senko) j = -j;
            if(-1 < posX + i && posX+i < 3 && -1 < posY + j && posY+j < 4){                            
                    Mark_distination(posX+i, posY+j);            
            }                    
            StateManager.SelectDistination(idf);
        }
        }  
        else{
            Debug.Log("out");
        }       
    }
}
