using System.Collections.Generic;

namespace BudgetBuddy.Application
{
    public interface IIdentityService
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInputModel);
    }
}
