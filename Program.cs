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

