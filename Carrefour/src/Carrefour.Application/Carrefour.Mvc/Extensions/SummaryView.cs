using Microsoft.AspNetCore.Mvc;

namespace Carrefour.Mvc.Extensions;

public class SummaryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
