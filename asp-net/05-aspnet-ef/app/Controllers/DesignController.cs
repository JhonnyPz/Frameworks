using Microsoft.AspNetCore.Mvc;
using app.Data.Interfaces;
using app.Data.Models;

namespace app.Controllers;

[ApiController]
[Route("[Controller]")]
public class DesignController : ControllerBase
{
  private readonly IDesignRepository _designRepository;

  public DesignController(IDesignRepository designRepository)
  {
    _designRepository = designRepository;
  }

  [HttpGet]
  public async Task<ActionResult> Getdesigns()
  {
    return Ok(await _designRepository.GetAll());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> Getdesign(string id)
  {
    var design = await _designRepository.GetById(id);
    if (design == null)
      return designNotFound(id);

    return Ok(design);
  }

  [HttpPost]
  public async Task<ActionResult> Postdesign([FromBody] Design design)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var newdesign = await _designRepository.Create(design);
    return CreatedAtAction(nameof(Getdesign), new { newdesign.Id }, newdesign);
  }

  [HttpPatch("{id}")]
  public async Task<ActionResult> Patchdesign(string id, [FromBody] Design design)
  {
    if (id != design.Id)
      return BadRequest(new { message = $"The ID({id}) does not match the design ID({design.Id})" });

    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var updatedesign = await _designRepository.Update(id, design);
    if (updatedesign == null)
      return designNotFound(id);

    return Ok(updatedesign);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Deletedesign(string id)
  {
    var result = await _designRepository.Delete(id);
    if (!result)
      return designNotFound(id);

    return Ok(new { message = "design deleted" });
  }

  [ApiExplorerSettings(IgnoreApi = true)]
  public NotFoundObjectResult designNotFound(string id)
  {
    return NotFound(new { message = $"The design with ID = {id} does not exist" });
  }
}