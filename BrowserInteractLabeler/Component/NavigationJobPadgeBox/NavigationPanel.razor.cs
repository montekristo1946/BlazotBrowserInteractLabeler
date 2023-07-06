using Microsoft.AspNetCore.Components;

namespace BrowserInteractLabeler.Component;

public class NavigationPanelModel : ComponentBase
{
    [Parameter] public RenderFragment SavePanelTemplate { get; set; }
    [Parameter] public RenderFragment SwipePanelTemplate { get; set; }
    [Parameter] public RenderFragment ProgressPanelTemplate { get; set; }
}