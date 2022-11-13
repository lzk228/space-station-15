using Content.Shared.Medical.Wounds.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.Set;

namespace Content.Shared.Damage.Prototypes
{
    /// <summary>
    ///     A single damage type. These types are grouped together in <see cref="DamageGroupPrototype"/>s.
    /// </summary>
    [Prototype("damageType")]
    [Serializable, NetSerializable]
    public sealed class DamageTypePrototype : IPrototype
    {
        [IdDataField]
        public string ID { get; } = default!;

        //TODO: Net serialize this shit!

        // --===   Wounding/Medical configuration  ===---

        //Note: these should be defined in order of severity!
        //surface wounds are wounds on skin or exposed bodyparts
        [DataField("surfaceWounds", customTypeSerializer: typeof(PrototypeIdHashSetSerializer<WoundPrototype>))]
        public HashSet<string> SurfaceWounds { get; init; } = new();

        //solid wounds are wounds that get caused when affecting a solid surface/object, such as bones or an exoskeleton
        [DataField("solidWounds", customTypeSerializer: typeof(PrototypeIdHashSetSerializer<WoundPrototype>))]
        public HashSet<string> SolidWounds { get; init; } = new();

        //internal wounds are wounds that are caused when an injury affects internal soft tissue such as organs or flesh
        [DataField("internalWounds", customTypeSerializer: typeof(PrototypeIdHashSetSerializer<WoundPrototype>))]
        public HashSet<string> InternalWounds { get; init; } = new();

        //used to calculate how much damage penetrates the skin
        [DataField("skinPenMod")] public float SkinPenModifier = 1.0f;

        //used to calculate how much damage penetrates a bodypart/flesh
        [DataField("fleshPenMod")] public float FleshPenModifier = 1.0f;

        //used to calculate how much damage propogates through a bone if it is protecting organs
        [DataField("bonePenMod")] public float BonePenModifier = 1.0f;

    }
}
