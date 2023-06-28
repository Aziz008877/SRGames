using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _rightAnsweredCount = 0;

    public void IncreaseScore()
    {
        _rightAnsweredCount++;
    }
}
