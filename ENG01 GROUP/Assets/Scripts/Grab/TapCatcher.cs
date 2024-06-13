using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCatcher : MonoBehaviour
{
    //ITS A SINGLETON
    public static TapCatcher instance { get; private set; }
    Rigidbody body;



    Vector2 tap = Vector2.zero;
    Vector3 clickPos = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
    }

    

    bool CheckHit(Vector2 tap)
    {
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(tap);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hitObject = hit.collider.gameObject;
           
            Debug.Log("Hit");

            
            

            if(hitObject == this.gameObject) {
                return true;
            }
           
            // Actual movement
            
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            tap = Input.mousePosition;
            if (CheckHit(tap))
            {
                body.useGravity = false;
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
            }
            else // this is here because i found a...bug? glitch? that when snapping out of the box it keeps floating
            {
                body.useGravity = true;
            }//use gravity is here because if you hold up a cube for long enough, IT SLAMS ITSELF DOWN. Basically fallSpeed = TIME *SPEED;

        }
        else //this is here because the body.useGravity is inside the getmousebutton, it can still be floating so redudancy is needed.
        {
            body.useGravity = true;
        }

    }
}
