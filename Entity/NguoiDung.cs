namespace DoAnMonHoc_23880108.Entity
{
	public class NguoiDung
	{
		private string _username;
		private string _password;

		public NguoiDung(string username, string pass)
		{
			_username = username;
			_password = pass;
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new Exception("Mật khẩu không hợp lệ");
				}
				_password = value;
			}
		}

		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new Exception("Tên đăng nhập không hợp lệ");
				}
				_username = value;
			}
		}
	}
}
