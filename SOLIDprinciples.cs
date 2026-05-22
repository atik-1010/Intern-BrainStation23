using System;
using System.Collections.Generic;

namespace SOLID_Demo
{
    // S -- SINGLE RESPONSIBILITY PRINCIPLE (SRP)
    // A class should have only ONE reason to change

    // Handles product data only
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    // Handles invoice calculations only
    public class Invoice
    {
        private readonly List<Product> _products;

        public Invoice(List<Product> products)
        {
            _products = products;
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (var product in _products)
            {
                total += product.Price;
            }

            return total;
        }
    }

    // Handles printing only
    public class InvoicePrinter
    {
        public void Print(double total)
        {
            Console.WriteLine($"Invoice Total: ${total}");
        }
    }

    // O -- OPEN/CLOSED PRINCIPLE (OCP)
    // Open for extension, closed for modification

    public interface IDiscount
    {
        double ApplyDiscount(double amount);
    }

    public class NoDiscount : IDiscount
    {
        public double ApplyDiscount(double amount)
        {
            return amount;
        }
    }

    public class SeasonalDiscount : IDiscount
    {
        public double ApplyDiscount(double amount)
        {
            return amount * 0.9; // 10% off
        }
    }

    public class PremiumDiscount : IDiscount
    {
        public double ApplyDiscount(double amount)
        {
            return amount * 0.8; // 20% off
        }
    }

    // L -- LISKOV SUBSTITUTION PRINCIPLE (LSP)
    // Derived classes should replace base classes safely

    public abstract class Bird
    {
        public abstract void Move();
    }

    public class FlyingBird : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    public class Penguin : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Penguin is swimming");
        }
    }

    // I -- INTERFACE SEGREGATION PRINCIPLE (ISP)
    // Clients should not depend on interfaces
    // they do not use

    public interface IWork
    {
        void Work();
    }

    public interface IEat
    {
        void Eat();
    }

    public class HumanWorker : IWork, IEat
    {
        public void Work()
        {
            Console.WriteLine("Human is working");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating");
        }
    }

    public class RobotWorker : IWork
    {
        public void Work()
        {
            Console.WriteLine("Robot is working");
        }
    }

    // D -- DEPENDENCY INVERSION PRINCIPLE (DIP)
    // High-level modules should depend on abstractions

    public interface IMessageService
    {
        void SendMessage(string message);
    }

    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email Sent: {message}");
        }
    }

    public class SMSService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS Sent: {message}");
        }
    }

    // High-level module depends on abstraction
    public class Notification
    {
        private readonly IMessageService _messageService;

        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.SendMessage(message);
        }
    }

    // MAIN PROGRAM

    class Program
    {
        static void Main(string[] args)
        {
            // SRP Example

            List<Product> products = new List<Product>
            {
                new Product("Laptop", 1000),
                new Product("Mouse", 50)
            };

            Invoice invoice = new Invoice(products);
            double total = invoice.CalculateTotal();

            InvoicePrinter printer = new InvoicePrinter();
            printer.Print(total);

            Console.WriteLine();


            // OCP Example


            IDiscount discount = new SeasonalDiscount();

            double discountedPrice = discount.ApplyDiscount(total);

            Console.WriteLine($"Discounted Total: ${discountedPrice}");

            Console.WriteLine();

            // LSP Example

            Bird sparrow = new FlyingBird();
            Bird penguin = new Penguin();

            sparrow.Move();
            penguin.Move();

            Console.WriteLine();


            // ISP Example

            HumanWorker human = new HumanWorker();
            human.Work();
            human.Eat();

            RobotWorker robot = new RobotWorker();
            robot.Work();

            Console.WriteLine();


            // DIP Example

            IMessageService emailService = new EmailService();

            Notification notification = new Notification(emailService);

            notification.Notify("Welcome to SOLID Principles!");

            IMessageService smsService = new SMSService();

            Notification smsNotification = new Notification(smsService);

            smsNotification.Notify("SMS Notification Example");
        }
    }
}