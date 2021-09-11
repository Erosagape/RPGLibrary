using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary
{
    public class RolePlayingGame
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private RolePlayingGame()
        {

        }
        public RolePlayingGame(string name,string description)
        {
            Name = name;
            Description = description;
        }
    }
}
