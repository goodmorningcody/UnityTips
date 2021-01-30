using UnityEngine;
using UnityEngine.UI;

namespace ReferenceAndEventDemo
{
    public class Cockpit : MonoBehaviour
    {
        [SerializeField] private Button toggleButton = null;
        [SerializeField] private Text stateText = null;

        private Airplane airplane;

        private void Start()
        {
            airplane = GetComponentInParent<Airplane>();
            airplane.OnDetectEngineFlawEvent += HandleDetectEngineFlawEvent;
            airplane.OnEnginesReadyEvent += HandleEnginesReadyEvent;
            airplane.OnEnginesOffEvent += HandleEnginesOffEvent;
        }
        private void HandleDetectEngineFlawEvent()
        {
            ChangeStateText("엔진 ERROR");
        }

        private void HandleEnginesReadyEvent()
        {
            ChangeStateText("엔진 ON");
        }

        private void HandleEnginesOffEvent()
        {
            ChangeStateText("엔진 OFF");
        }

        public void ChangeStateText(string _state)
        {
            stateText.text = _state;
        }
    }
}
