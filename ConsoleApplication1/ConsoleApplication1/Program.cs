using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RNGReporter;

namespace ConsoleApplication1 {
    class Program {
        public static string[] Escape(string[] s) {

            for(int i=0, count=s.Length; i<count; ++i)
                s[i] = s[i].Replace("'", "\\'");
            return s;
        }

        static void Main(string[] args) {
            List<Pokemon> pokemon = Pokemon.PokemonCollection();
            StringBuilder dex = new StringBuilder("function PokemonCollection() {");
            dex.AppendLine("");
            dex.AppendLine("\tpokedex = new Array();");
            dex.AppendLine("");
            
            foreach(Pokemon p in pokemon) {
                string[] names = {
                                     Pokemon.pokemonName(p.Index, 1),
                                     Pokemon.pokemonName(p.Index, 2),
                                     Pokemon.pokemonName(p.Index, 3),
                                     Pokemon.pokemonName(p.Index, 4),
                                     Pokemon.pokemonName(p.Index, 5),
                                     Pokemon.pokemonName(p.Index, 6),
                                     Pokemon.pokemonName(p.Index, 7)
                                 };
                string[] abilities1 = {
                                          Pokemon.abilityName(p.ability0, 1),
                                          Pokemon.abilityName(p.ability0, 2),
                                          Pokemon.abilityName(p.ability0, 3),
                                          Pokemon.abilityName(p.ability0, 4),
                                          Pokemon.abilityName(p.ability0, 5),
                                          Pokemon.abilityName(p.ability0, 6),
                                          Pokemon.abilityName(p.ability0, 7)
                                      };
                string[] abilities2 = {
                                          Pokemon.abilityName(p.ability1, 1),
                                          Pokemon.abilityName(p.ability1, 2),
                                          Pokemon.abilityName(p.ability1, 3),
                                          Pokemon.abilityName(p.ability1, 4),
                                          Pokemon.abilityName(p.ability1, 5),
                                          Pokemon.abilityName(p.ability1, 6),
                                          Pokemon.abilityName(p.ability1, 7)
                                      };
                names = Escape(names);
                abilities1 = Escape(abilities1);
                abilities2 = Escape(abilities2);
                dex.AppendLine("\tpokemon = new Array();");
                dex.AppendLine("\tpokemon['num'] = '" + p.DexNumber + "';");
                dex.AppendLine("\tpokemon['name'] = [ '" + names[0] + "', '" + names[1] + "', '" + names[2] + "', '" + names[3] + "', '" + names[4] + "' ];");
                dex.AppendLine("\tpokemon['mf'] = '" + p.GenderRatio + "';");
                dex.AppendLine("\tpokemon['ability1'] = [ '" + abilities1[0] + "', '" + abilities1[1] + "', '" + abilities1[2] + "', '" + abilities1[3] + "', '" + abilities1[4] + "', '" + abilities1[5] + "', '" + abilities1[5] + "' ];");
                dex.AppendLine("\tpokemon['ability2'] = [ '" + abilities2[0] + "', '" + abilities2[1] + "', '" + abilities2[2] + "', '" + abilities2[3] + "', '" + abilities2[4] + "', '" + abilities2[5] + "', '" + abilities2[5] + "' ];");
                dex.AppendLine("\tpokemon['hp'] = '" + p.BaseHp + "';");
                dex.AppendLine("\tpokemon['atk'] = '" + p.BaseAtk + "';");
                dex.AppendLine("\tpokemon['def'] = '" + p.BaseDef + "';");
                dex.AppendLine("\tpokemon['spatk'] = '" + p.BaseSpA + "';");
                dex.AppendLine("\tpokemon['spdef'] = '" + p.BaseSpD + "';");
                dex.AppendLine("\tpokemon['spe'] = '" + p.BaseSpe + "';");
                dex.AppendLine("\tpokedex.push(pokemon);");
                dex.AppendLine("");
            }

            dex.AppendLine("\treturn pokedex;");
            dex.Append("}");
            using(StreamWriter outfile = new StreamWriter("pokedex.js"))
                outfile.Write(dex.ToString());

        }
    }
}
