using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor
{
    public class GoldBoxCharacter
    {
        public string   nextCharacterAddress          {get;set;}
        public string   effectsAddress                {get;set;}
        public string   itemsAddress                  {get;set;}
        public string   equippedWeaponAddress         {get;set;}
        public string   equippedShieldAddress         {get;set;}
        public string   equippedArmorAddress          {get;set;}
        public string   equippedGauntletsAddress      {get;set;}
        public string   equippedHelmAddress           {get;set;}
        public string   equippedBeltAddress           {get;set;}
        public string   equippedRobeAddress           {get;set;}
        public string   equippedCloakAddress          {get;set;}
        public string   equippedBootsAddress          {get;set;}
        public string   equippedRing1Address          {get;set;}
        public string   equippedRing2Address          {get;set;}
        public string   equippedArrowAddress          {get;set;}
        public string   equippedBoltAddress           {get;set;}
        public string   combatAddress                 { get;set;}
        public string   name                           {get;set;}
        public byte     strength                      {get;set;}
        public byte     original_strength             {get;set;}
        public byte     intelligence                  {get;set;}
        public byte     original_intelligence         {get;set;}
        public byte     wisdom                        {get;set;}
        public byte     original_wisdom               {get;set;}
        public byte     dexterity                     {get;set;}
        public byte     original_dexterity            {get;set;}
        public byte     constitution                  {get;set;}
        public byte     original_constitution         {get;set;}
        public byte     charisma                      {get;set;}
        public byte     original_charisma             {get;set;}
        public int      strengthExpanded               {get;set;}
        public int      original_strengthExpanded      {get;set;}
        public int      experience                     {get;set;}
        public int      experienceMax                  {get;set;}
        public Int16    experienceAward               {get;set;}
        public Int16    steel                          {get;set; }
        public Int16    gems                           {get;set;}
        public Int16    jewelery                       {get;set;}
        public Int16    age                            {get;set;}
        public Int16    encumberance                   {get;set;}
        public byte     race                          {get;set;}
        public byte     char_class                    {get;set;}
        public byte     gender                        {get;set;}
        public byte     alignment                     {get;set;}
        public byte     god                            {get;set; }
        public byte     knight                            {get;set; }
        public byte     robe                            {get;set; }
        public byte     status                        { get; set; }
        public byte     highestHitpoints              { get; set; }
        public byte     hitpointsRolled              { get; set; }
        public byte     hitpointsCurrent              { get; set; }
        public byte     movementBase                    { get; set; }
        public byte     movementCurrent                  { get; set; }
        public byte     acBase                          { get; set; }
        public byte     acCurrent                       { get; set; }
        public byte     thac0base                       { get; set; }
        public byte     thac0Current                        { get; set; }
        public byte     cureDiseaseCount                    { get; set; }
        public byte     savethrow1                        { get; set; }
        public byte     savethrow2                        { get; set; }
        public byte     savethrow3                        { get; set; }
        public byte     savethrow4                        { get; set; }
        public byte     savethrow5                        { get; set; }
        public byte     levelHighest1                    { get; set; }
        public byte     levelHighest2                      { get; set; }
        public byte     thief1                            { get; set; }
        public byte     thief2                            { get; set; }
        public byte     thief3                            { get; set; }
        public byte     thief4                            { get; set; }
        public byte     thief5                            { get; set; }
        public byte     thief6                            { get; set; }
        public byte     thief7                            { get; set; }
        public byte     thief8                            { get; set; }
        public byte     highestLevelCleric                { get; set; }
        public byte     highestLevelKnight                { get; set; }
        public byte     highestLevelFighter                { get; set; }
        public byte     highestLevelPaladin                { get; set; }
        public byte     highestLevelRanger                { get; set; }
        public byte     highestLevelMage                  { get; set; }
        public byte     highestLevelThief                  { get; set; }
        public byte     levelCleric                       { get; set; }
        public byte     levelKnight                       { get; set; }
        public byte     levelFighter                       { get; set; }
        public byte     levelPaladin                       { get; set; }
        public byte     levelRanger                       { get; set; }
        public byte     levelMage                         { get; set; }
        public byte     levelThief                         { get; set; }
        public byte     formerLevelCleric                     { get; set; }
        public byte     formerLevelKnight                     { get; set; }
        public byte     formerLevelFighter                { get; set; }
        public byte     formerLevelPaladin                { get; set; }
        public byte     formerLevelRanger                 { get; set; }
        public byte     formerLevelMage                   { get; set; }
        public byte     formerLevelThief                   { get; set; }
        public byte     attacks1                          { get; set; }
        public byte     attacks2                          { get; set; }
        public byte     currentAttacks1                   { get; set; }
        public byte     currentAttacks2                   { get; set; }
        public byte     currentRolls                      { get; set; }
        public byte     currentRolls2                      { get; set; }
        public byte     currentDice                       { get; set; }
        public byte     currentDice2                       { get; set; }
        public byte     currentModifier                       { get; set; }
        public byte     currentModifier2                       { get; set; }
        public byte     unarmedRolls                        { get; set; }
        public byte     unarmedRolls2                        { get; set; }
        public byte     unarmedDice                         { get; set; }
        public byte     unarmedDice2                         { get; set; }
        public byte     unarmedModifier                     { get; set; }
        public byte     unarmedModifier2                     { get; set; }
        public byte     itemLimits                          { get; set; }
        public byte     numberOfItems                       { get; set; }
        public byte     flags1                              { get; set; }
        public byte     flags2                              { get; set; }
        public byte     saveBonus                           { get; set; }
        public byte     MagicResistance                     { get; set; }
        public byte[]   memorizedSpells                       { get; set; }
        public byte[]   knownSpells                         { get; set; }
        public byte     clericSpells1                         { get; set; }
        public byte     clericSpells2                         { get; set; }
        public byte     clericSpells3                         { get; set; }
        public byte     clericSpells4                         { get; set; }
        public byte     clericSpells5                         { get; set; }
        public byte     clericSpells6                         { get; set; }
        public byte     clericSpells7                         { get; set; }
        public byte     druidSpells1                            { get; set; }
        public byte     druidSpells2                            { get; set; }
        public byte     druidSpells3                            { get; set; }
        public byte     mageSpells1                         { get; set; }
        public byte     mageSpells2                         { get; set; }
        public byte     mageSpells3                         { get; set; }
        public byte     mageSpells4                         { get; set; }
        public byte     mageSpells5                         { get; set; }
        public byte     mageSpells6                         { get; set; }
        public byte     mageSpells7                         { get; set; }
        public byte     mageSpells8                         { get; set; }
        public byte     mageSpells9                         { get; set; }
        public byte     levelUndead                         { get; set; }
        public byte     ableToTrain                         { get; set; }
        public byte     npc                                 { get; set; }
        public byte     icon                                 { get; set; }
        public byte     iconDimensions                          { get; set; }
        public byte     iconColor1Body                      { get; set; }   
        public byte     iconColor2Body                      { get; set; }   
        public byte     iconColor1Arm                       { get; set; }   
        public byte     iconColor2Arm                       { get; set; }   
        public byte     iconColor1Leg                       { get; set; }   
        public byte     iconColor2Leg                       { get; set; }   
        public byte     iconColor1Hair                      { get; set; }   
        public byte     iconColor2Face                      { get; set; }   
        public byte     iconColor1Shield                    { get; set; }   
        public byte     iconColor2Shield                    { get; set; }   
        public byte     iconColor1Weapon                    { get; set; }   
        public byte     iconColor2Weapon                     { get; set; }
        public byte     handsEquipped                       { get; set; }
        public byte     enabled                             { get; set; }
        public byte     hostile                             { get; set; }
        public byte     quickfight                          { get; set; }
        public byte[]   itemsAndEffects                     { get; set; }
        public List<byte[]> items                           { get; set; }
        public List<byte[]> effects                         { get; set; }
    }
}
