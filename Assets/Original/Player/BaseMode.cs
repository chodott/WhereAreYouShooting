using UnityEngine;

public class BaseMode : MonoBehaviour
{
    static protected BattleSceneUI _battleSceneUI;

    protected void  Awake()
    {
        if (_battleSceneUI != null) return;
        _battleSceneUI =  FindAnyObjectByType<BattleSceneUI>();
    }
}
