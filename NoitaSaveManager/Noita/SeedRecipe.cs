using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoitaSaveManager.Noita
{
    struct SeedRecipeMaterials
    {
        public string Material1;
        public string Material2;
        public string Material3;
    }

    struct SeedRecipeData
    {
        public SeedRecipeMaterials LivelyConcoction;
        public SeedRecipeMaterials AlchemicalPrecursor;

        public override string ToString()
        {
            return string.Format(
                "LC: {0} -  AP: {1}",
                string.Format("{0}, {1}, {2}", LivelyConcoction.Material1, LivelyConcoction.Material2, LivelyConcoction.Material3),
                string.Format("{0}, {1}, {2}", AlchemicalPrecursor.Material1, AlchemicalPrecursor.Material2, AlchemicalPrecursor.Material3)
            );
        }
    }

    class SeedRecipe
    {
        static List<string> Liquids = new List<string>{
            "acid",
            "alcohol",
            "blood",
            "blood_fungi",
            "blood_worm",
            "cement",
            "lava",
            "berserkium",
            "pheromone",
            "levitatium",
            "hastium",
            "invisiblium",
            "concentrated_mana",
            "acceleratium",
            "ambrosia",
            "teleportatium",
            "unstable_polymorphine",
            "unstable_teleportatium",
            "worm_pheromone",
            "flummoxium",
            "mud",
            "oil",
            "poison",
            "toxic_sludge",
            "swamp",
            "urine",
            "water",
            "water_ice",
            "water_swamp",
            "chaotic_polymorphine"
        };

        static List<string> Alchemy = new List<string>{
            "bone",
            "brass",
            "coal",
            "copper",
            "diamond",
            "fungus",
            "gold",
            "grass",
            "gunpowder",
            "gunpowder_explosive",
            "rotten_meat",
            "sand",
            "silver",
            "slime",
            "snow",
            "soil",
            "wax",
            "honey"
        };

        private uint Seed;
        private PseudoRNG Random;
        private List<string> Materials = new List<string>();

        public SeedRecipe(PseudoRNG random, uint seed)
        {
            Seed = seed;
            Random = random;
            PickMaterials(Liquids, 3);
            PickMaterials(Alchemy, 1);
            ShuffleMaterials();
            Random.Get();
            Random.Get();
        }

        private void PickMaterials(List<string> source, int count)
        {
            int counter = 0;
            while (counter < count)
            {
                var picked = source[(int)(Random.Get() * source.Count)];
                if (!Materials.Any(v => v == picked))
                {
                    Materials = Materials.Append(picked).ToList();
                    counter++;
                }
            }
            return;
        }

        private void ShuffleMaterials()
        {
            PseudoRNG random = new PseudoRNG((Seed >> 1) + 12534);
            for (int i = Materials.Count - 1; i >= 0; i--)
            {
                int rand = (int)(random.Get() * (i + 1));
                var tmp = Materials[i];
                Materials[i] = Materials[rand];
                Materials[rand] = tmp;
            }
        }

        public SeedRecipeMaterials GetMaterials()
        {
            return new SeedRecipeMaterials
            {
                Material1 = Materials[0],
                Material2 = Materials[1],
                Material3 = Materials[2]
            };
        }

        public static SeedRecipeData GetRecipesForSeed(uint seed)
        {
            var random = new PseudoRNG(seed * 0.17127 + 1323.5903);
            for (int i = 0; i < 5; i++)
                random.Get();

            return new SeedRecipeData
            {
                LivelyConcoction = (new SeedRecipe(random, seed)).GetMaterials(),
                AlchemicalPrecursor = (new SeedRecipe(random, seed)).GetMaterials()
            };
        }

        public static string MaterialToString(string material)
        {
            StringBuilder sb = new StringBuilder();
            string[] parts = material.Split('_');
            foreach(var part in parts)
            {
                sb.Append(part.Substring(0, 1).ToUpper());
                sb.Append(part.Substring(1));
                sb.Append(" ");
            }
            string str = sb.ToString();
            str = str.Replace("Magic Liquid", "Potion:");
            return str.Substring(0, str.Length - 1) + " (" + material + ")";
        }
    }

}
