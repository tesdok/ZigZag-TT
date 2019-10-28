using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenRoad : MonoBehaviour
{
    public GameObject roadTile;
    public GameObject crystal;

    Vector3 lastPos;
    float width;

    private void Awake()
    {
        lastPos = roadTile.transform.position;
        width = roadTile.transform.localScale.x;
    }
     
    public void GenerationRoad()
    {
        int rnd = Random.Range(0, 4);
        if(rnd<2)
        {
            GenUp();
        }
        else
        {
            GenRight();
        }
    }

    void GenUp()
    {
        lastPos.x -= width;
        lastPos.y += 0.5f;
        lastPos.z += 0.001f;
        Instantiate(roadTile, lastPos, roadTile.transform.rotation);
        int rnd = Random.Range(0, 100);
        if (rnd < 20)
        {
            Instantiate(crystal, lastPos - new Vector3(0, 0, 0.001f), crystal.transform.rotation);
        }
    }

    void GenRight()
    {
        lastPos.x += width;
        lastPos.y += 0.5f;
        lastPos.z += 0.001f;
        Instantiate(roadTile, lastPos, roadTile.transform.rotation);
        int rnd = Random.Range(0, 100);
        if (rnd < 20)
        {
            Instantiate(crystal, lastPos - new Vector3(0, 0, 0.001f), crystal.transform.rotation);
        }
    }
}
