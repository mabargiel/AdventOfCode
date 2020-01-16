using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2019._14
{
    public class Nanofactory
    {
        private readonly Dictionary<string, int> _storage;
        public List<Reaction> Reactions { get; }

        public Nanofactory(string reactionsConfiguration)
        {
            Reactions = ProduceList(reactionsConfiguration);
            _storage = new Dictionary<string, int>();
        }

        public int ProduceChemical(string name, int quantity)
        {
            var oresUsed = 0;
            
            ProduceChemical(name, quantity, ref oresUsed);
            _storage[name] -= quantity;

            return oresUsed;
        }

        private void ProduceChemical(string name, in int quantity, ref int oresUsed)
        {
            var reaction = Reactions.First(x => x.Product.Name == name);

            if (!_storage.ContainsKey(name))
                _storage[name] = 0;
            
            //Produce the chemical until reaching desired minimum quantity
            while (_storage[name] < quantity)
            {
                foreach (var reactionPart in reaction.Parts)
                {
                    if (reactionPart.Chemical.Name != "ORE")
                    {
                        ProduceChemical(reactionPart.Chemical.Name, reactionPart.ProductQuantity, ref oresUsed);
                        _storage[reactionPart.Chemical.Name] -= reactionPart.ProductQuantity;
                    }
                    else oresUsed += reactionPart.ProductQuantity;
                }
                
                _storage[name] += reaction.ProductQuantity;
            }
        }

        private static List<Reaction> ProduceList(string reactionsConfiguration)
        {
            var regex = new Regex(@"(?<quantity>\d+) (?<name>\w+)");

            return (from reaction in reactionsConfiguration.Split(Environment.NewLine)
                select regex.Matches(reaction)
                into matches
                select matches.Select(match =>
                {
                    var name = match.Groups["name"].ToString();
                    var chemical = new Chemical(name);
                    return (chemical, int.Parse(match.Groups["quantity"].Value));
                })
                into chemicals
                select new Reaction(chemicals.Last().Item1, chemicals.Last().Item2, chemicals.Take(chemicals.Count() - 1))).ToList();
        }
    }
}