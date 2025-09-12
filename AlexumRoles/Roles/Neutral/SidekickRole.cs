using MiraAPI.Roles;
using MiraAPI.GameEnd;
using UnityEngine;
using AlexumRoles.GameOver;
using AlexumRoles.Roles;

namespace AlexumRoles.Roles.Neutral;

public class SidekickRole : NeutralRole, IAlexumRole
{
    public RoleAlignment RoleAlignment => RoleAlignment.NeutralKilling;
    public string RoleName => "Sidekick";
    public string RoleDescription => "Assist the Jackal, and take their place if they fall.";
    public string RoleLongDescription => RoleDescription;
    public Color RoleColor => Color.cyan;
    public ModdedRoleTeams Team => ModdedRoleTeams.Custom;

    public CustomRoleConfiguration Configuration => new(this)
    {
        CanGetKilled = true,
        CanUseVent = true,
        KillButtonOutlineColor = Color.cyan,
        HideSettings = true,
    };

    public TeamIntroConfiguration? IntroConfiguration { get; } = new(
        Color.gray,
        "NEUTRAL",
        "You are a Netural. You do not have a team.");

    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        // Sidekick does not get crew tasks
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return gameOverReason == CustomGameOver.GameOverReason<JackalGameOver>();
    }

    public bool CanLocalPlayerSeeRole(PlayerControl player)
    {
        // Jackal and Sidekick see each other
        bool localIsJackalOrSidekick = PlayerControl.LocalPlayer.Data.Role is JackalRole or SidekickRole;
        bool targetIsJackalOrSidekick = player.Data.Role is JackalRole or SidekickRole;

        // Return true if both are Jackal/Sidekick (like Impostor vision) or if the local player is dead
        return localIsJackalOrSidekick && targetIsJackalOrSidekick || PlayerControl.LocalPlayer.Data.IsDead;
    }
}
