using MiraAPI.GameEnd;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using Rewired;
using UnityEngine;
using AlexumRoles.Roles.Neutral;
using AlexumRoles.Buttons;

namespace AlexumRoles.Buttons.Neutral;

public class JackalKillButton : IKillButton
{
    public override LoadableAsset<Sprite> Sprite => AlexumAssets.JackalKillButton;
    public override bool Enabled(RoleBehaviour role)
    {
        return (role is JackalRole || role is SidekickRole);
    }
}