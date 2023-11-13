using Microsoft.AspNetCore.Identity;

namespace WebCosmetic.Admins.Role
{
    public class ModelErrorHanders : IdentityErrorDescriber
    {
        public override IdentityError ConcurrencyFailure()
        {
            return base.ConcurrencyFailure();
        }
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError() { Code = nameof(DuplicateRoleName),Description = "Đã tồn tại tên này rồi" };
        }
    }
}
