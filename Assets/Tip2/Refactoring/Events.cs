namespace ReferenceAndEventDemo
{
    public struct TurnOnEvent : Event
    {
    }

    public struct TurnOffEvent : Event
    {
    }

    public struct ResetEvent : Event
    {
    }

    public struct ChangedEngineEvent : Event
    {
        public EngineState EngineState { get; private set; }

        bool HasError => EngineState == EngineState.SomethingWrong;
        
        public ChangedEngineEvent(EngineState engineState)
        {
            EngineState = engineState;
        }
    }
}