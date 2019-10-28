using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0)&&GameManager.instance._startedGame)
        {
            if (_direction == Quaternion.AngleAxis(-26.57f, Vector3.forward) * Vector3.left)
            {
                _direction = Quaternion.AngleAxis(26.57f, Vector3.forward) * Vector3.right;
            }
            else
            {
                _direction = Quaternion.AngleAxis(-26.57f, Vector3.forward) * Vector3.left;
            }
        }

        if (!GameManager.instance._startedGame)
        {
            if (Camera.main.WorldToViewportPoint(this.transform.position).y < 0)
            {
                _direction = Vector3.zero;
                Destroy(this.transform.gameObject);
            }
        }

        Vector3 deltaPos = _speed * Time.fixedDeltaTime * _direction;
        this.transform.position += deltaPos;
        Camera.main.transform.position += deltaPos;
    }
}
