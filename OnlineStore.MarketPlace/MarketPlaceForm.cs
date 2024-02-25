using OnlineStore.Entities.User;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.OrderControl;
using OnlineStore.MarketPlace.PersonalAccountControl;
using OnlineStore.MarketPlace.ProductControl;

namespace OnlineStore.MarketPlace;

public sealed partial class MarketPlaceForm : Form
{
    private UserControl _currentUserControl = default!;
    private readonly UserEntity _user = default!;

    public MarketPlaceForm(UserEntity user)
    {
        InitializeComponent();
        _user = user;
    }

    private void BtnPersonalAccount_Click(object sender, EventArgs e)
    {
        ActivateButton(sender as Button);

        _currentUserControl = panelDesktop.OpenNewUserControlWIndow(new PersonalAccountForm(_user));
        labelTitle.Text = _currentUserControl.Text;
    }

    private void BtnProducts_Click(object sender, EventArgs e)
    {
        ActivateButton(sender as Button);

        _currentUserControl = panelDesktop.OpenNewUserControlWIndow(new ProductForm(Controls));
        labelTitle.Text = _currentUserControl.Text;
    }

    private void BtnOrder_Click(object sender, EventArgs e)
    {
        ActivateButton(sender as Button);

        _currentUserControl = panelDesktop.OpenNewUserControlWIndow(new OrderForm(_user.Id));
        labelTitle.Text = _currentUserControl.Text;
    }
}