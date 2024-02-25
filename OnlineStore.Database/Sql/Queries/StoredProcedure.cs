namespace OnlineStore.Database.Sql.Queries;

public static class StoredProcedure
{
    public static string GetUser => "sp_FindUser";
    public static string GetAllUsers => "sp_GetAllUsers";
    public static string GetProducts => "sp_GetAllProducts";
    public static string GetOrders => "sp_GetAllOrders";

    public static string AddUser => "sp_InsertUser";
    public static string AddProduct => "sp_InsertProduct";
    public static string AddOrder => "sp_InsertOrder";

    public static string DropUser => "sp_DropUser";
    public static string DropProduct => "sp_DropProduct";
    public static string DropOrder => "sp_DropOrders";
}