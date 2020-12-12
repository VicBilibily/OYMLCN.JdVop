namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品状态验证定义
    /// </summary>
    public class SkuNum
    {
        /// <summary>
        ///   商品状态验证定义
        /// </summary>
        public SkuNum() { }
        /// <summary>
        ///   商品状态验证定义
        /// </summary>
        /// <param name="skuId">商品</param>
        /// <param name="num">数量</param>
        public SkuNum(long skuId, int num)
        {
            this.SkuId = skuId;
            this.Num = num;
        }

        /// <summary>
        ///   商品编号
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   验证数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        ///   京东要求的JSON组装格式
        /// </summary>
        public override string ToString()
            => $"{{skuId:{SkuId},num:{Num}}}";
    }
}
