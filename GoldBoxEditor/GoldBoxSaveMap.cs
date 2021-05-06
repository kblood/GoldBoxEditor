using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxSaveMap
    {
        public int nextCharacterAddress          {get;set;}
        public int effectsAddress                {get;set;}
        public int itemsAddress                  {get;set;}
        public int equippedWeaponAddress         {get;set;}
        public int equippedShieldAddress         {get;set;}
        public int equippedArmorAddress          {get;set;}
        public int equippedGauntletsAddress      {get;set;}
        public int equippedHelmAddress           {get;set;}
        public int equippedBeltAddress           {get;set;}
        public int equippedRobeAddress           {get;set;}
        public int equippedCloakAddress          {get;set;}
        public int equippedBootsAddress          {get;set;}
        public int equippedRing1Address          {get;set;}
        public int equippedRing2Address          {get;set;}
        public int equippedArrowAddress          {get;set;}
        public int equippedBoltAddress           {get;set;}
        public int combatAddress                 { get;set;}
        public int name                      {get;set;}
        public int strength                    {get;set;}
        public int original_strength           {get;set;}
        public int intelligence                {get;set;}
        public int original_intelligence       {get;set;}
        public int wisdom                      {get;set;}
        public int original_wisdom             {get;set;}
        public int dexterity                   {get;set;}
        public int original_dexterity          {get;set;}
        public int constitution                {get;set;}
        public int original_constitution       {get;set;}
        public int charisma                    {get;set;}
        public int original_charisma           {get;set;}
        public int strengthExpanded             {get;set;}
        public int original_strengthExpanded    {get;set;}
        public int experience                   {get;set;}
        public int experienceMax                {get;set;}
        public int experienceAward              {get;set;}
        public int steel                        {get;set; }
        public int gems                         {get;set;}
        public int jewelery                     {get;set;}
        public int age                          {get;set;}
        public int encumberance                 {get;set;}
        public int race                        {get;set;}
        public int char_class                  {get;set;}
        public int gender                      {get;set;}
        public int alignment                   {get;set;}
        public int god                   {get;set; }
        public int knight                   {get;set; }
        public int robe                   {get;set; }
        public int status                      { get; set; }
        public int highestHitpoints            { get; set; }
        public int highestHPS               { get; set; }
        public int hitpointsRolled            { get; set; }
        public int hitpointsCurrent            { get; set; }
        public int movementBase          { get; set; }
        public int movementCurrent          { get; set; }
        public int acBase { get; set; }
        public int acCurrent { get; set; }
        public int thac0base               { get; set; }
        public int thac0Current              { get; set; }
        public int cureDiseaseCount          { get; set; }
        public int savethrow1              { get; set; }
        public int savethrow2              { get; set; }
        public int savethrow3              { get; set; }
        public int savethrow4              { get; set; }
        public int savethrow5              { get; set; }
        public int levelHighest1          { get; set; }
        public int levelHighest2            { get; set; }
        public int thief1          { get; set; }
        public int thief2 { get; set; }
        public int thief3 { get; set; }
        public int thief4 { get; set; }
        public int thief5 { get; set; }
        public int thief6 { get; set; }
        public int thief7 { get; set; }
        public int thief8 { get; set; }
        public int highestLevelCleric { get; set; }
        public int highestLevelKnight { get; set; }
        public int highestLevelFighter { get; set; }
        public int highestLevelPaladin { get; set; }
        public int highestLevelRanger { get; set; }
        public int highestLevelMage { get; set; }
        public int highestLevelThief { get; set; }
        public int levelCleric { get; set; }
        public int levelKnight { get; set; }
        public int levelFighter { get; set; }
        public int levelPaladin { get; set; }
        public int levelRanger { get; set; }
        public int levelMage { get; set; }
        public int levelThief { get; set; }
        public int formerLevelCleric { get; set; }
        public int formerLevelKnight { get; set; }
        public int formerLevelFighter { get; set; }
        public int formerLevelPaladin { get; set; }
        public int formerLevelRanger { get; set; }
        public int formerLevelMage { get; set; }
        public int formerLevelThief { get; set; }
        public int attacks1 { get; set; }
        public int attacks2 { get; set; }
        public int currentAttacks1 { get; set; }
        public int currentAttacks2 { get; set; }
        public int currentRolls { get; set; }
        public int currentRolls2 { get; set; }
        public int currentDice { get; set; }
        public int currentDice2 { get; set; }
        public int currentModifier { get; set; }
        public int currentModifier2 { get; set; }
        public int unarmedRolls { get; set; }
        public int unarmedRolls2 { get; set; }
        public int unarmedDice { get; set; }
        public int unarmedDice2 { get; set; }
        public int unarmedModifier { get; set; }
        public int unarmedModifier2 { get; set; }
        public int itemLimits { get; set; }
        public int numberOfItems { get; set; }
        public int flags1 { get; set; }
        public int flags2 { get; set; }
        public int saveBonus { get; set; }
        public int MagicResistance { get; set; }
        public int memorizedSpells { get; set; }
        public int knownSpells { get; set; }
        public int clericSpells1 { get; set; }
        public int clericSpells2 { get; set; }
        public int clericSpells3 { get; set; }
        public int clericSpells4 { get; set; }
        public int clericSpells5 { get; set; }
        public int clericSpells6 { get; set; }
        public int clericSpells7 { get; set; }
        public int druidSpells1 { get; set; }
        public int druidSpells2 { get; set; }
        public int druidSpells3 { get; set; }
        public int mageSpells1 { get; set; }
        public int mageSpells2 { get; set; }
        public int mageSpells3 { get; set; }
        public int mageSpells4 { get; set; }
        public int mageSpells5 { get; set; }
        public int mageSpells6 { get; set; }
        public int mageSpells7 { get; set; }
        public int mageSpells8 { get; set; }
        public int mageSpells9 { get; set; }
        public int levelUndead { get; set; }
        public int ableToTrain { get; set; }
        public int npc { get; set; }
        public int icon { get; set; }
        public int iconDimensions { get; set; }
        public int iconColor1Body      { get; set; }   
        public int iconColor2Body      { get; set; }   
        public int iconColor1Arm       { get; set; }   
        public int iconColor2Arm       { get; set; }   
        public int iconColor1Leg       { get; set; }   
        public int iconColor2Leg       { get; set; }   
        public int iconColor1Hair      { get; set; }   
        public int iconColor2Face      { get; set; }   
        public int iconColor1Shield    { get; set; }   
        public int iconColor2Shield    { get; set; }   
        public int iconColor1Weapon    { get; set; }   
        public int iconColor2Weapon     { get; set; }
        public int handsEquipped        { get; set; }
        public int enabled              { get; set; }
        public int hostile              { get; set; }
        public int quickfight           { get; set; }
        public int itemsAndEffects      { get; set; }
        public byte itemByteLength       { get; set; }
        public byte effectByteLength     { get; set; }
        public byte knownSpellsByteLength { get; set; }
        public byte memorizedSpellsByteLength { get; set; }

    }
}
