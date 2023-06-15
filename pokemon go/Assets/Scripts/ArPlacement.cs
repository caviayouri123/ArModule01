using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    private GameObject spawnedObject;
    private Pose PlacementPos;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseValid = false;
    private void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    //Need to update the placement Indicator, placement pose and spawn
    private void Update()
    {
        if (spawnedObject == null && placementPoseValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ArPlacedObjects();
        }

        UpdatePlacementPos();
        UpdatePlacementIndicator();
    }
    private void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPos.position, PlacementPos.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    private void UpdatePlacementPos()
    {
        var ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(ScreenCenter, hits, TrackableType.Planes);

        placementPoseValid = hits.Count > 0;
        if (placementPoseValid)
        {
            PlacementPos = hits[0].pose;
        }
    }
    private void ArPlacedObjects()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPos.position, PlacementPos.rotation);
    }
}
