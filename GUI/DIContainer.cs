using Microsoft.Extensions.DependencyInjection;

namespace GUI
{
    public static class DIContainer
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static T Get<T>() => ServiceProvider.GetRequiredService<T>();
    }
}
