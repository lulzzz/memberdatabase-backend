﻿// -----------------------------------------------------------------------
// <copyright file="SearchController.cs" company="Wahine Kai">
// Copyright (c) Wahine Kai. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace WahineKai.Backend.Host.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using WahineKai.Backend.DTO.Models;
    using WahineKai.Backend.Service;
    using WahineKai.Backend.Service.Contracts;

    /// <summary>
    /// Search Controller
    /// </summary>
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="loggerFactory">Logger factory given by ASP.NET</param>
        /// <param name="configuration">Global configuration given by ASP.NET</param>
        public SearchController(ILoggerFactory loggerFactory, IConfiguration configuration)
            : base(loggerFactory, configuration)
        {
            this.Logger.LogTrace("Construction of Search Controller beginning");

            this.searchService = new SearchService(loggerFactory, this.Configuration);

            this.Logger.LogTrace("Construction of Search Controller complete");
        }

        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A Collection of users</returns>
        [HttpGet]
        [ActionName("All")]
        public async Task<ICollection<ReadByAllUser>> GetAllUsersAsync()
        {
            this.Logger.LogDebug("Getting the user associated with this request");
            var users = await this.searchService.GetAllUsersAsync(this.GetUserEmailFromContext());
            return users;
        }

        /// <summary>
        /// Gets users from the database that match the query string
        /// </summary>
        /// <param name="query">The query string to check against the database</param>
        /// <returns>A Collection of users</returns>
        [HttpGet]
        [ActionName("Query")]
        public async Task<ICollection<ReadByAllUser>> SearchAsync([FromQuery] string query)
        {
            this.Logger.LogDebug("Getting the user associated with this request");
            var users = await this.searchService.GetByQueryAsync(this.GetUserEmailFromContext(), query);
            return users;
        }
    }
}
