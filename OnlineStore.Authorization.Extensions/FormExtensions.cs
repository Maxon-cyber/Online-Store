namespace OnlineStore.Authorization.Extensions;

public static class FormExtensions
{
    public static void StartApplication(this Form mainForm, Form form)
    {
        if (form == null)
            throw new NullReferenceException();
        if (mainForm == form)
            throw new ArgumentException("Одиннаковые ссылки", nameof(form));

        Application.Exit();

        Thread thread = new Thread(() => { Application.Run(form); })
        {
            Name = $"{form.Name}Thread",
        };

        thread.Start();
    }
}