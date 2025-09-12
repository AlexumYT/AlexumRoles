using MiraAPI.Hud;
using MiraAPI.Modifiers;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using AlexumRoles.Modifiers;
using MiraAPI.GameOptions;
using AlexumRoles.Options.Roles;
using Reactor.Utilities;
using Rewired;
using AlexumRoles.Roles.Impostor;

namespace AlexumRoles.Buttons.Impostor;

public class InvisButton : CustomActionButton
{
    public override string Name => "Invis";
    public override float Cooldown => OptionGroupSingleton<ChameleonRoleSettings>.Instance.InvisCooldown;
    public override float EffectDuration => OptionGroupSingleton<ChameleonRoleSettings>.Instance.InvisDuration;
    public override int MaxUses => (int)OptionGroupSingleton<ChameleonRoleSettings>.Instance.InvisUses;

    public override KeyboardKeyCode Defaultkeybind => KeyboardKeyCode.I;

    public override ButtonLocation Location => ButtonLocation.BottomRight;

    public override LoadableAsset<Sprite> Sprite => AlexumAssets.InvisButton;

    protected override void OnClick()
    {
        PlayerControl.LocalPlayer?.RpcAddModifier<InvisModifier>();
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is ChameloenRole;
    }
}