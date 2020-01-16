using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MoreLinq;
using MoreLinq.Extensions;

namespace AdventOfCode.Days._2019._14
{
    public class Nanofactory
    {
        private readonly string _reactionsConfiguration;

        public Nanofactory(string reactionsConfiguration)
        {
            _reactionsConfiguration = reactionsConfiguration;
        }

        public (int Ores, Dictionary<string, int> Rests) GetRequiredOres(string chemicalName, int chemicalQuantity)
        {
            var reactions = ProduceList(_reactionsConfiguration);

            var chemicalReaction = reactions.First(x => x.Product.ProductName == chemicalName);
            var ingredients = chemicalReaction.Ingredients.ToDictionary(x => x.ProductName, x => x.ProductQty);
            var rests = new Dictionary<string, int>();

            while (ingredients.Keys.Any(x => x != "ORE"))
            {
                ConsolidateIngredients(ingredients, rests, reactions);
                TransformRests(rests, ingredients, reactions);
                Flatten(ingredients, reactions, false);
                Flatten(rests, reactions, true);
            }
            
            return (ingredients.First().Value, rests);
        }

        private static void TransformRests(Dictionary<string,int> rests, Dictionary<string,int> ingredients, List<Reaction> reactions)
        {
            foreach (var (key, qty) in new Dictionary<string, int>(rests))
            {
                var reaction = reactions.First(x => x.Product.ProductName == key);
                var minimumQty = reaction.Product.ProductQty;
                
                if(qty < minimumQty)
                    continue;

                var qtyToTransport = (int) Math.Floor(qty / (double) minimumQty) * minimumQty;
                rests[key] -= qtyToTransport;
                ingredients[key] -= qtyToTransport;

                if (rests[key] == 0)
                    rests.Remove(key);
                
                if (ingredients[key] == 0)
                    ingredients.Remove(key);
            }
        }

        private static void Flatten(Dictionary<string,int> chemicals, List<Reaction> reactions, bool excludeOres)
        {
            foreach (var (chemical, qty) in new Dictionary<string, int>(chemicals))
            {
                if(chemical == "ORE")
                    continue;
                
                var reaction = reactions.First(x => x.Product.ProductName == chemical);
                
                if(reaction.Ingredients.Any(x => x.ProductName == "ORE") && excludeOres)
                    continue;
                
                if(qty < reaction.Product.ProductQty)
                    continue;

                var realQty = qty / reaction.Product.ProductQty;
                
                foreach (var ingredient in reaction.Ingredients)
                {
                    if (chemicals.ContainsKey(ingredient.ProductName))
                        chemicals[ingredient.ProductName] += realQty * ingredient.ProductQty;
                    else chemicals[ingredient.ProductName] = realQty * ingredient.ProductQty;
                }

                chemicals[chemical] -= qty;
                if (chemicals[chemical] == 0)
                    chemicals.Remove(chemical);
            }
        }

        private static void ConsolidateIngredients(IDictionary<string, int> left, IDictionary<string, int> right, IReadOnlyCollection<Reaction> reactions)
        {
            foreach (var (ingredient, requiredQty) in new Dictionary<string, int>(left))
            {
                if(ingredient == "ORE")
                    continue;
                
                var reaction = reactions.First(x => x.Product.ProductName == ingredient);

                var minimumQty = reaction.Product.ProductQty;
                var consolidatedQty = (int) Math.Ceiling(requiredQty / (double) minimumQty) * minimumQty;
                var rest = consolidatedQty - requiredQty;

                left[ingredient] = consolidatedQty;
                
                if(rest == 0)
                    continue;

                if (right.ContainsKey(ingredient))
                    right[ingredient] += rest;
                else right[ingredient] = rest;
            }
        }

        private static List<Reaction> ProduceList(string reactionsConfiguration)
        {
            var regex = new Regex(@"(((?<ingredientQty>\d+) (?<ingredient>\w+)(, )?)+) => (?<productQty>\d+) (?<product>\w+)");
            var result = new List<Reaction>();

            foreach (var reaction in reactionsConfiguration.Split(Environment.NewLine))
            {
                var matches = regex.Matches(reaction);

                foreach (Match match in matches)
                {
                    var product = match.Groups["product"].ToString();
                    var productQty = int.Parse(match.Groups["productQty"].Value);
                    var ingredientProducts = new List<string>();
                    var ingredientQtys = new List<int>();

                    foreach (var ingredient in match.Groups["ingredient"].Captures)
                    {
                        ingredientProducts.Add(ingredient.ToString());
                    }

                    foreach (var ingredientQty in match.Groups["ingredientQty"].Captures)
                    {
                        ingredientQtys.Add(int.Parse(ingredientQty.ToString()));
                    }

                    var ingredients = ingredientProducts.Select((t, i) => new Chemical(t, ingredientQtys[i])).ToList();
                    
                    result.Add(new Reaction(new Chemical(product, productQty), ingredients));
                }
            }

            return result;
        }
    }

    public class Reaction
    {
        public Chemical Product { get; }
        public List<Chemical> Ingredients { get; }

        public Reaction(Chemical product, List<Chemical> ingredients)
        {
            Product = product;
            Ingredients = ingredients;
        }
    }

    public class Chemical
    {
        public string ProductName { get; }
        public int ProductQty { get; }

        public Chemical(string productName, int productQty)
        {
            ProductName = productName;
            ProductQty = productQty;
        }
    }
}