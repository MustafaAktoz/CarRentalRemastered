﻿using Core.Entities.Abstract;

namespace Entities.DTO
{
    public class RegisterDTO : IDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
