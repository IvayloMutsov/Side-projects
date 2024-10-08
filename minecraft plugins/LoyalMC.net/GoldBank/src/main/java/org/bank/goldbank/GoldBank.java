package org.bank.goldbank;

import org.bukkit.Bukkit;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.configuration.file.FileConfiguration;
import org.bukkit.configuration.file.YamlConfiguration;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerInteractEvent;
import org.bukkit.plugin.java.JavaPlugin;
import org.bukkit.Material;

import java.io.File;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import java.util.Objects;
import java.util.UUID;

public class GoldBank extends JavaPlugin implements Listener {

    private Map<UUID, Integer> goldBalances = new HashMap<>();
    private FileConfiguration config;

    @Override
    public void onEnable() {
        getCommand("gold").setExecutor(new GoldBankCommand());
        Bukkit.getServer().getPluginManager().registerEvents(this, this);

        if (!getDataFolder().exists()) {
            getDataFolder().mkdir();
        }

        if (!new File(getDataFolder(), "config.yml").exists()) {
            try {
                new File(getDataFolder(), "config.yml").createNewFile();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        config = YamlConfiguration.loadConfiguration(new File(getDataFolder(), "config.yml"));

        // Load gold balances from config
        for (String key : config.getKeys(false)) {
            UUID uuid = UUID.fromString(key);
            int balance = config.getInt(key);
            goldBalances.put(uuid, balance);
        }
    }

    @Override
    public void onDisable() {
        // Save gold balances to config
        for (Map.Entry<UUID, Integer> entry : goldBalances.entrySet()) {
            config.set(entry.getKey().toString(), entry.getValue());
        }

        try {
            config.save(new File(getDataFolder(), "config.yml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private class GoldBankCommand implements CommandExecutor {
        @Override
        public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
            if (!(sender instanceof Player)) {
                sender.sendMessage("Only players can use this command!");
                return true;
            }

            Player player = (Player) sender;

            if (args.length == 0) {
                // Display gold balance
                player.sendMessage("Your current gold balance is: " + getGoldBalance(player));
                return true;
            } else if (args[0].equalsIgnoreCase("deposit")) {
                // Deposit gold
                if (args.length < 2) {
                    player.sendMessage("Usage: /gold deposit <amount>");
                    return true;
                }

                int amount = Integer.parseInt(args[1]);
                depositGold(player, amount);
                return true;
            } else if (args[0].equalsIgnoreCase("withdraw")) {
                // Withdraw gold
                if (args.length < 2) {
                    player.sendMessage("Usage: /gold withdraw <amount>");
                    return true;
                }

                int amount = Integer.parseInt(args[1]);
                withdrawGold(player, amount);
                return true;
            }

            return false;
        }
    }

    private int getGoldBalance(Player player) {
        return goldBalances.getOrDefault(player.getUniqueId(), 0);
    }

    private void depositGold(Player player, int amount) {
        goldBalances.put(player.getUniqueId(), getGoldBalance(player) + amount);
        player.sendMessage("Deposited " + amount + " gold. Your new balance is: " + getGoldBalance(player));
    }

    private void withdrawGold(Player player, int amount) {
        if (getGoldBalance(player) < amount) {
            player.sendMessage("You don't have enough gold to withdraw that amount!");
            return;
        }

        goldBalances.put(player.getUniqueId(), getGoldBalance(player) - amount);
        player.sendMessage("Withdrew " + amount + " gold. Your new balance is: " + getGoldBalance(player));
    }

    @EventHandler
    public void onPlayerInteract(PlayerInteractEvent event) {
        // Implement gold deposit/withdrawal logic on player interaction
        Player player = event.getPlayer();
        if (event.getClickedBlock().getType() == Material.GOLD_BLOCK) {
            if (event.getAction().toString().contains("RIGHT_CLICK_BLOCK")) {
                // Deposit gold
                depositGold(player, 1);
            } else if (event.getAction().toString().contains("LEFT_CLICK_BLOCK")) {
                // Withdraw gold
                withdrawGold(player, 1);
            }
        }
    }
}