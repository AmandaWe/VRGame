using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicatorController : MonoBehaviour
{
    private ARRaycastManager raycastManager;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitsList = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitsList, TrackableType.Planes);
        
        if (hitsList.Count > 0) {
            transform.position = hitsList[0].pose.position;
            transform.rotation = hitsList[0].pose.rotation;

            if (!gameObject.activeInHierarchy) {
                gameObject.SetActive(true);
            }
        }
    }
}
