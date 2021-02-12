using ReferenceAndEventDemo;

namespace Hunting
{   
    public struct LaidEggsEvent : Event
    {
        public int EggsCount { get; private set; }
        public LaidEggsEvent(int eggsCount)
        {
            EggsCount = eggsCount;
        }
    }

    public struct IncubatedEggsEvent : Event
    {
        public int EggsCount { get; private set; }
        public IncubatedEggsEvent(int eggsCount)
        {
            EggsCount = eggsCount;
        }
    }
}