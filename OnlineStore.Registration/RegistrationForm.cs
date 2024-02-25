namespace OnlineStore.Registration;

public sealed partial class RegistrationForm : Form
{
    public RegistrationForm()
        => InitializeComponent();

    private void RegistrationForm_Load(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show(text:"",
                                                    caption: "",
                                                    buttons: MessageBoxButtons.OKCancel,
                                                    icon: MessageBoxIcon.Question,
                                                    defaultButton: MessageBoxDefaultButton.Button1,
                                                    options: MessageBoxOptions.RtlReading,
                                                    displayHelpButton: false);
        //if (dialogResult == DialogResult.OK)
    }

    private async void RegistrationBtn_Click(object sender, EventArgs e)
    {
        //if (!UserRegistration.IsValidFields(errorProvider: errorProvider,
        //                                    textBoxes: Controls.OfType<TextBox>().ToArray()))
        //    return;

        //string login = textBoxLogin.Text;
        //string password = textBoxPassword.Text;

        //if (!(UserValidator.IsValidLogin(login) && UserValidator.IsValidPassword(password)))
        //{
        //    UserRegistration.IsValidFields(
        //        errorProvider,
        //        "Логин или пароль не соответсвует требованиям",
        //        new TextBox[]
        //        {
        //            textBoxLogin,
        //            textBoxPassword
        //        });

        //    return;
        //}

        //bool isRegistered = await UserRegistration.RegistrationAsync(new UserEntity()
        //{
        //    Id = ID.Create(),
        //    Name = nameTextBox.Text,
        //    SecondName = secondNameTextBox.Text,
        //    Patronymic = patronymicTextBox.Text,
        //    Login = login,
        //    Password = password,
        //    DateOfRegistartion = DateTime.Now,
        //    Role = UserParameters.DEFAULT_ROLE,
        //});

        //if (!isRegistered)
        //{
        //    MessageBox.Show("Пользователь с таким логином уже зарегстрирован");
        //    return;
        //}

        //MessageBox.Show("Вы успешно зарегистрированы!");
    }
}