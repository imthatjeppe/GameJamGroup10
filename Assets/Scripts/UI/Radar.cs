using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject[] Trackedobjects;
    List<GameObject> RadarObjects;
    public GameObject Radarprefab;
    List<GameObject> BorderObjects;
    public float Switchdistance;
    public Transform HelpTransform;

    void Start()
    {
        CreateRadarObjects();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < RadarObjects.Count; i++)
        {
            if (Vector3.Distance(RadarObjects[i].transform.position,transform.position) > Switchdistance)
            {
                HelpTransform.LookAt(RadarObjects[i].transform);
                BorderObjects[i].transform.position = transform.position + Switchdistance * HelpTransform.forward;
                BorderObjects[i].layer = LayerMask.NameToLayer("RadarCamera");
                BorderObjects[i].layer = LayerMask.NameToLayer("Invisible");
            }
            else
            {
                BorderObjects[i].layer = LayerMask.NameToLayer("Invisible");
                BorderObjects[i].layer = LayerMask.NameToLayer("RadarCamera");
            }
        
        }
    }

    void CreateRadarObjects()
    {
        RadarObjects = new List<GameObject>();
        BorderObjects = new List<GameObject>();
        foreach (GameObject o in Trackedobjects)
        {
            GameObject k = Instantiate(Radarprefab, o.transform.position, Quaternion.identity) as GameObject;
            RadarObjects.Add(k);
            GameObject j = Instantiate(Radarprefab, o.transform.position, Quaternion.identity) as GameObject;
            RadarObjects.Add(j);
        }
    }


}
