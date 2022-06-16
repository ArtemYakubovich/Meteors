using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int _life;
    [SerializeField] private int _score;

    public int Life => _life;
    public int Score => _score;

    public event Action<int> OnScoreChaged;
    public event Action<int> OnLifeChanged;

    public void AddScore(int score)
    {
        _score += score;
        OnScoreChaged?.Invoke(_score);
    }

    public void ChangeLife(int delta)
    {
        _life += delta;
        OnLifeChanged?.Invoke(_life);
    }
}
