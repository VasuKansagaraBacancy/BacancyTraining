﻿namespace EF_CORE_Day3.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
