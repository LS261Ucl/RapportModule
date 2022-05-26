using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rapport.Api.Response;
using Rapport.BusinessLogig.Services;
using Rapport.Entites.Identity;
using Rapport.Shared.Dto_er.Identity;
using Rapport.Shared.Dto_er.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<UserRoles> _roleManager;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AuthenticateController> logger,
            RoleManager<UserRoles> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                if (user == null) return NotFound();



                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (!result.Succeeded)
                {
                    _logger.LogInformation("Bad email / password combination.");
                    return Unauthorized();
                }


                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
         

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                var userExists = await _userManager.FindByEmailAsync(model.Email);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new RespnseMessages { Status = "Error", Message = "User already exists!" });

                AppUser user = new()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return Ok(new RespnseMessages { Status = "Success", Message = "User created successfully!" });
                else
                    return Unauthorized(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }

        [HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto model)
        //{
        //    var userExists = await _userManager.FindByNameAsync(model.Email);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new RespnseMessages { Status = "Error", Message = "User already exists!" });

        //    AppUser user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Email
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new RespnseMessages { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    if (!await _roleManager.RoleExistsAsync(UserRoles))
        //        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        //        await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //    if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        //    }
        //    if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await _userManager.AddToRoleAsync(user, UserRoles.User);
        //    }
        //    return Ok(new RespnseMessages { Status = "Success", Message = "User created successfully!" });
        //    }

            private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

