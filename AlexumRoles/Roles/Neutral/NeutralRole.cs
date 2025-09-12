using Il2CppSystem.Text;

namespace AlexumRoles.Roles.Neutral;

public abstract class NeutralRole : ImpostorRole
{
    public override bool IsDead => false; // needed because we inherit from RoleBehaviour
    public override bool IsAffectedByComms => false;

    public override bool CanUse(IUsable usable)
    {
        return GameManager.Instance.LogicUsables.CanUse(usable, Player);
    }

    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        // remove existing task header.
    }
}