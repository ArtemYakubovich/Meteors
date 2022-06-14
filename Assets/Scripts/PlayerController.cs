using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _acceliration;

    public float RotationDirection { get; set; }
    public float Thrust { get; set; }
    public bool UseWeapon { get; set; }

    private Rigidbody2D _body;
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(RotationDirection != 0)
        {
            _body.angularVelocity = -RotationDirection * _rotationSpeed;
        }

        if(Thrust > 0)
        {
            Vector2 accelerationDelta = transform.up * _acceliration;
            _body.velocity += accelerationDelta;
        }
    }
}
