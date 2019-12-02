using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPokemon : MonoBehaviour
{
    [SerializeField]
    private Transform _refPokemonSpawnLocation;

    //Change Variable from list to the pokemon class object
    private List<Vector2> pokemonLocations;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        
    }

    private IEnumerator GetPokeInfoDB()
    {
        yield return new WaitForSeconds(5);

        if (Input.location.status == LocationServiceStatus.Running)
        {
            //TODO: Get info from data base and add them into pokemonLocations variable
            foreach (Vector3 pokePos in pokemonLocations)
            {
                if (GPS.Instance.longitude == pokePos[0] && GPS.Instance.latitude == pokePos[1])
                {
                    //TODO: Spawn pokemon
                }
            }
        }

        yield return null;
    }
}
