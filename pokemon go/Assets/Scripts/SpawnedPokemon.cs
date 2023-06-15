using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedPokemon : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject pokemon;
    void Start()
    {
        obj = Instantiate(pokemon, obj.transform.position, obj.transform.rotation);
    }

    void Update()
    {
        
    }
}
