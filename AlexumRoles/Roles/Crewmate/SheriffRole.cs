using AlexumRoles.Utilities;
using AmongUs.GameOptions;
using MiraAPI.Patches.Stubs;
using MiraAPI.Roles;
using Reactor.Utilities;
using TMPro;
using UnityEngine;

namespace AlexumRoles.Roles.Crewmate;

public class SheriffRole : IAlexumCrewRole
{
    public bool IsPowerCrew => true;
    public RoleAlignment RoleAlignment => RoleAlignment.CrewmateKilling;
    public string RoleName => "Sheriff";
    public string RoleLongDescription => "Kill The Evils Before They Kill You!";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => new Color32(255,255,0,255);
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new(this)
    {
        IntroSound = CustomRoleUtils.GetIntroSound(RoleTypes.Shapeshifter),
    };
}