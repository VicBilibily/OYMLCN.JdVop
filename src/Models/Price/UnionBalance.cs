namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   查询金采和预存款余额的结果
    /// </summary>
    public class UnionBalanceResult
    {
        /// <summary>
        ///   账户余额
        /// </summary>
        public Balance Balance { get; set; }
        /// <summary>
        ///   金采余额
        /// </summary>
        public Geious Geious { get; set; }
    }
    /// <summary>
    ///   账户余额
    /// </summary>
    public class Balance
    {
        /// <summary>
        ///   入参的pin值
        /// </summary>
        public string Pin { get; set; }
        /// <summary>
        ///   账户余额
        /// </summary>
        public decimal RemainLimit { get; set; }
    }
    /// <summary>
    ///   金采余额
    /// </summary>
    public class Geious
    {
        /// <summary>
        ///   入参的pin值
        /// </summary>
        public string Pin { get; set; }
        /// <summary>
        ///  金采的违约金金额
        /// </summary>
        public decimal PenaltySumAmt { get; set; }
        /// <summary>
        ///   金采的总授信额度
        /// </summary>
        public decimal CreditLimit { get; set; }
        /// <summary>
        ///   金采的待还款额度
        /// </summary>
        public decimal DebtSumAmt { get; set; }
        /// <summary>
        ///   金采账户余额
        /// </summary>
        public decimal RemainLimit { get; set; }
    }


}
