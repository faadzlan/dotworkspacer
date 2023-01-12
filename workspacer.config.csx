#r "C:\Program Files\workspacer\workspacer.Shared.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Gap\workspacer.Gap.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.ActionMenu;
using workspacer.FocusIndicator;
using workspacer.Gap;
using workspacer.Bar.Widgets;
using System.Collections.Generic;
using System.Linq;

Action<IConfigContext> doConfig = (context) =>
{
    // Uncomment to switch update branch (or to disable updates)
    //context.Branch = Branch.None

	// Configure layouts
	// context.DefaultLayouts = () => new ILayoutEngine[] { new FullLayoutEngine(), new TallLayoutEngine()};

	// Configure the Workspacer bar
	context.AddBar(new BarPluginConfig()
	{
	BarTitle = "workspacer.Bar",
	BarHeight = 22,
	FontName = "UbuntuCondensed Nerd Font",
	FontSize = 12,
	DefaultWidgetForeground = Color.White,
    DefaultWidgetBackground = Color.Black,
	LeftWidgets = () => new IBarWidget[]
	{
		new WorkspaceWidget(), new TextWidget(": "), new TitleWidget() {IsShortTitle = true}
	},
	RightWidgets = () => new IBarWidget[] { new TextWidget("\uf073"), new TimeWidget(1000, "dddd yyyy/MM/dd  HH:mm"), new TextWidget("\uf60b"), new BatteryWidget(), new TextWidget("\uf878"), new ActiveLayoutWidget() },
	});

	// Configure focus indicator
    context.AddFocusIndicator(new FocusIndicatorPluginConfig() {
	BorderColor = Color.Teal,
	});

    // Configure modifier key
	var mod = KeyModifiers.Alt;

	// Configure action menu
    var actionMenu = context.AddActionMenu(new ActionMenuPluginConfig() {
    RegisterKeybind = true,
	KeybindMod = mod,
    KeybindKey = Keys.P,
	MenuTitle = "workspacer.ActionMenu",
    MenuHeight = 50,
    MenuWidth = 600,
    FontSize = 12,
	FontName = "Inconsolata Nerd Font Mono",
});

    // Create 9 workspaces
    context.WorkspaceContainer.CreateWorkspaces("1", "2", "3", "4", "5", "6", "7", "8", "9");
};

return doConfig;