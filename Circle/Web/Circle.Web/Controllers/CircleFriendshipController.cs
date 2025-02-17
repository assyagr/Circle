using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Circle.Service;
using Circle.Data.Models;

namespace Circle.Web.Controllers
{
    public class CircleFriendshipController : Controller
    {
        private readonly CircleFriendshipService _friendshipService;

        public CircleFriendshipController(CircleFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(Guid senderId, string addresseeUsername)
        {
            try
            {
                var friendship = await _friendshipService.SendFriendRequestAsync(senderId, addresseeUsername);
                return Ok(friendship);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AcceptFriendRequest(Guid friendshipId)
        {
            try
            {
                await _friendshipService.AcceptFriendRequestAsync(friendshipId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DenyFriendRequest(Guid friendshipId)
        {
            try
            {
                await _friendshipService.DenyFriendRequestAsync(friendshipId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CancelFriendRequest(Guid friendshipId)
        {
            try
            {
                await _friendshipService.CancelFriendRequestAsync(friendshipId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
