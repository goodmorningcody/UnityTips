using UnityEngine;
using UnityEngine.UI;

namespace ReferenceAndEventDemo
{
    public class RefactoringCockpit : MonoBehaviour
    {
        [SerializeField] private RefactoringToggleButton toggleButton = null;
        [SerializeField] private Text stateText = null;

        void Start()
        {
            toggleButton.SetListener(() => this.Emit(new TurnOnEvent()));
        }

        public void Checking()
        {
            toggleButton.Disable();
            stateText.text = "엔진 CHECKING";
        }

        public void TurnedOff()
        {
            toggleButton.SetListener(() => this.Emit(new TurnOnEvent()));
            toggleButton.SetText("엔진 ON");
            stateText.text = "";
        }

        public void TurnedOn()
        {
            toggleButton.SetListener(() => this.Emit(new TurnOffEvent()));
            toggleButton.SetText("엔진 OFF");
            stateText.text = "엔진 ON";
        }

        public void OccurredError()
        {
            toggleButton.SetListener(() => this.Emit(new ResetEvent()));
            toggleButton.SetText("엔진 RESET");
            stateText.text = "엔진 ERROR";
        }
    }
}
