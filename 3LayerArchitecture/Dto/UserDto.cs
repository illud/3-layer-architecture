﻿namespace _3LayerArchitecture.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
