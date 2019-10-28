using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    Vector3 _initPosition;

    [SerializeField]
    private float _speed = 7;

    // Start is called before the first frame update
    void Start()
    {
        _initPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * this._speed;
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}