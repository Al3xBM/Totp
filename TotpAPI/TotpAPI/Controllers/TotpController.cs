using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotpAPI.DataTransferObjects;
using TotpAPI.Models;
using TotpAPI.Services.Interfaces;

namespace TotpAPI.Controllers
{
    [Route("[controller]")]
    public class TotpController : ControllerBase
    {
        private readonly ITotpService _totpService;
        private readonly IUserVaultService _userVaultService;

        public TotpController(ITotpService totpService, IUserVaultService userVaultService)
        {
            _totpService = totpService;
            _userVaultService = userVaultService;
        }

        [HttpPost]
        [Route("/getTotp")]
        public ActionResult<TotpDTO> GetTotp([FromBody] TotpInputDTO input)
        {
            if (string.IsNullOrEmpty(input.Key))
            {
                UserVault newVault = _userVaultService.Create(input.UserId);

                if (newVault == null)
                    return BadRequest();

                input.Key = newVault.Secret;
            }

            TotpDTO res = new TotpDTO();
            res.Password = _totpService.ComputeTotp(input.UserId, input.Key, input.Step, input.PasswordLength);
            return Ok(res);
        }

        [HttpGet]
        [Route("/getSecret/{userId}")]
        public ActionResult<string> GetSecret(string userId)
        {
            UserVault userVault = _userVaultService.GetByUserId(userId);

            if (userVault == null)
                return BadRequest();

            return Ok(userVault.Secret);
        }
    }
}
