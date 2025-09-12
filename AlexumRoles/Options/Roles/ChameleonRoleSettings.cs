using AlexumRoles.Roles.Impostor;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;

namespace AlexumRoles.Options.Roles;

public class ChameleonRoleSettings : AbstractOptionGroup<ChameloenRole>
{
    public override string GroupName => "Custom Role";

    [ModdedNumberOption("Invis Cooldown", 5, 50, 1, MiraNumberSuffixes.Seconds)]
    public float InvisCooldown { get; set; } = 5;

    [ModdedNumberOption("Invis Duration", 15, 50, 1, MiraNumberSuffixes.Seconds)]
    public float InvisDuration { get; set; } = 15;

    [ModdedNumberOption("Invis Uses", 0, 5, 1, MiraNumberSuffixes.None, null, true)]
    public float InvisUses { get; set; } = 0;
}