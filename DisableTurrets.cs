namespace Oxide.Plugins;

[Info("Disable Turrets", "&anhe", "1.0.0")]
[Description("Prevents player turrets from targeting other players.")]
public class DisableTurrets : RustPlugin
{
    private bool CanBeTargeted(BasePlayer player, BaseEntity entity) => (
        !player.IsAdmin &&
        (
            // World
            entity.OwnerID == 0 ||
            // Yours
            entity.OwnerID == player.userID ||
            // Team’s
            player.Team.members.Contains(entity.OwnerID) == true
        )
    );
}