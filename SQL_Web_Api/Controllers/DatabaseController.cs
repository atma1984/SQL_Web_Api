using System.Web.Http;
using SQL_Web_Api.Services;


namespace SQL_Web_Api.Controllers
{

    [RoutePrefix("api/database")]
    public class DatabaseController : ApiController
    {
   
        private static IDatabaseService _db = new SqlServerDatabaseService();

        [HttpPost]
        [Route("connect")]
        public IHttpActionResult Connect([FromBody] string connectionString)
        {
            _db.Connect(connectionString);
            return Ok("Connected");
        }

        [HttpGet]
        [Route("version")]
        public IHttpActionResult Version()
        {
            var version = _db.GetVersion();
            return Ok(version);
        }

        [HttpPost]
        [Route("disconnect")]
        public IHttpActionResult Disconnect()
        {
            _db.Disconnect();
            return Ok("Disconnected");
        }

    }
}