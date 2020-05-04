using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen: int
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128,
}

public class Allergies
{
    private int mask;

    public Allergies(int mask) => this.mask = mask;

    public bool IsAllergicTo(Allergen allergen)
    {
        return (((int)allergen & mask) > 0);
    }

    public Allergen[] List()
    {
         return Enum.GetValues(typeof(Allergen))
            .Cast<Allergen>()
            .Where(x => IsAllergicTo(x))
            .ToArray();
    }
}
