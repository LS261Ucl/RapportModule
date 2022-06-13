using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rapport.Api.ResponseMessage;
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
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;


        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AuthController> logger,
            RoleManager<IdentityRole> roleManager,

            IConfiguration configuration)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                if (user == null) return NotFound();

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (!result.Succeeded)
                {
                    _logger.LogInformation("Bad email / password combination.");
                    return Unauthorized();
                }
                else
                {


                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach(var role in roles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var token = GetToken(authClaims);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }






            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("registre")]
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
                    UserName = model.Email,
                    Admin = model.Role,
                    User = model.Role

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {


                    if (!await _roleManager.RoleExistsAsync(user.Admin))
                        await _roleManager.CreateAsync(new IdentityRole(user.Admin));
                    if (!await _roleManager.RoleExistsAsync(user.User))
                        await _roleManager.CreateAsync(new IdentityRole(user.User));

                    if (await _roleManager.RoleExistsAsync(user.Admin))
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    if (await _roleManager.RoleExistsAsync(user.User))
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }


                    return Ok(new RespnseMessages { Status = "Success", Message = "User created successfully!" });
                }

                else
                    return Unauthorized(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return Ok(new UserDto
            {
                Email = user.Email,
                FullName = user.FullName,
            });
        }

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

