using MiraAPI.GameEnd;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using MiraAPI.Networking;
using Rewired;
using UnityEngine;
using AlexumRoles.Roles.Impostor;
using MiraAPI.Utilities;

namespace AlexumRoles.Buttons;

public class IKillButton : CustomActionButton<PlayerControl>
{
    public override string Name => "Kill";
    public override float Cooldown => 25f;
    public override LoadableAsset<Sprite> Sprite => AlexumAssets.KillButton;
    public override KeyboardKeyCode Defaultkeybind => KeyboardKeyCode.K;
    public override ButtonLocation Location => ButtonLocation.BottomRight;
    protected override void OnClick()
    {
        if (Target == null) return;

        PlayerControl.LocalPlayer.RpcCustomMurder(Target);
    }

    public override PlayerControl? GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.ImpostorRed));
    }

    public override bool IsTargetValid(PlayerControl? target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour? role)
    {
        return false;
    }
}