using HospitalWebApi.Hospital;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWebApi.Repository
{
    public partial class Repository
    {
        public void CreateAdmin(TblAdmin tblAdmin) 
        {
            using (AngularHospitalContext db = new())
            {
                db.TblAdmins.Find(tblAdmin.AdminId);
                if (tblAdmin.FirstName != "" && tblAdmin.LastName != "" && tblAdmin.Password != "" && tblAdmin.PhoneNum != "" && tblAdmin.EmailId != "")
                {
                    db.TblAdmins.Add(tblAdmin);
                    db.SaveChanges();
                }
            }
        }
        public void Login(string username, string password) 
        {
            TblAdmin tblAdmin = new();
            tblAdmin.EmailId = username;
            tblAdmin.Password = password;
            AuthenticateUser(tblAdmin);
            
        }
        public void JWTAuthorization() 
        {
        }
        public void LogOut() 
        {
        }
        public string GenerateJSONWebToken(TblAdmin admin_info, IConfiguration _config)
        {
            if (admin_info == null)
                return null;
            try
            {
                /*var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);*/
                var userName = admin_info.EmailId;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", userName) }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _config["Jwt:Issuer"],
                    Audience = _config["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public TblAdmin GetAdminDetails(string mailId) 
        {
            using (AngularHospitalContext db = new())
            {
                List<TblAdmin> tblAdmins = db.TblAdmins.ToList();
                TblAdmin tblAdmin = new();
                for (int i = 0; i < tblAdmins.Count; i++)
                {
                    if (tblAdmins[i].EmailId == mailId)
                        return tblAdmins[i];
                }
                //TblAdmin tblAdmin = new() { AdminId = 1, EmailId = "malhar@jojare.com", Password = "Test@123", FirstName = "Malhar" };
                return tblAdmin;
            }
        }
        public dynamic AuthenticateUser(TblAdmin login)
        {
            if (login == null)
            {
                return null;
            }
            try
            {
                TblAdmin user = null;

                using (AngularHospitalContext angularHospitalContext = new())
                {
                    List<TblAdmin> ValidUsers = angularHospitalContext.TblAdmins.ToList();

                    if (ValidUsers == null)
                        return null;
                    else
                    {
                        if (ValidUsers.Any(u => u.EmailId == login.EmailId && u.Password == login.Password))
                        {
                            user = new TblAdmin { EmailId = login.EmailId, Password = login.Password };
                        }
                    }

                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    
}
}
