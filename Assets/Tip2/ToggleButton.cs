using UnityEngine;
using UnityEngine.UI;

namespace ReferenceAndEventDemo
{
    public class ToggleButton : MonoBehaviour
    {
        public enum ToggleCommand { EngineOn, EngineOff, EngineReset }
        private ToggleCommand toggleCommand = ToggleCommand.EngineOn;
        [SerializeField] private Text text = null;

        private Airplane airplane;

        private void Start()
        {
            airplane = GetComponentInParent<Airplane>();
            airplane.OnDetectEngineFlawEvent += HandleDetectEngineFlawEvent;
            airplane.OnEnginesReadyEvent += HandleEngineReadyEvent;
            airplane.OnEnginesOffEvent += HandleEnginesOff;
        }

        public void ToggleButtonEvent()
        {
            switch (toggleCommand)
            {
                case ToggleCommand.EngineOn:
                    airplane.StartEngineCheck();
                    break;

                case ToggleCommand.EngineOff:
                    airplane.TurnOffEngines();
                    break;

                case ToggleCommand.EngineReset:
                    airplane.ResetEngines();
                    break;
            }

        }

        private void HandleDetectEngineFlawEvent()
        {
            SwitchToggleCommand(ToggleCommand.EngineReset);

        }

        private void HandleEngineReadyEvent()
        {
            SwitchToggleCommand(ToggleCommand.EngineOff);
        }

        private void HandleEnginesOff()
        {
            SwitchToggleCommand(ToggleCommand.EngineOn);
        }

        public void SwitchToggleCommand(ToggleCommand command)
        {
            toggleCommand = command;

            switch (toggleCommand)
            {
                case ToggleCommand.EngineOn:
                    text.text = "엔진 ON";
                    break;

                case ToggleCommand.EngineOff:
                    text.text = "엔진 OFF";
                    break;

                case ToggleCommand.EngineReset:
                    text.text = "엔진 RESET";
                    break;
                default:
                    text.text = "";
                    break;
            }
        }





    }

}
