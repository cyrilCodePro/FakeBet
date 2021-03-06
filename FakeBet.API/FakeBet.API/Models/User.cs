﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeBet.API.Models
{
    public enum UserStatus
    {
        /// <summary>
        /// User that confirmed his email. Normal state.
        /// </summary>
        Active,

        /// <summary>
        /// User that not confirmed his email.
        /// </summary>
        NonActivated,

        /// <summary>
        /// User that requested account delete.
        /// </summary>
        Deactivated,

        /// <summary>
        /// User that has been banned.
        /// </summary>
        Banned
    }

    public class User
    {
        [Key] public string NickName { get; set; }

        [Required] public string Email { get; set; }

        [Required, MaxLength(64)] public byte[] PasswordHash { get; set; }

        [Required, MaxLength(128)] public byte[] Salt { get; set; }

        [Required] public DateTime CreateTime { get; set; } = DateTime.UtcNow;

        [Required] public int Points { get; set; } = 100;

        public int FailedLoginsAttemps { get; set; } = 0;

        public List<Bet> Bets { get; set; }

        public UserStatus Status { get; set; } = UserStatus.NonActivated;

        public UserRole Role { get; set; } = UserRole.User;

        public void IncreaseFailedLoginCounter()
        {
            FailedLoginsAttemps++;
            if (FailedLoginsAttemps >= 10)
            {
                Status = UserStatus.NonActivated;
            }
        }

        public void ResetFailedLoginCounterAsync()
        {
            FailedLoginsAttemps = 0;
        }
    }

    public enum UserRole
    {
        Admin,

        User
    }
}