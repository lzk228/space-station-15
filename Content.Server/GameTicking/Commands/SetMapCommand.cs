using System.Linq;
using Content.Server.Administration;
using Content.Server.Maps;
using Content.Shared.Administration;
using Content.Shared.CCVar;
using Robust.Shared.Configuration;
using Robust.Shared.Console;
using Robust.Shared.Prototypes;

namespace Content.Server.GameTicking.Commands
{
    [AdminCommand(AdminFlags.Round)]
    sealed class SetMapCommand : IConsoleCommand
    {
        [Dependency] private readonly IConfigurationManager _configurationManager = default!;
        [Dependency] private readonly IEntityManager _entityManager = default!;

        public string Command => "setmap";
        public string Description => Loc.GetString("setmap-command-description");
        public string Help => Loc.GetString("setmap-command-help");

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (args.Length != 1)
            {
                shell.WriteLine(Loc.GetString("setmap-command-need-one-argument"));
                return;
            }
//// CODE

            var ticker = _entityManager.EntitySysManager.GetEntitySystem<GameTicker>();
            if (ticker.CanUpdateMap())
            {
                if (_gameMapManager.TrySelectMapIfEligible(picked.ID))
                {
                    ticker.UpdateInfoText();
                }
            }
            else
            {
                if (ticker.RoundPreloadTime <= TimeSpan.Zero)
                {
                    shell.WriteLine(Loc.GetString("ui-vote-map-notlobby"));
                }
                else
                {
                    var timeString = $"{ticker.RoundPreloadTime.Minutes:0}:{ticker.RoundPreloadTime.Seconds:00}";
                    shell.WriteLine(Loc.GetString("ui-vote-map-notlobby-time", ("time", timeString)));
                }
            }

//// CODE
        }

        public CompletionResult GetCompletion(IConsoleShell shell, string[] args)
        {
            if (args.Length == 1)
            {
                var options = IoCManager.Resolve<IPrototypeManager>()
                    .EnumeratePrototypes<GameMapPrototype>()
                    .Select(p => new CompletionOption(p.ID, p.MapName))
                    .OrderBy(p => p.Value);

                return CompletionResult.FromHintOptions(options, Loc.GetString("setmap-command-arg-map"));
            }

            return CompletionResult.Empty;
        }
    }
}
