using Content.Shared.Body.Systems;
using Content.Shared.Dice;
using Content.Shared.Mobs.Components;

namespace Content.Server.Dice;

public sealed class DiceOfFateSystem : EntitySystem
{
    [Dependency] private readonly SharedBodySystem _body = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeNetworkEvent<DiceOfFateComponent, DiceOfFateEvent>(OnLand);
    }

    private void OnLand(EntityUid uid, DiceOfFateComponent comp, ref DiceOfFateEvent args)
    {
        var user = args.User
        switch (args.Value)
        {
            // Instant gib
            case 1:
                _body.GibBody(user, true);
                break;
            // Kill you
            case 2:
                if(!TryComp<MobStateComponent>(user, out var mobState))
                    return;
                mobState.CurrentState = MobState.Dead
                break;
            // Spawn angry mobs
            case 3:

                break;
            // Delete all weared items
            case 4:

                break;
            // Turn into monkey
            case 5:

                break;
            // Decrease movement speed
            case 6:

                break;
            // Stun, flash and damage
            case 7:

                break;
            // Explosion
            case 8:

                break;
            // Disease
            case 9:

                break;
            // Nothing
            case 10:

                break;
            // Cookies
            case 11:

                break;
            // Heal all
            case 12:

                break;
            // Money
            case 13:

                break;
            // Revolver
            case 14:

                break;
            // Spell book
            case 15:

                break;
            // Servant
            case 16:

                break;
            // Thief toolbox
            case 17:

                break;
            // AA
            case 18:

                break;
            // Decrease incoming damage
            case 19:

                break;
            // Become a wizard
            case 20:

                break;
        }
    }

    private void Spawn()
}

