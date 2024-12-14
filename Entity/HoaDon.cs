namespace DoAnMonHoc_23880108.Entity
{
	public class HoaDon
	{
		public string Ma { get; set; }
		public string TenNguoi { get; set; }
		public string NgayTao { get; set; }

		public HoaDon(string ma, string ten, string date)
		{
			Ma = ma;
			TenNguoi = ten;
			NgayTao = date;
		}
	}
}
