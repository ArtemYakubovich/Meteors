using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _acceliration;
    [SerializeField] private Projectile _laserWeapon;
    [SerializeField] private Cooldown _laserCooldown;

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

    private void Update()
    {
        if (UseWeapon && _laserCooldown.IsReady)
        {
            ShootWithLaser();
        }
    }

    private void ShootWithLaser()
    {
        var progectile = Instantiate(_laserWeapon, transform.position, transform.rotation);
        progectile.Lunch(_body.velocity, transform.up);
        _laserCooldown.Reset();
    }
}
