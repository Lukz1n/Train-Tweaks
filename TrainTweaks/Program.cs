using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using TrainTweaks.Core;
using TrainTweaks.Games;
using TrainTweaks.Operations;
using Spectre.Console;

namespace TrainTweaks.ConsoleApp;

internal static class Program
{
    private static readonly string[] Tools =
    [
        nameof(CriarPontoRestauracaoEBackup),
        nameof(AbrirDnsJumper),
        nameof(RenovarConexaoDeRede),
        nameof(LiberarMemoriaRam),
        nameof(AbrirAutoruns),
        nameof(AbrirArquivoDebloater)
    ];

    private static readonly string[] Gpu =
    [
        nameof(OtimizarAmd),
        nameof(OtimizarNvidia),
        nameof(OtimizarIntel),
        nameof(ReverterOtimizacoesGpu)
    ];

    private static readonly string[] Fixes =
    [
        nameof(FixBluetooth),
        nameof(FixReativarWifi),
        nameof(FixAudio),
        nameof(FixLojaWindows),
        nameof(FixNotebookModoAviao),
        nameof(FixPcNaoDesliga),
        nameof(FixArquivosCorrompidos),
        nameof(FixRedeInternet),
        nameof(FixErroDisco),
        nameof(FixMenuIniciarBarraTarefas),
        nameof(FixServicosXbox),
        nameof(FixWindowsUpdate),
        nameof(FixXboxApp),
        nameof(FixCamera),
        nameof(FixMicrofone),
        nameof(FixDefender),
        nameof(FixWindowsSearch),
        nameof(FixAplicativosWindows),
        nameof(FixWindowsHello),
        nameof(FixImpressora),
        nameof(LimparFilaImpressao),
        nameof(FixExplorador),
        nameof(FixIconesMiniaturas),
        nameof(FixCopiarColar),
        nameof(FixDns),
        nameof(FixWindowsInstaller),
        nameof(FixTelaPreta),
        nameof(FixAltoUsoCpu),
        nameof(FixAltoUsoRam),
        nameof(FixDisco100),
        nameof(FixDll),
        nameof(RepararAplicativoCamera)
    ];

    public static async Task<int> Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Title = "Train Tweaks";

        if (args.Any(x => string.Equals(x, "--cleaner-run", StringComparison.OrdinalIgnoreCase)))
        {
            var result = await AutoCleaner.RunAsync();
            return result.Errors == 0 ? 0 : 1;
        }

        if (!OperatingSystem.IsWindows())
        {
            AnsiConsole.MarkupLine("[bold red]Este programa só pode ser executado no Windows.[/]");
            return 1;
        }

