﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Meteor : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1f;
    [SerializeField] private float _maxSpeed = 6f;
    [SerializeField] private float _torque = 3f;
    [SerializeField] private int _score;

    [Space][SerializeField] private AudioClip _destroySfx;

    private Rigidbody2D _body;
    private AudioSource _audio;
    private GameSession _gameSession;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _audio = FindObjectOfType<AudioSource>();
    }

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var projectile = other.gameObject.GetComponent<Projectile>();
        if(projectile != null)
        {
            _audio.PlayOneShot(_destroySfx);
            _gameSession.AddScore(_score);
        }
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
