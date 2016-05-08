using System;
using System.ComponentModel.DataAnnotations;

namespace MakeAccount.Models
{
    /// <summary>
    /// 記帳類別:收入、支出
    /// </summary>
    public enum EnumAccountType { Expense, Revenue }

    public class AccountEntryModels
    {
        /// <summary>
        /// #
        /// </summary>
        public int Sn { get; set; }

        [Required(ErrorMessage = "類別為必填")]
        /// <summary>
        /// 類別
        /// </summary>
        public EnumAccountType AccountType { get; set; }

        [Required(ErrorMessage = "日期為必填")]
        [DataType(DataType.Date)]
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime KeepDate { get; set; }

        [Required(ErrorMessage = "金額為必填")]
        /// <summary>
        /// 金額
        /// </summary>
        public Decimal Amount { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public String Memo { get; set; }
    }
}
