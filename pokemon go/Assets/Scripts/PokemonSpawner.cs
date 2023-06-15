using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSpawner : MonoBehaviour
{
    public GameObject[] pokemonPrefab; // Reference to the Pokémon prefab to spawn

    private void Start()
    {
        // Example usage: spawn Pokémon at specific latitude and longitude
        SpawnPokemonAtLocation(51.7365f, 5.328244f);
    }

    // Spawn Pokémon at a given latitude and longitude
    public void SpawnPokemonAtLocation(float latitude, float longitude)
    {
        // Convert latitude and longitude to Unity coordinates
        Vector2 unityCoords = ConvertToUnityCoordinates(latitude, longitude);

        // Instantiate the Pokémon prefab at the converted coordinates
        Instantiate(pokemonPrefab[Random.Range(0, 3)], new Vector3(unityCoords.x, 0f, unityCoords.y), Quaternion.identity);
    } 

    // Convert latitude and longitude to Unity coordinates (simplified conversion)
    private Vector2 ConvertToUnityCoordinates(float latitude, float longitude)
    {
        // Treat latitude as Y coordinate and longitude as X coordinate
        // Adjust scale or apply more accurate conversions based on your specific needs
        return new Vector2(longitude, latitude);
    }
}
