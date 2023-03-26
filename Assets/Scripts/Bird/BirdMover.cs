using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private AudioSource _wingSound;
 
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = new Vector2(_speed, 0);

            transform.rotation = _maxRotation;

            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            _wingSound.Play();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speedRotation * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}
