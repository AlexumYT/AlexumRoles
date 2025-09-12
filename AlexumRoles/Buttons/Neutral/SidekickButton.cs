using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using Reactor.Utilities;
using AmongUs.GameOptions;
using MiraAPI.Roles;
using Rewired;
using AlexumRoles.Roles.Neutral;

namespace AlexumRoles.Buttons.Neutral;

public class SidekickButton : CustomActionButton<PlayerControl>
{
    public override string Name => "Make Sidekick";
    public override float Cooldown => 0f; // optional cooldown
    public override float EffectDuration => 0f;
    public override int MaxUses => -1; // unlimited
    public override ButtonLocation Location => ButtonLocation.BottomRight;

    public override KeyboardKeyCode Defaultkeybind => KeyboardKeyCode.S;
    public override LoadableAsset<Sprite> Sprite => AlexumAssets.InvisButton; // replace with proper sprite

    // When button is clicked
    protected override void OnClick()
    {
        foreach (var p in PlayerControl.AllPlayerControls)
        {
            if (p.Data.Role is SidekickRole && !p.Data.IsDead)
                return;
        }

        if (Target == null) return;

        Target.RpcSetRole((RoleTypes)RoleId.Get<SidekickRole>(), true);
    }

    // Get closest player in range
    public override PlayerControl GetTarget()
    {
        return MiraAPI.Utilities.Extensions.GetClosestPlayer(PlayerControl.LocalPlayer, true, Distance, false, false);
    }

    // Outline the target when aiming
    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Color.cyan));
    }

    // Validate the target
    public override bool IsTargetValid(PlayerControl target)
    {
        return target != null && !target.Data.IsDead && !(target.Data.Role is JackalRole || target.Data.Role is SidekickRole);
    }

    // Enable button only for Jackal
    public override bool Enabled(RoleBehaviour role)
    {
        bool NosidekickAlive = true;

        foreach (var p in PlayerControl.AllPlayerControls)
        {
            if (p.Data.Role is SidekickRole && !p.Data.IsDead)
            {
                NosidekickAlive = false;
                break;
            }
        }

        return role is JackalRole && NosidekickAlive;
    }
}