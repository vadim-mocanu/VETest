using System;
using System.Collections.Generic;
using System.Linq;

namespace VETest.Service
{
    public class RegisterService : IRegisterService
    {
        #region Base64

        public string GeneratePassword(string userId, DateTime datetime)
        {
            IEnumerable<byte> time = BitConverter.GetBytes(datetime.ToBinary());
            IEnumerable<byte> user = GetBytes(userId);
			return Convert.ToBase64String(time.Concat(user).ToArray());
        }
		
		public DateTime GetTimeFromPassword(string password)
		{
            byte[] data = Convert.FromBase64String(password);
			return DateTime.FromBinary(BitConverter.ToInt64(data, 0));
		}
		
		private byte[] GetBytes(string userId)
		{
			byte[] bytes = new byte[userId.Length * sizeof(char)];
			System.Buffer.BlockCopy(userId.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
        }

        #endregion 
    }
}
