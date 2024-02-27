using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class EditState
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }
    [Inject]
    public SalesManagerClientService SalesManagerClientService { get; set; }

    [Parameter]
    public long Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        state = await SalesManagerClientService.GetStateById(id:Id);
    }

    protected bool errorVisible;
    protected LookupDto state;

    protected async Task FormSubmit()
    {
        try
        {
            await SalesManagerClientService.UpdateState(state);
            DialogService.Close(state);
        }
        catch
        {
            errorVisible = true;
        }
    }

    protected Task CancelButtonClick(MouseEventArgs args)
    {
        DialogService.Close(null);
        return Task.CompletedTask;
    }
}