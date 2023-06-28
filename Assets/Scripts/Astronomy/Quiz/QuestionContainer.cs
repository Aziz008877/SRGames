using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionContainer : MonoBehaviour
{
    [SerializeField] private List<QuestionData> _allQuestions;
    [SerializeField] private UnityEvent<QuestionData> _onQuestionSent;
    [SerializeField] private UnityEvent _onQuizPassed;
    private int _currentQuestionID = 0;

    private void Start()
    {
        SendNewQuestion();
    }

    private void SendNewQuestion()
    {
        _onQuestionSent?.Invoke(_allQuestions[_currentQuestionID]);
    }

    public void TryIncreaseQuestionData()
    {
        if (_currentQuestionID < _allQuestions.Count - 1)
        {
            _currentQuestionID++;
            SendNewQuestion();
        }
        else
        {
            _onQuizPassed?.Invoke();
        }
    }
}
