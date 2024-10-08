package org.shop.jesua;

import org.bukkit.plugin.java.JavaPlugin;
import org.bukkit.Bukkit;
import org.bukkit.Material;
import org.bukkit.command.Command;
import org.bukkit.command.CommandSender;
import org.bukkit.command.ConsoleCommandSender;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.block.Action;
import org.bukkit.event.player.PlayerInteractEvent;
import org.bukkit.inventory.ItemStack;
import org.bukkit.block.Block;
import org.bukkit.block.Sign;

public final class GoldShop extends JavaPlugin implements Listener{

    @Override
    public void onEnable() {
        // Register the event listener
        getServer().getPluginManager().registerEvents(this, this);
        getLogger().info("GoldShop plugin enabled for 1.8.8!");
    }

    @Override
    public void onDisable() {
        getLogger().info("GoldShop plugin disabled!");
    }

    // Command handler for /goldshop (optional for opening shop)
    @Override
    public boolean onCommand(CommandSender sender, Command cmd, String label, String[] args) {
        if (cmd.getName().equalsIgnoreCase("goldshop")) {
            if (sender instanceof Player) {
                Player player = (Player) sender;
                player.sendMessage("Use the gold shop sign to buy or sell items!");
                return true;
            } else if (sender instanceof ConsoleCommandSender) {
                sender.sendMessage("This command can only be run by a player.");
                return true;
            }
        }
        return false;
    }

    // Event Listener to handle interactions with a shop sign
    @EventHandler
    public void onPlayerInteract(PlayerInteractEvent event) {
        if (event.getAction() == Action.RIGHT_CLICK_BLOCK) {
            Block block = event.getClickedBlock();

            // Check if the block is a sign
            if (block.getState() instanceof Sign) {
                Sign sign = (Sign) block.getState();
                Player player = event.getPlayer();

                // Check if this is a Gold Shop sign
                if (sign.getLine(0).equalsIgnoreCase("[GoldShop]")) {
                    String action = sign.getLine(1); // Buy or Sell
                    String materialName = sign.getLine(2); // Material name
                    String amountStr = sign.getLine(3); // Amount to buy/sell

                    Material material = Material.matchMaterial(materialName);
                    if (material == null) {
                        player.sendMessage("§cInvalid item!");
                        return;
                    }

                    int amount;
                    try {
                        amount = Integer.parseInt(amountStr);
                    } catch (NumberFormatException e) {
                        player.sendMessage("§cInvalid amount!");
                        return;
                    }

                    if (action.equalsIgnoreCase("Buy")) {
                        handleBuy(player, material, amount);
                    } else if (action.equalsIgnoreCase("Sell")) {
                        handleSell(player, material, amount);
                    } else {
                        player.sendMessage("§cInvalid action! Use Buy or Sell.");
                    }
                }
            }
        }
    }

    // Handle buying items from the shop
    private void handleBuy(Player player, Material material, int amount) {
        ItemStack goldIngot = new ItemStack(Material.GOLD_INGOT);
        int cost = amount; // 1 item = 1 gold ingot (you can change this logic)
        ItemStack itemToBuy = new ItemStack(material, amount);

        if (player.getInventory().containsAtLeast(goldIngot, cost)) {
            player.getInventory().removeItem(new ItemStack(Material.GOLD_INGOT, cost));
            player.getInventory().addItem(itemToBuy);
            player.sendMessage("§aYou bought " + amount + " " + material.name() + "(s) for " + cost + " gold ingot(s)!");
        } else {
            player.sendMessage("§cYou don't have enough gold to buy this!");
        }
    }

    // Handle selling items to the shop
    private void handleSell(Player player, Material material, int amount) {
        ItemStack itemToSell = new ItemStack(material, amount);
        int reward = amount; // 1 item = 1 gold ingot (you can change this logic)

        if (player.getInventory().containsAtLeast(itemToSell, amount)) {
            player.getInventory().removeItem(itemToSell);
            player.getInventory().addItem(new ItemStack(Material.GOLD_INGOT, reward));
            player.sendMessage("§aYou sold " + amount + " " + material.name() + "(s) for " + reward + " gold ingot(s)!");
        } else {
            player.sendMessage("§cYou don't have enough " + material.name() + "(s) to sell!");
        }
    }
}

