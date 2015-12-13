﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.Item.Item
{
    public class Item
    {
        public int id { get; set; }
        public int disenchantingSkillRank { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int stackable { get; set; }
        public int itemBind { get; set; }
        public List<BonusStat> bonusStats { get; set; }
        public List<object> itemSpells { get; set; }
        public int buyPrice { get; set; }
        public int itemClass { get; set; }
        public int itemSubClass { get; set; }
        public int containerSlots { get; set; }
        public WeaponInfo weaponInfo { get; set; }
        public int inventoryType { get; set; }
        public bool equippable { get; set; }
        public int itemLevel { get; set; }
        public int maxCount { get; set; }
        public int maxDurability { get; set; }
        public int minFactionId { get; set; }
        public int minReputation { get; set; }
        public int quality { get; set; }
        public int sellPrice { get; set; }
        public int requiredSkill { get; set; }
        public int requiredLevel { get; set; }
        public int requiredSkillRank { get; set; }
        public ItemSource itemSource { get; set; }
        public int baseArmor { get; set; }
        public bool hasSockets { get; set; }
        public bool isAuctionable { get; set; }
        public int armor { get; set; }
        public int displayInfoId { get; set; }
        public string nameDescription { get; set; }
        public string nameDescriptionColor { get; set; }
        public bool upgradable { get; set; }
        public bool heroicTooltip { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
        public List<string> availableContexts { get; set; }
        public BonusSummary bonusSummary { get; set; }
    }
}
