using System.Collections;
using UnityEngine;

namespace ReferenceAndEventDemo
{
    public class RefactoringEngine : MonoBehaviour
    {
        private EngineState _state = EngineState.Off;
        private EngineState state
        {
            set
            {
                if ( _state != value )
                {
                    _state = value;
                    this.Emit(new ChangedEngineEvent(_state));
                }
            }
        }

        public bool IsOff => _state == EngineState.Off;
        public bool IsOn => _state == EngineState.On;

        public void TurnOn()
        {
            if ( IsOff )
            {
                StartCoroutine(Checking());
            }
        }

        public void TurnOff()
        {
            if ( !IsOff )
            {
                StartCoroutine(Off());
            }
        }

        private IEnumerator Off()
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            state = EngineState.Off;
        }

        private IEnumerator Checking()
        {
            state = EngineState.Checking;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            state = Random.Range(0f, 1f) > 0.3f ? EngineState.On : EngineState.SomethingWrong;
        }
    }
}