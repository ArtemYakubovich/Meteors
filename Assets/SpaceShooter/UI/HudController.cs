using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Text _lifeText;
    [SerializeField] private Text _scoreText;

    private void Start()
    {
        var session = FindObjectOfType<GameSession>();

        session.OnScoreChaged += ScoreChangedHandler;
        session.OnLifeChanged += LifeChangedHandler;

        LifeChangedHandler(session.Life);
        ScoreChangedHandler(session.Score);
    }

    public void ScoreChangedHandler(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void LifeChangedHandler(int life)
    {
        _lifeText.text = $"x{life}";
    }
}
