using DartTime.DTOs.UserAuth;
using DartTime.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DartTime.Controllers;

[Route("[controller]")]
public class UserAuthController : ControllerBase
{
    #region Variables
    private readonly ILogger<UserAuthController> _logger;
    private readonly IUserRepo _userRepo;
    #endregion

    #region Constructor
    public UserAuthController(ILogger<UserAuthController> logger, IUserRepo userRepo)
    {
        _userRepo = userRepo;
        _logger = logger;
    }
    #endregion

    #region Endpoints

    [HttpPost]
    public async Task<ActionResult> RegisterUser(RegisterDTO registerDTO) 
    {
        //create user and save password to DB
        return null;
    }
    #endregion
}