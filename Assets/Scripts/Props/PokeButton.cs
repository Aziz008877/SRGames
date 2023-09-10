using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class PokeButton : MonoBehaviour
{
   [SerializeField] private XRSimpleInteractable _interactable;
   private bool _canPress = true;
   public event Action OnButtonPressed;
   private void Start()
   {
      _interactable.selectEntered.AddListener(x => ButtonPressed());
   }

   private void ButtonPressed()
   {
      if (_canPress)
      {
         OnButtonPressed?.Invoke();
      }
   }

   private void OnDestroy()
   {
      _interactable.selectEntered.RemoveAllListeners();
   }
}
