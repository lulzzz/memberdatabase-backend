﻿// -----------------------------------------------------------------------
// <copyright file="CosmosConfiguration.cs" company="Wahine Kai">
// Copyright (c) Wahine Kai. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace WahineKai.Backend.DTO.Properties
{
    using Microsoft.Extensions.Configuration;
    using WahineKai.Backend.Common;

    /// <summary>
    /// Configuration needed to connect to Azure Cosmos DB
    /// </summary>
    public class CosmosConfiguration
    {
        /// <summary>
        /// Gets the url of the Cosmos DB endpoint
        /// </summary>
        public string? EndpointUrl { get; init; }

        /// <summary>
        /// Gets the primary key of the Cosmos DB endpoint
        /// </summary>
        public string? PrimaryKey { get; init; }

        /// <summary>
        /// Gets the database id of this cosmos configuration
        /// </summary>
        public string? DatabaseId { get; init; }

        /// <summary>
        /// Builds a cosmos configuration from a configuration
        /// </summary>
        /// <param name="configuration">Dotnet configuration object</param>
        /// <returns>A validated Cosmos configuration. Throws if not possible.</returns>
        public static CosmosConfiguration BuildFromConfiguration(IConfiguration configuration)
        {
            // Build CosmosConfiguration
            var cosmosConfiguration = new CosmosConfiguration
            {
                EndpointUrl = configuration["CosmosConfiguration:EndpointUrl"],
                PrimaryKey = configuration["CosmosConfiguration:PrimaryKey"],
                DatabaseId = configuration["CosmosConfiguration:DatabaseId"],
            };

            // Validate Cosmos Configuration
            cosmosConfiguration.Validate();

            return cosmosConfiguration;
        }

        /// <summary>
        /// Ensures that this is a complete and correct configuration
        /// </summary>
        public void Validate()
        {
            Ensure.IsNotNullOrWhitespace(() => this.EndpointUrl);
            Ensure.IsNotNullOrWhitespace(() => this.PrimaryKey);
            Ensure.IsNotNullOrWhitespace(() => this.DatabaseId);
        }
    }
}
