using System;
using Exchanger.Framework.Entities;

public class Coin: BaseEntity
{
    public decimal Value { get; set; }

    public int Quantity { get; set; }

    public Coin(decimal value, int quantity)
    {
        this.Value = value;
        this.Quantity = quantity;
    }
}