using System;

namespace FareEngineAssessment
{
    public enum TripStatus { Pending, Paid, Failed }

    public interface IPromotion
    {
        decimal ApplyDiscount(decimal currentFare, decimal baseFare);
    }

    public interface IPaymentService
    {
        bool ProcessPayment(string passengerId, decimal amount);
    }

    // Custom Exception
    public class InvalidTripException : Exception
    {
        public InvalidTripException(string message) : base(message) { }
    }

    // Passenger Model
    public record Passenger(string Id, string Name);

    // Abstract Vehicle
    public abstract class Vehicle
    {
        public string LicensePlate { get; init; }
        public decimal BaseFare { get; init; }

        protected Vehicle(string licensePlate, decimal baseFare)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("License plate is required.");

            LicensePlate = licensePlate;
            BaseFare = baseFare;
        }

        public abstract decimal PerKmRate { get; }
        public abstract decimal PerMinuteRate { get; }

        public virtual decimal CalculateTripFare(double distance, double duration)
        {
            return BaseFare + ((decimal)distance * PerKmRate) + ((decimal)duration * PerMinuteRate);
        }
    }

    // Standard Car
    public class StandardCar : Vehicle
    {
        public StandardCar(string licensePlate) : base(licensePlate, 50m) { }

        public override decimal PerKmRate => 15m;
        public override decimal PerMinuteRate => 2m;
    }

    // Luxury Sedan
    public class LuxurySedan : Vehicle
    {
        private const decimal LuxuryTax = 100m;

        public LuxurySedan(string licensePlate) : base(licensePlate, 150m) { }

        public override decimal PerKmRate => 30m;
        public override decimal PerMinuteRate => 5m;

        public override decimal CalculateTripFare(double distance, double duration)
        {
            return base.CalculateTripFare(distance, duration) + LuxuryTax;
        }
    }

    // Percentage Discount
    public class PercentageDiscount : IPromotion
    {
        private readonly decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Invalid discount percentage.");

            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal currentFare, decimal baseFare)
        {
            decimal discountedFare = currentFare * (1 - (_percentage / 100));

            return Math.Max(discountedFare, baseFare);
        }
    }

    // Flat Discount
    public class FlatDiscount : IPromotion
    {
        private readonly decimal _amount;

        public FlatDiscount(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Discount amount cannot be negative.");

            _amount = amount;
        }

        public decimal ApplyDiscount(decimal currentFare, decimal baseFare)
        {
            return Math.Max(currentFare - _amount, baseFare);
        }
    }

    // Payment Service
    public class CreditCardPaymentService : IPaymentService
    {
        public bool ProcessPayment(string passengerId, decimal amount)
        {
            Console.WriteLine($"Processing payment of ${amount:F2} for Passenger {passengerId}");

            return true;
        }
    }

    // Trip Class
    public class Trip
    {
        public Vehicle Vehicle { get; }
        public Passenger Passenger { get; }
        public double DistanceKms { get; }
        public double DurationMinutes { get; }

        public IPromotion? Promotion { get; set; }

        public TripStatus Status { get; private set; } = TripStatus.Pending;

        public Trip(Vehicle vehicle, Passenger passenger, double distance, double duration)
        {
            Vehicle = vehicle ?? throw new InvalidTripException("Vehicle is required.");

            Passenger = passenger ?? throw new InvalidTripException("Passenger is required.");

            if (distance < 0) throw new ArgumentException("Distance cannot be negative.");

            if (duration <= 0) throw new ArgumentException("Duration must be greater than zero.");

            DistanceKms = distance;
            DurationMinutes = duration;
        }

        public decimal CalculateFinalFare()
        {
            decimal fare = Vehicle.CalculateTripFare(DistanceKms, DurationMinutes);

            if (Promotion != null)
            {
                fare = Promotion.ApplyDiscount(fare, Vehicle.BaseFare);
            }

            return fare;
        }

        public void CompleteTrip(IPaymentService paymentService)
        {
            if (paymentService == null) throw new ArgumentNullException(nameof(paymentService));

            if (Status != TripStatus.Pending) throw new InvalidOperationException("Trip already completed.");

            decimal finalFare = CalculateFinalFare();

            bool success = paymentService.ProcessPayment(Passenger.Id, finalFare);

            Status = success ? TripStatus.Paid : TripStatus.Failed;

            Console.WriteLine($"Trip Status: {Status}, Final Fare: ${finalFare:F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                var passenger = new Passenger("P101", "Rahim");

                var paymentService = new CreditCardPaymentService();

                Console.WriteLine("=== Standard Car ===");

                var car = new StandardCar("DHAKA-123");

                var trip1 = new Trip(car, passenger, 10, 20);

                trip1.CompleteTrip(paymentService);

                Console.WriteLine();

                Console.WriteLine("=== Luxury Sedan ===");

                var luxury = new LuxurySedan("LUX-999");

                var trip2 = new Trip(luxury, passenger, 15, 30)
                {
                    Promotion = new PercentageDiscount(10)
                };

                trip2.CompleteTrip(paymentService);

                Console.WriteLine();

                Console.WriteLine("=== Flat Discount ===");

                var trip3 = new Trip(car, passenger, 1, 1)
                {
                    Promotion = new FlatDiscount(500)
                };

                trip3.CompleteTrip(paymentService);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}