using Data.HospitalCountext;
using Data.Model;
using System;
using System.Linq;
using System.Security.Claims;

namespace Service
{
    public class UserHelper
    {
        public static int FindUserId(HospitalContext _context, ClaimsPrincipal User)
        {

            var doctorEmail = User.FindFirstValue(ClaimTypes.Email);

            int doctorId = _context.Users.FirstOrDefault(u => u.UserName == doctorEmail).Id;
            return doctorId;
        }
        //public static string FindUserRole(ClaimsPrincipal User)
        //{
        //    HospitalContext _context = new HospitalContext();
        //    var userEmail = User.FindFirstValue(ClaimTypes.Email);
        //    string userRole = _context.Users.FirstOrDefault(u => u.UserName == userEmail).HostapitalRoles.Name;
        //    return userRole;
        //}
        //public static string FindUserRole(HospitalContext _context, ClaimsPrincipal User)
        //{
        //    var userEmail = User.FindFirstValue(ClaimTypes.Email);
        //    string userRole = _context.Users.FirstOrDefault(u => u.UserName == userEmail).Specialities.Name;
        //    return userRole;
        //}
    }
}
