using AmongUs.GameOptions;
using MiraAPI.Roles;
using UnityEngine;

namespace AlexumRoles.Roles.Crewmate;
internal class AltruistRole : CrewmateRole, IAlexumRole
{
    public bool IsPowerCrew => false;
    public RoleAlignment RoleAlignment => RoleAlignment.CrewmateProtective;
    public override bool IsAffectedByComms => false;
    public string RoleName => "Altruist";
    public string RoleDescription => "Revive Dead Crewmates";
    public string RoleLongDescription => "Revive dead crewmates in groups";
    public Color RoleColor => new Color32(102, 0, 0, 255);
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new(this)
    {
        IntroSound = CustomRoleUtils.GetIntroSound(RoleTypes.Shapeshifter),
    };
}
