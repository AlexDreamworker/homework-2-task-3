using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        Input.Movement.Sprint.started += OnSprintKeyPressed;
        Input.Movement.Sprint.canceled += OnSprintKeyCanceled;

        Input.Movement.Jump.started += OnJumpKeyPressed;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        Input.Movement.Sprint.started -= OnSprintKeyPressed;
        Input.Movement.Sprint.canceled -= OnSprintKeyCanceled;

        Input.Movement.Jump.started -= OnJumpKeyPressed;
    }

    protected virtual void OnSprintKeyPressed(InputAction.CallbackContext obj) { }
    protected virtual void OnSprintKeyCanceled(InputAction.CallbackContext obj) { }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
}