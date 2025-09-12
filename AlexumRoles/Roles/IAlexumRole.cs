﻿using System.Globalization;
using System.Text;
using Il2CppInterop.Runtime.Attributes;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using AlexumRoles.Utilities;
using System;

namespace AlexumRoles.Roles;

public interface IAlexumRole : ICustomRole
{
    RoleAlignment RoleAlignment { get; }

    bool HasImpostorVision => false;
    public virtual bool MetWinCon => false;

    public virtual string YouAreText
    {
        get
        {
            var prefix = " a";
            if (RoleName.StartsWithVowel())
            {
                prefix = " an";
            }

            if (Configuration.MaxRoleCount is 0 or 1)
            {
                prefix = " the";
            }

            if (RoleName.StartsWith("the", StringComparison.OrdinalIgnoreCase))
            {
                prefix = "";
            }

            return $"You are{prefix}";
        }
    }

    RoleOptionsGroup ICustomRole.RoleOptionsGroup
    {
        get
        {
            if (RoleAlignment == RoleAlignment.CrewmateInvestigative)
            {
                return AlexumRoleGroups.CrewInvest;
            }

            if (RoleAlignment == RoleAlignment.CrewmateKilling)
            {
                return AlexumRoleGroups.CrewKiller;
            }

            if (RoleAlignment == RoleAlignment.CrewmateProtective)
            {
                return AlexumRoleGroups.CrewProc;
            }

            if (RoleAlignment == RoleAlignment.CrewmatePower)
            {
                return AlexumRoleGroups.CrewPower;
            }

            if (RoleAlignment == RoleAlignment.ImpostorConcealing)
            {
                return AlexumRoleGroups.ImpConceal;
            }

            if (RoleAlignment == RoleAlignment.ImpostorKilling)
            {
                return AlexumRoleGroups.ImpKiller;
            }

            if (RoleAlignment == RoleAlignment.ImpostorPower)
            {
                return AlexumRoleGroups.ImpPower;
            }

            if (RoleAlignment == RoleAlignment.NeutralEvil)
            {
                return AlexumRoleGroups.NeutralEvil;
            }

            if (RoleAlignment == RoleAlignment.NeutralOutlier)
            {
                return AlexumRoleGroups.NeutralOutlier;
            }

            if (RoleAlignment == RoleAlignment.NeutralKilling)
            {
                return AlexumRoleGroups.NeutralKiller;
            }

            return Team switch
            {
                ModdedRoleTeams.Crewmate => AlexumRoleGroups.CrewSup,
                ModdedRoleTeams.Impostor => AlexumRoleGroups.ImpSup,
                _ => AlexumRoleGroups.NeutralBenign
            };
        }
    }

    bool WinConditionMet()
    {
        return false;
    }

    /// <summary>
    ///     LobbyStart - Called for each role when a lobby begins.
    /// </summary>
    void LobbyStart()
    {
    }

    public static StringBuilder SetNewTabText(ICustomRole role)
    {
        var alignment = role is IAlexumRole touRole
            ? touRole.RoleAlignment.ToDisplayString()
            : "Custom";

        if (alignment.Contains("Crewmate"))
        {
            alignment = alignment.Replace("Crewmate", "<color=#68ACF4>Crewmate");
        }
        else if (alignment.Contains("Impostor"))
        {
            alignment = alignment.Replace("Impostor", "<color=#D63F42>Impostor");
        }
        else if (alignment.Contains("Neutral"))
        {
            alignment = alignment.Replace("Neutral", "<color=#8A8A8A>Neutral");
        }

        var prefix = " a";
        if (role.RoleName.StartsWithVowel())
        {
            prefix = " an";
        }

        if (role.Configuration.MaxRoleCount is 0 or 1)
        {
            prefix = " the";
        }

        if (role.RoleName.StartsWith("the", StringComparison.OrdinalIgnoreCase))
        {
            prefix = "";
        }

        var stringB = new StringBuilder();
        stringB.AppendLine(CultureInfo.InvariantCulture,
            $"{role.RoleColor.ToTextColor()}You are{prefix}<b> {role.RoleName}.</b></color>");
        stringB.AppendLine(CultureInfo.InvariantCulture, $"<size=60%>Alignment: <b>{alignment}</color></b></size>");
        stringB.Append("<size=70%>");
        stringB.AppendLine(CultureInfo.InvariantCulture, $"{role.RoleLongDescription}");

        return stringB;
    }

    public static StringBuilder SetDeadTabText(ICustomRole role)
    {
        var alignment = role is IAlexumRole touRole
            ? touRole.RoleAlignment.ToDisplayString()
            : "Custom";

        if (alignment.Contains("Crewmate"))
        {
            alignment = alignment.Replace("Crewmate", "<color=#68ACF4>Crewmate");
        }
        else if (alignment.Contains("Impostor"))
        {
            alignment = alignment.Replace("Impostor", "<color=#D63F42>Impostor");
        }
        else if (alignment.Contains("Neutral"))
        {
            alignment = alignment.Replace("Neutral", "<color=#8A8A8A>Neutral");
        }

        var prefix = " a";
        if (role.RoleName.StartsWithVowel())
        {
            prefix = " an";
        }

        if (role.Configuration.MaxRoleCount is 0 or 1)
        {
            prefix = " the";
        }

        if (role.RoleName.StartsWith("the", StringComparison.OrdinalIgnoreCase))
        {
            prefix = "";
        }

        var stringB = new StringBuilder();
        stringB.AppendLine(CultureInfo.InvariantCulture,
            $"{role.RoleColor.ToTextColor()}You were{prefix}<b> {role.RoleName}.</b></color>");
        stringB.AppendLine(CultureInfo.InvariantCulture, $"<size=60%>Alignment: <b>{alignment}</color></b></size>");
        stringB.Append("<size=70%>");
        stringB.AppendLine(CultureInfo.InvariantCulture, $"{role.RoleLongDescription}");

        return stringB;
    }

    [HideFromIl2Cpp]
    public StringBuilder SetTabText()
    {
        return SetNewTabText(this);
    }
}

public enum RoleAlignment
{
    CrewmateInvestigative,
    CrewmateKilling,
    CrewmateProtective,
    CrewmatePower,
    CrewmateSupport,
    ImpostorConcealing,
    ImpostorKilling,
    ImpostorPower,
    ImpostorSupport,
    NeutralBenign,
    NeutralEvil,
    NeutralOutlier,
    NeutralKilling
}