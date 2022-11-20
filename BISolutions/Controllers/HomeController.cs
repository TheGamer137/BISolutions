using Microsoft.AspNetCore.Mvc;

namespace BISolutions.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    /// <summary>
    /// Функционал сложения каждого второго нечетного числа
    /// </summary>
    /// <param name="array">массив чисел тела запроса</param>
    /// <returns>Сумма по модулю</returns>
    [HttpPost("firstSolution")]
    public float FirstSolution(float[] array)
    {
        if (array.Any())
        {
            return Math.Abs(array
                .Where(x => x % 2 != 0)
                .Select((item, index) => new { item, index })
                .Where(x => x.index % 2 != 0).Sum(x => x.item));
        }
        throw new ArgumentNullException();
    }
    
    /// <summary>
    /// Функционал сложения двух непустых связанных списков, представляющих два положительных целых числа
    /// </summary>
    /// <param name="lists">Связанные списки</param>
    /// <returns>Результат сложения связанных списков</returns>
    [HttpPost("secondSolution")]
    public LinkedList<int> SecondSolution(SecondSolutionLists lists)
    {
        if (lists.First.Any() || lists.Second.Any())
        {
            LinkedList<int> result = new LinkedList<int>();
            int maxCount = lists.First.Count() > lists.Second.Count() ? lists.First.Count() : lists.Second.Count();
            int carry = 0;
            for (int i = 0; i < maxCount; ++i)
            {
                int temp = lists.First.ElementAtOrDefault(i) + lists.Second.ElementAtOrDefault(i);
                result.AddFirst((temp + carry) % 10);
                carry = (temp + carry) / 10;
            }

            return result;
        }
        throw new ArgumentNullException();

    }
    
    /// <summary>
    /// Функционал определения входящий строки является ли она палиндромом
    /// </summary>
    /// <param name="word">входящее слово</param>
    [HttpGet("thirdSolution")]
    public IActionResult ThirdSolution(string word)
    {
        if (!string.IsNullOrEmpty(word))
        {
            if (word.SequenceEqual(word.Reverse()))
                return Ok("Это слово палиндром");
            return Ok("Слово не является палиндромом");
        }
        return BadRequest();
    }
}