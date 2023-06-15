using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PokemonARDisplay : MonoBehaviour
{
    public GameObject pokemonPrefab; // Reference to the Pokemon model prefab
    private ARRaycastManager raycastManager;

    void Awake()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Pokemon"))
                {
                    // Display the Pokemon in AR
                    Instantiate(pokemonPrefab, hit.transform.position, hit.transform.rotation);
                }
            }
        }
    }
}