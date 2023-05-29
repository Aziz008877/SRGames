using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Astronomy/Question")]
public class QuestionData : ScriptableObject
{
    [SerializeField] private string _question;
    public string Question => _question;
    
    [SerializeField] private string _rightAnswer;
    public string RightAnswer => _rightAnswer;
    
    [SerializeField] private List<string> _answerOptions;
    public List<string> AnswerOptions => _answerOptions;
}
