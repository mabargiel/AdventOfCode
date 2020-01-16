using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2019._14
{
    public class Reaction
    {
        public Chemical Product { get; }
        public int ProductQuantity { get; }
        public IEnumerable<(Chemical Chemical, int ProductQuantity)> Parts { get; }

        public Reaction(Chemical product, int productQuantity, IEnumerable<(Chemical Chemical, int ProductQuantity)> parts)
        {
            Product = product;
            ProductQuantity = productQuantity;
            Parts = parts;
        }

        public override string ToString()
        {
            return $"{string.Join(", ", Parts.Select(part => $"{part.ProductQuantity} {part.Chemical.Name}"))} => {ProductQuantity} {Product.Name}";
        }
    }
    
    public class Ore : Chemical
    {
        public Ore() : base("ORE")
        {
        }
    }

    public class Chemical : IEquatable<Chemical>
    {
        public string Name { get; }

        public Chemical(string name)
        {
            Name = name;
        }

        public bool Equals(Chemical other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Chemical) obj);
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}