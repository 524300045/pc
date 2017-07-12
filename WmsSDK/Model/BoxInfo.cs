using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WmsSDK.Model
{
    public class BoxInfo
    {
        /** id */
        [JsonProperty("id")]
        public long id;
        /** 客户编码 */
        [JsonProperty("customerCode")]
        public String customerCode;
        /** 客户名称 */
        [JsonProperty("customerName")]
        public String customerName;
        /** 仓库编码 */
        [JsonProperty("warehouseCode")]
        public String warehouseCode;
        /** 仓库名称 */
        [JsonProperty("warehouseName")]
        public String warehouseName;
        /** 门店编码 */
        [JsonProperty("storedCode")]
        public String storedCode;
        /** 门店名称 */
        [JsonProperty("storedName")]
        public String storedName;
        /** 箱号 */
        [JsonProperty("boxCode")]
        public String boxCode;
        /** 打印时间 */
        //[JsonProperty("printTime")]
        //public DateTime printTime;
        /** 打印人 */
        [JsonProperty("printMan")]
        public String printMan;
        /** 创建时间 */
        //[JsonProperty("createTime")]
        //public DateTime createTime;
        /** 创建人 */
        [JsonProperty("createUser")]
        public String createUser;
        /** 更新时间 */
        //[JsonProperty("updateTime")]
        //public DateTime updateTime;
        /** 更新人 */
        [JsonProperty("updateUser")]
        public String updateUser;
        /** 是否有效 */
        [JsonProperty("yn")]
        public int yn;
    }
}
