using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    private Rigidbody2D _rigidbody;    

    List<Collider2D> _allCollisions = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (!this._allCollisions.Contains(collider2D) && !collider2D.CompareTag("Crystal"))
        {
            this._allCollisions.Add(collider2D);
        }
        else
        {
            Destroy(collider2D.gameObject);
            GameManager.instance.addScore();
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (this._allCollisions.Contains(collider2D))
        {
            this._allCollisions.Remove(collider2D);
            collider2D.gameObject.AddComponent<DestroyRoad>();
        }       
    }

    void FixedUpdate()
    {
        if (this._allCollisions.Count == 0 && GameManager.instance._startedGame)
        {
            _rigidbody.gravityScale = 3.0f;
            GameManager.instance.gameOver();                 
        }
    }
}
