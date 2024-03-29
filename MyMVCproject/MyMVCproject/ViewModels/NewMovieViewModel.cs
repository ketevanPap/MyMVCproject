﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCproject.Models;

namespace MyMVCproject.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}