using System.Collections.Generic;
using CJBCheatsMenu.Framework.Components;
using StardewValley;
using StardewValley.Menus;

namespace CJBCheatsMenu.Framework.Cheats.PlayerAndTools;

/// <summary>A cheat which adds various numbers of casino coins to the player.</summary>
internal class AddCasinoCoinsCheat : BaseCheat
{
    /*********
    ** Public methods
    *********/
    /// <inheritdoc />
    public override IEnumerable<OptionsElement> GetFields(CheatContext context)
    {
        foreach (int amount in new[] { 100, 1_000, 10_000 })
        {
            yield return new CheatsOptionsButton(
                label: I18n.Add_AmountOther(amount: Utility.getNumberWithCommas(amount)),
                slotWidth: context.SlotWidth,
                toggle: () => this.AddCoins(amount)
            );
        }
    }


    /*********
    ** Private methods
    *********/
    /// <summary>Add an amount to the player's club coin balance.</summary>
    /// <param name="amount">The amount to add.</param>
    private void AddCoins(int amount)
    {
        Game1.player.clubCoins += amount;
        Game1.playSound("coin");
    }
}
