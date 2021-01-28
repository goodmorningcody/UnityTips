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
    public class Airplane : MonoBehaviour
    {
        [SerializeField] private Engine[] engines = null;
    }
}