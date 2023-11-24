using FileUploadingWebAPI.Data;
using FileUploadingWebAPI.Filter;
using FileUploadingWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace FileUploadingWebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FileController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");

        var fileModel = new FileModel
        {
            FileName = file.FileName
        };

        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            fileModel.FileContent = ms.ToArray();
        }

        _context.Files.Add(fileModel);
        _context.SaveChanges();

        return Ok(new { fileModel.Id });
    }

    [HttpGet("{id}")]
    public IActionResult Download(int id)
    {
        var fileModel = _context.Files.FirstOrDefault(e => e.Id == id);
        if (fileModel == null)
            return NotFound();

        return File(fileModel.FileContent, "application/octet-stream", fileModel.FileName);
    }

    [HttpGet]
    public IActionResult List()
    {
        var fileModels = _context.Files.Select(x => x.FileName);
        return Ok(fileModels);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var fileModel = _context.Files.FirstOrDefault(e => e.Id == id);
        if (fileModel == null)
            return NotFound();

        _context.Files.Remove(fileModel);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, IFormFile file)
    {
        var fileModel = _context.Files.FirstOrDefault(e => e.Id == id);
        if (fileModel == null)
            return NotFound();
        fileModel.FileName = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyTo(ms);
            fileModel.FileContent = ms.ToArray();
        }

        _context.SaveChanges();

        return Ok();
    }

    [HttpPost]
    [ImageValidator]
    public IActionResult UploadImage(IFormFile iamge)
    {
        var fileModel = new FileModel
        {
            FileName = iamge.FileName
        };

        using (var ms = new MemoryStream())
        {
            iamge.CopyTo(ms);
            fileModel.FileContent = ms.ToArray();
        }

        _context.Files.Add(fileModel);
        _context.SaveChanges();

        return Ok(new { fileModel.Id });
    }

    [HttpPost]
    public IActionResult UploadMultibleFiles(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return Content("files not selected");

        foreach (var file in files)
        {
            var fileModel = new FileModel
            {
                FileName = file.FileName
            };

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileModel.FileContent = ms.ToArray();
            }
            _context.Files.Add(fileModel);
        }
        _context.SaveChanges();

        return Ok();
    }
}
