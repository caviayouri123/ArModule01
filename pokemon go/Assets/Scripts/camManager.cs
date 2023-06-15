using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camManager : MonoBehaviour
{
    public Camera arCam;
    public GameObject ground;
    public GameObject pokemon;
    public bool cannotDoAgain = true;

    public GameObject ballPrefab;               // Prefab of the ball to be thrown
    public Transform throwStartPosition;        // The position from where the ball is thrown
    public float throwForce = 10f;              // The force applied to the thrown ball

    private PokemonClick refference;
    
    // Start is called before the first frame update
    void Start()
    {
        refference = GameObject.FindWithTag("Pokemon").GetComponent<PokemonClick>();
        arCam.gameObject.SetActive(false);
        ground.gameObject.SetActive(false);
        pokemon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(refference.arCamActivated == true && cannotDoAgain == true)
        {
            arCam.gameObject.SetActive(true);
            ground.gameObject.SetActive(true);
            pokemon.gameObject.SetActive(true);
            cannotDoAgain = false;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ThrowBall();
            }
        }

    }
    private void ThrowBall()
    {
        // Instantiate the ball
        GameObject ball = Instantiate(ballPrefab, throwStartPosition.position, Quaternion.identity);

        // Apply force to the ball in the forward direction
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(throwStartPosition.forward * throwForce, ForceMode.Impulse);
    }
}
