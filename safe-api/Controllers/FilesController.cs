using Microsoft.AspNetCore.Mvc;
using safe_api.Services;

namespace safe_api.Controllers;

[Route("api/files")]
public class FilesController: ControllerBase
{
    private FilesService _filesService;
    
    public FilesController(FilesService filesService)
    {
        _filesService = filesService;
    }
    
    [HttpGet("get-files")]
    public IActionResult GetFiles()
    {
        return Ok();
    }
}