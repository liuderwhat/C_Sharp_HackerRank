using System;
/*
Checked and unchecked statements enable you to specify whether numerical operations are allowed to cause an overflow 
when the result is stored in a variable that is too small to hold the resulting value. 
For more information, see checked and unchecked.
 */
namespace CheckImplement
{
    public class Current
    {
        static int current = 2147483647;

        public void CheckMethod(int increaseValue)
        {
            try
            {
                int modifiedCur = checked(current + increaseValue);
            }
            catch (Exception e)
            {
                // Arithmetic operation resulted in an overflow.
                Console.WriteLine(e.Message);
            }
        }

        public void CheckMethodByBlock(int increaseValue)
        {
            try
            {
                checked
                {
                    int modifiedCur = checked(current + increaseValue);
                }
            }
            catch (Exception e)
            {
                // Arithmetic operation resulted in an overflow.
                Console.WriteLine(e.Message);
            }
        }

        public void NoCheckMethod(int increaseValue)
        {
            try
            {
                int modifiedCur = current + increaseValue;
                Console.WriteLine(modifiedCur);
            }
            catch (Exception e)
            {
                // Arithmetic operation resulted in an overflow.
                Console.WriteLine(e.Message);
            }
        }
    }

    class Test
    {
        static void Main()
        {
            Current c = new();
            int increaseValue = 100;
            // 若不加上checked，期會允許溢位行為
            c.CheckMethod(increaseValue);
            c.CheckMethodByBlock(increaseValue);
            c.NoCheckMethod(increaseValue);
        }
    }
}

