using System;

namespace VETest.Service
{
    public interface IRegisterService
    {
        string GeneratePassword(string userId, DateTime datetime);
		
		DateTime GetTimeFromPassword(string password);
    }
}
