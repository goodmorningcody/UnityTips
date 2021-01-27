using UnityEngine;

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

        private State state = State.Off;
    }
}