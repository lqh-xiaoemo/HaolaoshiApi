using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Web.Jwt
{
    /// <summary>
    /// Jwt帮助类
    /// </summary>
    public class JwtHelper
    {

        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <param name="jwtConfig"></param>
        /// <returns></returns>
        public static string IssueJWT(Token tokenModel, JwtConfig jwtConfig)
        {
            var dateTime = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtClaimTypes.Audience,jwtConfig.Audience),
                new Claim(JwtClaimTypes.Issuer,jwtConfig.Issuer),
                new Claim(JwtClaimTypes.Id, tokenModel.Uid.ToString()),//用户Id
                new Claim(JwtClaimTypes.Name, tokenModel.Uname.ToString()), 
                new Claim(JwtClaimTypes.Role, tokenModel.Role),//角色
                new Claim("Project", tokenModel.Project),//身份
                new Claim(JwtRegisteredClaimNames.Iat,dateTime.ToString(),ClaimValueTypes.Integer64)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //过期时间
            double exp = 0;
            switch (tokenModel.TokenType.ToString())
            {
                case "Web":
                    exp = jwtConfig.WebExp;
                    break;
                case "App":
                    exp = jwtConfig.AppExp;
                    break;
                case "MiniProgram":
                    exp = jwtConfig.MiniProgramExp;
                    break;
                case "Other":
                    exp = jwtConfig.OtherExp;
                    break;
                default:
                    exp = jwtConfig.AppExp;
                    break;
            }
            var jwt = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                claims: claims, //声明集合
                expires: dateTime.AddHours(exp),
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static Token SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object id = new object();
            object name = new object(); ;
            object role = new object(); ;
            object project = new object();
            try
            {
                jwtToken.Payload.TryGetValue(JwtClaimTypes.Id, out id);
                jwtToken.Payload.TryGetValue(JwtClaimTypes.Name, out name);
                jwtToken.Payload.TryGetValue(JwtClaimTypes.Role, out role);
                jwtToken.Payload.TryGetValue("Project", out project);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new Token
            {
                Uid = Convert.ToInt32(id),
                Uname=name.ToString(),
                Role = role.ToString(),
                Project = project.ToString()
            };
            return tm;
        }
    }

}
