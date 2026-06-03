using System;
using Autofac;

namespace AutofacExample
{
    public interface INotificationService
    {
        void NotifyUserNameChanged(string newName);
    }

    public class ConsoleNotification : INotificationService
    {
        public void NotifyUserNameChanged(string newName)
        {
            Console.WriteLine($"User name changed to: {newName}");
        }
    }

    public class User
    {
        public string UserName { get; set; } = "";
    }

    public class UserService
    {
        private readonly INotificationService _notificationService;

        public UserService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void ChangeUserName(User user, string newName)
        {
            user.UserName = newName;
            _notificationService.NotifyUserNameChanged(newName);
        }
    }

    public class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleNotification>()
                   .As<INotificationService>();

            builder.RegisterType<UserService>();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ProgramModule>();

            var container = builder.Build();

            using var scope = container.BeginLifetimeScope();

            var userService = scope.Resolve<UserService>();

            var user = new User
            {
                UserName = "InitialName"
            };

            userService.ChangeUserName(user, "NewName");

            Console.ReadLine();
        }
    }
}