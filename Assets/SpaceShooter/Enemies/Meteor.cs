using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Meteor : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1f;
    [SerializeField] private float _maxSpeed = 6f;
    [SerializeField] private float _torque = 3f;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    public void Launch()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        _body.velocity = randomDirection * Random.Range(_minSpeed, _maxSpeed);
        float randomTorque = Random.Range(-_torque, _torque);
        _body.AddTorque(randomTorque);
    }
}
