﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSDK.Model;

namespace WmsApp
{
   public   class UserInfo
    {
       public static string UserName;

       public static string RealName;

       public static string PartnerCode;

       public static String PartnerName;

       public static String WareHouseCode;

       public static string WareHouseName;

       public static string CompanyName;

       public static List<Menu> menuDtos { get; set; }
    }
}
