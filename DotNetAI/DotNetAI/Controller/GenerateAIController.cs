using DotNetAI.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAI.Controller
{
    [ApiController]
    public class GenerateAIController : ControllerBase
    {
        private readonly ChatService _chatService;
        public GenerateAIController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("ask-ai")]
        public async Task<IActionResult> AskAi([FromBody] string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                return BadRequest("Prompt cannot be empty.");
            }
            var response = await _chatService.GetResponseAsync(prompt);
            return Ok(response);
        }
    }
}
