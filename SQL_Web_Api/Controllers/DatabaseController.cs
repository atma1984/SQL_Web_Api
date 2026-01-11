using System;
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
            //var connect_data = _databaseService.Connect(connectionString);
            //return Ok(connect_data);


            bool isConnected = _databaseService.Connect(connectionString);

            if (isConnected)
            {
                return Ok("Успешное подключение к базе данных.");
            }
            else
            {
                return InternalServerError(new Exception("Не удалось подключиться к базе данных."));
            }
        }

        [HttpGet]
        [Route("version")]
        public IHttpActionResult Version()
        {
            try
            {
                var version = _databaseService.GetVersion();
                if (version.StartsWith("Ошибка"))
                {
                    return InternalServerError(new Exception(version));
                }

                return Ok(version);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("disconnect")]
        public IHttpActionResult Disconnect()
        {
            bool isDisconnected = _databaseService.Disconnect();

            if (isDisconnected)
            {
                return Ok("Соединение с базой данных закрыто.");
            }
            else
            {
                return BadRequest("Нет активного соединения для закрытия.");
            }
        }

    }
}