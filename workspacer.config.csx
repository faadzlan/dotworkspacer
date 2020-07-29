#r "C:\Program Files\workspacer\workspacer.Shared.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.ActionMenu;
using workspacer.FocusIndicator;

Action<IConfigContext> doConfig = (context) =>
{
    // Customise bar
    context.AddBar(new BarPluginConfig()
    {
        BarTitle = "workspacer.Bar",
        BarHeight = 20,
        FontSize = 12,
        FontName = "UbuntuCondensed Nerd Font",
    });

    // Customise focus indicator
    context.AddFocusIndicator(new FocusIndicatorPluginConfig()
    {
        BorderColor = Color.Teal, 
        BorderSize = 5, 
        TimeToShow = 100, 
    });

    //Customise action menu
    var actionMenu = context.AddActionMenu(new ActionMenuPluginConfig()
    {
        KeybindMod = KeyModifiers.RAlt,
        KeybindKey = Keys.P,
        FontSize = 12,

    });

    // Create a different action menu
    var newMenu = actionMenu.Create();
    newMenu.Add("Restart Workspacer", () => context.Restart());
    newMenu.Add("Quit Workspacer", () => context.Quit());
    // newMenu.AddMenu("Switch to Window", () => context.CreateSwitchToWindowMenu()); 
    context.Keybinds.Subscribe(KeyModifiers.Win, Keys.Y, () => actionMenu.ShowMenu(newMenu));
    
    //Customise workspaces
    context.WorkspaceContainer.CreateWorkspaces("1", "2", "3", "4", "5", "6", "7", "8", "9");

    //Customise keybindings
    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.E,
        () => context.Enabled = !context.Enabled, "toggle enable/disable");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.C,
        () => context.Workspaces.FocusedWorkspace.CloseFocusedWindow(), "close focused window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Space,
        () => context.Workspaces.FocusedWorkspace.NextLayoutEngine(), "next layout");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.Space,
        () => context.Workspaces.FocusedWorkspace.PreviousLayoutEngine(), "previous layout");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.N,
        () => context.Workspaces.FocusedWorkspace.ResetLayout(), "reset layout");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.J,
        () => context.Workspaces.FocusedWorkspace.FocusNextWindow(), "focus next window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.K,
        () => context.Workspaces.FocusedWorkspace.FocusPreviousWindow(), "focus previous window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.M,
        () => context.Workspaces.FocusedWorkspace.FocusPrimaryWindow(), "focus primary window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Enter,
        () => context.Workspaces.FocusedWorkspace.SwapFocusAndPrimaryWindow(), "swap focus and primary window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.J,
        () => context.Workspaces.FocusedWorkspace.SwapFocusAndNextWindow(), "swap focus and next window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.K,
        () => context.Workspaces.FocusedWorkspace.SwapFocusAndPreviousWindow(), "swap focus and previous window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.H,
        () => context.Workspaces.FocusedWorkspace.ShrinkPrimaryArea(), "shrink primary area");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.L,
        () => context.Workspaces.FocusedWorkspace.ExpandPrimaryArea(), "expand primary area");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Oemcomma,
        () => context.Workspaces.FocusedWorkspace.IncrementNumberOfPrimaryWindows(), "increment # primary windows");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.OemPeriod,
        () => context.Workspaces.FocusedWorkspace.DecrementNumberOfPrimaryWindows(), "decrement # primary windows");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.T,
        () => context.Windows.ToggleFocusedWindowTiling(), "toggle tiling for focused window");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.Q, context.Quit, "quit workspacer");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Q, context.Restart, "restart workspacer");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D1,
        () => context.Workspaces.SwitchToWorkspace(0), "switch to workspace 1");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D2,
        () => context.Workspaces.SwitchToWorkspace(1), "switch to workspace 2");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D3,
        () => context.Workspaces.SwitchToWorkspace(2), "switch to workspace 3");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D4,
        () => context.Workspaces.SwitchToWorkspace(3), "switch to workspace 4");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D5,
        () => context.Workspaces.SwitchToWorkspace(4), "switch to workspace 5");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D6,
        () => context.Workspaces.SwitchToWorkspace(5), "switch to workspace 6");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D7,
        () => context.Workspaces.SwitchToWorkspace(6), "switch to workspace 7");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D8,
        () => context.Workspaces.SwitchToWorkspace(7), "switch to workspace 8");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.D9,
        () => context.Workspaces.SwitchToWorkspace(8), "switch to workpsace 9");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Left,
        () => context.Workspaces.SwitchToPreviousWorkspace(), "switch to previous workspace");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Right,
        () => context.Workspaces.SwitchToNextWorkspace(), "switch to next workspace");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.Oemtilde,
        () => context.Workspaces.SwitchToLastFocusedWorkspace(), "switch to last focused workspace");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D1,
                () => context.Workspaces.MoveFocusedWindowToWorkspace(0), "switch focused window to workspace 1");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D2,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(1), "switch focused window to workspace 2");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D3,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(2), "switch focused window to workspace 3");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D4,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(3), "switch focused window to workspace 4");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D5,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(4), "switch focused window to workspace 5");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D6,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(5), "switch focused window to workspace 6");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D7,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(6), "switch focused window to workspace 7");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D8,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(7), "switch focused window to workspace 8");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.D9,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(8), "switch focused window to workspace 9");

    context.Keybinds.Subscribe(KeyModifiers.RAlt, Keys.O,
        () => context.Windows.DumpWindowDebugOutput(), "dump debug info to console for all windows");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.O,
        () => context.Windows.DumpWindowUnderCursorDebugOutput(), "dump debug info to console for window under cursor");

    context.Keybinds.Subscribe(KeyModifiers.RAlt | KeyModifiers.RShift, Keys.I,
        () => context.ToggleConsoleWindow(), "toggle debug console");

};
return doConfig;