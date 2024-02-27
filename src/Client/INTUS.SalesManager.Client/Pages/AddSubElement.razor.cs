using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class AddSubElement
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

    protected override Task OnInitializedAsync()
    {
        subElement = new SubElementDto() { ElementType = new LookupDto() };
        return Task.CompletedTask;
    }
    protected bool errorVisible;
    protected SubElementDto subElement;

    protected IEnumerable<WindowListDto> windowsForWindowId;

    protected IEnumerable<LookupDto> elementTypesForElementTypeId;


    protected int windowsForWindowIdCount;
    protected WindowListDto windowsForWindowIdValue;
    protected async Task windowsForWindowIdLoadData(LoadDataArgs args)
    {
        try
        {
            windowsForWindowId = await SalesManagerClientService.GetWindows();
            windowsForWindowIdCount = windowsForWindowId.Count();

        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Window" });
        }
    }

    protected int elementTypesForElementTypeIdCount;
    protected LookupDto elementTypesForElementTypeIdValue;
    protected async Task elementTypesForElementTypeIdLoadData(LoadDataArgs args)
    {
        try
        {
            elementTypesForElementTypeId = await SalesManagerClientService.GetElementTypes();
            elementTypesForElementTypeIdCount = elementTypesForElementTypeId.Count();

        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load ElementType" });
        }
    }
    protected async Task FormSubmit()
    {
        try
        {
            await SalesManagerClientService.CreateSubElement(subElement);
            DialogService.Close(subElement);
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