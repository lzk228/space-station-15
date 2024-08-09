using Robust.Shared.Serialization;

namespace Content.Shared.Dice

[Serializable, NetSerializable]
public sealed class DiceOfFateEvent(EntityUid dice, EntityUid user, int value) : EntityEventArgs
{
    public EntityUid Dice = dice;
    public EntityUid User = user;
    public int Value = value;
}
