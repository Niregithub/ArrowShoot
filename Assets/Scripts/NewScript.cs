using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    GameObject arrow;
    public GameObject arrowprefab;
    Vector3 Rightfp;
    Vector3 Leftfp;

    Vector3 Rightlp;
    Vector3 Leftlp;
    // Start is called before the first frame update
    public Text txt;

    Rigidbody2D rb;
    float speed = 500f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.

                    Vector3 v = touch.position;
                    Rightfp = Camera.main.ScreenToWorldPoint(v);
                    Leftfp = Camera.main.ScreenToWorldPoint(v);
                    txt.text = ""+ Rightfp;
                    arrow = Instantiate(arrowprefab, new Vector3(Rightfp.x, Rightfp.y, -2), Quaternion.identity);
                    rb = arrow.GetComponent<Rigidbody2D>();
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    Vector3 v1 = touch.position;
                    Rightlp = Camera.main.ScreenToWorldPoint(v1);
                    Leftlp = Camera.main.ScreenToWorldPoint(v1);
                    Destroy(arrow, 3);
                    txt.text = "End";

                    break;
            }
        }

        if (Rightlp.x < Rightfp.x)
        {
            txt.text = "Right to left";
            rb.velocity = new Vector2(-speed*Time.deltaTime, 0);
            //gameObject.transform.position = new Vector2(fireballXValue, gameObject.transform.position.y);

        }
        if (Leftfp.x < Leftlp.x)
        {
            txt.text = "Right to left";
            rb.velocity = new Vector2(speed * Time.deltaTime,0);
            //gameObject.transform.position = new Vector2(fireballXValue, gameObject.transform.position.y);

        }
        /*
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            txt.text = "first";
            if(touch.phase == TouchPhase.Began)
            {
                txt.text = "began";

                Rightfp = touch.position;
                arrow = Instantiate(arrowprefab, new Vector3(Rightfp.x,Rightfp.y,-1), Quaternion.identity);
            }
            if(touch.phase == TouchPhase.Ended)
            {
               // txt.text = "end";

                Rightlp = touch.position;
            }

        }
        */
    }
}
