namespace Oxide.Plugins;

[Info("Disable Turrets", "&anhe", "1.0.1")]
[Description("Prevents player turrets from targeting other players.")]
public class DisableTurrets : RustPlugin
{
    private object CanBeTargeted(BaseCombatEntity target, AutoTurret entity)
    {
        if (entity.OwnerID == 0)
            return null;
        
        return (
            target is BasePlayer player &&
            (
                // Yours
                entity.OwnerID == player.userID ||
                // Team’s
                player.Team.members.Contains(entity.OwnerID) == true
            )
        );
    }

    private object CanBeTargeted(BasePlayer player, FlameTurret entity)
    {
        if (entity.OwnerID == 0)
            return null;

        return (
            // Yours
            entity.OwnerID == player.userID ||
            // Team’s
            player.Team.members.Contains(entity.OwnerID) == true
        );
    }
}