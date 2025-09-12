using MiraAPI.Roles;
using AlexumRoles.Roles;

namespace AlexumRoles.Extensions
{
    public static class RoleExtensions
    {
        public static bool IsNeutral(this RoleBehaviour role)
        {
            if (role is IAlexumRole alexumRole)
            {
                return alexumRole.RoleAlignment.ToString().StartsWith("Neutral");
            }

            return false;
        }

        public static bool CheckIsNeutralKilling(this RoleBehaviour role)
        {
            return role is IAlexumRole alexumRole &&
                   alexumRole.RoleAlignment == RoleAlignment.NeutralKilling;
        }
    }
}
