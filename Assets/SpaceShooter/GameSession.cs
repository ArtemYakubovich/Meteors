using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int _life;
    [SerializeField] private int _score;

    public int Life => _life;
    public int Score => _score;

    public void AddScore(int score)
    {
        _score += score;
    }

    public void ChangeLife(int delta)
    {
        _life += delta;
    }
}
