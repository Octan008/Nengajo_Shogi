using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Board : MonoBehaviour
{
    public GameObject piece;
    public GameObject zo;
    public GameObject lion;
    public GameObject kirin;
    public GameObject hiyoko;
    // Start is called before the first frame update
    void Start()
    {
        StateManager.SetBoard(this.transform.gameObject);
        
        float size  =0.221f;
        var parent = this.transform;
        for(int i=0; i<3; i++){
            for(int j=0; j<4; j++){
                var _obj  =Instantiate(piece, new Vector3( -size*1.5f + j*size, 0.0f, -size*1f + i*size), Quaternion.identity, parent);
                _obj.transform.GetComponent<Tile>().Setpos(i, j);
                var _renderer = _obj.GetComponent<Renderer>();
                _renderer.material.color = new Color(0f,0f,1f,0.0f);
            }
        }
        
        var komabase = this.transform.GetChild(0);
        var obj =  Instantiate(kirin, new Vector3( -size*1.5f , 0.0f, -size*1f), Quaternion.identity, komabase);
        obj.GetComponent<Koma>().idf = 0; obj.GetComponent<Koma>().posX = 0; obj.GetComponent<Koma>().posY = 0; obj.GetComponent<Koma>().senko = true;
        obj =  Instantiate(kirin, new Vector3( size*1.5f , 0.0f, size*1f), Quaternion.Euler(0,180,0), komabase);
        obj.GetComponent<Koma>().idf = 1; obj.GetComponent<Koma>().posX = 2; obj.GetComponent<Koma>().posY = 3; obj.GetComponent<Koma>().senko = false;
        
        obj =  Instantiate(lion, new Vector3( -size*1.5f , 0.0f, size*0f), Quaternion.identity, komabase);
        obj.GetComponent<Koma>().idf = 2; obj.GetComponent<Koma>().posX = 1; obj.GetComponent<Koma>().posY = 0; obj.GetComponent<Lion>().senko = true;
        obj =  Instantiate(lion, new Vector3( size*1.5f , 0.0f, size*0f), Quaternion.Euler(0,180,0), komabase);
        obj.GetComponent<Koma>().idf = 3; obj.GetComponent<Koma>().posX = 1; obj.GetComponent<Koma>().posY = 3; obj.GetComponent<Koma>().senko = false;

        obj =  Instantiate(zo, new Vector3( -size*1.5f , 0.0f, size*1f), Quaternion.identity, komabase);
        obj.GetComponent<Koma>().idf = 4; obj.GetComponent<Koma>().posX = 2; obj.GetComponent<Koma>().posY = 0; obj.GetComponent<Koma>().senko = true;
        obj =  Instantiate(zo, new Vector3( size*1.5f , 0.0f, -size*1f), Quaternion.Euler(0,180,0), komabase);
        obj.GetComponent<Koma>().idf = 5; obj.GetComponent<Koma>().posX = 0; obj.GetComponent<Koma>().posY = 3; obj.GetComponent<Koma>().senko = false;

        obj =  Instantiate(hiyoko, new Vector3( -size*0.5f , 0.0f, size*0f), Quaternion.identity, komabase);
        obj.GetComponent<Koma>().idf = 6; obj.GetComponent<Koma>().posX = 1; obj.GetComponent<Koma>().posY = 1; obj.GetComponent<Koma>().senko = true;
        obj =  Instantiate(hiyoko, new Vector3( size*0.5f , 0.0f, size*0f), Quaternion.Euler(0,180,0), komabase);
        obj.GetComponent<Koma>().idf = 7; obj.GetComponent<Koma>().posX = 1; obj.GetComponent<Koma>().posY = 2; obj.GetComponent<Koma>().senko = false;
        
    }
}
