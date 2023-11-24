using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FileUploadingWebAPI.Filter;

public class ImageValidatorAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var image = context.ActionArguments["iamge"] as IFormFile;
        if(image is null || image.Length ==0)
            context.Result = new BadRequestObjectResult("Select Image!!");

        if(!IsImage(image))
            context.Result = new BadRequestObjectResult("Invalid Image Format!!");
    }

    private bool IsImage(IFormFile image)
    {
        return image.ContentType.Contains("image");
    }

}
