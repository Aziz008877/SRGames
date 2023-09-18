using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Question", fileName = "New Question")]
public class QuestionData : ScriptableObject
{
    [SerializeField] private string _question;
    [SerializeField] private List<string> _wrongAnswers;
    [SerializeField] private string _rightAnswer;
    public string Question => _question;
    public List<string> WrongAnswers => _wrongAnswers;
    public string RightAnswer => _rightAnswer;
}
