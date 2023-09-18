using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestionContainer : MonoBehaviour
{
    [SerializeField] private List<QuestionData> _allPlanetQuestions;
    private int _currentQuestionID;
    public event Action<QuestionData> OnQuestionDataSent;
    public event Action OnAllQuestionsEnded;

    private void SendCurrentQuestion()
    {
        OnQuestionDataSent?.Invoke(_allPlanetQuestions[_currentQuestionID]);
    }

    private void IncreaseQuestionID()
    {
        if (_currentQuestionID + 1 < _allPlanetQuestions.Count - 1)
        {
            _currentQuestionID++;
        }
        else
        {
            OnAllQuestionsEnded?.Invoke();
        }
    }
}
