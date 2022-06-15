using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 4f);
    }

    public void Lunch(Vector2 velocity, Vector2 direction)
    {
        _body.velocity = velocity + direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}