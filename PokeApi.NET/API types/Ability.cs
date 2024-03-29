﻿using System;
using System.Collections.Generic;
using System.Linq;
using LitJson;

namespace PokeAPI.NET
{
    /// <summary>
    /// Represents an instance of a Pokémon Ability
    /// </summary>
    public class Ability : PokeApiType
    {
        /// <summary>
        /// Wether it should cache ability data or not
        /// </summary>
        public static bool ShouldCacheData = true;
        /// <summary>
        /// All cached abilities
        /// </summary>
        public static Dictionary<int, Ability> CachedAbilities = new Dictionary<int, Ability>();

        #region public readonly static IDictionary<string, int> IDs = new Dictionary<string, int>() { [...] };
        /// <summary>
        /// All ability string->ID maps
        /// </summary>
        public readonly static IDictionary<string, int> IDs = new Dictionary<string, int>()
        {
            {"stench", 1},
            {"drizzle", 2},
            {"speed boost", 3},
            {"battle armor", 4},
            {"sturdy", 5},
            {"damp", 6},
            {"limber", 7},
            {"sand veil", 8},
            {"static", 9},
            {"volt absorb", 10},
            {"water absorb", 11},
            {"oblivious", 12},
            {"cloud nine", 13},
            {"compoundeyes", 14},
            {"insomnia", 15},
            {"color change", 16},
            {"colour change", 16},
            {"immunity", 17},
            {"flash fire", 18},
            {"shield dust", 19},
            {"own tempo", 20},
            {"suction cups", 21},
            {"intimidate", 22},
            {"shadow tag", 23},
            {"rough skin", 24},
            {"wonder guard", 25},
            {"levitate", 26},
            {"effect spore", 27},
            {"synchronize", 28},
            {"clear body", 29},
            {"natural cure", 30},
            {"lightningrod", 31},
            {"serene grace", 32},
            {"swift swim", 33},
            {"chlorophyll", 34},
            {"illuminate", 35},
            {"trace", 36},
            {"huge power", 37},
            {"poison point", 38},
            {"inner focus", 39},
            {"magma armor", 40},
            {"water veil", 41},
            {"magnet pull", 42},
            {"soundproof", 43},
            {"rain dish", 44},
            {"sand stream", 45},
            {"pressure", 46},
            {"thick fat", 47},
            {"early bird", 48},
            {"flame body", 49},
            {"run away", 50},
            {"keen eye", 51},
            {"hyper cutter", 52},
            {"pickup", 53},
            {"truant", 54},
            {"hustle", 55},
            {"cute charm", 56},
            {"plus", 57},
            {"minus", 58},
            {"forecast", 59},
            {"sticky hold", 60},
            {"shed skin", 61},
            {"guts", 62},
            {"marvel scale", 63},
            {"liquid ooze", 64},
            {"overgrow", 65},
            {"blaze", 66},
            {"torrent", 67},
            {"swarm", 68},
            {"rock head", 69},
            {"drought", 70},
            {"arena trap", 71},
            {"vital spirit", 72},
            {"white smoke", 73},
            {"pure power", 74},
            {"shell armor", 75},
            {"air lock", 76},
            {"tangled feet", 77},
            {"motor drive", 78},
            {"rivalry", 79},
            {"steadfast", 80},
            {"snow cloak", 81},
            {"gluttony", 82},
            {"anger point", 83},
            {"unburden", 84},
            {"heatproof", 85},
            {"simple", 86},
            {"dry skin", 87},
            {"download", 88},
            {"iron fist", 89},
            {"poison heal", 90},
            {"adaptability", 91},
            {"skill link", 92},
            {"hydration", 93},
            {"solar power", 94},
            {"quick feet", 95},
            {"normalize", 96},
            {"sniper", 97},
            {"magic guard", 98},
            {"no guard", 99},
            {"stall", 100},
            {"technician", 101},
            {"leaf guard", 102},
            {"klutz", 103},
            {"mold breaker", 104},
            {"super luck", 105},
            {"aftermath", 106},
            {"anticipation", 107},
            {"forewarn", 108},
            {"unaware", 109},
            {"tinted lens", 110},
            {"filter", 111},
            {"slow start", 112},
            {"scrappy", 113},
            {"storm drain", 114},
            {"ice body", 115},
            {"solid rock", 116},
            {"snow warning", 117},
            {"honey gather", 118},
            {"frisk", 119},
            {"reckless", 120},
            {"multitype", 121},
            {"flower gift", 122},
            {"bad dreams", 123},
            {"pickpocket", 124},
            {"sheer force", 125},
            {"contrary", 126},
            {"unnerve", 127},
            {"defiant", 128},
            {"defeatist", 129},
            {"cursed body", 130},
            {"healer", 131},
            {"friend guard", 132},
            {"weak armor", 133},
            {"heavy metal", 134},
            {"light metal", 135},
            {"multiscale", 136},
            {"toxic boost", 137},
            {"flare boost", 138},
            {"harvest", 139},
            {"telepathy", 140},
            {"moody", 141},
            {"overcoat", 142},
            {"poison touch", 143},
            {"regenerator", 144},
            {"big pecks", 145},
            {"sand rush", 146},
            {"wonder skin", 147},
            {"analytic", 148},
            {"illusion", 149},
            {"imposter", 150},
            {"infiltrator", 151},
            {"mummy", 152},
            {"moxie", 153},
            {"justified", 154},
            {"rattled", 155},
            {"magic bounce", 156},
            {"sap sipper", 157},
            {"prankster", 158},
            {"sand force", 159},
            {"iron barbs", 160},
            {"zen mode", 161},
            {"victory star", 162},
            {"turboblaze", 163},
            {"teravolt", 164},
            {"aerilate", 165},
            {"aroma veil", 166},
            {"aura break", 167},
            {"bulletproof", 168},
            {"cheek pouch", 169},
            {"competitive", 170},
            {"dark aura", 171},
            {"fairy aura", 172},
            {"flower veil", 173},
            {"fur coat", 174},
            {"gale wings", 175},
            {"gooey", 176},
            {"grass pelt", 177},
            {"magician", 178},
            {"mega launcher", 179},
            {"parental bond", 180},
            {"pixilate", 181},
            {"protean", 182},
            {"refrigerate", 183},
            {"stance change", 184},
            {"strong jaw", 185},
            {"sweet veil", 186},
            {"symbiosis", 187},
            {"tough claws", 188},
            {"mountaineer", 189},
            {"wave rider", 190},
            {"skater", 191},
            {"thrust", 192},
            {"perception", 193},
            {"parry", 194},
            {"instinct", 195},
            {"dodge", 196},
            {"jagged edge", 197},
            {"frostbite", 198},
            {"tenacity", 199},
            {"pride", 200},
            {"deep sleep", 201},
            {"power nap", 202},
            {"spirit", 203},
            {"warm blanket", 204},
            {"gulp", 205},
            {"herbivore", 206},
            {"sandpit", 207},
            {"hot blooded", 208},
            {"medic", 209},
            {"life force", 210},
            {"lunchbox", 211},
            {"nurse", 212},
            {"melee", 213},
            {"sponge", 214},
            {"bodyguard", 215},
            {"hero", 216},
            {"last bastion", 217},
            {"stealth", 218},
            {"vanguard", 219},
            {"nomad", 220},
            {"sequence", 221},
            {"grass cloak", 222},
            {"celebrate", 223},
            {"lullaby", 224},
            {"calming", 225},
            {"daze", 226},
            {"frighten", 227},
            {"interference", 228},
            {"mood maker", 229},
            {"confidence", 230},
            {"fortune", 231},
            {"bonanza", 232},
            {"explode", 233},
            {"omnipotent", 234},
            {"share", 235},
            {"black hole", 236},
            {"shadow dash", 237},
            {"sprint", 238},
            {"disgust", 239},
            {"high rise", 240},
            {"climber", 241},
            {"flame boost", 242},
            {"aqua boost", 243},
            {"run up", 244},
            {"conqueror", 245},
            {"shackle", 246},
            {"decoy", 247},
            {"shield", 248}
        };
        #endregion

