using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirbornStateConfig _airbornStateConfig;

    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
}