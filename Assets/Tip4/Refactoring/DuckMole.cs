using UnityEngine;
using ReferenceAndEventDemo;

namespace Hunting
{
    public class DuckMole : MonoBehaviour, MonoEventListener
    {
        void Update()
        {
            if ( GetComponent<NursingAnimal>().IsNursing == false && GetComponent<EggIncubateAnimal>().IsIncubating == false )
            {
                GetComponent<LayEggAnimal>().RequestGiveBirth();
            }
        }

        public void OnEventHandle(ReferenceAndEventDemo.Event param)
        {
            if ( param is LaidEggsEvent laidEggs )
            {
                var eggIncubateAnimal = GetComponent<EggIncubateAnimal>();
                eggIncubateAnimal.RequestIncubate(laidEggs.EggsCount);
            }
            else if ( param is IncubatedEggsEvent incubatedEggs )
            {
                var nursingAnimal = GetComponent<NursingAnimal>();
                for( var i = 0; i<incubatedEggs.EggsCount; ++i )
                {
                    nursingAnimal.RequestNursing(new NursingBaby());
                }
            }
        }
    }
}