        await MainMenuAsync();
        return 0;
    }

    private static async Task MainMenuAsync()
    {
        var operations = LoadOperations();
        var games = operations.Where(x => x.GetType().Namespace == typeof(PriorizarSevenDaysToDie).Namespace).ToList();
        var toolItems = SelectByTypeNames(operations, Tools);
        var gpuItems = SelectByTypeNames(operations, Gpu);
        var fixItems = SelectByTypeNames(operations, Fixes);
        var categorized = Tools.Concat(Gpu).Concat(Fixes).ToHashSet(StringComparer.Ordinal);
        var windowsItems = operations
            .Where(x => !categorized.Contains(x.GetType().Name) && x.GetType().Namespace != typeof(PriorizarSevenDaysToDie).Namespace)
            .OrderBy(x => x.Name, StringComparer.CurrentCultureIgnoreCase)
            .ToList();

        while (true)
        {
            DrawHeader("PAINEL PRINCIPAL");
            var choice = Select("Escolha uma área", new[]
            {
                "Otimizações do Windows",
                "Perfis de GPU",
                "Prioridade de jogos",
                "Correções e diagnósticos",
                "Ferramentas do BAT",
                "Auto Cleaner semanal",
                "Sair"
            });

            switch (choice)
            {
                case "Otimizações do Windows":
                    await OperationMenuAsync("AJUSTES DO WINDOWS", windowsItems);
                    break;
                case "Perfis de GPU":
                    await OperationMenuAsync("AMD / NVIDIA / INTEL", gpuItems);
                    break;
                case "Prioridade de jogos":
                    await GameMenuAsync(games);
                    break;
                case "Correções e diagnósticos":
                    await OperationMenuAsync("CORREÇÕES E DIAGNÓSTICOS", fixItems);
                    break;
                case "Ferramentas do BAT":
                    await OperationMenuAsync("FERRAMENTAS", toolItems);
                    break;
                case "Auto Cleaner semanal":
                    await CleanerMenuAsync();
                    break;
                default:
                    return;
            }
        }
    }

    private static List<WindowsOperation> LoadOperations()
    {
        return typeof(WindowsOperation).Assembly
            .GetTypes()
            .Where(type => !type.IsAbstract && typeof(WindowsOperation).IsAssignableFrom(type))
            .Select(type => (WindowsOperation)Activator.CreateInstance(type)!)
            .OrderBy(operation => operation.GetType().Name, StringComparer.Ordinal)
            .ToList();
    }

    private static List<WindowsOperation> SelectByTypeNames(IEnumerable<WindowsOperation> all, IEnumerable<string> names)
    {
        var set = names.ToHashSet(StringComparer.Ordinal);
        return all.Where(operation => set.Contains(operation.GetType().Name)).OrderBy(operation => operation.Name).ToList();
    }

    private static async Task OperationMenuAsync(string title, IReadOnlyCollection<WindowsOperation> operations)
    {
        while (true)
        {
            DrawHeader(title);
            var choices = operations
                .Select(operation => new MenuItem(FormatOperationLabel(operation), operation))
                .Append(new MenuItem("Voltar", null))
                .ToList();
            var selected = Select(title, choices.Select(x => x.Label).ToList());
            if (selected == "Voltar")
                return;
            var item = choices.First(x => x.Label == selected);
            if (item.Operation is not null)
                await RunOperationAsync(item.Operation);
        }
    }

    private static async Task GameMenuAsync(IReadOnlyCollection<WindowsOperation> games)
    {
        while (true)
        {
            DrawHeader("PRIORIDADE POR JOGO");
            var filter = AnsiConsole.Prompt(new TextPrompt<string>("[red]Filtro do jogo[/] [grey](Enter mostra todos)[/]").AllowEmpty());
            var filtered = games
                .Where(game => GameLabel(game).Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(GameLabel, StringComparer.CurrentCultureIgnoreCase)
                .ToList();
            if (filtered.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]Nenhum jogo corresponde a esse filtro.[/]");
                Pause();
                continue;
            }
            var choices = filtered.Select(game => new MenuItem(GameLabel(game), game)).Append(new MenuItem("Voltar", null)).ToList();
            var selected = Select($"JOGOS DISPONÍVEIS · {filtered.Count}", choices.Select(x => x.Label).ToList());
            if (selected == "Voltar")
                return;
            var item = choices.First(x => x.Label == selected);
            if (item.Operation is not null)
                await RunOperationAsync(item.Operation);
        }
    }

    private static string GameLabel(WindowsOperation operation)
    {
        var name = operation.GetType().Name;
        name = name.StartsWith("Priorizar", StringComparison.Ordinal) ? name["Priorizar".Length..] : name;
        name = Regex.Replace(name, "([a-z0-9])([A-Z])", "$1 $2");
        name = Regex.Replace(name, "([A-Z])([A-Z][a-z])", "$1 $2");
        return name;
    }

    private static string FormatOperationLabel(WindowsOperation operation)
    {
        var className = Regex.Replace(operation.GetType().Name, "([a-z0-9])([A-Z])", "$1 $2");
        className = Regex.Replace(className, "([A-Z])([A-Z][a-z])", "$1 $2");
        var suffix = operation.RequiresAdministrator ? "  ·  ADMIN" : string.Empty;
        return $"{operation.Name}  ·  {className}{suffix}";
    }

    private static async Task RunOperationAsync(WindowsOperation operation)
    {
        DrawHeader("CONFIRMAR AÇÃO");
        AnsiConsole.Write(new Panel(new Markup(Markup.Escape(operation.Name)))
            .Border(BoxBorder.Rounded)
            .BorderStyle(Style.Parse("red")));
        if (operation.RequiresAdministrator)
            AnsiConsole.MarkupLine("[yellow]Esta ação precisa que o programa esteja aberto como administrador.[/]");
        var warning = WarningFor(operation.GetType().Name);
        if (!string.IsNullOrWhiteSpace(warning))
            AnsiConsole.MarkupLine($"[bold yellow]{Markup.Escape(warning)}[/]");
        if (!AnsiConsole.Confirm("Executar esta ação agora?", false))
            return;

        try
        {
            var result = await AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots)
                .SpinnerStyle(Style.Parse("red"))
                .StartAsync("[red]Executando...[/]", _ => operation.ExecuteAsync());
            var color = result.Succeeded ? "green" : "red";
            AnsiConsole.MarkupLine($"[{color}]Finalizado · código {result.ExitCode}[/]");
            if (!string.IsNullOrWhiteSpace(result.StandardOutput))
                WriteOutput("Saída", result.StandardOutput);
            if (!string.IsNullOrWhiteSpace(result.StandardError))
                WriteOutput("Detalhes", result.StandardError);
        }
        catch (Exception exception)
        {
            AnsiConsole.WriteException(exception, ExceptionFormats.ShortenEverything);
        }
        Pause();
    }

    private static string? WarningFor(string className)
    {
        if (className.Contains("Vbs", StringComparison.OrdinalIgnoreCase) || className.Contains("IsolamentoDeNucleo", StringComparison.OrdinalIgnoreCase))
            return "A alteração reduz proteções de segurança do Windows e pode exigir reinicialização.";
        if (className.Contains("Debloater", StringComparison.OrdinalIgnoreCase) || className == nameof(DesativarXbox) || className == nameof(DesativarCortana))
            return "A ação pode remover aplicativos ou recursos do Windows.";
        if (className == nameof(ReiniciarComputador))
            return "O computador será reiniciado imediatamente. Salve seus arquivos antes.";
        if (className == nameof(FixErroDisco))
            return "A verificação pode demorar e solicitar reinicialização.";
        if (className == nameof(LimparFilaImpressao))
            return "Os trabalhos de impressão pendentes serão apagados.";
        if (className == nameof(DesativarServicosSelecionados))
            return "A configuração desativa serviços de impressão, biometria, diagnóstico e telemetria.";
        return null;
    }

    private static async Task CleanerMenuAsync()
    {
        var scheduler = new CleanerTaskScheduler();
        while (true)
        {
            DrawHeader("AUTO CLEANER");
            AnsiConsole.MarkupLine("[grey]Limpa arquivos temporários com mais de 7 dias. Arquivos em uso ou sem permissão são ignorados.[/]");
            var choice = Select("Tarefa semanal", new[]
            {
                "Ver status da tarefa",
                "Instalar tarefa semanal",
                "Limpar agora",
                "Remover tarefa semanal",
                "Voltar"
            });
            if (choice == "Voltar")
                return;

            if (choice == "Ver status da tarefa")
            {
                var status = await scheduler.GetStatusAsync();
                if (status.Exists)
                    WriteOutput("Tarefa agendada", status.Output);
                else
                    AnsiConsole.MarkupLine("[yellow]Ainda não há tarefa semanal instalada.[/]");
                Pause();
            }
            else if (choice == "Instalar tarefa semanal")
            {
                await InstallCleanerTaskAsync(scheduler);
            }
            else if (choice == "Limpar agora")
            {
                if (!AnsiConsole.Confirm("Limpar temporários antigos agora?", false))
                    continue;
                var result = await AnsiConsole.Status()
                    .Spinner(Spinner.Known.Dots)
                    .SpinnerStyle(Style.Parse("red"))
                    .StartAsync("[red]Limpando arquivos temporários...[/]", _ => AutoCleaner.RunAsync());
                AnsiConsole.MarkupLine($"[green]Arquivos removidos: {result.FilesDeleted}[/]");
                AnsiConsole.MarkupLine($"[green]Pastas removidas: {result.DirectoriesDeleted}[/]");
                AnsiConsole.MarkupLine($"[grey]Ignorados ou sem acesso: {result.Errors}[/]");
                AnsiConsole.MarkupLine($"[grey]Log: {Markup.Escape(result.LogPath)}[/]");
                Pause();
            }
            else if (choice == "Remover tarefa semanal")
            {
                if (!AnsiConsole.Confirm("Remover a tarefa Auto Cleaner do Agendador do Windows?", false))
                    continue;
                var result = await scheduler.RemoveAsync();
                AnsiConsole.MarkupLine(result.Succeeded ? "[green]Tarefa removida.[/]" : $"[yellow]{Markup.Escape(result.Output)}[/]");
                Pause();
            }
        }
    }

    private static async Task InstallCleanerTaskAsync(CleanerTaskScheduler scheduler)
    {
        var days = new Dictionary<string, DayOfWeek>
        {
            ["Domingo"] = DayOfWeek.Sunday,
            ["Segunda-feira"] = DayOfWeek.Monday,
            ["Terça-feira"] = DayOfWeek.Tuesday,
            ["Quarta-feira"] = DayOfWeek.Wednesday,
            ["Quinta-feira"] = DayOfWeek.Thursday,
            ["Sexta-feira"] = DayOfWeek.Friday,
            ["Sábado"] = DayOfWeek.Saturday
        };
        var dayLabel = Select("Escolha o dia semanal", days.Keys.ToList());
        var rawTime = AnsiConsole.Prompt(new TextPrompt<string>("Horário local [grey](HH:mm)[/]").DefaultValue("03:00"));
        if (!TimeOnly.TryParseExact(rawTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
        {
            AnsiConsole.MarkupLine("[red]Horário inválido. Use o formato 03:00.[/]");
            Pause();
            return;
        }
        var day = days[dayLabel];
        AnsiConsole.MarkupLine($"A limpeza ficará agendada toda [red]{dayLabel} às {time:HH\\:mm}[/], para esta conta do Windows.");
        if (!AnsiConsole.Confirm("Salvar essa tarefa no Agendador do Windows?", false))
            return;
        var result = await scheduler.InstallWeeklyAsync(day, time);
        AnsiConsole.MarkupLine(result.Succeeded ? "[green]Tarefa semanal instalada.[/]" : "[red]Não foi possível instalar a tarefa.[/]");
        if (!string.IsNullOrWhiteSpace(result.Output))
            WriteOutput("Agendador do Windows", result.Output);
        Pause();
    }

    private static string Select(string title, IReadOnlyCollection<string> choices)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title($"[bold red]{Markup.Escape(title)}[/]")
            .PageSize(18)
            .MoreChoicesText("[grey]Use ↑/↓ para navegar[/]")
            .AddChoices(choices));
    }

    private static void DrawHeader(string section)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new FigletText("TRAIN").Centered().Color(Color.Red));
        AnsiConsole.MarkupLine("[bold white]TWEAKS[/]");
        AnsiConsole.Write(new Rule($"[red]{Markup.Escape(section)}[/]").RuleStyle(Color.Red));
        AnsiConsole.MarkupLine("[grey]Otimizações · Jogos · Diagnóstico · Limpeza[/]");
        AnsiConsole.WriteLine();
    }

    private static void WriteOutput(string title, string text)
    {
        var content = text.Trim();
        if (content.Length > 12000)
            content = content[^12000..];
        AnsiConsole.Write(new Panel(new Text(content))
            .Header(title)
            .Border(BoxBorder.Rounded)
            .BorderStyle(Style.Parse("grey")));
    }

    private static void Pause()
    {
        AnsiConsole.MarkupLine("[grey]Pressione qualquer tecla para continuar...[/]");
        Console.ReadKey(true);
    }

    private sealed record MenuItem(string Label, WindowsOperation? Operation);
}
