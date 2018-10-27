﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sportlance.WebAPI.Extensions;
using Sportlance.WebAPI.Requests;
using Sportlance.WebAPI.Responses;
using Sportlance.WebAPI.Teams;
using Sportlance.WebAPI.Entities;

namespace Sportlance.WebAPI.Controllers
{
    [Route("teams/{teamId}/members")]
    public class TeamMemberController : Controller
    {
        private readonly  ITeamService _service;

        public TeamMemberController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<PartialCollectionResponse<TeamPhotoItem>> GetAll(long teamId)
        {
            var trainers = await _service.GetPhotosAsync(0, 10, teamId);

            return trainers.ToPartialCollectionResponse();
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InvitePMemberAsync(long teamId, [FromBody] InviteMemberRequest request)
        {
            await _service.InviteMemberAsync(teamId, request.MemberId);
            return NoContent();
        }
    }
}