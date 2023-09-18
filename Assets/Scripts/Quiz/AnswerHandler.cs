using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class AnswerHandler : MonoBehaviour
{
    [SerializeField] private List<AnswerOption> _answerOptions;
    [Inject] private QuestionContainer _questionContainer;
    private string _correctAnswer;
    public event Action<bool> OnPlayerAnsweredState; 
    private void Awake()
    {
        _questionContainer.OnQuestionDataSent += ReceiveCorrectAnswer;

        foreach (var option in _answerOptions)
        {
            option.OnObjectClicked += CheckClickedAnswer;
        }
    }

    private void CheckClickedAnswer(string clickedAnswerText)
    {
        OnPlayerAnsweredState?.Invoke(_correctAnswer == clickedAnswerText);
    }

    private void ReceiveCorrectAnswer(QuestionData questionData)
    {
        _correctAnswer = questionData.RightAnswer;
    }

    private void OnDestroy()
    {
        _questionContainer.OnQuestionDataSent -= ReceiveCorrectAnswer;
        
        foreach (var option in _answerOptions)
        {
            option.OnObjectClicked -= CheckClickedAnswer;
        }
    }
}
