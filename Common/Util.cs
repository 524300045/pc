using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public    class Util
    {

       /// <summary>
       /// 克转换为斤
       /// </summary>
       /// <param name="g"></param>
       /// <returns></returns>
       public static decimal ConvertGToJin(decimal g)
       {
           decimal stand = 500;
           decimal result = g /stand;
           return result;
       }
    }
}
