using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace SI_10a.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecutor;
        private static int IgnorePostRequests = 0;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter) 
        {
            _schema = schema;
            _documentExecutor = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query) 
        {
            // For some mysterious reason it sends 2 empty post requests upon program startup.
            if (IgnorePostRequests < 2) 
            {
                IgnorePostRequests++;
                return BadRequest("Empty Query");
            }

            if (query == null) return BadRequest("Empty query");

            var inputs = query.Variables?.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            // Execute query
            var result = await _documentExecutor.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0) return BadRequest("Invalid query");

            return Ok(result.Data);
        }
    }
}
