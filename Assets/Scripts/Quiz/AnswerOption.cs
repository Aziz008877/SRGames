using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _answerText;
    [SerializeField] private Button _optionButton;
    public event Action<string> OnObjectClicked;
    private void Start()
    {
        _optionButton.onClick.AddListener(delegate
        {
            OnObjectClicked?.Invoke(_answerText.text);
        });
    }

    private void OnDestroy()
    {
        _optionButton.onClick.RemoveAllListeners();
    }
}
