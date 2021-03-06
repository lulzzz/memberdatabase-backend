﻿// -----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Wahine Kai">
// Copyright (c) Wahine Kai. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace WahineKai.Backend.DTO.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WahineKai.Backend.DTO.Models;

    /// <summary>
    /// Interface for actions connecting Users with User store
    /// </summary>
    /// <typeparam name="T">The type of user to return</typeparam>
    public interface IUserRepository<T>
        where T : UserBase
    {
        /// <summary>
        /// Get the user given by the email from the database
        /// </summary>
        /// <param name="email">An email of a user</param>
        /// <returns>A validated user</returns>
        public Task<T> GetUserByEmailAsync(string email);

        /// <summary>
        /// Get the user given by the id from the database
        /// </summary>
        /// <param name="id">An id of a user</param>
        /// <returns>A validated user</returns>
        public Task<T> GetUserByIdAsync(Guid id);

        /// <summary>
        /// Delete the user given by the id from the database
        /// </summary>
        /// <param name="user">The user to delete</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task DeleteUserAsync(T user);

        /// <summary>
        /// Gets all users from the repository
        /// </summary>
        /// <returns>A collection of users</returns>
        public Task<ICollection<T>> GetAllUsersAsync();

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user">The user to add to the database</param>
        /// <returns>The user added to the database</returns>
        public Task<T> CreateUserAsync(T user);

        /// <summary>
        /// Replace a user in the database with a new user
        /// </summary>
        /// <param name="updatedUser">The updated user to replace the old user with</param>
        /// <param name="id">Guid of the user to update</param>
        /// <returns>The updated user from the database</returns>
        public Task<T> ReplaceUserAsync(T updatedUser, Guid id);

        /// <summary>
        /// Get all users that match with a query
        /// </summary>
        /// <param name="query">The query to match users from</param>
        /// <returns>A Collection of users</returns>
        public Task<ICollection<T>> GetUsersByQueryAsync(string query);
    }
}
