// using Microsoft.AspNetCore.Mvc;
// using app.Services;

// namespace app.Controllers;

// [ApiController]
// [Route("[Controller]")]
// public class TestUploadDesignsController : ControllerBase
// {
//   private readonly IUploadDesignsSerivces _uploadDesignsService;

//   public TestUploadDesignsController(IUploadDesignsSerivces uploadDesignsService)
//   {
//     _uploadDesignsService = uploadDesignsService;
//   }

//   [HttpPost]
//   public async Task<ActionResult> PostTestUploadDesigns()
//   {
//     return Ok(await _uploadDesignsService.CreateTestUploadDesigns());
//   }
// }
