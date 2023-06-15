using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballManager : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject oldBallPos;

    [SerializeField]
    GameObject button;

    [SerializeField]
    GameObject backButton;

    public bool cannotDoAgain = true;

    //public Camera cam;

    private PokemonClick refference;

    // Start is called before the first frame update
    private void Start()
    {
        refference = GameObject.FindWithTag("Pokemon").GetComponent<PokemonClick>();
        button.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (refference.arCamActivated == true && cannotDoAgain == true)
        {
            button.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            cannotDoAgain = false;
        }
    }
    public void Spawn()
    {
        Instantiate(ball, oldBallPos.transform.position, oldBallPos.transform.rotation);
    }
    public void Back()
    {
        SceneManager.LoadScene("Game");
    }
}
