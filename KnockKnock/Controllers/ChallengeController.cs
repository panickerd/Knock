using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KnockKnock.Controllers
{
    [Route("api")]
    public class ChallengeController : Controller
    {
        /// <summary>
        /// Returns the nth fibonacci number
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>nTh fibonacci number</returns>
        [HttpGet("Fibonacci")]
        public ActionResult FibonacciNumber(long n)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "The request is invalid." });
            }

            if (n == 0)
            {
                return Ok(0);
            }
            else if ((n == 1) || (n == 2) || (n == -1) || (n == -2))
            {
                return Ok(1);
            }
            else { 
                return Ok(GetFibonacciNumber(n));
            }
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence
        /// </summary>
        /// <param name="sentence">sentence</param>
        /// <returns>reverse string</returns>
        [HttpGet("ReverseWords")]
        public ActionResult Reverse(string sentence)
        {
            char[] arr = sentence.ToCharArray();
            Array.Reverse(arr);
            return Ok(new string(arr));
        }

        /// <summary>
        /// Your token
        /// </summary>
        /// <returns>token guid</returns>
        [HttpGet("Token")]
        public ActionResult Token()
        {
            return Ok(new Guid());
        }

        /// <summary>
        /// Returns the type of triange given the lengths of its sides.
        /// </summary>
        /// <param name="a">side a</param>
        /// <param name="b">side b</param>
        /// <param name="c">side c</param>
        /// <returns>triange type</returns>
        [HttpGet("TriangleType")]
        public ActionResult TriangleType(int a, int b, int c)
        {
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "The request is invalid." });
            }
            if (a + b > c && a + c > b && b + c > a)
            {
                int[] sides = new int[3] { a, b, c };
                int count = sides.GroupBy(x => x).Count();
                if (count == 1)
                {
                    result = "Equilateral";
                }
                else if (count == 2)
                {
                    result = "Isosceles";
                }
                else
                {
                    result = "Scalene";
                }
            }
            else
            {
                result = "Error";
            }

            return Ok(result);
        }

        /// <summary>
        /// Recursive function to get Fibonacci number
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>result</returns>
        public static long GetFibonacciNumber(long n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if ((n == 1) || (n == 2) || (n == -1) || (n == -2))
            {
                return 1;
            }
            if (n > 0)
            {
                return GetFibonacciNumber(n - 1) + GetFibonacciNumber(n - 2);
            }
            else
            {
                return GetFibonacciNumber(n + 1) + GetFibonacciNumber(n + 2);
            }
        }
    }
}