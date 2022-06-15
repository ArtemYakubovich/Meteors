using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    void Update()
    {
        _player.RotationDirection = Input.GetAxis("Horizontal");
        _player.Thrust = Input.GetAxis("Vertical");

        _player.UseWeapon = Input.GetButton("Fire1");
    }
}
