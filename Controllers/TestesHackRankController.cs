using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using testHackRank.Classes;

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
        public IActionResult ListaSimplesSoma(int tamanhoLista, string numeros)
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

                    if (numerosInt.Count() != lista.Capacity)
                    {
                        return BadRequest("Os itens da lista nao equivalem a capacidade da lista");
                    }

                    foreach (var num in numerosInt)
                    {
                        lista.Add(num);
                        //somaFinal = lista.Sum(); aqui se fosse somar ja com os valores do array
                    }


                    //Decidi colocar uma verificação de se os itens do array são menores que 1000
                    if (CheckValueMenorQueMil(lista))
                    {
                        somaFinal = lista.Sum();

                        return new OkObjectResult(new { Mensagem = $"  Capacidade da Lista: {tamanhoLista}.  lista inteira: {numeros}. A soma : {somaFinal}. " });
                    }

                    return BadRequest("Reveja os numeros colocados, Capacidade da lista maior que 0 e numeros da lista menores que 1000");

                }

                return BadRequest("Reveja os numeros colocados, Capacidade da lista maior que 0 e numeros da lista menores que 1000");

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

        protected bool CheckValueMenorQueMil(List<int> b)
        {
            bool re = b.All(numero => numero <= 1000);
            return re;
        }

        #endregion
    }
}
