﻿namespace UdemyNewMicroservice.Catalog.Api.Features.Courses
{
    public class Feature
    {
        public int Duration { get; set; }
        public float Rating { get; set; }

        public string EdicatorFullName { get; set; } = default!;
    }
}