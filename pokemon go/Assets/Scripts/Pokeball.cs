using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    [SerializeField]
    private float throwSpeed;
    private float speed;
    private float lastMouseX, lastMouseY;

    private bool thrown, holding;

    private Rigidbody rb;
    private Vector3 newPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Reset();
    }

    void Update()
    {
        if (holding)
            OnTouch();
        if (thrown)
            return;
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f))
            {
                if(hit.transform == transform)
                {
                    holding = true;
                    transform.SetParent(null);
                }
            }
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if(lastMouseY < Input.GetTouch(0).position.y)
            {
                ThrowhBall(Input.GetTouch(0).position);
            }
        }
        if (Input.touchCount == 1)
        {
            lastMouseX = Input.GetTouch(0).position.x;
            lastMouseY = Input.GetTouch(0).position.y;
        }
    }
    /*private void Reset()
    {
        CancelInvoke();
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, Camera.main.nearClipPlane * 7.5f));
        newPos = transform.position;
        thrown = holding = false;

        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 200, 0);
        transform.SetParent(Camera.main.transform);
    }*/
    void OnTouch()
    {
        Vector3 mousePos = Input.GetTouch(0).position;
        mousePos.z = Camera.main.nearClipPlane = 7f;

        newPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, 50f * Time.deltaTime);
    }
    void ThrowhBall(Vector3 mousePos)
    {
        rb.useGravity = true;

        float differenceY = (mousePos.y - lastMouseY) / Screen.height * 100f;
        speed = throwSpeed * differenceY;

        float x = (mousePos.x / Screen.width) - (lastMouseX / Screen.width);
        x = Mathf.Abs(Input.GetTouch(0).position.x - lastMouseX) / Screen.width * 100f * x;

        Vector3 dir = new Vector3(x, 0f, 1f);
        dir = Camera.main.transform.TransformDirection(dir);

        rb.AddForce((dir * speed / 2f) + (Vector3.up * speed));

        holding = false;
        thrown = true;

        //Invoke("Reset", 5.0f);
    }
}
