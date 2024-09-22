using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonsInstantiate : MonoBehaviour
{
    [SerializeField]
    List<Material> MaterialsList;
    [SerializeField]
    private float radius, heightPos, timeSwapper;
    [SerializeField]
    private int angle; //Angle to balloons appear
    private float startTime;
    public Transform BallonsParnent;
    public Transform PlayerObj;
    public GameObject BalloonPrefab;
    public Vector3 spawnPos;
    private Vector3 ballonPos;
    private float ang;


    void Start()
    {
        startTime = Time.time;
        ang = Random.value * angle;
        StartCoroutine(createBallon());
    }

    private IEnumerator createBallon()
    {
        Vector3 center = PlayerObj.transform.position;
        while (true)
        {
            spawnPos = RandomCircle(center, radius);
            GameObject New_Ballon_obj = Instantiate(BalloonPrefab, spawnPos, Quaternion.identity);
            New_Ballon_obj.transform.GetChild(0).GetComponent<MeshRenderer>().material = getRandomMaterial();
            New_Ballon_obj.transform.SetParent(BallonsParnent);
            yield return new WaitForSeconds(timeSwapper - ((Time.time - startTime) / 60));
        }

    }


    Vector3 RandomCircle(Vector3 center, float radius)
    {
        ang = Random.value * angle;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = heightPos;
        pos.z = center.z + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        return pos;
    }

    private Material getRandomMaterial()
    {

        //Random Material TIME
        if (MaterialsList != null && MaterialsList.Count > 0)
            return MaterialsList[Random.Range(0, MaterialsList.Count)];

        return null;

    }

    
}