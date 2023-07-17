﻿namespace Sciences.API.Exceptions;

public class ScienceNotFoundException : System.Exception
{
    public ScienceNotFoundException(string message): base($"Science not found with id: {message}")
    {
        
    }
    
}