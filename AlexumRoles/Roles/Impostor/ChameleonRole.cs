using AmongUs.GameOptions;
using MiraAPI.Patches.Stubs;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using Reactor.Utilities;
using AlexumRoles.Utilities;
using TMPro;
using UnityEngine;

namespace AlexumRoles.Roles.Impostor;

public class ChameloenRole : ImpostorRole, IAlexumRole
{
    public RoleAlignment RoleAlignment => RoleAlignment.ImpostorConcealing;
    public string RoleName => "Chamelon";
    public string RoleLongDescription => "Go Invisible And Kill The Crew.";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.AcceptedGreen;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new(this)
    {
        IntroSound = CustomRoleUtils.GetIntroSound(RoleTypes.Shapeshifter),
    };

    public bool WinConditionMet()
    {
        if (Player.Data.IsDead)
        {
            return false;
        }

        var result = Helpers.GetAlivePlayers().Count <= 2 && MiscUtils.KillersAliveCount == 1;

        return result;
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return WinConditionMet();
    }
}