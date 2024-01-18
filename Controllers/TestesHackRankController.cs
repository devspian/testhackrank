using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace testHackRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestesHackRankController : ControllerBase
    {

        private readonly ILogger<TestesHackRankController> _logger;

        public TestesHackRankController(ILogger<TestesHackRankController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "PrimeiroTesteHackRank")]
        public string SumNumbers(int a, int b)
        {
            if (CheckNumberValue(a, b))
                return (a + b).ToString();
            else
                return "Reveja os numeros adicionados";
        }


        [HttpGet(Name = "Simple Array Sum")]
        public string SimpleArraySum()
        {
            return "";
        }


        #region Helpers
        protected bool CheckNumberValue(int a, int b)
        {
            return a >= 1 && b <= 1000 ? true : false;           
        }

        #endregion
    }
}
