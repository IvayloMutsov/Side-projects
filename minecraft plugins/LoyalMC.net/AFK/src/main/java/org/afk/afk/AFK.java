package org.afk.afk;

import org.bukkit.Bukkit;
import org.bukkit.Location;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerMoveEvent;
import org.bukkit.plugin.java.JavaPlugin;
import org.bukkit.scheduler.BukkitRunnable;

import java.util.HashMap;
import java.util.Map;

public class AFK extends JavaPlugin implements Listener {
    private final Map<Player, Long> afkPlayers = new HashMap<>();
    private final long afkThreshold = 60000; // 1 minute in milliseconds
    private final long rewardInterval = 60000; // 1 minute in milliseconds

    @Override
    public void onEnable() {
        Bukkit.getPluginManager().registerEvents(this, this);
        getLogger().info("AFK Pool Plugin Enabled!");

        new BukkitRunnable() {
            @Override
            public void run() {
                checkAfkPlayers();
            }
        }.runTaskTimer(this, 20L, 20L); // Check every second

        new BukkitRunnable() {
            @Override
            public void run() {
                rewardAfkPlayers();
            }
        }.runTaskTimer(this, rewardInterval / 50, rewardInterval / 50); // Reward every minute
    }

    @Override
    public void onDisable() {
        getLogger().info("AFK Pool Plugin Disabled!");
    }

    @EventHandler
    public void onPlayerMove(PlayerMoveEvent event) {
        Player player = event.getPlayer();
        Location poolLocation = new Location(player.getWorld(), 100, 64, 100); // Replace with your AFK pool location

        if (player.getLocation().distance(poolLocation) <= 5) { // Check if in range
            afkPlayers.put(player, System.currentTimeMillis());
        } else {
            afkPlayers.remove(player);
        }
    }

    private void checkAfkPlayers() {
        long currentTime = System.currentTimeMillis();
        for (Map.Entry<Player, Long> entry : afkPlayers.entrySet()) {
            Player player = entry.getKey();
            long lastMoveTime = entry.getValue();

            if (currentTime - lastMoveTime >= afkThreshold) {
                player.sendMessage("You are now marked as AFK!");
            }
        }
    }

    private void rewardAfkPlayers() {
        long currentTime = System.currentTimeMillis();
        for (Player player : afkPlayers.keySet()) {
            long lastMoveTime = afkPlayers.get(player);
            if (currentTime - lastMoveTime >= afkThreshold) {
                player.getInventory().addItem(new org.bukkit.inventory.ItemStack(Material.GOLD_INGOT, 1));
                player.sendMessage("You have received 1 gold ingot for being AFK!");
            }
        }
    }
}

