using MiraAPI.Utilities.Assets;

namespace AlexumRoles;

public static class AlexumAssets
{
    public static LoadableResourceAsset InvisButton { get; } = new("AlexumRoles.Assets.InvisButton.png");
    public static LoadableResourceAsset SheriffKillButton { get; } = new("AlexumRoles.Assets.SheriffKillButton.png");
    public static LoadableResourceAsset KillButton { get; } = new("AlexumRoles.Assets.KillButton.png");
    public static LoadableResourceAsset JackalKillButton { get; } = new("AlexumRoles.Assets.JackalKillButton.png");
}