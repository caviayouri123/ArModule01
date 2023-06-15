using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PokemonClick : MonoBehaviour
{
    public bool arCamActivated = false;
    private void Update()
    {
        // Check if the player has tapped on the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if the touch hit an object
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the one you want to interact with
                if (hit.collider.gameObject == gameObject)
                {
                    // Call the function to handle the object click
                    HandleObjectClick();
                }
            }
        }
    }

    private void HandleObjectClick()
    {
        // Code to perform the desired action when the object is clicked
        arCamActivated = true;
    }
}
