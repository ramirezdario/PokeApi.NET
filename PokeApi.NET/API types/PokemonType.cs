﻿using System;
using System.Collections.Generic;
using System.Linq;
using LitJson;

namespace PokeAPI.NET
{
    using PTIDT = Tuple<TypeID, TypeID>;

    /// <summary>
    /// Represents an instance of a Pokémon Type
    /// </summary>
    /// <remarks>Can be implicitely casted to a PokemonType enumeration (and vice versa).</remarks>
    public class PokemonType : PokeApiType
    {
        /// <summary>
        /// Wether it should cache types or not
        /// </summary>
        public static bool ShouldCacheData = true;
        /// <summary>
        /// Gets all cached types
        /// </summary>
        public static Dictionary<int, PokemonType> CachedTypes = new Dictionary<int, PokemonType>();

        #region public readonly static Dictionary<PTIDT, double> DamageMultipliers = new Dictionary<PTIDT, double>() { [...] };
        /// <summary>
        /// The damage multipliers map. The items in the tuple represent the move's type and the defending Pokémon's type, respectively.
        /// </summary>
        /// <remarks>Only works for single types.</remarks>
        public readonly static Dictionary<PTIDT, double> DamageMultipliers = new Dictionary<PTIDT, double>()
        {
            // http://bulbapedia.bulbagarden.net/wiki/Type_chart

            #region Normal
            { new PTIDT(TypeID.Normal, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Rock    ), 0.5d },
            { new PTIDT(TypeID.Normal, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Ghost   ), 0d   },
            { new PTIDT(TypeID.Normal, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Normal, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Normal, TypeID.Unknown ), 1d   },
            #endregion

            #region Fighting
            { new PTIDT(TypeID.Fighting, TypeID.Normal  ), 2d   },
            { new PTIDT(TypeID.Fighting, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Flying  ), 0.5d },
            { new PTIDT(TypeID.Fighting, TypeID.Poison  ), 0.5d },
            { new PTIDT(TypeID.Fighting, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Rock    ), 2d   },
            { new PTIDT(TypeID.Fighting, TypeID.Bug     ), 0.5d },
            { new PTIDT(TypeID.Fighting, TypeID.Ghost   ), 0d   },
            { new PTIDT(TypeID.Fighting, TypeID.Steel   ), 2d   },
            { new PTIDT(TypeID.Fighting, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Psychic ), 0.5d },
            { new PTIDT(TypeID.Fighting, TypeID.Ice     ), 2d   },
            { new PTIDT(TypeID.Fighting, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Fighting, TypeID.Dark    ), 2d   },
            { new PTIDT(TypeID.Fighting, TypeID.Fairy   ), 0.5d },
            { new PTIDT(TypeID.Fighting, TypeID.Unknown ), 1d   },
            #endregion

            #region Flying
            { new PTIDT(TypeID.Flying, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Fighting), 2d   },
            { new PTIDT(TypeID.Flying, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Rock    ), 0.5d },
            { new PTIDT(TypeID.Flying, TypeID.Bug     ), 2d   },
            { new PTIDT(TypeID.Flying, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Flying, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Grass   ), 2d   },
            { new PTIDT(TypeID.Flying, TypeID.Electric), 0.5d },
            { new PTIDT(TypeID.Flying, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Flying, TypeID.Unknown ), 1d   },
            #endregion

            #region Poison
            { new PTIDT(TypeID.Poison, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Fighting), 2d   },
            { new PTIDT(TypeID.Poison, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Poison  ), 0.5d },
            { new PTIDT(TypeID.Poison, TypeID.Ground  ), 0.5d },
            { new PTIDT(TypeID.Poison, TypeID.Rock    ), 0.5d },
            { new PTIDT(TypeID.Poison, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Ghost   ), 0.5d },
            { new PTIDT(TypeID.Poison, TypeID.Steel   ), 0d   },
            { new PTIDT(TypeID.Poison, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Grass   ), 2d   },
            { new PTIDT(TypeID.Poison, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Poison, TypeID.Fairy   ), 2d   },
            { new PTIDT(TypeID.Poison, TypeID.Unknown ), 1d   },
            #endregion

            #region Ground
            { new PTIDT(TypeID.Ground, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Flying  ), 0d   },
            { new PTIDT(TypeID.Ground, TypeID.Poison  ), 2d   },
            { new PTIDT(TypeID.Ground, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Rock    ), 2d   },
            { new PTIDT(TypeID.Ground, TypeID.Bug     ), 0.5d },
            { new PTIDT(TypeID.Ground, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Steel   ), 2d   },
            { new PTIDT(TypeID.Ground, TypeID.Fire    ), 2d   },
            { new PTIDT(TypeID.Ground, TypeID.Water   ), 0.5d },
            { new PTIDT(TypeID.Ground, TypeID.Grass   ), 2d   },
            { new PTIDT(TypeID.Ground, TypeID.Electric), 2d   },
            { new PTIDT(TypeID.Ground, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Ground, TypeID.Unknown ), 1d   },
            #endregion

            #region Rock
            { new PTIDT(TypeID.Rock, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Fighting), 0.5d },
            { new PTIDT(TypeID.Rock, TypeID.Flying  ), 2d   },
            { new PTIDT(TypeID.Rock, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Ground  ), 0.5d },
            { new PTIDT(TypeID.Rock, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Bug     ), 2d   },
            { new PTIDT(TypeID.Rock, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Rock, TypeID.Fire    ), 2d   },
            { new PTIDT(TypeID.Rock, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Ice     ), 2d   },
            { new PTIDT(TypeID.Rock, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Rock, TypeID.Unknown ), 1d   },
            #endregion

            #region Bug
            { new PTIDT(TypeID.Bug, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Fighting), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Flying  ), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Poison  ), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Ghost   ), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Fire    ), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Psychic ), 2d   },
            { new PTIDT(TypeID.Bug, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Bug, TypeID.Dark    ), 2d   },
            { new PTIDT(TypeID.Bug, TypeID.Fairy   ), 0.5d },
            { new PTIDT(TypeID.Bug, TypeID.Unknown ), 1d   },
            #endregion

            #region Ghost
            { new PTIDT(TypeID.Ghost, TypeID.Normal  ), 0d   },
            { new PTIDT(TypeID.Ghost, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Ghost   ), 2d   },
            { new PTIDT(TypeID.Ghost, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Ghost, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Psychic ), 2d   },
            { new PTIDT(TypeID.Ghost, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Dark    ), 0.5d },
            { new PTIDT(TypeID.Ghost, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Ghost, TypeID.Unknown ), 1d   },
            #endregion

            #region Steel
            { new PTIDT(TypeID.Steel, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Rock    ), 2d   },
            { new PTIDT(TypeID.Steel, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Steel, TypeID.Fire    ), 0.5d },
            { new PTIDT(TypeID.Steel, TypeID.Water   ), 0.5d },
            { new PTIDT(TypeID.Steel, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Electric), 0.5d },
            { new PTIDT(TypeID.Steel, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Ice     ), 2d   },
            { new PTIDT(TypeID.Steel, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Steel, TypeID.Fairy   ), 2d   },
            { new PTIDT(TypeID.Steel, TypeID.Unknown ), 1d   },
            #endregion

            #region Fire
            { new PTIDT(TypeID.Fire, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Ground  ), 0.5d },
            { new PTIDT(TypeID.Fire, TypeID.Rock    ), 0.5d },
            { new PTIDT(TypeID.Fire, TypeID.Bug     ), 2d   },
            { new PTIDT(TypeID.Fire, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Steel   ), 2d   },
            { new PTIDT(TypeID.Fire, TypeID.Fire    ), 0.5d },
            { new PTIDT(TypeID.Fire, TypeID.Water   ), 0.5d },
            { new PTIDT(TypeID.Fire, TypeID.Grass   ), 2d   },
            { new PTIDT(TypeID.Fire, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Ice     ), 2d   },
            { new PTIDT(TypeID.Fire, TypeID.Dragon  ), 0.5d },
            { new PTIDT(TypeID.Fire, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Fire, TypeID.Unknown ), 1d   },
            #endregion

            #region Water
            { new PTIDT(TypeID.Water, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Ground  ), 2d   },
            { new PTIDT(TypeID.Water, TypeID.Rock    ), 2d   },
            { new PTIDT(TypeID.Water, TypeID.Bug     ), 2d   },
            { new PTIDT(TypeID.Water, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Steel   ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Fire    ), 2d   },
            { new PTIDT(TypeID.Water, TypeID.Water   ), 0.5d },
            { new PTIDT(TypeID.Water, TypeID.Grass   ), 0.5d },
            { new PTIDT(TypeID.Water, TypeID.Electric), 0.5d },
            { new PTIDT(TypeID.Water, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Dragon  ), 0.5d },
            { new PTIDT(TypeID.Water, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Water, TypeID.Unknown ), 1d   },
            #endregion

            #region Grass
            { new PTIDT(TypeID.Grass, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Flying  ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Poison  ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Ground  ), 2d   },
            { new PTIDT(TypeID.Grass, TypeID.Rock    ), 2d   },
            { new PTIDT(TypeID.Grass, TypeID.Bug     ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Fire    ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Water   ), 2d   },
            { new PTIDT(TypeID.Grass, TypeID.Grass   ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Dragon  ), 0.5d },
            { new PTIDT(TypeID.Grass, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Grass, TypeID.Unknown ), 1d   },
            #endregion

            #region Electric
            { new PTIDT(TypeID.Electric, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Flying  ), 2d   },
            { new PTIDT(TypeID.Electric, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Ground  ), 0d   },
            { new PTIDT(TypeID.Electric, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Steel   ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Water   ), 2d   },
            { new PTIDT(TypeID.Electric, TypeID.Grass   ), 0.5d },
            { new PTIDT(TypeID.Electric, TypeID.Electric), 0.5d },
            { new PTIDT(TypeID.Electric, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Dragon  ), 0.5d },
            { new PTIDT(TypeID.Electric, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Electric, TypeID.Unknown ), 1d   },
            #endregion

            #region Psychic
            { new PTIDT(TypeID.Psychic, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Fighting), 2d   },
            { new PTIDT(TypeID.Psychic, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Poison  ), 2d   },
            { new PTIDT(TypeID.Psychic, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Bug     ), 0.5d },
            { new PTIDT(TypeID.Psychic, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Psychic, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Psychic ), 0.5d },
            { new PTIDT(TypeID.Psychic, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Dark    ), 0d   },
            { new PTIDT(TypeID.Psychic, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Psychic, TypeID.Unknown ), 1d   },
            #endregion

            #region Ice
            { new PTIDT(TypeID.Ice, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Flying  ), 2d   },
            { new PTIDT(TypeID.Ice, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Ground  ), 2d   },
            { new PTIDT(TypeID.Ice, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Ice, TypeID.Fire    ), 0.5d },
            { new PTIDT(TypeID.Ice, TypeID.Water   ), 0.5d },
            { new PTIDT(TypeID.Ice, TypeID.Grass   ), 2d   },
            { new PTIDT(TypeID.Ice, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Ice     ), 0.5d },
            { new PTIDT(TypeID.Ice, TypeID.Dragon  ), 2d   },
            { new PTIDT(TypeID.Ice, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Ice, TypeID.Unknown ), 1d   },
            #endregion

            #region Dragon
            { new PTIDT(TypeID.Dragon, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Dragon, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Dragon  ), 2d   },
            { new PTIDT(TypeID.Dragon, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Dragon, TypeID.Fairy   ), 0d   },
            { new PTIDT(TypeID.Dragon, TypeID.Unknown ), 1d   },
            #endregion

            #region Dark
            { new PTIDT(TypeID.Dark, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Fighting), 0.5d },
            { new PTIDT(TypeID.Dark, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Ghost   ), 2d   },
            { new PTIDT(TypeID.Dark, TypeID.Steel   ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Psychic ), 2d   },
            { new PTIDT(TypeID.Dark, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Dark, TypeID.Dark    ), 0.5d },
            { new PTIDT(TypeID.Dark, TypeID.Fairy   ), 0.5d },
            { new PTIDT(TypeID.Dark, TypeID.Unknown ), 1d   },
            #endregion

            #region Fairy
            { new PTIDT(TypeID.Fairy, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Fighting), 2d   },
            { new PTIDT(TypeID.Fairy, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Poison  ), 0.5d },
            { new PTIDT(TypeID.Fairy, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Steel   ), 0.5d },
            { new PTIDT(TypeID.Fairy, TypeID.Fire    ), 0.5d },
            { new PTIDT(TypeID.Fairy, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Dragon  ), 2d   },
            { new PTIDT(TypeID.Fairy, TypeID.Dark    ), 2d   },
            { new PTIDT(TypeID.Fairy, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Fairy, TypeID.Unknown ), 1d   },
            #endregion

            #region Unknown
            { new PTIDT(TypeID.Unknown, TypeID.Normal  ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Fighting), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Flying  ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Poison  ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Ground  ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Rock    ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Bug     ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Ghost   ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Steel   ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Fire    ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Water   ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Grass   ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Electric), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Psychic ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Ice     ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Dragon  ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Dark    ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Fairy   ), 1d   },
            { new PTIDT(TypeID.Unknown, TypeID.Unknown ), 1d   }
            #endregion
        };
        #endregion

        /// <summary>
        /// The types this PokemonType instance is ineffective against
        /// </summary>
        public List<NameUriPair> Ineffective
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// The types this PokemonType instance has no effect against
        /// </summary>
        public List<NameUriPair> NoEffect
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// The types this PokemonType instance is resistant to
        /// </summary>
        public List<NameUriPair> Resistance
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// The types this PokemonType instance is super effective against
        /// </summary>
        public List<NameUriPair> SuperEffective
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// The types this PokemonType instance is weak to
        /// </summary>
        public List<NameUriPair> Weakness
        {
            get;
            private set;
        } = new List<NameUriPair>();

        /// <summary>
        /// Gets an entry of the Ineffective list as a PokemonType
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the Ineffective list as a PokemonType</returns>
        public PokemonType RefIneffective(int index)
        {
            return GetInstance(Ineffective[index].Name);
        }
        /// <summary>
        /// Gets an entry of the NoEffect list as a PokemonType
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the NoEffect list as a PokemonType</returns>
        public PokemonType RefNoEffect(int index)
        {
            return GetInstance(NoEffect[index].Name);
        }
        /// <summary>
        /// Gets an entry of the Resistance list as a PokemonType
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the Resistance list as a PokemonType</returns>
        public PokemonType RefResistance(int index)
        {
            return GetInstance(Resistance[index].Name);
        }
        /// <summary>
        /// Gets an entry of the SuperEffective list as a PokemonType
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the SuperEffective list as a PokemonType</returns>
        public PokemonType RefSuperEffective(int index)
        {
            return GetInstance(SuperEffective[index].Name);
        }
        /// <summary>
        /// Gets an entry of the Weakness list as a PokemonType
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the Weakness list as a PokemonType</returns>
        public PokemonType RefWeakness(int index)
        {
            return GetInstance(Weakness[index].Name);
        }

        /// <summary>
        /// Creates a new instance from a JSON object
        /// </summary>
        /// <param name="source">The JSON object where to create the new instance from</param>
        protected override void Create(JsonData source)
        {
            foreach (JsonData data in source["no_effect"])
                NoEffect.Add(ParseNameUriPair(data));
            foreach (JsonData data in source["ineffective"])
                Ineffective.Add(ParseNameUriPair(data));
            foreach (JsonData data in source["resistance"])
                Resistance.Add(ParseNameUriPair(data));
            foreach (JsonData data in source["super_effective"])
                SuperEffective.Add(ParseNameUriPair(data));
            foreach (JsonData data in source["weakness"])
                Weakness.Add(ParseNameUriPair(data));
        }

        /// <summary>
        /// Creates an instance of a PokemonType with the given name.
        /// </summary>
        /// <param name="name">The name of the PokemonType to instantiate</param>
        /// <returns>The created instance of the PokemonType</returns>
        /// <remarks>Only works on a single-type PokemonType.</remarks>
        public static PokemonType GetInstance(string name)
        {
            if (name.Trim() == "???")
                name = "Unknown";

            if (Enum.TryParse(name.Trim(), true, out TypeID id))
                return GetInstance((int)id);

            return null;
        }
        /// <summary>
        /// Creates an instance of a PokemonType with the given PokemonTypeID
        /// </summary>
        /// <param name="type">The type of the PokemonType to instantiate</param>
        /// <returns>The created instance of the PokemonType</returns>
        public static PokemonType GetInstance(TypeID type)
        {
            return GetInstance((int)type);
        }
        /// <summary>
        /// Creates an instance of a PokemonType with the given PokemonTypeFlags
        /// </summary>
        /// <param name="flags">The type of the PokemonType to instantiate</param>
        /// <returns>The created instance of the PokemonType</returns>
        public static PokemonType GetInstance(TypeFlags flags)
        {
            return GetInstance(flags.ID());
        }
        /// <summary>
        /// Creates an instance of a PokemonType with the given ID
        /// </summary>
        /// <param name="id">The id of the PokemonType to instantiate</param>
        /// <returns>The created instance of the PokemonType</returns>
        public static PokemonType GetInstance(int id)
        {
            if (CachedTypes.ContainsKey(id))
                return CachedTypes[id];

            PokemonType p = new PokemonType();
            if (id == 0)
            {
                p.Created = p.LastModified = DateTime.Now;

                p.ID = 0;
                p.Name = "???";

                p.Ineffective    = new List<NameUriPair>();
                p.NoEffect       = new List<NameUriPair>();
                p.Resistance     = new List<NameUriPair>();
                p.SuperEffective = new List<NameUriPair>();
                p.Weakness       = new List<NameUriPair>();

                p.ResourceUri = new Uri("http://www.pokeapi.co/");
            }
            else
                Create(DataFetcher.GetType(id), p);

            if (ShouldCacheData)
                CachedTypes.Add(id, p);

            return p;
        }

        /// <summary>
        /// Gets the damage multiplier of the given attacking and defending types.
        /// </summary>
        /// <param name="attacking">The attacking type.</param>
        /// <param name="defending">The defending type. Can be multiple types.</param>
        /// <returns>The damage multiplier of the given attacking and defending types.</returns>
        public static double GetDamageMultiplier(TypeID attacking, TypeFlags defending)
        {
            List<TypeID> analyzed = defending.AnalyzeIDs();

            double ret = 1d;

            for (int i = 0; i < analyzed.Count; i++)
                ret *= DamageMultipliers[new PTIDT(attacking, analyzed[i])];

            return ret;
        }

        /// <summary>
        /// Combines multiple PokemonTypes into one PokemonTypeID.
        /// </summary>
        /// <param name="types">The PokemonTypes to combine.</param>
        /// <returns>The combined PokemonTypes as a PokemonTypeID.</returns>
        public static TypeFlags Combine(params PokemonType[] types)
        {
            TypeFlags ret = 0;

            for (int i = 0; i < types.Length; i++)
                ret |= types[i];

            return ret;
        }
        /// <summary>
        /// Combines multiple PokemonTypes into one PokemonTypeID.
        /// </summary>
        /// <param name="types">The PokemonTypes to combine.</param>
        /// <returns>The combined PokemonTypes as a PokemonTypeID.</returns>
        public static TypeFlags Combine(IEnumerable<PokemonType> types)
        {
            return Combine(types.ToArray());
        }

        /// <summary>
        /// Converts a PokemonType into a PokemonType
        /// </summary>
        /// <param name="type">The PokemonType to convert from</param>
        public static implicit operator TypeFlags(PokemonType type)
        {
            return (TypeFlags)Math.Pow(2, type.ID - 1);
        }
        /// <summary>
        /// Converts a PokemonType into a PokemonType
        /// </summary>
        /// <param name="type">The PokemonType to convert from</param>
        public static explicit operator PokemonType(TypeFlags type)
        {
            return GetInstance(type);
        }
        /// <summary>
        /// Converts a PokemonType into a PokemonType
        /// </summary>
        /// <param name="type">The PokemonType to convert from</param>
        public static implicit operator TypeID(PokemonType type)
        {
            return (TypeID)type.ID;
        }
        /// <summary>
        /// Converts a PokemonType into a PokemonType
        /// </summary>
        /// <param name="type">The PokemonType to convert from</param>
        public static explicit operator PokemonType(TypeID type)
        {
            return GetInstance(type);
        }
    }
}
