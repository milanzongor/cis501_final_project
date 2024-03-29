﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient.Shared
{
    public class User
    {
        public int userID { get; }
        public string sessionID { get; set; }
        public Credentials credentials { get; }

        public User(int userID, Credentials credentials)
        {
            this.userID = userID;
            this.credentials = credentials;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            User other = (User)obj;
            return this.credentials.userName.Equals(other.credentials.userName);
        }

        public override int GetHashCode()
        {
            return -155231879 + EqualityComparer<Credentials>.Default.GetHashCode(credentials);
        }
    }
}
