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

        [HttpGet("PrimeiroTesteHackRank")]
        public string SumNumbers(int a, int b)
        {
            if (CheckNumberValue(a, b))
                return (a + b).ToString();
            else
                return "Reveja os numeros adicionados";
        }

        [HttpGet("SimpleArraySum")]
        public string ListaSimplesSoma(int tamanhoLista, string numeros)
        {
            try
            {
                List<int> lista = new List<int>();

                List<int> lista_Numeros = new List<int>();

                int somaFinal = 0;

                if (CheckValueMaiorQueZero(tamanhoLista))
                {
                    lista.Capacity = tamanhoLista;

                    string[] numerosArray = numeros.Split(',');

                    int[] numerosInt = Array.ConvertAll(numerosArray, int.Parse);

                    
                    foreach (var num in numerosInt)
                    {
                        lista.Add(num);
                        somaFinal = lista.Sum();
                    }

                    return $"  Capacidade da Lista: {tamanhoLista}. {Environment.NewLine} E os numeros que compoem ela são: {numeros}. {Environment.NewLine} A soma deles da um total de {somaFinal}. ";
                   
                }
                return "Reveja os numeros colodados";
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            } 


        }


        #region Helpers
        protected bool CheckNumberValue(int a, int b)
        {
            return a >= 1 && b <= 1000 ? true : false;           
        }

        protected bool CheckValueMaiorQueZero(int a)
        {
            return a >= 0 ? true : false;
        }

        #endregion
    }
}
