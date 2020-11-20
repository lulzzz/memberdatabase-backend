// <copyright file="User.cs" company="Wahine Kai">
// Copyright (c) Wahine Kai. All rights reserved.
// </copyright>

namespace WahineKai.Backend.Host
{
    public record User
    {
        /// <summary>
        /// Gets user email address.
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Gets user Password.
        /// </summary>
        public string Password { get; init; }
    }
}