using Microsoft.IdentityModel.Tokens;
using OnlineStore.Database;
using OnlineStore.Database.Sql.Queries;
using OnlineStore.Entities.User;

namespace OnlineStore.Registration;

internal static class UserRegistration
{
    internal static bool IsValidFields(ErrorProvider errorProvider, string caption = "Введите значение", params TextBox[] textBoxes)
    {
        foreach (TextBox textBox in textBoxes.Where(tb => tb.Text.IsNullOrEmpty()))
            errorProvider.SetError(textBox, caption);

        bool isValidFields = errorProvider.HasErrors &&
            UserValidation.IsValidLogin("") && UserValidation.IsValidPassword("");

        return !errorProvider.HasErrors;
    }

    internal static async Task<bool> RegistrationAsync(UserEntity user)
    {
        await using DatabaseMapper database = new DatabaseMapper(StoredProcedure.AddUser);

        bool result = await database.UpdateEntityAsync(user);

        return result;
    }
}