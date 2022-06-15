using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private AudioClip _shootSfx;

    private Rigidbody2D _body;
    private AudioSource _audio;
    

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _audio = FindObjectOfType<AudioSource>();

        Destroy(gameObject, 4f);
    }

    public void Lunch(Vector2 velocity, Vector2 direction)
    {
        _body.velocity = velocity + direction * _speed;
        _audio.PlayOneShot(_shootSfx);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}