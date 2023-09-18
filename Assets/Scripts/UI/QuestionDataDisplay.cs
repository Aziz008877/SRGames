using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
public class QuestionDataDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private List<TextMeshProUGUI> _allQuestionTexts;
    [Inject] private QuestionContainer _questionContainer;
    private QuestionData _questionData;
    private int _correctID;
    private void Awake()
    {
        _questionContainer.OnQuestionDataSent += ReceiveQuestionData;
    }

    private void ReceiveQuestionData(QuestionData questionData)
    {
        _questionData = questionData;
        
        _questionText.text = _questionData.Question;

        _correctID = Random.Range(0, _allQuestionTexts.Count - 1);
        _allQuestionTexts[_correctID].text = _questionData.RightAnswer;

        List<TextMeshProUGUI> updatedList = new List<TextMeshProUGUI>(_allQuestionTexts);

        updatedList.Remove(_allQuestionTexts[_correctID]);

        for (int i = 0; i < updatedList.Count; i++)
        {
            _allQuestionTexts[i].text = _questionData.WrongAnswers[i];
        }
    }

    private void OnDestroy()
    {
        _questionContainer.OnQuestionDataSent -= ReceiveQuestionData;
    }
}
