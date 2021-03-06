﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeBet.API.Models;
using FakeBet.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FakeBet.API.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        // EF 
        private AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        private IQueryable<User> Users => context.Users;

        private IQueryable<Bet> Bets => context.Bets;

        public async Task<User> GetUserWithoutBetsAsync(string nickName)
        {
            return await Users.SingleOrDefaultAsync(u => u.NickName == nickName);
        }

        public async Task RegisterUserAsync(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task ChangeUserStatusAsync(string nickName, UserStatus status)
        {
            context.Users.Single(u => u.NickName == nickName).Status = status;

            await context.SaveChangesAsync();
        }

        public async Task<List<User>> Get20BestUsersAsync()
        {
            var usersSorted = await Users.OrderByDescending(x => x.Points).Take(20).ToListAsync();
            return usersSorted;
        }

        public async Task UpdateUserAsync(User user)
        {
            var original = await this.context.Users.SingleAsync(u => u.NickName == user.NickName);
            AutoMapper.Mapper.Map(original, user);
            this.context.Users.Update(original);
            await this.context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await this.context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return this.context.Users.Select(x => x);
        }
    }
}