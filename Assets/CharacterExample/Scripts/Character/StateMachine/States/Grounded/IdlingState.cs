using UnityEngine.InputSystem;

public class IdlingState : GroundedState
{
    private bool _canSprint;

    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartIdling();

        Data.Speed = 0;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        if (_canSprint) 
            StateSwitcher.SwitchState<RunningState>();
        else
            StateSwitcher.SwitchState<WalkingState>();
    }

    protected override void OnSprintKeyPressed(InputAction.CallbackContext obj) => _canSprint = true;

    protected override void OnSprintKeyCanceled(InputAction.CallbackContext obj) => _canSprint = true;
}