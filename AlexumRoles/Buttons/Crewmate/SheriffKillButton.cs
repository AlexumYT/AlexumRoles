using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using MiraAPI.Patches;
using MiraAPI.Networking;
using Rewired;
using UnityEngine;
using AlexumRoles.Roles.Crewmate;
using AlexumRoles.Roles.Neutral;
using AlexumRoles.Extensions;

namespace AlexumRoles.Buttons.Crewmate;

public class SheriffKillButton : CustomActionButton<PlayerControl>
{
    public override string Name => "Shoot";

    public override float Cooldown => 25f;

    public override int MaxUses => -1;

    public override LoadableAsset<Sprite> Sprite => AlexumAssets.SheriffKillButton;

    public override KeyboardKeyCode Defaultkeybind => KeyboardKeyCode.K;

    public override ButtonLocation Location => ButtonLocation.BottomRight;
    public override ModifierKey Modifier1 => ModifierKey.Control;

    private void MisFire()
    {
        if (Target == null) { return; }

        PlayerControl.LocalPlayer.RpcCustomMurder(PlayerControl.LocalPlayer);
    }

    protected override void OnClick()
    {
        if (Target.Data.Role.IsNeutral() || Target.Data.Role.IsImpostor)
        {
            PlayerControl.LocalPlayer.RpcCustomMurder(Target);
        }
        else
        {
            MisFire();
        }
    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(new Color32(255, 255, 0, 255)));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is SheriffRole && !PlayerControl.LocalPlayer.Data.IsDead;
    }
}