﻿using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Commentifier.Models;
using Commentifier.Services;

namespace Commentifier.Controllers
{
    [Route("api/[controller]")]
	public class UpdateController : Controller
	{
        readonly IUpdateService _updateService;
        readonly BotConfiguration _config;

        public UpdateController(IUpdateService updateService, BotConfiguration config)
		{
			_updateService = updateService;
            _config = config;
		}

		[HttpPost]
		public void Post([FromBody]Update update)
		{
			_updateService.Echo(update);
		}
	}
}
