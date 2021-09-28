using UnityEngine.XR.Interaction.Toolkit;

public class TeleportState : State
{
    private readonly InteractorController _interactorRay;
    private readonly InteractorController _teleportRay;

    // Start is called before the first frame update
    public TeleportState(InteractorController interactRay, InteractorController teleportRay)
    {
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(IdleState));
    }

    public override void Enter()
    {
        base.Enter();
       _teleportRay.Show();
       _interactorRay.Hide();
    }
    public override void Exit()
    {
        base.Exit();
        _teleportRay.Hide();
        _interactorRay.Hide();
    }
    public override void Update()
    {
        base.Update();
    }
}
