using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Numerics;

public class UserInterface : MonoBehaviour {
    
    //Screen
    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI planetDetails;
    public Camera cam;

    //Description
    private string objName;
    private string description;

    private void Start() {
        if (panel != null) {
            planetDetails = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();        //Finding the textbox
        }
    }

    //Performing a ray cast
    void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.CompareTag("Planet")) {                           //Only interacting with planets
                PlanetDetails(hit.transform.name);
                planetDetails.text = "Planet Name: " + objName + "\nDescription:" + description;
            }
            else if (hit.transform.CompareTag("Star")) {                           //Only interacting with stars
                planetDetails.text = "Star Name: " + hit.transform.name;
            }
        }
        else {
            planetDetails.text = "";
        }
    }
    //Details of planets
    private void PlanetDetails(string planet) {
        switch (planet) {
            case "Earth":
                objName = "Earth";
                description = "Place where humans live";
                break;
            case "Mars":
                objName = "Mars";
                description = "Place where aliens live";
                break;

            //Add more cases for all planets and more details on planets
            default:
                objName = "";
                description = "";
                break;
        }
    }
}
