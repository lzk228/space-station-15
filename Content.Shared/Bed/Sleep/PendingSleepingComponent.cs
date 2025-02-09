using Robust.Shared.GameStates;

namespace Content.Shared.Bed.Sleep;

/// <summary>
/// Makes entity wait before sleep
/// </summary>
[NetworkedComponent, RegisterComponent]
[AutoGenerateComponentState, AutoGenerateComponentPause(Dirty = true)]
public sealed partial class PendingSleepingComponent : Component
{
    /// <summary>
    /// Time in seconds before entity goes to sleep
    /// </summary>
    [DataField]
    public float PendingTime;

    /// <summary>
    ///     Cooldown time between users hand interaction.
    /// </summary>
    [DataField]
    [AutoNetworkedField, AutoPausedField]
    public TimeSpan FallAsleepTime;
}
