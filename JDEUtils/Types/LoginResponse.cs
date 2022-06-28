using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDEUtils.Types
{

    public class LoginResponse
    {
        public string username { get; set; }
        public string environment { get; set; }
        public string role { get; set; }
        public string jasserver { get; set; }
        public UserInfo userInfo { get; set; }
        public bool userAuthorized { get; set; }
        public object version { get; set; }
        public object poStringJSON { get; set; }
        public object altPoStringJSON { get; set; }
        public string aisSessionCookie { get; set; }
        public bool adminAuthorized { get; set; }
        public bool passwordAboutToExpire { get; set; }
        public string envColor { get; set; }
        public string machineName { get; set; }
        public bool deprecated { get; set; }
    }

    public class DstRule
    {
        public int startDate { get; set; }
        public int endDate { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public object startEffectiveDate { get; set; }
        public int startDayOfWeek { get; set; }
        public object ruleDescription { get; set; }
        public object endEffectiveDate { get; set; }
        public int dstSavings { get; set; }
        public int endDay { get; set; }
        public int startMonth { get; set; }
        public int endDayOfWeek { get; set; }
        public int endMonth { get; set; }
        public int startDay { get; set; }
        public int effectiveYear { get; set; }
        public int dstruleOffset { get; set; }
    }



    public class UserInfo
    {
        public string token { get; set; }
        public string langPref { get; set; }
        public string locale { get; set; }
        public string dateFormat { get; set; }
        public string dateSeperator { get; set; }
        public string simpleDateFormat { get; set; }
        public string timeFormat { get; set; }
        public string decimalFormat { get; set; }
        public int addressNumber { get; set; }
        public string alphaName { get; set; }
        public string appsRelease { get; set; }
        public string country { get; set; }
        public string username { get; set; }
        public string longUserId { get; set; }
        public string timeZoneOffset { get; set; }
        public string dstRuleKey { get; set; }
        public DstRule dstRule { get; set; }
    }


}
