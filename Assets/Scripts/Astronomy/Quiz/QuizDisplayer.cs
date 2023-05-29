using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuizDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private List<Button> _answerOptions;
    [SerializeField] private UnityEvent _onAnsweredCorrect;
    [SerializeField] private UnityEvent _onAnsweredWrong;
    private QuestionData _currentQuestion = null;

    private void Start()
    {
        foreach (var button in _answerOptions)
        {
            button.onClick.AddListener(delegate
            {
                if (GetComponentInChildren<TextMeshProUGUI>().text == _currentQuestion.RightAnswer)
                {
                    _onAnsweredCorrect?.Invoke();
                }
                else
                {
                    _onAnsweredWrong?.Invoke();
                }
            });
        }
    }

    public void ReceiveQuestionData(QuestionData questionData)
    {
        _currentQuestion = questionData;
        
        _questionText.text = _currentQuestion.Question;
        
        for (int i = 0; i < _answerOptions.Count; i++)
        {
            _answerOptions[i].GetComponentInChildren<TextMeshProUGUI>().text = _currentQuestion.AnswerOptions[i];
        }
    }
}
