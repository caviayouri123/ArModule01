using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeScript : MonoBehaviour
{
    Vector2 startPos, endPos, dir; // touch start position, touch end position and swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to control throw force in Z direction

    [SerializeField]
    float throwForceInXandY = 1f; // to control throw force in X and Y directions

    [SerializeField]
    float throwForceInZ = 50f; // to control throw in Z directions

    Rigidbody rb;

    public GameObject snorlax;

    private PokemonClick refference;

    void Start()
    {
        refference = GameObject.FindWithTag("Pokemon").GetComponent<PokemonClick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if you touch the screen
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && refference.arCamActivated == true)
        {
            // getting touch position and marking time when you touch the screen
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        // if you release your finger 
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && refference.arCamActivated == true)
        {
            // marking time when you release it
            touchTimeFinish = Time.time;
            
            // calculate swimpe time interval
            timeInterval = touchTimeFinish - touchTimeStart;

            // getting release finger position
            endPos = Input.GetTouch(0).position;

            // calculating swipe direction in 2D pace
            dir = startPos - endPos;

            // add force to balls rigidbidy in 3D space depending on swipe time, direction and throw forces
            rb.isKinematic = false;
            rb.AddForce (-dir.x * throwForceInXandY, -dir.y * throwForceInXandY, throwForceInZ / timeInterval);

            // destroy ball in 4 seconds
            //Destroy(gameObject, 3f);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("snorlax"))
        {
            Destroy(snorlax);
        }
    }
}
