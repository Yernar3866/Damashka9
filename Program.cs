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