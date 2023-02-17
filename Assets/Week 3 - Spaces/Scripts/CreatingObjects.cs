using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingObjects : MonoBehaviour
{
    [SerializeField] public GameObject star;
    //[SerializeField] public GameObject planet;
    public GameObject currentStar;
    //public GameObject currentPlanet;

    [SerializeField] public GameObject[] array;
    [SerializeField] public string[] starNames;



    void Start()
    {
        Creation();
        //Orbiting();
    }

    private void Update() 
    {
        
    }

    private void Creation()
    {
        array = new GameObject[10];

        for (var i = 0; i < 10; i++)
        {
            var positionStar = new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f));
            array[i] = Instantiate(star, positionStar, Quaternion.identity);
            array[i].transform.tag = "Star";
            array[i].transform.name = starNames[Random.Range(0, starNames.Length)] + " " + i;


            //for (var j = 0; j < 3; j++)
            //{
            //    var positionPlanet = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
            //    currentPlanet = Instantiate(planet, positionPlanet + currentStar.transform.position, Quaternion.identity, currentStar.transform);

            //    array[i, j] = currentPlanet;
            //}
        }
    }

    //private void Orbiting() 
    //{
    //    foreach(var item in array)
    //    {
    //        Debug.Log(item.ToString());
    //    }
    //}
}
