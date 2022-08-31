﻿namespace Library.Domain.Common;

using System.Collections.Generic;

public abstract class PayloadBase
{
    protected PayloadBase(IReadOnlyList<UserError>? errors = null)
    {
        Errors = errors;
    }

    public IReadOnlyList<UserError>? Errors { get; }
}

