using UnityEngine;
using ReferenceAndEventDemo;

namespace Hunting
{
    public class Duck : MonoBehaviour, MonoEventListener
    {
        void Start()
        {
            GetComponent<LayEggAnimal>().RequestGiveBirth();
        }
        public void OnEventHandle(ReferenceAndEventDemo.Event param)
        {
            if ( param is LaidEggsEvent laidEggs )
            {
                var eggIncubateAnimal = GetComponent<EggIncubateAnimal>();
                eggIncubateAnimal.RequestIncubate(laidEggs.EggsCount);
            }
            else if ( param is IncubatedEggsEvent incubatdEggs )
            {
                GetComponent<LayEggAnimal>().RequestGiveBirth();
            }
        }
    }
}