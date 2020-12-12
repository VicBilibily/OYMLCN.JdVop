using System.Collections.Generic;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   配送预约日历信息
    /// </summary>
    public class PromiseCalendar
    {
        /// <summary>
        ///   商品物流分类信息
        /// </summary>
        public SkuClassifyResult SkuClassifyResult { get; set; }
        /// <summary>
        ///   中小件的预约日历结果
        /// </summary>
        public CalendarResult CalendarListResult { get; set; }
        /// <summary>
        ///   大家电的预约日历结果
        /// </summary>
        public LaCalendarResult LaCalendarListResult { get; set; }
    }

    /// <summary>
    ///   商品物流分类结果
    /// </summary>
    public class SkuClassifyResult
    {
        /// <summary>
        ///   获取成功标识
        /// </summary>
        public bool Success => ResultCode == 1;
        /// <summary>
        ///   状态，只有1表示处理成功
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        ///   对 <see cref="ResultCode"/> 的简要说明
        /// </summary>
        public string ResultMessage { get; set; }
        /// <summary>
        ///   详细区分结果
        ///   <para><see langword="Keys"/> 表示商品 sku，<see langword="Values"/> 表示类型（1指中小件/2指大家电）。</para>
        /// </summary>
        public Dictionary<long, int> SkuClassifyMaps { get; set; }
    }

    /// <summary>
    ///   中小件的预约日历结果
    /// </summary>
    public class CalendarResult
    {
        /// <summary>
        ///   获取成功标识
        /// </summary>
        public bool Success => ResultCode == 1;
        /// <summary>
        ///   状态，只有1表示处理成功
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        ///   对 <see cref="ResultCode"/> 的简要说明
        /// </summary>
        public string ResultMessage { get; set; }
        /// <summary>
        ///   履约时间
        ///   <para><see langword="Keys"/> 表示类型</para>
        ///   <para>1、只工作日送货(双休日、假日不用送)</para>
        ///   <para>2、只双休日、假日送货(工作日不用送)</para>
        ///   <para>3、工作日、双休日与假日均可送货</para>
        ///   <para><see langword="Values"/> 里面放置返回的promise字符串（包括html语句）；若没有，则返回空字符串。</para>
        /// </summary>
        public Dictionary<int, string> PromiseTime { get; set; }
        /// <summary>
        ///   提示信息
        ///   <para>311区域：“配送服务升级，晚间也可以送货上门啦！”</para>
        ///   <para>211和次日达区域：“配送服务升级，可以指定上午和下午送货上门啦！”</para>
        /// </summary>
        public string TipMsg { get; set; }
        /// <summary>
        ///   中小件预约日历的详细信息
        /// </summary>
        public CalendarItem[] CalendarList { get; set; }
    }
    /// <summary>
    ///   预约日历
    /// </summary>
    public class CalendarItem
    {
        /// <summary>
        ///   预约日期，格式：yyyy-MM-dd
        /// </summary>
        public string DateStr { get; set; }
        /// <summary>
        ///   周几，1：表示周1，7:表示周日
        /// </summary>
        public int Week { get; set; }
        /// <summary>
        ///   预约时间段
        /// </summary>
        public Timelist[] TimeList { get; set; }
        /// <summary>
        ///   今天是否就是 <see cref="DateStr"/>
        /// </summary>
        public bool Today { get; set; }
    }
    /// <summary>
    ///   预约时间段
    /// </summary>
    public class Timelist
    {
        /// <summary>
        ///   可预约的时间段
        /// </summary>
        public string TimeRange { get; set; }
        /// <summary>
        ///   这个时间段是否可以选择预约
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        ///   是否为默认系统选中的时间段
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        ///   波次id
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        ///   天的偏移量
        /// </summary>
        public int? ReservingDate { get; set; }
        /// <summary>
        ///   时间段 <see cref="TimeRange"/> 的编码
        /// </summary>
        public int TimeRangeCode { get; set; }
    }

    /// <summary>
    ///   大家电的预约日历结果
    /// </summary>
    public class LaCalendarResult
    {
        /// <summary>
        ///   获取成功标识
        /// </summary>
        public bool Success => ResultCode == 1;
        /// <summary>
        ///   状态，只有1表示处理成功
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        ///   对 <see cref="ResultCode"/> 的简要说明
        /// </summary>
        public string ResultMessage { get; set; }
        /// <summary>
        ///   是否支持配送
        /// </summary>
        public bool SupportShip { get; set; }
        /// <summary>
        ///   是否支持安装
        /// </summary>
        public bool SupportInstall { get; set; }
        /// <summary>
        ///   是否支持夜间配送
        /// </summary>
        public bool SupportNightShip { get; set; }
        /// <summary>
        ///   可选的预约配送时间，只有 <see cref="SupportShip"/> 为 <see langword="true"/> 时才会有值。
        /// </summary>
        public List<int> ReservingDateList { get; set; }
        /// <summary>
        ///   可选的预约安装时间，只有 <see cref="SupportInstall"/> 为 <see langword="true"/> 时才会有值。
        /// </summary>
        public Dictionary<int, int[]> ReservingInstallDateMap { get; set; }
        /// <summary>
        ///   系统默认选中日期
        /// </summary>
        public int DefaultDate { get; set; }
        /// <summary>
        ///   Sku列表（不支持配送或支持安装时，此字段有值，其他情况下，此字段为 <see langword="null"/>。）
        /// </summary>
        public LaCalendarSkuInfo[] SkuInfoList { get; set; }

        /// <summary>
        ///   预约日期列表
        /// </summary>
        public CalendarItem[] ReservedCalendarList { get; set; }
        /// <summary>
        ///   是否支持定时达
        /// </summary>
        public bool SetTimeArrive { get; set; }
    }
    /// <summary>
    ///   Sku列表项目
    /// </summary>
    public class LaCalendarSkuInfo
    {
        /// <summary>
        ///   商品编号
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   是否支持配送
        /// </summary>
        public bool SupportShip { get; set; }
        /// <summary>
        ///   是否支持安装
        /// </summary>
        public bool SupportInstall { get; set; }
    }
}
