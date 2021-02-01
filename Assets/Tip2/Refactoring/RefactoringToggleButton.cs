using System;
using UnityEngine;
using UnityEngine.UI;

namespace ReferenceAndEventDemo
{
    [RequireComponent(typeof(Button))]
    public class RefactoringToggleButton : MonoBehaviour
    {
        [SerializeField] private Text title = null;
        private Button button = null;

        void Awake()
        {
            button = GetComponent<Button>();
        }

        public void Disable()
        {
            button.interactable = false;
        }

        public void SetListener(Action onClicked)
        {
            button.interactable = true;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClicked());
        }

        public void SetText(string text)
        {
            title.text = text;
        }
    }
}