        /// <summary>
        /// The description of this Ability instance
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new instance from a JSON object
        /// </summary>
        /// <param name="source">The JSON object where to create the new instance from</param>
        protected override void Create(JsonData source)
        {
            Description = source["description"].ToString();
        }

        /// <summary>
        /// Creates an instance of a Ability with the given Ability
        /// </summary>
        /// <param name="ability">The Ability of the Ability to instantiate</param>
        /// <returns>The created instance of the Ability</returns>
        public static Ability GetInstance(AbilityID ability)
        {
            return GetInstance((int)ability);
        }
        /// <summary>
        /// Creates an instance of a Ability with the given name
        /// </summary>
        /// <param name="name">The name of the Ability to instantiate</param>
        /// <returns>The created instance of the Ability</returns>
        public static Ability GetInstance(string name)
        {
            return GetInstance(IDs[name.ToLower()]);
        }
        /// <summary>
        /// Creates an instance of a Ability with the given ID
        /// </summary>
        /// <param name="id">The id of the Ability to instantiate</param>
        /// <returns>The created instance of the Ability</returns>
        public static Ability GetInstance(int id)
        {
            if (CachedAbilities.ContainsKey(id))
                return CachedAbilities[id];

            Ability p = new Ability();
            Create(DataFetcher.GetAbility(id), p);

            if (ShouldCacheData)
                CachedAbilities.Add(id, p);

            return p;
        }

        /// <summary>
        /// Converts the Ability instance to an AbilityID
        /// </summary>
        /// <param name="ability">The Ability to convert from</param>
        public static implicit operator AbilityID(Ability ability)
        {
            // lazy<me>
            AbilityID ret = 0;
            Enum.TryParse(ability.Name.Replace(' ', '_'), false, out ret);
            return ret;
        }
        /// <summary>
        /// Converts the AbilityID instance to an Ability
        /// </summary>
        /// <param name="ability">The Ability to convert from</param>
        public static explicit operator Ability(AbilityID ability)
        {
            return GetInstance(ability);
        }
    }
}
