using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReferenceAndEventDemo
{
    // 1. 비행기 오브젝트 계층
    // Airplane
    //      ⌙ Wings
    //          ⌙ Engine
    //          ⌙ Engine
    //      ⌙ Cockpit
    //          ⌙ ToggleButton
    //          ⌙ StateText

    // 2. 비행기 동작
    //      1) 시동 On 버튼을 클릭
    //          - StateText에 "엔진 Checking" 표시
    //      2) 모든 엔진 랜덤 1-3초간 상태 체크 후 상태 반환
    //          (1) 엔진이 하나라도 문제 있으면
    //              - StateText에 "엔진 ERROR" 표시
    //              - 엔진이 정상인 엔진은 Engine.State.OFF로 변경
    //              - ToggleButton은 "엔진 RESET"으로 변경
    //          (2) 엔진 모두 정싱아면
    //              - StateText에 "엔진 ON" 표시
    //              - ToggleButton은 "엔진 OFF"로 변경
    //      3-1) 엔진 OFF ToggleButton 버튼 클릭하면
    //          (1) 모든 엔진 1-3초 후 OFF 상태 반환
    //      3-2) 엔진 RESET Toggle 버튼 클릭하면
    //          (1) 모든 엔진 1-3초 후 OFF로 상태 반환
    //      4) 모든 엔진 OFF로 상태 변경되면
    //          (1) StateText "엔진 OFF"로 표시
    //          (2) ToggleButton은 "엔진 ON"으로 변경
    public class RefactoringAirplane : MonoBehaviour, MonoEventListener
    {
        [SerializeField] private List<RefactoringEngine> engines = new List<RefactoringEngine>();
        [SerializeField] private RefactoringCockpit cockpit = null;

        bool IsOff => engines.FindAll((engine) => engine.IsOff).Count == engines.Count;
        bool IsOn => engines.FindAll((engine) => engine.IsOn).Count == engines.Count;

        public void OnEventHandle(Event param)
        {
            if ( param is TurnOnEvent )
            {
                engines.ForEach((engine) => engine.TurnOn());
            }
            else if ( param is TurnOffEvent || param is ResetEvent )
            {
                engines.ForEach((engine) => engine.TurnOn());
            }
            else if ( param is ChangedEngineEvent changedEngine )
            {
                var engineState = changedEngine.EngineState;
                if ( engineState == EngineState.SomethingWrong )
                {
                    engines.ForEach((engine) => engine.TurnOff());
                    cockpit.OccurredError();
                }
                else if ( engineState == EngineState.Checking )
                {
                    cockpit.Checking();
                }
                else if ( IsOff )
                {
                    cockpit.TurnedOff();
                }
                else if ( IsOn )
                {
                    cockpit.TurnedOn();
                }
            }
        }
    }
}