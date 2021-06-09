using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TouchObject : MonoBehaviour
{
    [SerializeField]
    UnityEvent touchEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TouchInfo info = AppUtil.GetTouch();
        // if(info == TouchInfo.Began){
        //     Debug.Log("test");
        //     touchEvent.Invoke();
        // }

        if (OnTouch() && StateManager.play)
        {
            Debug.Log("test");
            touchEvent.Invoke();
        }
        
    }
    bool OnTouch()
    {
        TouchInfo info = AppUtil.GetTouch();
        Vector3 pos = AppUtil.GetTouchPosition();
        // if (0 < Input.touchCount)
        if(info == TouchInfo.Began)
        {
            // Debug.Log("ontouch");
            //     Touch touch= Input.GetTouch(0);

            //     if (touch.phase == TouchPhase.Began)
            //     {
                    //タッチした位置からRayを飛ばす
                    Ray ray = Camera.main.ScreenPointToRay(pos);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject == this.gameObject)
                        {
                            return true;
                        }
                    }
                    
                // } 
        }
        return false; 
    }
}
