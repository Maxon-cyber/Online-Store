using Microsoft.IdentityModel.Tokens;
using OnlineStore.Authorization.Extensions;
using OnlineStore.Entities.User;
using OnlineStore.MarketPlace;

namespace OnlineStore.Identification;

public sealed partial class FormIdentification : Form
{
    public FormIdentification()
        => InitializeComponent();

    private async void BtnLogin_Click(object sender, EventArgs e)
    {
        string login = textBoxLogin.Text;
        string password = textBoxPassword.Text;

        if (login.IsNullOrEmpty() || password.IsNullOrEmpty())
        {
            MessageBox.Show("��������� ��� ����");
            return;
        }

        UserEntity? user = await UserAuthetication.CheckAsync(login, password);

        if (user == null)
        {
            MessageBox.Show("������������ ����� ��� ������", "������", MessageBoxButtons.OK);
            return;
        }

        MessageBox.Show($"����� ����������, {user}!");

        switch (user.Role)
        {
            case Role.User:
                this.StartApplication(new MarketPlaceForm(user));
                break;
            case Role.Admin:
                this.StartApplication(null);
                break;
        }
    }
}