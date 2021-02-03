using UnityEngine;
using System;
using System.Collections;

namespace ReferenceAndEventDemo
{
    public class Engine : MonoBehaviour
    {
        public enum State
        {
            Off,
            Checking,
            On,
            SomethingWrong,
        }
        private Airplane airplane;


        [SerializeField]
        private State state = State.Off;
        public event Action<Engine, Engine.State> OnEngineCheck;
        public event Action<Engine, Engine.State> OnEngineOff;

        private void Start()
        {
            airplane = GetComponentInParent<Airplane>();
            airplane.OnDetectEngineFlawEvent += HandleDetectEngineFlawEvent;
        }

        IEnumerator detectCoroutine = null;
        public void CheckEngine()
        {
            state = State.Checking;

            detectCoroutine = DetectEngineFlaw();
            StartCoroutine(DetectEngineFlaw());
        }

        IEnumerator DetectEngineFlaw()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 3.0f));

            state = CheckState();

            if (state == State.SomethingWrong)
            {
                OnEngineCheck?.Invoke(this, state);
            }
            else
            {
                OnEngineCheck?.Invoke(this, state);
            }

            detectCoroutine = null;
        }

        private State CheckState()
        {
            float random = UnityEngine.Random.Range(0.0f, 1.0f);
            if (random < 0.3f)
            {
                return State.SomethingWrong;
            }
            else
            {
                return State.On;
            }
        }

        public void TurnOffEngine()
        {
            StartCoroutine(StopEngine());
        }

        public IEnumerator StopEngine()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 3.0f));

            state = State.Off;
            OnEngineOff?.Invoke(this, state);
        }

        private void HandleDetectEngineFlawEvent()
        {
            //keep coroutine is kept runnig, stop and make it null 
            if (detectCoroutine != null)
            {
                StopCoroutine(detectCoroutine);
                detectCoroutine = null;
            }

            if (state == State.On || state == State.Checking)
            {
                state = State.Off;
            }
        }
    }


}