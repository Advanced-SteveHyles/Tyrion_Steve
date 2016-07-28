using System;
using System.Security.Principal;
using Server.Controllers;

namespace Server.Providers
{
    public class OAuthIdentity : IIdentity
    {
        private readonly ClientToken _clientToken;

        public OAuthIdentity(ClientToken clientToken)
        {
            _clientToken = clientToken;
            //Name = userInfo.Name;
            //MemberId = userInfo.MemberID;
            //Email = userInfo.Email;
            //Uid = userInfo.Uid;
            //MemberTypeID = userInfo.MemberTypeID;
            //UserWebAccessRights = userInfo.UserWebAccessRights;
        }

        public string Name => _clientToken.FullName;
        public string AuthenticationType => "OAuth";

        public bool IsAuthenticated => true;
        
        //public string Name { get; }
        //public Guid MemberId { get; }
        //public string Email { get; }
        //public short Uid { get; set; }
        //public int MemberTypeID { get; set; }
        //public string UserWebAccessRights { get; set; }

        //public bool IsBarrister => (MemberTypeID == 1);
        //public bool IsClerk => (MemberTypeID == 7);

        //public bool HasAccess(AccessArea area, AccessRight minRights)
        //{
        //    int pos = (int)area;
        //    int min = (int)minRights;
        //    string uarStr = (UserWebAccessRights != null && UserWebAccessRights.Length > pos) ? UserWebAccessRights.Substring((int)area, 1) : "0";
        //    int uar = 0;
        //    int.TryParse(uarStr, out uar);

        //    return (uar >= min);
        //}

        //public enum AccessArea
        //{
        //    Booking
        //}
        //public enum AccessRight
        //{
        //    None,
        //    Read,
        //    Write,
        //    ReadWrite
        //}

    }
}