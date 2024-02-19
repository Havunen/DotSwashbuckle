using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Highly contrived example to show how Swashbuckle doesn't pull in XML Doc comments
/// when referenced via the `include` tag.
/// </summary>
/// <remarks>
/// Has 2 methods - one that has the docs inline,
/// and one that has the docs referenced in a separate file.
/// </remarks>
[ApiController]
[Route("[controller]")]
public class PingController
{
  /// <summary>
  /// Does a ping.
  /// </summary>
  /// <returns>Returns a pong.</returns>
  /// <remarks>XML doc comments are referenced in the same file.</remarks>
  [HttpGet]
  [Route("embedded")]
  public string PingEmbedded() => "embedded pong";

  /// <include file='./PingController.xml' path='/PingController/ReferencedPing'/>
  [HttpGet]
  [Route("referenced")]
  public string ReferencedPing3() => "referenced pong";
}