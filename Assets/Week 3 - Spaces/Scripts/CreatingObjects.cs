using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingObjects : MonoBehaviour
{
    [SerializeField] public GameObject star;
    [SerializeField] public GameObject planet;

    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            var positionStar = new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f));
            GameObject currentStar = Instantiate(star, positionStar, Quaternion.identity);
            
            for (var j = 0; j < 3; j++)
            {
                var positionPlanet = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
                Instantiate(planet, positionPlanet + currentStar.transform.position, Quaternion.identity, currentStar.transform);
            }
        }
    }
}
