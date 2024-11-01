using System;

public abstract class Beverage
{
    public abstract string GetDescription();
    public abstract double Cost();
}
public class Espresso : Beverage
{
    public override string GetDescription() => "Espresso";
    public override double Cost() => 1.5;

}
public class Tea : Beverage
{
    public override string GetDescription() => "Espresso";
    public override double Cost() => 1.5;

}
public class Latte : Beverage
{
    public override string GetDescription() => "Latte";
    public override double Cost() => 2.0;
}
public abstract class BeverageDecorator : Beverage
{
    protected Beverage _beverage;

    public BeverageDecorator(Beverage beverage)
    {
        _beverage = beverage;
    }
    public override string GetDescription() => _beverage.GetDescription();
    public override double Cost() => _beverage.Cost();
}

public class Milk : BeverageDecorator
{
    public Milk(Beverage beverage) : base(beverage) { }
    public override string GetDescription() => _beverage.GetDescription() + ", Milk";
    public override double Cost() => _beverage.Cost() + 0.3;
}
public class Sugar : BeverageDecorator
{
    public Sugar(Beverage beverage) : base(beverage) { }
    public override string GetDescription() => _beverage.GetDescription() + ", Sugar";
    public override double Cost() => _beverage.Cost() + 0.2;
}

public class WhippedCream : BeverageDecorator
{
    public WhippedCream(Beverage beverage) : base(beverage) { }
    public override string GetDescription() => _beverage.GetDescription() + ", Whipped Cream";
    public override double Cost() => _beverage.Cost() + 0.5;
}
public class Syrup : BeverageDecorator
{
    public Syrup(Beverage beverage) : base(beverage) { }
    public override string GetDescription() => _beverage.GetDescription() + ", Syrup";
    public override double Cost() => _beverage.Cost() + 0.4;
}
public class CafeOrder
{
    public static void CreateOrder()
    {
        Beverage beverage= new Beverage();
        beverage = new Milk(beverage);
        beverage = new Sugar(beverage);
        beverage= new WhippedCream(beverage);

        Console.WriteLine($"Order: {beverage.GetDescription()}");
        Console.WriteLine($"Total Cost: ${beverage.Cost():0.00}");
    }
}
public interface IPaymentProcessor
{
    void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing Paypal payment of ${amount:0.00}");

    }
}
public class StripePaymentService
{
    public void MakeTransaction(double totalAmount)
    {
        Console.WriteLine($"Processing Stripe transaction of ${totalAmount:0.00}");
    }

    internal void ProcessSquarePayment(double amount)
    {
        throw new NotImplementedException();
    }
}
 
public class StripePaymentAdapter : IPaymentProcessor
{
    private readonly StripePaymentService stripePaymentService;
    private StripePaymentService _stripePaymentService;

    public StripePaymentAdapter(StripePaymentService stripePaymentService)
    {
        _stripePaymentService = stripePaymentService;
    }
    public void ProcessPayment(double amount)
    {
        _stripePaymentService.MakeTransaction(amount);
    }
}
public class SquarePaymentService
{
    public void ProcessSquarePayment(Double amount)
    {
        Console.WriteLine($"Processing Square payment of ${amount:0.00}");

    }
}

public class SquarePaymentAdapter : IPaymentProcessor
{
    private readonly StripePaymentService _stripePaymentService;

    public SquarePaymentAdapter(
        StripePaymentService stripePaymentService)
    {
        _stripePaymentService = stripePaymentService;
    }
    public void ProcessPayment(double amount)
    {
        _stripePaymentService.ProcessSquarePayment(amount);
    }
}
public class PaymentClient
{
    public static void ProcessPayments()
    {
        IPaymentProcessor paypal = new PayPalPaymentProcessor();
        paypal.ProcessPayment(50.0);

        IPaymentProcessor stripe = new StripePaymentAdapter(new StripePaymentService());
        stripe.ProcessPayment(75.0);

        IPaymentProcessor square = new SquarePaymentAdapter(new SquarePaymentService());
        square.ProcessPayment(100.0);
    }
}
 public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- Zakaz v coffee----");
        CafeOrder.CreateOrder();
        Console.WriteLine("\n---- Oplata zakaza----");
        PaymentClient.ProcessPayments();
    }
}



