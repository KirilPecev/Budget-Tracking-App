namespace BudgetBuddy.Infrastructure.Identity
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user, IList<string> roles);
    }
}
