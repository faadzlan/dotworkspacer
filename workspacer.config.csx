#r "C:\Program Files\workspacer\workspacer.Shared.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.ActionMenu;
using workspacer.Bar.Widgets;
using workspacer.FocusIndicator;

Action<IConfigContext> doConfig = (context) =>
{
    // Uncomment to switch update branch (or to disable updates)
    //context.Branch = Branch.None

	// Configure layouts
	context.DefaultLayouts = () => new ILayoutEngine[] { new FullLayoutEngine(), new TallLayoutEngine(), new HorzLayoutEngine(), new VertLayoutEngine() };

	// Configure the Workspacer bar.
	context.AddBar(new BarPluginConfig()
	{
	BarTitle = "workspacer.Bar",
	BarHeight = 20,
	FontName = "UbuntuCondensed Nerd Font",
	FontSize = 12,
	DefaultWidgetForeground = Color.White,
    DefaultWidgetBackground = Color.Black,
	RightWidgets = () => new IBarWidget[] { new TimeWidget(1000, "yyyy/MM/dd  HH:mm"), new BatteryWidget(), new TextWidget("\uf108"), new ActiveLayoutWidget() },
	});

	// Configure focus indicator.
    context.AddFocusIndicator(new FocusIndicatorPluginConfig() {
	BorderColor = Color.Teal,
	});

    // Configure Modifier key
	var mod = KeyModifiers.Alt;

	// Configure action menu.
    var actionMenu = context.AddActionMenu(new ActionMenuPluginConfig() {
    RegisterKeybind = true,
	KeybindMod = mod,
    KeybindKey = Keys.P,
	MenuTitle = "workspacer.ActionMenu",
    MenuHeight = 50,
    MenuWidth = 500,
    FontSize = 12,
	FontName = "Inconsolata Nerd Font Mono",
});

    context.WorkspaceContainer.CreateWorkspaces("1", "2", "3", "4", "5", "6", "7", "8", "9");
};

return doConfig;