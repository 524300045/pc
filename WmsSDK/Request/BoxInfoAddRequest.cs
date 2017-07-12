using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSDK.Model;
using WmsSDK.Response;

namespace WmsSDK.Request
{
    public class BoxInfoAddRequest : IWMSRequest<BoxInfoAddResponse>
    {
        public string GetAPIPath()
        {
            return "/boxInfo/add";
        }

      //  [JsonProperty("request")]
        public List<BoxInfo> request { get; set; }
        ///** 客户编码 */
        //[JsonProperty("customerCode")]
        //private String customerCode;
        ///** 客户名称 */
        //[JsonProperty("customerName")]
        //private String customerName;
        ///** 仓库编码 */
        //[JsonProperty("warehouseCode")]
        //private String warehouseCode;
        ///** 仓库名称 */
        //[JsonProperty("warehouseName")]
        //private String warehouseName;
        ///** 门店编码 */
        //[JsonProperty("storedCode")]
        //private String storedCode;
        ///** 门店名称 */
        //[JsonProperty("storedName")]
        //private String storedName;
        ///** 箱号 */
        //[JsonProperty("boxCode")]
        //private String boxCode;

        //[JsonProperty("printMan")]
        //private String printMan;

        //[JsonProperty("createUser")]
        //private String createUser;

        //[JsonProperty("updateUser")]
        //private String updateUser;

    }
}
