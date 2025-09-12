using MiraAPI.Roles;
using UnityEngine;

namespace AlexumRoles.Roles;

public static class AlexumRoleGroups
{
    public static RoleOptionsGroup CrewInvest { get; } = new("Crewmate Investigative Roles", Palette.CrewmateRoleBlue);
    public static RoleOptionsGroup CrewKiller { get; } = new("Crewmate Killing Roles", Palette.CrewmateRoleBlue);
    public static RoleOptionsGroup CrewProc { get; } = new("Crewmate Protective Roles", Palette.CrewmateRoleBlue);
    public static RoleOptionsGroup CrewPower { get; } = new("Crewmate Power Roles", Palette.CrewmateRoleBlue);
    public static RoleOptionsGroup CrewSup { get; } = new("Crewmate Support Roles", Palette.CrewmateRoleBlue);
    public static RoleOptionsGroup NeutralBenign { get; } = new("Neutral Benign Roles", Color.gray);
    public static RoleOptionsGroup NeutralEvil { get; } = new("Neutral Evil Roles", Color.gray);
    public static RoleOptionsGroup NeutralOutlier { get; } = new("Neutral Outlier Roles", Color.gray);
    public static RoleOptionsGroup NeutralKiller { get; } = new("Neutral Killing Roles", Color.gray);
    public static RoleOptionsGroup ImpConceal { get; } = new("Impostor Concealing Roles", new Color32(214, 64, 66, 255));
    public static RoleOptionsGroup ImpKiller { get; } = new("Impostor Killing Roles", new Color32(214, 64, 66, 255));
    public static RoleOptionsGroup ImpPower { get; } = new("Impostor Power Roles", new Color32(214, 64, 66, 255));
    public static RoleOptionsGroup ImpSup { get; } = new("Impostor Support Roles", new Color32(214, 64, 66, 255));
}   