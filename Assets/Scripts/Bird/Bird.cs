using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private AudioSource _pointSound;

    private int _score = 0;

    public event UnityAction BirdDied;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        ScoreChanged?.Invoke(_score);
    }

    public void AddScore()
    {
        _score++;
        _pointSound.Play();

        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        _dieSound.Play();

        BirdDied?.Invoke();
    }
}
