using System.Web.Http;
using SQL_Web_Api.Services;


namespace SQL_Web_Api.Controllers
{

    [RoutePrefix("api/database")]
    public class DatabaseController : ApiController
    {
        private readonly IDatabaseService _databaseService;

        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost]
        [Route("connect")]
        public IHttpActionResult Connect([FromBody] string connectionString)
        {
            var connect_data = _databaseService.Connect(connectionString);
            return Ok(connect_data);
        }

        [HttpGet]
        [Route("version")]
        public IHttpActionResult Version()
        {
            var version = _databaseService.GetVersion();
            return Ok(version);
        }

        [HttpPost]
        [Route("disconnect")]
        public IHttpActionResult Disconnect()
        {
            var disconnect_data = _databaseService.Disconnect();
            return Ok(disconnect_data);
        }

    }
}