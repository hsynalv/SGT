﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second);

        string CreateRefreshToken();
    }
}
