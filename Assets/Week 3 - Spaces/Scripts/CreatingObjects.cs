using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingObjects : MonoBehaviour
{
    [SerializeField] public GameObject star;
    [SerializeField] public GameObject planet;

    //[SerializeField] 

    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            

            var positionStar = new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f));
            GameObject currentStar = Instantiate(star, positionStar, Quaternion.identity);

            //List < GameObject >> solarSystems = new List<GameObject>();
            //solarSystems.Add(currentStar);

            for (var j = 0; j < 3; j++)
            {
                var positionPlanet = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
                GameObject currentPlanet = Instantiate(planet, positionPlanet + currentStar.transform.position, Quaternion.identity, currentStar.transform);
                //solarSystems.Add(currentPlanet);
            }

            //List<List<GameObject>> galaxy = new List<List<GameObject>>(solarSystem[i]);
        }
        //foreach (GameObject solarsystem in solarSystems) {
        //    Debug.Log(solarsystem.name);
        //}
    }

    private void Update() {
        
    }

    //private void Orbiting() {
    //    foreach (GameObject solarsystem in solarSystems) {
    //        Debug.Log(solarsystem.name);
    //    }
    //}
}
