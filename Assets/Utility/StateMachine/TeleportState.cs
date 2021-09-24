using UnityEngine.XR.Interaction.Toolkit;

public class TeleportState : State
{
    private readonly XRController _interactorRay;
    private readonly XRController _teleportRay;

    // Start is called before the first frame update
    public TeleportState(XRController interactRay, XRController teleportRay)
    {
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(IdleState));
    }

    public override void Enter()
    {
        base.Enter();
       _teleportRay.gameObject.SetActive(true);
       _interactorRay.gameObject.SetActive(false);
    }
    public override void Exit()
    {
        base.Exit();
        _teleportRay.gameObject.SetActive(false);
        _interactorRay.gameObject.SetActive(true);
    }
    public override void Update()
    {
        base.Update();
    }
}
