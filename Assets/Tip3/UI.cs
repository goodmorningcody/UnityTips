using System;
using UnityEngine;
using UnityEngine.UI;

namespace OOPWithInterface
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private AquariumUI aquariumUI = null;
        [SerializeField] private Button snatchButton = null;

        public void StartSnatchListener(Action onSnatch)
        {
            snatchButton.onClick.RemoveAllListeners();
            snatchButton.onClick.AddListener(() => onSnatch());
        }

        public void Refresh()
        {
            aquariumUI.Refresh();
        }
    }
}